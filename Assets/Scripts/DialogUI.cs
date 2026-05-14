using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using JetBrains.Annotations;
using UnityEngine.EventSystems;

public class DialogUI : MonoBehaviour
{
    public DialogManager DM;
    public TextMeshProUGUI SpeakerTextDisplay;
    public TextMeshProUGUI DialogTextDisplay;
    public List<Button> Buttons;
    public List<TextMeshProUGUI> ButtonLabels;

    private void OnEnable()
    {
        DialogManager.OnDialogUpdated += UpdateUI;
    }

    private void OnDisable()
    {
        DialogManager.OnDialogUpdated -= UpdateUI;
    }


    private void UpdateUI(string speaker, string dialog, List<DialogChoice> choices)
    {
        SpeakerTextDisplay.text = speaker;
        DialogTextDisplay.text = dialog;

        for (int i = 0; i < Buttons.Count; i++)
        {
            if (i < choices.Count)
            {
                Buttons[i].gameObject.SetActive(true);
                ButtonLabels[i].text = choices[i].ChoiceText;
            }
            else
            {
                Buttons[i].gameObject.SetActive(false);
            }
            
        }


    }

    public void OnChoiceClicked(int index)
    {
        DM.SelectChoice(index);
        EventSystem.current.SetSelectedGameObject(null);


    }    



}
