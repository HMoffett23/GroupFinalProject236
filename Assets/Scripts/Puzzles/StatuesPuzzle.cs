using UnityEngine;

public class StatuesPuzzle : MonoBehaviour
{
    [Header("The Objects to Track")]
    public InteractableRotator2 statue1;
    public InteractableRotator2 statue2;
    public InteractableRotator2 statue3;

    [Header("The Winning Sprite Indices")]
    public int target1 = 0;
    public int target2 = 0;
    public int target3 = 0;

    void Update()
    {
        if (statue1.GetCurrentSpriteIndex() == target1 &&
            statue2.GetCurrentSpriteIndex() == target2 &&
            statue3.GetCurrentSpriteIndex() == target3)
        {
            Debug.Log("Puzzle Solved!");
            OnPuzzleSolved();
        }
    }

    void OnPuzzleSolved()
    {
        statue1.Lock();
        statue2.Lock();
        statue3.Lock();
        
        this.enabled = false;
    }
}
