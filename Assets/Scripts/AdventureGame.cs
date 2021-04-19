using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] private TMP_Text textComponent;
    [SerializeField] private StateBase startingState;
    [SerializeField] private List<Button> buttons;

    private StateBase state;
    private Player player = new Player();

    // Start is called before the first frame update
    private void Start()
    {
        state = startingState;

        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button.name));
        }

        ManageButtons();
    }

    // Update is called once per frame
    private void Update()
    {
        var stateStory = state.GetStateStory(player);
        textComponent.text = stateStory.StoryText;
    }

    private void ManageButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if(state.GetNextStates(player).Length > i)
            {
                buttons[i].enabled = true;
                continue;
            }

            buttons[i].enabled = false;
        }
    }

    private void ManageItems(StateStory stateStory)
    {
        if (player.Items.Contains(PlayerItem.GameOver))
        {
            player = new Player();
        }

        foreach (var item in stateStory.ItemsToAdd)
        {
            player.Items.Add(item);
        }

        foreach (var item in stateStory.ItemsToRemove)
        {
            player.Items.Remove(item);
        }
    }

    private void OnButtonClick(string buttonName)
    {
        ManageItems(state.GetStateStory(player)); ;

        var showState = buttons.FindIndex(i => i.name == buttonName);
        state = state.GetNextStates(player)[showState];

        if (state is LinkToAppsState)
        {
            Application.OpenURL("https://play.google.com/store/apps/developer?id=Daryl+Jones");
        }

        ManageButtons();
    }
}
