using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YouDiedScript : MonoBehaviour
{

    private Text scoreLabel;
    private Text highScoreLabel;

    void Start()
    {
        scoreLabel = GameObject.Find("YourScoreValue").GetComponent<Text>();
        highScoreLabel = GameObject.Find("TopScoreValue").GetComponent<Text>();

        if (Score.CurrentScore > Score.HighScore)
        {
            Score.HighScore = Score.CurrentScore;
        }

        scoreLabel.text = Score.CurrentScore.ToString();
        highScoreLabel.text = Score.HighScore.ToString();
    }

    public void OnStartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnQuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
