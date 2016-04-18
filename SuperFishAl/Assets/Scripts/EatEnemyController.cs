using UnityEngine;

public class EatEnemyController : MonoBehaviour
{

    public KeyCode EatKey = KeyCode.Space;
    public AudioClip eatingSoundClip;
    public AudioSource audioSource;
    public float EatHealthRegen = .5f;

    private bool eating;
    private bool canEat;

    private Animator animator;
    private HealthComponent playerHealth;

    // Use this for initialization
    void Start()
    {
        this.animator = this.GetComponent<Animator>();
        var player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<HealthComponent>();
        canEat = true;
        eating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(this.EatKey) && !eating)
        {
            animator.SetBool("Chomp", true);
            audioSource.PlayOneShot(eatingSoundClip, 0.3f);
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
                // Play the enemy's RIP audio if it has one
                var audioSource = thingToEat.GetComponent<AudioSource>();
                if (audioSource)
                {
                    audioSource.Play();
                }
                Destroy(thingToEat);
                playerHealth.IncreaseHealth(EatHealthRegen);
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
