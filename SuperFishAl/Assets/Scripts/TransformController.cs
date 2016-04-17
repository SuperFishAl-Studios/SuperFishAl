using UnityEngine;

public class TransformController : MonoBehaviour
{
    public GameObject[] transformations;
    public GameObject target;

    private int currentTransformationIndex;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject newTarget = null;
        if (Input.GetKey(KeyCode.Alpha1) && transformations.Length > 0 && currentTransformationIndex != 0)
        {
            currentTransformationIndex = 0;
            newTarget = transformations[currentTransformationIndex];
        }
        else if (Input.GetKey(KeyCode.Alpha2) && transformations.Length > 1 && currentTransformationIndex != 1)
        {
            currentTransformationIndex = 1;
            newTarget = transformations[currentTransformationIndex];
        }
        else if (Input.GetKey(KeyCode.Alpha3) && transformations.Length > 2 && currentTransformationIndex != 2)
        {
            currentTransformationIndex = 2;
            newTarget = transformations[currentTransformationIndex];
        }
        else if (Input.GetKey(KeyCode.Alpha4) && transformations.Length > 3 && currentTransformationIndex != 3)
        {
            currentTransformationIndex = 3;
            newTarget = transformations[currentTransformationIndex];
        }
        else if (Input.GetKey(KeyCode.Alpha5) && transformations.Length > 4 && currentTransformationIndex != 4)
        {
            currentTransformationIndex = 4;
            newTarget = transformations[currentTransformationIndex];
        }

        if (newTarget != null)
        {
            var createdTarget = Instantiate(newTarget, target.transform.position, Quaternion.identity) as GameObject;
            createdTarget.transform.parent = target.transform.parent;

            // RIP
            Destroy(target);
            target = createdTarget;
        }
    }
}
