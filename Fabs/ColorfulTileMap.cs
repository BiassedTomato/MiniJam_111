using Godot;
using System;

public class ColorfulTileMap : TileMap
{
    [Export]
    public bool Walkable=false;



    public override void _Ready()
    {
        base._Ready();
    }

    public void StateChange(bool state, ColorCode color)
    {
        var material = Material as ShaderMaterial;


        if ((!Walkable && state) || (Walkable && !state))
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
