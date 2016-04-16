using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] objects;
    public float rate = 3;
    public float width = 50;

    private Vector3 previous;
    private float distanceTraveled;

    // Use this for initialization
    void Start()
    {
        distanceTraveled = 0.01f;
        previous = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceTraveled += (transform.position.y - previous.y);

        if (Random.value * distanceTraveled > rate)
        {
            Instantiate(this.objects[Random.Range(0, this.objects.GetLength(0))], new Vector3(Random.Range(width / -2, width / 2), transform.position.y, 0), Quaternion.identity);
            distanceTraveled -= rate;
        }

        previous = transform.position;
    }
}
