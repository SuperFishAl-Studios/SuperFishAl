using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private int score;
    private Transform previous;
    private Text Label;

    // Use this for initialization
    void Start()
    {
        this.Label = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        this.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.score = (int)(transform.position.y - 50f);
        this.Label.text = this.score.ToString();
    }
}
