using UnityEngine;

public class TransformController : MonoBehaviour
{
    public GameObject[] transformations;
    public GameObject target;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject newTarget = null;
        if (Input.GetKey(KeyCode.Alpha1) && transformations.Length > 0)
        {
            newTarget = transformations[0];
        }
        else if (Input.GetKey(KeyCode.Alpha2) && transformations.Length > 1)
        {
            newTarget = transformations[1];
        }
        else if (Input.GetKey(KeyCode.Alpha2) && transformations.Length > 2)
        {
            newTarget = transformations[2];
        }
        else if (Input.GetKey(KeyCode.Alpha2) && transformations.Length > 3)
        {
            newTarget = transformations[3];
        }
        else if (Input.GetKey(KeyCode.Alpha2) && transformations.Length > 4)
        {
            newTarget = transformations[4];
        }

        if (newTarget != null)
        {
            var createdTarget = Instantiate(newTarget, target.transform.position, Quaternion.identity) as GameObject;
            createdTarget.transform.parent = target.transform.parent;
            Destroy(target);
            target = createdTarget;
        }
    }
}
