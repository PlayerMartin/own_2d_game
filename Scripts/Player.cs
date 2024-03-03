using Godot;

public enum weapon { sniper, pistol, shotgun, assault_rifle, machine_gun };


public partial class Player : CharacterBody2D
{
    [Export] public weapon Weapon { get; set; }
	[Export] public int Health { get; private set; }
	[Export] public double ViewRange { get; private set; }
	[Export] public int Armon { get; private set; }
	[Export] public int Exp { get; private set; }
	[Export] public int Level { get; private set; }
    [Export] public int Speed { get; set; } = 400;

    public void GetInput()
    {
        Weapon = weapon.sniper;
        Vector2 inputDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        this.Velocity = inputDirection * Speed;
    }

    public void Aim() 
    {
        this.LookAt(GetGlobalMousePosition());
    }

    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndSlide();
        Aim();
    }
}