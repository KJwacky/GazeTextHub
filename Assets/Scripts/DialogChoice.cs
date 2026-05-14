using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]

public class DialogChoice
{

    [Header("UI")]
    public string ChoiceText; // choice that player sees and can select

    [Header("Flow")]
    public string NextNodeID; // ID of the next node
    public bool ReloadScene = false;

    [Header("Conditions")]
    public List<string> RequiredFlags = new(); // all must present in order for the quest to appear
    public List<string> ForbiddenFlags = new(); // if the player has this then don't show the choice

    [Header("Flags on Select")]
    public List<string> GrantFlags = new(); // flags to add when player picks this choice


}
