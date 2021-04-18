using System;

[Serializable]
public class ItemCondition
{
    public PlayerItem Key;

    public string storyText;

    public StateBase[] nextStates;
}