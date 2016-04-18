using System.Linq;
using UnityEngine;
using System.Collections;

public class EnemyCollisionDamageComponent : MonoBehaviour
{
    public float damageAmount = 0.5f;
    public float timeBetweenAttacks = 2f;

    public Sprite collisionSprite;

    private HealthComponent playerHealth;
    private GameObject playerFish;

    private bool playerInRange;

    private float timer;

    private SpriteRenderer spriteRenderer;
    private Sprite originalsprite;

	// Use this for initialization
	void Start ()
	{
	    var player = GameObject.FindGameObjectWithTag("Player");
        playerFish = player.GetComponentsInChildren<Transform>().Last().gameObject;
        playerHealth = player.GetComponent<HealthComponent>();

        spriteRenderer = GetComponent<SpriteRenderer>();
	    originalsprite = spriteRenderer.sprite;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timer += Time.deltaTime;

	    if (timer > timeBetweenAttacks && playerInRange)
	    {
            Debug.Log("ATTACK!");
	        Attack();
	    }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == playerFish)
        {
            playerInRange = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject == playerFish)
        {
            playerInRange = false;
        }
    }

    void Attack()
    {
        timer = 0f;

        if (collisionSprite != null)
        {
            spriteRenderer.sprite = collisionSprite;
            Invoke("ResetSprite", .5f);
        }

        if (playerHealth.CurrentHealth > playerHealth.MinHealth)
        {
            playerHealth.DecreaseHealth(damageAmount);
        }

    }

    void ResetSprite()
    {
        spriteRenderer.sprite = originalsprite;
    }
}
