using UnityEngine;

public abstract class StateBase : ScriptableObject
{
    [SerializeField] private StateStory story;
    [SerializeField] private StateBase[] nextStates;

    public virtual string GetStateStory(Player player) => story.StoryText;

    public virtual StateBase[] GetNextStates(Player player) => nextStates;
}
