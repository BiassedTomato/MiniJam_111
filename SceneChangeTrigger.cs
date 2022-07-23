using Godot;
using System;

public class SceneChangeTrigger : Area2D
{

    [Export(PropertyHint.File,"*.tscn")]
    public string ScenePath;

    void OnBodyEntered2D(Node body)
    {
        if (body.IsInGroup("Character"))
            GetTree().ChangeScene(ScenePath);
    }
}
