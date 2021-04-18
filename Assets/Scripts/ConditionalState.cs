using UnityEngine;

[CreateAssetMenu(menuName = nameof(ConditionalState))]
public class ConditionalState : StateBase
{
    [TextArea(10, 14), SerializeField] private string storyTextWithArmour;
    [SerializeField] private StateBase[] nextStatesWithArmour;

    public override string GetStateStory(Player player) =>  player.HasArmour? storyTextWithArmour: storyText;

    public override StateBase[] GetNextStates(Player player) => 
        player.HasArmour && nextStatesWithArmour.Length != 0 ? nextStatesWithArmour : nextStates;
}
