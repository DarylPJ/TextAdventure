using UnityEngine;

public abstract class StateBase : ScriptableObject
{
    [SerializeField] private StateStory story;
    [SerializeField] private StateBase[] nextStates;

    public virtual StateStory GetStateStory(Player player) => story;

    public virtual StateBase[] GetNextStates(Player player) => nextStates;
}
