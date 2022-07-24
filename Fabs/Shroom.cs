using Godot;
using System;

public class Shroom : Sprite
{
    public override void _Ready()
    {
        var mat = Material as ShaderMaterial;

        if (Red)
            mat.SetShaderParam("red", true);
        else
            mat.SetShaderParam("red", false);

        if (Green)
            mat.SetShaderParam("green", true);
        else
            mat.SetShaderParam("green", false);

        if (Blue)
            mat.SetShaderParam("blue", true);
        else
            mat.SetShaderParam("blue", false);

    }

    [Export]
    public bool Red;

    [Export]
    public bool Green;

    [Export]
    public bool Blue;

    public void CheckBody(Node body)
    {
        if (body.IsInGroup("Character"))
        {
            (body as Character).Shroom(this);
            QueueFree();
        }
        // else if (body.IsInGroup("Doppel"))
        //     (body as Character).Shroom(this);
    }


}
