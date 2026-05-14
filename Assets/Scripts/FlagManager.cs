using UnityEngine;
using System.Collections.Generic;

public class FlagManager : MonoBehaviour
{
    private HashSet<string> _flags = new();

    // a way to check if we have a flag
    public bool HasFlag(string flag)
    {
        // return true or false based on where the argument we pass through is in the hashset
        return _flags.Contains(flag);

    }

    // a way to add/grant flags
    public void AddFlag(string flag)
    {
        // if the flag that we are trying to add is empty or null then just move on
        if (string.IsNullOrEmpty(flag)) return;
        // otherwise let us add that string flag to the hashset
        _flags.Add(flag);

    }


}
