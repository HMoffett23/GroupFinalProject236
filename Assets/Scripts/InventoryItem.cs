using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Inventory Inventory;
    public int Index; 
    
    public void OnItemClicked()
    {
        Inventory.RemoveItem(Index);
    }
}
