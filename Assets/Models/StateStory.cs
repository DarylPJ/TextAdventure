using System;
using UnityEngine;

[Serializable]
public class StateStory
{
    [TextArea(10, 14)] public string StoryText;

    public PlayerItem[] ItemsToRemove;
    public PlayerItem[] ItemsToAdd;
}

