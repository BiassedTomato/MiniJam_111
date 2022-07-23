using Godot;
using System;

public class Wave : Sprite
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    [Export]
    public float Speed=60;


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        RegionRect = new Rect2(RegionRect.Position.x, RegionRect.Position.y + delta * Speed, RegionRect.Size);// +=new Vector2(0,delta);
    }

    public void StateChange(bool state, ColorCode color)
    {
        var material = Material as ShaderMaterial;

        material.SetShaderParam(color.ToString().ToLower(), state);
    }
}
