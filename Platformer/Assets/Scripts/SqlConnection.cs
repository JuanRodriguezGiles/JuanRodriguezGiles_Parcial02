using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
public class SqlConnection : MonoBehaviourSingletonPersistent<SqlConnection>
{
    public void CallRegister()
    {
        StartCoroutine(Register());
    }
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("playername", GameManager.Instance.playerInfo.name);
        form.AddField("score", GameManager.Instance.playerInfo.scoreSaved);
        form.AddField("deathcount", GameManager.Instance.playerInfo.deathCount);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/PlayerInfo/register.php", form);
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Cargado");
        }
    }
}