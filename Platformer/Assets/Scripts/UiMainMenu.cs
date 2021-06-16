using TMPro;
using UnityEngine;
public class UiMainMenu : MonoBehaviour
{
    public TMP_InputField nameField;
    public void Play()
    {
        GameManager.Instance.playerInfo.name = nameField.text;
        SqlConnection.Instance.CallRegister();
        GameManager.Instance.LoadGameplay();
    }
    public void Exit()
    {
        Application.Quit();
    }
}