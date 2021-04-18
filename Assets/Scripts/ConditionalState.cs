using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = nameof(ConditionalState))]
public class ConditionalState : StateBase
{
    [SerializeField] private ItemCondition[] statesBasedOnItems;

    public override StateStory GetStateStory(Player player) 
    {
        var state = FindFirstItemCondition(player);

        if (state != null)
        {
            return state.StateStory.GetStateStory(player);
        }

        return base.GetStateStory(player);
    }

    public override StateBase[] GetNextStates(Player player)
    {
        var state = FindFirstItemCondition(player);

        if (state != null)
        {
            return state.StateStory.GetNextStates(player);
        }

        return base.GetNextStates(player);
    }

    private ItemCondition FindFirstItemCondition(Player player)
    {
        return statesBasedOnItems.FirstOrDefault(i => player.Items.Contains(i.Key));
    }
}
