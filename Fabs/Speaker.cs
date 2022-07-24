using Godot;
using System;

public class Speaker : RichTextLabel
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    [Export]
    public string AnimationName;

    public void Speak()
    {
        GetNode<AnimationPlayer>("AnimationPlayer").Play(AnimationName);
    }
}
