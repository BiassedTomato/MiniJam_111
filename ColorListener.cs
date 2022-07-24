using Godot;
using System;

public class ColorListener : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    [Signal]
    public delegate void ColorStateSet();

    [Export]
    public bool NeedsRed;

    [Export]
    public bool NeedsGreen;

    [Export]
    public bool NeedsBlue;


    bool red, green, blue;

    public void StateChange(bool state, ColorCode color)
    {
        if (color == ColorCode.Red)
            red = state;
        else if (color == ColorCode.Green)
            green = state;
        else if (color == ColorCode.Blue)
            blue = state;

        if(!(NeedsRed^red)&&!(NeedsGreen^green)&&!(NeedsBlue^blue))
        {
            EmitSignal("ColorStateSet");
        }

    }
}
