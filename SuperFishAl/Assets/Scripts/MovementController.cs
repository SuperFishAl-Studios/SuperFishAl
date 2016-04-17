using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{
    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode UpKey = KeyCode.W;
    public KeyCode DownKey = KeyCode.S;

    public float Acceleration = 10;
    public float MaxSpeed = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartScreen");
        }

        var rigidBody = GetComponent<Rigidbody2D>();
        var velocity = rigidBody.velocity;
        Vector2 direction = new Vector2();

        if (Input.GetKey(this.LeftKey) && (velocity.x > (-1 * this.MaxSpeed)))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(this.RightKey) && (velocity.x < this.MaxSpeed))
        {
            direction += Vector2.right;
        }
        if (Input.GetKey(this.UpKey) && (velocity.y < this.MaxSpeed * 2))
        {
            direction += Vector2.up;
        }
        if (velocity.y < this.MaxSpeed)
        {
            direction += Vector2.up / 2;
        }
        if (Input.GetKey(this.DownKey) && (velocity.y > this.MaxSpeed))
        {
            direction += Vector2.down;
        }

        rigidBody.AddForce(direction * this.Acceleration, ForceMode2D.Force);
    }
}
