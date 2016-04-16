using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
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
