using Godot;
using System;

public class Character : KinematicBody2D
{
    public override void _Ready()
    {

    }


    [Export]
    public float Speed = 2f;

    public void Shroom(Shroom shroom)
    {
        var material = GetNode<Sprite>("Sprite").Material as ShaderMaterial;



        if (shroom.Red)
        {
            material.SetShaderParam("red", true);

            int bit = ~(1 << 3);
            CollisionLayer &= (uint)bit;
            CollisionMask &= (uint)bit;

        }
        else
        {
            material.SetShaderParam("red", false);



            CollisionLayer |= (uint)(1 << 3);
            CollisionMask |= (uint)(1 << 3);
        }

        if (shroom.Green)
        {
            material.SetShaderParam("green", true);

            int bit = ~(1 << 4);
            CollisionLayer &= (uint)bit;
            CollisionMask &= (uint)bit;

        }
        else
        {
            material.SetShaderParam("green", false);



            CollisionLayer |= (uint)(1 << 4);
            CollisionMask |= (uint)(1 << 4);
        }

        if (shroom.Blue)
        {
            material.SetShaderParam("blue", true);


            int bit = ~(1 << 5);
            CollisionLayer &= (uint)bit;
            CollisionMask &= (uint)bit;

        }
        else
        {
            material.SetShaderParam("blue", false);


            CollisionLayer |= (uint)(1 << 5);
            CollisionMask |= (uint)(1 << 5);
        }

        if (IsInGroup("Doppel") && (!shroom.Red && !shroom.Green && !shroom.Blue))
        {
            QueueFree();
        }
    }

    public override void _PhysicsProcess(float delta)
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
    }

    public void StateChange(bool state, ColorCode color)
    {
        if (IsInGroup("Doppel"))
        {
            var material = GetNode<Sprite>("Sprite").Material as ShaderMaterial;

            material.SetShaderParam(color.ToString().ToLower(), state);

            var _visible = (bool)material.GetShaderParam("red") || (bool)material.GetShaderParam("green") || (bool)material.GetShaderParam("blue");

            if (!_visible)
                QueueFree();

        }
    }

    public void Ded()
    {
        GD.Print("Achieved");
    }


    public override void _Process(float delta)
    {

        if (IsInGroup("Character"))
        {



            if (Input.IsActionJustPressed("fullscreen"))
                OS.WindowFullscreen = !OS.WindowFullscreen;

            if (Input.IsActionJustPressed("reset"))
                GetTree().ReloadCurrentScene();

        }

    }
}
