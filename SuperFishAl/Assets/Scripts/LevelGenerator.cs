using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] objects;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value > .95)
        {
            Instantiate(this.objects[Random.Range(0, this.objects.GetLength(0))], new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y, 0), Quaternion.identity);
        }
    }
}
