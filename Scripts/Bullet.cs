using Godot;
using System;

public partial class Bullet : RigidBody2D
{
	Gun gun;
	Player owner;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gun = GetNode<Gun>("/root/World/Player/Gun");
		owner = (Player)gun.GetParent(); // how to identify unique Player
		Timer timer = GetNode<Timer>("Timer");
		timer.WaitTime = gun.Range;
		timer.Timeout += () => QueueFree();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void _on_body_entered(Node node)
	{
		// doesnt effect Player2 on World scene, wtf
		// if (node is Player) {
		// 	QueueFree();
		// }

		if (node is Player) {
			Player player = node as Player;
			QueueFree();
			player.Health -= gun.Damage;
			GD.Print("GotHit");
		}
		if (node is CharacterBody2D) {
			QueueFree();
			owner.Exp += gun.Damage;
			GD.Print("Hit");
		}
		if (node is StaticBody2D) {
			QueueFree();
		}
	}
}
