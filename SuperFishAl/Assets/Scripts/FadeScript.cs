using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour
{

    public Texture2D fadeOutTexture;// The texture that will overlay the screen
    public float fadeSpeed = 0.8f;  // The fading speed

    private int drawDepth = -1000;  // The texture's order in the draw hierarchy: a low number means it renders on top
    private float alpha = 1.0f;     // The texture's alpha between 0 and 1
    private int fadeDir = -1;       // The direction to fade: in = -1 or out = 1

    void OnGUI()
    {
        alpha += fadeDir*fadeSpeed*Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return fadeSpeed; // return the fadeSpeed variable so it's easy to time the LoadScene();
    }

    void OnLevelWasLoaded()
    {
        alpha = 1;
        BeginFade(-1);
    }
}
