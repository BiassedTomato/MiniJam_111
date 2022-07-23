using Godot;
using System;

public enum ColorCode
{
    Red = 3,
    Green = 4,
    Blue = 5
}

public class ColorManager : Node2D
{
    [Export]
    public bool DefaultRedEnabled = false;

    [Export]
    public bool DefaultGreenEnabled = false;

    [Export]
    public bool DefaultBlueEnabled = false;



    ColorRect _screenShader;
    public override void _Ready()
    {

        GD.Print(GetTree().GetNodesInGroup("Blue").Count);


        if (DefaultRedEnabled)
            GetTree().CallGroup("Red", "StateChange", true, ColorCode.Red);
        else
            GetTree().CallGroup("Red", "StateChange", false, ColorCode.Red);


        if (DefaultGreenEnabled)
            GetTree().CallGroup("Green", "StateChange", true, ColorCode.Green);
        else
            GetTree().CallGroup("Green", "StateChange", false, ColorCode.Green);


        if (DefaultBlueEnabled)
            GetTree().CallGroup("Blue", "StateChange", true, ColorCode.Blue);
        else
            GetTree().CallGroup("Blue", "StateChange", false, ColorCode.Blue);




    }



    public void ColorStateChanged(bool state, ColorCode color)
    {
        GetTree().CallGroup((color).ToString(), "StateChange", state, color);
    }
}
