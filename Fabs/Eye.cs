using Godot;
using System;

public class Eye : KinematicBody2D
{
    Sprite Pupil;
    Node2D Pivot;
    public override void _Ready()
    {

        Pivot = GetNode<Node2D>("PupilPivot");


        (GetNode<Sprite>("Sprite").Material as ShaderMaterial)
        .SetShaderParam(Color.ToString().ToLower(), true);
    }

    bool _open = true;

    [Export]
    public bool Open
    {
        get => _open;
        set
        {
            _open = value;

            if (value)
            {
                Pivot?.SetVisible(true);
            }
            else
            {
                Pivot?.SetVisible(false);
                // set sprite
            }
        }
    }

    [Signal]
    public delegate void OpenChanged(bool open);

    [Export]
    public ColorCode Color;

    public void Toggle()
    {
        EmitSignal("OpenChanged", Open);
        GD.Print(Color.ToString());
        GetTree().CallGroup(Color.ToString(), "StateChange", !Open, Color);

    }

    public override void _Process(float delta)
    {
        var character = GetTree().GetNodesInGroup("Character")[0] as Node2D;

        Pivot.LookAt(character.Position);
    }


    public void StateChange(bool state, ColorCode color)
    {
        if (color == Color)
            Open = state;
    }

    public void BodyEntered(Node body)
    {
        if (body.IsInGroup("Character"))
        {
            Toggle();
        }
    }
}
