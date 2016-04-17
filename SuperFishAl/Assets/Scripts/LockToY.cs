using System.Linq;
using UnityEngine;

public class LockToY : MonoBehaviour
{
    public GameObject target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var childTransform = target.GetComponentsInChildren<Transform>().Last();
        transform.position = new Vector3(transform.position.x, childTransform.transform.position.y, transform.position.z);
    }
}
