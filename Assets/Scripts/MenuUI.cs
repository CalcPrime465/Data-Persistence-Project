#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUI : MonoBehaviour
{
    string defaultName = "Name";

    public void SaveName(string name)
    {
        StaticManager.Instance.playerName = name;
    }

    public void StartNew()
    {
        if (StaticManager.Instance.playerName == string.Empty)
        {
            StaticManager.Instance.playerName = defaultName;
        }
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        StaticManager.Instance.SaveGameData();
    }

    public void HighScoreScene()
    {
        SceneManager.LoadScene(2);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
