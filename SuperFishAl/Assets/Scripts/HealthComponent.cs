using System.Linq;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthComponent : MonoBehaviour {

    public double CurrentHealth;
    public double StartingHealth = 5;
    public double MaxHealth = 5;
    public double MinHealth = 0;

    public AudioClip smallDamageSound;
    public AudioClip largeDamageSound;
    public float largeDamageThreshold = 1.0f; // Above this value is large damage
    public AudioSource audioSource;

    private bool IsDead;
    private bool IsDamaged;

	// Use this for initialization
	void Start () {
        CurrentHealth = StartingHealth;
        Debug.Log("Starting Health: " + CurrentHealth);
	}

    public void IncreaseHealth(double amount)
    {
        var updatedHealth = CurrentHealth + amount;

        if (updatedHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        else
        {
            CurrentHealth = updatedHealth;
        }
    }

    public void DecreaseHealth(double amount)
    {
        this.IsDamaged = true;
        var updatedHealth = CurrentHealth - amount;

        if (updatedHealth <= MinHealth && !IsDead)
        {
            CurrentHealth = MinHealth;
            KillThePlayer();
        }
        else
        {
            CurrentHealth = updatedHealth;
        }
        Debug.Log("OUCH! Health: " + CurrentHealth);

        if (amount > largeDamageThreshold)
        {
            audioSource.PlayOneShot(largeDamageSound);
        }
        else
        {
            audioSource.PlayOneShot(smallDamageSound);
        }
    }

    public void ResetHealth()
    {
        CurrentHealth = MaxHealth;
    }

    public void KillThePlayer()
    {
        Debug.Log("RIP!");
        IsDead = true;
        var playerFish = gameObject.GetComponentsInChildren<Transform>().Last().gameObject;
        Destroy(playerFish);


        // TODO: death animation here or something

        SceneManager.LoadScene("DeathScreen");
    }

}
