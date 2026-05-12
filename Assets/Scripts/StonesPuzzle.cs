using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class StonesPuzzle : MonoBehaviour
{
    public StoneSlot StoneSlot;
    public List<StoneSlot> StoneSlots = new List<StoneSlot>();
    public List<string> currentStonesOrder = new List<string>{"", "", "", ""};
    private List<string> correctStonesOrder = new List<string>{"StoneRed", "StoneYellow", "StoneGreen", "StoneBlue"};
    private bool isStonesPuzzleCompleted = false;
    
    public bool IsAStone(string stone)
    {
        return correctStonesOrder.Contains(stone);
    }

    public void AddStone(int index, string stone)
    {
        RemoveDuplicateStone(stone);
        currentStonesOrder[index] = stone;
        IsStonesOrderCorrect();
    }

    public void RemoveDuplicateStone(string stone)
    {
        for (int i = 0; i < 4; i++)
        {
            if (currentStonesOrder[i] == stone)
            {
                RemoveStone(i);
            }
        }
    }

    public void RemoveStone(int index)
    {
        currentStonesOrder[index] = "";
    }
    
    public bool IsStonesOrderCorrect()
    {
        if (!isStonesPuzzleCompleted)
        {
            for (int i = 0; i < 4; i++)
            {
                if (currentStonesOrder[i] != correctStonesOrder[i])
                {
                    StonesPuzzleWrong();
                    return false;
                }
            }
            StonesPuzzleCorrect();
            return true;
        }
        return false;
    }

    public void StonesPuzzleCorrect()
    {
        foreach (var stoneSlot in StoneSlots)
        {
            stoneSlot.DisableStone();
            stoneSlot.SetStoneColor(Color.green);
        }
    }

    public bool AllSlotsFull()
    {
        for (int i = 0; i < 4; i++)
        {
            if (currentStonesOrder[i] == "")
            {
                return false;
            }
        }
        return true;
    }

    public void StonesPuzzleWrong()
    {
        if (AllSlotsFull())
        {
            foreach (var stoneSlot in StoneSlots)
            {
                stoneSlot.SetStoneColor(Color.red);
            }
        }
        else
        {
            foreach (var stoneSlot in StoneSlots)
            {
                stoneSlot.SetStoneColor(Color.white);
            }
        }
    }
}
