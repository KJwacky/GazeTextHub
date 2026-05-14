using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(menuName = "Dialog/DialogDatabase")]
public class DialogDatabase : ScriptableObject
{

    // the list of Dialog nodes in this database
    public List<DialogNode> Nodes = new();

    // the dictionary for easily looking up info on a node based on the nodeID key
    private Dictionary<string, DialogNode> _lookup;

    // Build the dictionary
    private void BuildNodeDictionary()
    {
        // if the dictionary already exists, then dont worry about it, because it already exists
        if (_lookup != null) return;
        // otherwise, we should create a new instance of the dictionary
        _lookup = new();
        // cycle through the list of nodes, and add each node to the dictionary with the NodeID as the key
        foreach (DialogNode node in Nodes)
        {
            _lookup.Add(node.NodeID, node);
        }
    }

    // create a function for getting a node from the dictionary based on the nodeID
    public DialogNode GetNode(string id)
    {
        // if the ID doesnt exist, return null
        if (string.IsNullOrEmpty(id))
        {
            return null;
        }

        // only build the dictionary if it doesnt already exist aka build the dictionary
        BuildNodeDictionary();
        // try to fetch the node from the dictionary if you find it, save it in a temp variable
        _lookup.TryGetValue(id, out DialogNode node);
        // return the node
        return node;


    }

}
