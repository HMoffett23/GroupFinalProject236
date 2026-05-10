using System.Collections;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableText : InteractableTile
{
    public GameObject text;
    public CanvasGroup textObjectsCanvasGroup;

    public void Display()
    {
        StartCoroutine(DisplayAndWaitRoutine());
    }

    private IEnumerator DisplayAndWaitRoutine()
    {
        ShowTextPanel();
        DisplayText();
        
        yield return null; 

        while (!Keyboard.current.anyKey.wasPressedThisFrame)
        {
            yield return null;
        }

        HideTextPanel();
    }

    private void Awake()
    {
        CanvasGroupDisplayer.Hide(textObjectsCanvasGroup);
    }

    private void DisplayText()
    {
        text.SetActive(true);
    }

    private void ShowTextPanel()
    {
        CanvasGroupDisplayer.Show(textObjectsCanvasGroup);
    }

    private void HideTextPanel()
    {
        CanvasGroupDisplayer.Hide(textObjectsCanvasGroup);
        text.SetActive(false);
    }
}
