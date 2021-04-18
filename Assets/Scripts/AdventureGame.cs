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
    private readonly Player player = new Player();

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
        textComponent.text = state.GetStateStory(player);
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

    private void OnButtonClick(string buttonName)
    {
        var showState = buttons.FindIndex(i => i.name == buttonName);

        state = state.GetNextStates(player)[showState];
        ManageButtons();
    }
}
