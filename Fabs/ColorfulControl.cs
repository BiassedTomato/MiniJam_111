using Godot;
using System;

public class ColorfulControl : NinePatchRect
{

    public void StateChange(bool state, ColorCode color)
    {
        var material = Material as ShaderMaterial;

        material.SetShaderParam(color.ToString().ToLower(), state);

    }
}
