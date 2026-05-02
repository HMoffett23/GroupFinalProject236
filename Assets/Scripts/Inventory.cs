using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Sprite> Items = new List<Sprite>();

    public void AddItem(Sprite item)
    {
        Items.Add(item);
        
        // for debugging
        string line = "Items in the inventory: ";
        foreach (Sprite itemName in Items)
        {
            line += itemName.name + " ";
        }
        print(line);
    }
}
