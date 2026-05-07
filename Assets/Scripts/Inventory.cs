using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Sprite> Items = new List<Sprite>();
    public List<Image> SlotImages = new List<Image>();
    public List<GameObject> Prefabs = new List<GameObject>();

    public bool AddItem(Sprite item)
    {
        if (Items.Count == SlotImages.Count)
        {
            print("Inventory Full!");
            return false;
        }
        Items.Add(item);
        UpdateInventoryUI();
        return true;
    }
    
    public void UpdateInventoryUI()
    {
        for (int i = 0; i < SlotImages.Count; i++)
        {
            var image = SlotImages[i];

            if (i < Items.Count)
            {
                image.sprite = Items[i];
                image.enabled = true;
            }
            else
            {
                image.sprite = null;
                image.enabled = false;
            }
        }
    }

    public void RemoveItem(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= Items.Count) 
            return;
        
        string itemName = Items[itemIndex].name;
        Items.RemoveAt(itemIndex);
        UpdateInventoryUI();
        SpawnItem(itemName);
    }
    
    public void SpawnItem(string itemToSpawn)
    {
        for (int i = 0; i < Prefabs.Count; i++)
        {
            if (Prefabs[i].tag == itemToSpawn)
            {
                Instantiate(Prefabs[i], SpawnTools.CenterOfScreenLocationWorldSpace(), Quaternion.identity);
                break;
            }
        }
    }
}
