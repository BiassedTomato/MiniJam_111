using Godot;
using System;

public class ButtonMasher : Sprite
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _default = Texture;
    }

    Texture _default;

    [Export]
    public Texture PressedTexture;

    public void Mash()
    {
        if (Texture == PressedTexture)
            Texture = _default;
        else
        {
            Texture = PressedTexture;
        }

        GetNode<Timer>("Timer").Start((float)rand.NextDouble() * 1 + 0.3f);
    }

    Random rand = new Random();

    public override void _Process(float delta)
    {
    }

}
