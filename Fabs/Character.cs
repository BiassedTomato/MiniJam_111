using Godot;
using System;

public class Character : KinematicBody2D
{
    public override void _Ready()
    {

    }

    [Export]
    public float Speed = 2f;
    public override void _Process(float delta)
    {
        var direction = new Vector2();

        if (Input.IsActionPressed("left"))
            direction.x -= 1;
        if (Input.IsActionPressed("right"))
            direction.x += 1;

        if (Input.IsActionPressed("up"))
            direction.y -= 1;
        if (Input.IsActionPressed("down"))
            direction.y += 1;

        if (direction != Vector2.Zero)
            MoveAndSlide(direction.Normalized() * Speed * 60);

        if (Input.IsActionJustPressed("fullscreen"))
            OS.WindowFullscreen = !OS.WindowFullscreen;

        if (Input.IsActionJustPressed("reset"))
            GetTree().ReloadCurrentScene();


    }
}
