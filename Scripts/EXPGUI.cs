using Godot;
using System;

public partial class EXPGUI : Label
{
	Player player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = (Player) GetNode("/root/World/Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.Text = player.Exp.ToString();
	}
}
