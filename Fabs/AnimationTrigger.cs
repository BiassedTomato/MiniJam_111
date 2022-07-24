using Godot;
using System;

public class AnimationTrigger : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    [Export]
    public string Animation;

    [Export]
    public bool OneShot = true;

    public void OnBodyEntered(Node body)
    {
        GD.Print("Detect");
        if (body.IsInGroup("Character"))
            Start();
    }

    public void Start()
    {
        GetNode<AnimationPlayer>("AnimationPlayer").Play(Animation);

        if (OneShot)
        {
            SetDeferred("monitoring",false);
        }

    }
}
