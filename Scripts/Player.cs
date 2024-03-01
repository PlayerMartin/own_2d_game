using Godot;
using System;

public enum weapon { sniper, pistol, shotgun, assault_rifle, machine_gun };

public partial class Player : Node2D
{
	[Export]
	public weapon Weapon { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Weapon = weapon.sniper;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
