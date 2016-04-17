using System.Linq;
using UnityEngine;
using System.Collections;

public class EnemyCollisionDamageComponent : MonoBehaviour
{
    public double damageAmount = 0.5;
    public float timeBetweenAttacks = 2f;

    private HealthComponent playerHealth;
    private GameObject playerFish;

    private bool playerInRange;

    private float timer;

	// Use this for initialization
	void Start ()
	{
	    var player = GameObject.FindGameObjectWithTag("Player");
        playerFish = player.GetComponentsInChildren<Transform>().Last().gameObject;
        playerHealth = player.GetComponent<HealthComponent>();
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

        if (playerHealth.CurrentHealth > playerHealth.MinHealth)
        {
            playerHealth.DecreaseHealth(damageAmount);
        }

    }
}
