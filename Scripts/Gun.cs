using Godot;
using System;
using System.Threading.Tasks;

public partial class Gun : Line2D
{
	[Export]
	public double Firerate { get; set; }
	[Export]
	public int Damage { get; set; }
	[Export]
	public int ReloadTime { get; set; }
	[Export]
	public int AmmoMaxCount { get; set; }
	[Export]
	public int AmmoCurrCount { get; set; }
	[Export]
	public double ShotSpeed { get; set; }

	public bool reloading = false;

	Player player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = (Player) this.GetParent().GetParent(); // get Player
		GD.Print($"weapon {player.Weapon}");
		InitStats();
	}

	public void InitStats()
	{
		switch (player.Weapon)
		{
			case weapon.sniper:
				Firerate = 1;
				Damage = 80;
				ReloadTime = 3;
				AmmoMaxCount = 6;
				AmmoCurrCount = AmmoMaxCount;
				ShotSpeed = 100;
				break;
			default: // TODO
				break;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

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
		if (AmmoCurrCount != 0 && !reloading) {
			AmmoCurrCount--;
			GD.Print($"Curr ammo {AmmoCurrCount} at {mouseEvent.Position}");
		}
	}

	public async void Reload()
	{
		reloading = true;
		await Task.Delay(ReloadTime * 1000);
		reloading = false;
		AmmoCurrCount = AmmoMaxCount;
	}
}
