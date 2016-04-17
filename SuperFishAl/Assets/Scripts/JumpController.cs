using UnityEngine;

public class JumpController : MonoBehaviour
{
    public KeyCode JumpKey = KeyCode.Space;

    private bool jumping;
    private bool canJump;

    private Animator animator;

    // Use this for initialization
    void Start()
    {
        this.animator = this.GetComponent<Animator>();
        canJump = true;
        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(this.JumpKey) && !jumping && canJump)
        {
            animator.SetBool("Jump", true);
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
                if (contact.otherCollider.tag != "Background" && contact.collider.tag != "Background")
                {
                    Physics2D.IgnoreCollision(contact.otherCollider, contact.collider);
                }
            }
        }
    }

    void EndJump()
    {
        animator.SetBool("Jump", false);
        jumping = false;
        canJump = false;
        Invoke("EndCooldown", 0.25f);
    }

    void EndCooldown()
    {
        jumping = false;
        canJump = true;
    }
}
