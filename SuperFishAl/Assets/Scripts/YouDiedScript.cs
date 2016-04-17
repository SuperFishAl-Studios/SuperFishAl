using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class YouDiedScript : MonoBehaviour {

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
