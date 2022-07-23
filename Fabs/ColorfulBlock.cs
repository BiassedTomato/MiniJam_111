using Godot;
using System;

public class ColorfulBlock : StaticBody2D
{

    public void StateChange(bool state, ColorCode color)
    {
        var material = GetNode<Sprite>("Sprite").Material as ShaderMaterial;

        if (state)
        {
            int bit = 1 << (int)color;
            CollisionLayer |= (uint)bit;
            CollisionMask |= (uint)bit;

            GD.Print("Toggle on: " + Name + " " + CollisionLayer);


        }
        else
        {
            int bit = ~(1 << (int)color);
            CollisionLayer &= (uint)bit;
            CollisionMask &= (uint)bit;

            GD.Print("Toggle off: " + Name + " " + CollisionLayer);



        }

        material.SetShaderParam(color.ToString().ToLower(), state);
    }


}
