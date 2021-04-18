using UnityEngine;

[CreateAssetMenu(menuName = nameof(FoundArmourState))]
public class FoundArmourState : StateBase
{
    public override string GetStateStory(Player player) 
    {
        player.HasArmour = true;
        return base.GetStateStory(player);
    }
}
