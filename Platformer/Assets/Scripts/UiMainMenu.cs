using TMPro;
using UnityEngine;
public class UiMainMenu : MonoBehaviour
{
    public TMP_InputField nameField;
    public void Play()
    {
        GameManager.Get().userName = nameField.text;
        GameManager.Get().LoadGameplay();
    }
    public void Exit()
    {
        Application.Quit();
    }
}