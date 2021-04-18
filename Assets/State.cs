using UnityEngine;

[CreateAssetMenu(menuName = nameof(State))]
public class State : ScriptableObject
{
    [TextArea(10, 14), SerializeField] private string storyText;
    [SerializeField] private State[] nextStates;

    public string GetStateStory => storyText;

    public State[] GetNextStates => nextStates;
}
