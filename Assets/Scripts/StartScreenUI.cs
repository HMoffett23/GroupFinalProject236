using UnityEngine;

public class StartScreenUI : MonoBehaviour
{
    public CanvasGroup StartScreen;

    public void ShowStartScreen()
    {
        CanvasGroupDisplayer.Show(StartScreen);
    }
    
    public void HideStartScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreen);
    }
}
