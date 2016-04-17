using UnityEngine;

public class JumpController : MonoBehaviour
{
    public KeyCode JumpKey = KeyCode.Space;

    private bool jumping;
    private bool canJump;

    // Use this for initialization
    void Start()
    {
        canJump = true;
        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(this.JumpKey) && !jumping)
        {
            jumping = true;
            canJump = false;
            Invoke("EndJump", 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (jumping)
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.otherCollider.tag != "Background")
                {
                    Physics2D.IgnoreCollision(contact.otherCollider, contact.collider);
                }
            }
        }
    }

    void EndJump()
    {
        jumping = false;
        canJump = false;
        Invoke("EndCooldown", 1);
    }

    void EndCooldown()
    {
        jumping = false;
        canJump = true;
    }
}
