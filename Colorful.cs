using Godot;
using System;


public class Colorful : KinematicBody2D
{
    public override void _Ready()
    {

    }



    public override void _Process(float delta)
    {
        Vector2 dir = new Vector2();

        if (Input.IsActionPressed("ui_left"))
            dir.x -= 1;
        if (Input.IsActionPressed("ui_right"))
            dir.x += 1;

        if (Input.IsActionPressed("ui_up"))
            dir.y -= 1;
        if (Input.IsActionPressed("ui_down"))
            dir.y += 1;

        MoveAndSlide(dir.Normalized() * 2 * 60);
    }

    public void StateChange(bool state, ColorCode color)
    {
        var material = GetNode<Sprite>("Sprite").Material as ShaderMaterial;

        if (state)
        {
            int bit = 1 << (int)color;
            CollisionLayer |= (uint)bit;
            CollisionMask |= (uint)bit;
        }
        else
        {
            int bit = ~(1 << (int)color);
            CollisionLayer &= (uint)bit;
            CollisionMask &= (uint)bit;
        }

        material.SetShaderParam(color.ToString().ToLower(), state);
    }
}
