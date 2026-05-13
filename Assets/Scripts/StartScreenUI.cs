using UnityEngine;

public class StartScreenUI : MonoBehaviour
{
    public CanvasGroup StartScreen;
    public SpriteRenderer playerSpriteRenderer;
  
    void Start()
    {
        ShowStartScreen();
    }
    void Update()
    {
        //while(StartScreen == true)
        //{
            //playerSpriteRenderer.transform.position = new Vector3(0,0,0);
        //}
    }

    public void ShowStartScreen()
    {
        CanvasGroupDisplayer.Show(StartScreen);
    }
    
    public void HideStartScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreen);
    }
    
    public void OnStartButtonClicked()
    {
        HideStartScreen();
    }
}
