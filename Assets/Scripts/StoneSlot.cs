using UnityEngine;

public class StoneSlot : MonoBehaviour
{
    public int stonesSlotIndex;
    public StonesPuzzle StonesPuzzle;
    private GameObject currentStone;
    private SpriteRenderer stoneSlotSpriteRenderer;
    
    private void Awake()
    {
        stoneSlotSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!StonesPuzzle.IsAStone(other.tag))
            return;
        
        if (!StonesPuzzle.IsStonesOrderCorrect())
        {
            if (currentStone != null && currentStone != other.gameObject)
            {
               PushStoneOutOfSlot(currentStone);
            }

            currentStone = other.gameObject;
            SnapStoneIntoSlot(currentStone);
            StonesPuzzle.AddStone(stonesSlotIndex, currentStone.tag);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (!StonesPuzzle.IsAStone(other.tag))
            return;
        
        if (other.gameObject == currentStone)
        {
            StonesPuzzle.RemoveStone(stonesSlotIndex);
            currentStone = null;
        }
    }

    public void SnapStoneIntoSlot(GameObject stone)
    {
        if (StonesPuzzle.IsAStone(stone.tag))
        {
            stone.transform.position = transform.position;
        }
    }
    
    public void PushStoneOutOfSlot(GameObject stone)
    {
        if (StonesPuzzle.IsAStone(stone.tag))
        {
            stone.transform.position = transform.position + Vector3.down * 2f;
        }
    }

    public void DisableStone()
    {
        currentStone.GetComponent<Collider2D>().enabled = false;
    }
    
    public void SetStoneColor(Color color)
    {
        stoneSlotSpriteRenderer.color = color;
    }
}
