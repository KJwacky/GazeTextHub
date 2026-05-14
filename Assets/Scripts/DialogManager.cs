using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEditor.Rendering;

public class DialogManager : MonoBehaviour
{
    [Header("Data")]
    public DialogDatabase Database; // the list of dialog nodes
    public FlagManager FlagManager; // the hashset of string values for the player
    public string StartNodeID; // the dialog node that we want to play on start

    public delegate void DialogUpdated(string speakerName, string dialogText, List<DialogChoice> choices);
    public static event DialogUpdated OnDialogUpdated;

    private DialogNode _currentNode;

    private void Start()
    {
        GoToNode(StartNodeID);
    }


    // reloads current scene
    private void ReloadScene()
    {
        // hold the current scene info in temp var
        var currentScene = SceneManager.GetActiveScene();
        // load current scene
        SceneManager.LoadScene(currentScene.name);
    }

    private bool IsChoiceAvailable(DialogChoice choice)
    {
        foreach (var required in choice.RequiredFlags)
        {
            if (!FlagManager.HasFlag(required)) return false;
        }

        foreach (var forbidden in choice.ForbiddenFlags)
        {
            if (FlagManager.HasFlag(forbidden)) return false;
        }

        return true;

    }

    private List<DialogChoice> FilterChoices(List<DialogChoice> choices)
    {
        var result = new List<DialogChoice>();

        foreach (var choice in choices)
        {
            if (IsChoiceAvailable(choice))
            {
                result.Add(choice);
            }
        }


        return result;

    }

    public void SelectChoice(int index)
    {
        var filtered = FilterChoices(_currentNode.Choices);
        var choice = filtered[index];

        foreach (var flag in choice.GrantFlags)
        {
            FlagManager.AddFlag(flag);
        }

        if (choice.ReloadScene)
        {
            ReloadScene();
            return;
        }

        GoToNode(choice.NextNodeID);

    }


    public void GoToNode(string nodeID)
    {
        _currentNode = Database.GetNode(nodeID);

        if (_currentNode == null)
        {
            OnDialogUpdated?.Invoke("", "*Dialog Ended*", _currentNode.Choices);
            return;
        }

        var filtered = FilterChoices(_currentNode.Choices);

        OnDialogUpdated?.Invoke(_currentNode.SpeakerName, _currentNode.DialogText, filtered);

    }


}
