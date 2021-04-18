using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = nameof(ConditionalState))]
public class ConditionalState : StateBase
{
    [TextArea(10, 14), SerializeField] private string storyTextWithItem;
    [SerializeField] private StateBase[] nextStatesWithArmour;

    [SerializeField] private ItemCondition[] statesBasedOnItems;

    public override string GetStateStory(Player player) 
    {
        var state = FindFirstItemCondition(player);

        if (state != null)
        {
            return state.storyText;
        }

        return base.GetStateStory(player);
    }

    public override StateBase[] GetNextStates(Player player)
    {
        var state = FindFirstItemCondition(player);

        if (state != null)
        {
            return state.nextStates;
        }

        return base.GetNextStates(player);
    }

    private ItemCondition FindFirstItemCondition(Player player)
    {
        return statesBasedOnItems.FirstOrDefault(i => player.Items.Contains(i.Key));
    }
}
