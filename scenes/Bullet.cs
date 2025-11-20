using Godot;
using System;

public partial class Bullet : RigidBody2D
{
    public override void _Ready()
    {
        Timer timer = GetNode<Timer>("Timer");
        timer.Timeout += () => QueueFree();
    }


    public override void _PhysicsProcess(double delta)
    {
        var collision = MoveAndCollide(LinearVelocity * (float)delta);
        if (collision == null) return;
        if((collision.GetCollider() as Node).IsInGroup("player")) QueueFree();

        LinearVelocity = LinearVelocity.Bounce(collision.GetNormal());
        Rotation = LinearVelocity.Angle();
            
    }
}
