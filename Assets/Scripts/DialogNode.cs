using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Dialog/Dialog Node")]

public class DialogNode : ScriptableObject
{

    [Header("Identity")]
    public string NodeID; // unique ID, "speakerName_intro_001"

    [Header("Dialog")]
    public string SpeakerName; // speaker who is talking
    [TextArea(3,5)]
    public string DialogText; // words the speaker is speaking

    [Header("Choices")]
    public List<DialogChoice> Choices = new();


}
