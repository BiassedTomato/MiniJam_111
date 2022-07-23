using Godot;
using System;

public class Intro : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    AnimationPlayer player;
    public override void _Ready()
    {
        player = GetNode<AnimationPlayer>("CanvasLayer/RichTextLabel/AnimationPlayer");

        player.Play("TextRead");
    }

    [Export(PropertyHint.File, "*.tscn")]
    public string NextScene;

    public void FinishIntro(string name)
    {
        if (name == "TextRead")
        {
            player.Play("AnonSpeech");
        }

        //GetTree().ChangeScene(NextScene);
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("skip"))
        {
            GetTree().ChangeScene(NextScene);

        }

        if (Input.IsActionJustPressed("fullscreen"))
        {
            OS.WindowFullscreen = !OS.WindowFullscreen;
        }
    }
}
