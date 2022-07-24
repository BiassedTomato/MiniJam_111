using Godot;
using System;

public class Eye : KinematicBody2D
{
    Sprite Pupil;
    Node2D Pivot;

    Sprite sprite;
    public override void _Ready()
    {

        Pivot = GetNode<Node2D>("PupilPivot");

        sprite = GetNode<Sprite>("Sprite");

        _openTexture = sprite.Texture;

        (sprite.Material as ShaderMaterial)
        .SetShaderParam(Color.ToString().ToLower(), true);

        if (!IsInGroup(Color.ToString()))
            AddToGroup(Color.ToString());
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
    public ColorCode Color = ColorCode.Red;

    [Export]
    public Texture ClosedTexture;

    Texture _openTexture;

    public void Toggle()
    {
        EmitSignal("OpenChanged", Open);
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
        {
            Open = state;
            if (Open)
                sprite.Texture = _openTexture;
            else
                sprite.Texture = ClosedTexture;
        }
    }

    public void BodyEntered(Node body)
    {
        if (body.IsInGroup("Character") || body.IsInGroup("Doppel"))
        {
            var k = body as KinematicBody2D;

            var bit = (1 << (int)Color);

            if ((k.CollisionLayer & (uint)bit) >= (int)Color)
            {
                if (Open)
                    GetNode<Particles2D>("Particles2D").Emitting = true;

                Toggle();

            }
        }
    }
}
