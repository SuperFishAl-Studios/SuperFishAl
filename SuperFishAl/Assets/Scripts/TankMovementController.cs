using System;
using UnityEngine;

public class TankMovementController : MonoBehaviour
{
    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode ForwardKey = KeyCode.W;
    public KeyCode SlowKey = KeyCode.S;

    public float Acceleration = 20;
    public float MaxSpeed = 20;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        var velocity = rigidBody.velocity;

        // Rotate
        if (Input.GetKey(this.LeftKey))
        {
            var turnSpeed = Math.Min((this.MaxSpeed - velocity.magnitude) / this.MaxSpeed, 0.1f) * 1f;
            rigidBody.AddTorque(turnSpeed, ForceMode2D.Impulse);
        }
        if (Input.GetKey(this.RightKey))
        {
            var turnSpeed = Math.Min((this.MaxSpeed - velocity.magnitude) / this.MaxSpeed, 0.1f) * -1f;
            rigidBody.AddTorque(turnSpeed, ForceMode2D.Impulse);
        }

        if (Input.GetKey(this.ForwardKey) && (velocity.magnitude < this.MaxSpeed * 2))
        {
            rigidBody.AddForce(rigidBody.transform.up * this.Acceleration, ForceMode2D.Force);
        }

        if (velocity.y < this.MaxSpeed)
        {
            rigidBody.AddForce(Vector2.up / 2 * this.Acceleration, ForceMode2D.Force);
        }

        if (Input.GetKey(this.SlowKey))
        {
            rigidBody.velocity = rigidBody.velocity / 2;
        }

    }
}
