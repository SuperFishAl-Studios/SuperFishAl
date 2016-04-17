using UnityEngine;

public class EatEnemyController : MonoBehaviour
{

    public KeyCode EatKey = KeyCode.Space;

    private bool eating;
    private bool canEat;

    private Animator animator;

    // Use this for initialization
    void Start()
    {
        this.animator = this.GetComponent<Animator>();
        canEat = true;
        eating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(this.EatKey) && !eating)
        {
            Debug.Log("nom");
            animator.SetBool("Chomp", true);
            eating = true;
            canEat = false;
            Invoke("EndEat", 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (eating)
        {
            var thingToEat = collision.gameObject;
            if (thingToEat.tag == "Enemy")
            {
                Debug.Log("CHOMP");

                // Play the enemy's RIP audio if it has one
                var audioSource = thingToEat.GetComponent<AudioSource>();
                if (audioSource)
                {
                    Debug.Log("rip enemy");
                    audioSource.Play();
                }
                Destroy(thingToEat);
            }
        }
    }

    void EndEat()
    {
        animator.SetBool("Chomp", false);
        eating = false;
        canEat = false;
        Invoke("EndCooldown", 2);
    }

    void EndCooldown()
    {
        eating = false;
        canEat = true;
    }
}
