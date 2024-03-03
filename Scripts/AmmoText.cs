using Godot;
using System;

public partial class AmmoText : Label
{
	Gun gun;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gun = (Gun) GetNode("/root/World/Player/Gun");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.Text = gun.AmmoCurrCount.ToString();
	}
}
