using Godot;

public partial class Body : CharacterBody2D
{
    [Export]
    public int Speed { get; set; } = 400;

    public void GetInput()
    {

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