using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int score;
    private Transform previous;

    // Use this for initialization
    void Start()
    {
        this.score = 0;
        this.previous = transform;
    }

    // Update is called once per frame
    void Update()
    {
        var deltaY = transform.position.y - this.previous.position.y;
        this.score += (int)deltaY;
        this.previous = transform;
    }
}
