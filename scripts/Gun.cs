using Godot;
using System;

public partial class Gun : Node2D
{
    [Export] PackedScene BulletScene; 
    [Export] float BulletSpeed = 30f;
    [Export] float BPM = 5f;
    [Export] float BulletDamage = 30f;


    float FireRate;
    float TimeUntillFire = 0f;

    public override void _Ready()
    {
        FireRate = 1 / BPM;
    }
    public override void _PhysicsProcess(double delta)
    {
        if(Input.IsActionPressed("click") && TimeUntillFire > FireRate)
        {
            RigidBody2D bullet = BulletScene.Instantiate<RigidBody2D>();

            bullet.Rotation = GlobalRotation;
            bullet.GlobalPosition = GlobalPosition;
            bullet.LinearVelocity = bullet.Transform.X * BulletSpeed;

            GetTree().Root.AddChild(bullet);

            TimeUntillFire = 0f;
        }else {TimeUntillFire += (float)delta;}
    }
}
