using UnityEngine;

public class WhirlpoolController : MonoBehaviour
{
    private Rigidbody2D Body;

    // Use this for initialization
    void Start()
    {
        this.Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.Body.AddTorque(0.1f, ForceMode2D.Impulse);
    }
}
