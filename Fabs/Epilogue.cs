using Godot;
using System;

public class Epilogue : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
       (GetNode(AnimPlayer) as AnimationPlayer).Play("Type");
    }

    [Export(PropertyHint.File, "*.tscn")]
    public string NextScene;

[Export]
    public NodePath AnimPlayer; 

    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("fullscreen"))
            OS.WindowFullscreen = !OS.WindowFullscreen;

        if (Input.IsActionJustPressed("skip"))
        {
            GetTree().ChangeScene(NextScene);
        }

    }
}
