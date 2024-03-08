using Godot;
using System;

public partial class Bullet : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Gun gun = GetNode<Gun>("/root/World/Player/Gun");
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

		if (node is CharacterBody2D || node is StaticBody2D) {
			QueueFree();
		}
	}
}
