using UnityEngine;

public abstract class StateBase : ScriptableObject
{
    [TextArea(10, 14), SerializeField] protected string storyText;
    [SerializeField] protected StateBase[] nextStates;

    public virtual string GetStateStory(Player player) => storyText;

    public virtual StateBase[] GetNextStates(Player player) => nextStates;
}
