using System.Linq;
using UnityEngine;
using System.Collections;

public class HealthComponent : MonoBehaviour {

    public double CurrentHealth;
    public double StartingHealth = 5;
    public double MaxHealth = 5;
    public double MinHealth = 0;

    private bool IsDead;
    private bool IsDamaged;

	// Use this for initialization
	void Start () {
        CurrentHealth = StartingHealth;
        Debug.Log("Starting Health: " + CurrentHealth);
	}
	
	// Update is called once per frame
    void Update () {
	    // TODO: any damaged sounds/animations here
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
    }

}
