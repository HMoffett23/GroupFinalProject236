using UnityEngine;

public class Game : MonoBehaviour
{
    private static bool isGameStarted = false;
    public StartScreenUI StartScreenUI;
    
    void Start()
    {
        StartScreenUI.ShowStartScreen();
    }

    public void OnStartButtonClick()
    {
        StartScreenUI.HideStartScreen();
        isGameStarted = true;
    }

    public static bool IsGameStarted()
    {
        return isGameStarted;
    }
    
    public static bool IsGameNotStarted()
    {
        return !isGameStarted;
    }
}
