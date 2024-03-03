using Godot;
using System;

public partial class Middle : Area2D
{
	[Export] Sprite2D sprite;
	[Export] Texture2D mid_activated;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

}
