using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    public void OnStartGame()
    {
        StartCoroutine(ChangeLevel());
    }

    IEnumerator ChangeLevel()
    {
        var waitTime = GetComponent<FadeScript>().BeginFade(1);
        yield return new WaitForSeconds(waitTime);
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
