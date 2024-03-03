using Godot;
using System;
using System.Threading.Tasks;

public partial class Gun : Node2D
{
	[Export]
	public double Firerate { get; set; }
	[Export]
	public double BulletPerSecond { get; set; }
	[Export]
	public int Damage { get; set; }
	[Export]
	public int ReloadTime { get; set; }
	[Export]
	public int AmmoMaxCount { get; set; }
	[Export]
	public int AmmoCurrCount { get; set; }
	[Export]
	public float ShotSpeed { get; set; }
	[Export]
	public int Range { get; set; } = 1; // seconds alive

	[Export]
	PackedScene bullet_scn;

	public bool reloading = false;
	public double time_until_fire;
	public double GlobalDelta;
	
	Player player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = (Player) GetNode("/root/World/Player"); // get Player
		GD.Print($"weapon {player.Weapon}");
		InitStats();
	}

	public void InitStats()
	{
		switch (player.Weapon)
		{
			case weapon.sniper:
				Damage = 80;
				BulletPerSecond = 1;
				ReloadTime = 3;
				AmmoMaxCount = 6;
				AmmoCurrCount = AmmoMaxCount;
				ShotSpeed = 1000;
				break;
			default: // TODO
				break;
		}
		Firerate = 1 / BulletPerSecond;
		time_until_fire = Firerate;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		time_until_fire += delta;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
		{
			switch (mouseEvent.ButtonIndex)
			{
				case MouseButton.Left:
					Shoot(mouseEvent);
					break;
				case MouseButton.WheelUp:
					GD.Print("Wheel up");
					break;
			}
		}

		if(@event is InputEventKey keyEvent && keyEvent.Pressed) {
			switch (keyEvent.Keycode)
			{
				case Key.R:
					if (AmmoCurrCount < AmmoMaxCount) {
						Reload();
					}
					break;
				default: // TODO more action buttons 
					break;
			}
		}
	}

	public void Shoot(InputEventMouseButton mouseEvent)
	{
		if (time_until_fire >= Firerate && AmmoCurrCount != 0 && !reloading) {
			AmmoCurrCount--;
			SpawnBullet();
			time_until_fire = 0;
			GD.Print($"Curr ammo {AmmoCurrCount} at {mouseEvent.Position}");
		}
	}

	public void SpawnBullet()
	{
		RigidBody2D bullet = bullet_scn.Instantiate<RigidBody2D>();
		bullet.Rotation = this.GlobalRotation;
		bullet.GlobalPosition = this.GlobalPosition;
		bullet.LinearVelocity = bullet.Transform.X * ShotSpeed;

		GetTree().Root.AddChild(bullet);
	}

	public async void Reload()
	{
		reloading = true;
		await Task.Delay(ReloadTime * 1000);
		reloading = false;
		AmmoCurrCount = AmmoMaxCount;
	}
}
