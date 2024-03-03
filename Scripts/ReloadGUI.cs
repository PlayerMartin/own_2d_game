using Godot;
using System;

public partial class ReloadGUI : ColorRect
{
	Gun gun;
	Color normal;
	Color reload;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gun = (Gun) GetNode("/root/World/Player/Gun");
		reload = new Color(100, 0, 0, 70);
		normal = new Color(0, 0, 0, 0);
		this.Color = normal;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (gun.reloading && this.Color == normal) {
			this.Color = reload;
		}
		if (!gun.reloading && this.Color != normal) {
			this.Color = normal;
		}
	}
}
