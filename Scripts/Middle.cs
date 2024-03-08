using Godot;
using System;
using System.Threading.Tasks;

public partial class Middle : Area2D
{
	[Export] Sprite2D sprite;
	[Export] Texture2D mid_deactivated;
	[Export] Texture2D mid_activated;
	[Export] Player player;

	private int ExpDelay = 2;
	private double ExpGain = 30;
	private bool activated = false;
	private bool waiting = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!waiting && activated) {
			GainExp();
		}
		if (!activated && this.OverlapsBody(player)) {
			sprite.Texture = mid_activated;
			activated = true;
		}
		if (activated && !this.OverlapsBody(player)) {
			sprite.Texture = mid_deactivated;
			activated = false;
		}
	}

	public async void GainExp()
	{
		waiting = true;
		await Task.Delay(ExpDelay * 1000);
		player.Exp += ExpGain;
		waiting = false;
	}
}
