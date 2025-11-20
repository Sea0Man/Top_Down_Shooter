using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public int speed { get; set; } = 500;
	public override void _PhysicsProcess(double delta)
    {
        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
		LookAt(GetGlobalMousePosition());
		Velocity = inputDirection * speed;

		MoveAndSlide();
		
    }
}
