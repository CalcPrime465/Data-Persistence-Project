using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BestScore : MonoBehaviour
{
    public TMP_Text BestScoreText;

    void Start()
    {
        SetBestScore();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetBestScore()
    {
        StaticManager.Instance.bestPlayerName = "none";
        StaticManager.Instance.bestScore = 0;
        StaticManager.Instance.SaveGameData();

        SetBestScore();
    }

    public void SetBestScore()
    {
        BestScoreText.text = "Current Best Score: " + StaticManager.Instance.bestPlayerName + " : " + StaticManager.Instance.bestScore;
    }
}
