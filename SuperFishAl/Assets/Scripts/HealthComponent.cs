using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour {

    public float CurrentHealth;
    public float StartingHealth = 5;
    public float MaxHealth = 5;
    public float MinHealth = 0;

    public AudioClip smallDamageSound;
    public AudioClip largeDamageSound;
    public float largeDamageThreshold = 1.0f; // Above this value is large damage
    public AudioSource audioSource;

    private bool IsDead;
    private bool IsDamaged;

    private Slider healthSlider;
    private Image healthSliderFillImage;
    private float healthFillFlashSpeed = .5f;
    private Color originalHealthBarColor;

    float duration = 5; // This will be your time in seconds.
    float smoothness = 0.02f; // This will determine the smoothness of the lerp. Smaller values are smoother. Really it's the time between updates.

	// Use this for initialization
	void Start () {
        CurrentHealth = StartingHealth;
        
	    healthSlider = GameObject.FindGameObjectWithTag("Health").GetComponent<Slider>();
	    healthSliderFillImage = GameObject.FindGameObjectWithTag("HealthFill").GetComponent<Image>();
        originalHealthBarColor = healthSliderFillImage.color;

        UpdateHealthBar();
	    
        Debug.Log("Starting Health: " + CurrentHealth);
	}

    public void IncreaseHealth(float amount)
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
        UpdateHealthBar();
    }

    public void DecreaseHealth(float amount)
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
        FlashHealthBarForDamage();
        UpdateHealthBar();
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
        UpdateHealthBar();
    }

    public void KillThePlayer()
    {
        Debug.Log("RIP!");
        IsDead = true;
        var playerFish = gameObject.GetComponentsInChildren<Transform>().Last().gameObject;
        Destroy(playerFish);


        // TODO: death animation here or something

        StartCoroutine(EndLevel());
    }

    IEnumerator EndLevel()
    {
        var waitTime = GetComponent<FadeScript>().BeginFade(1);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("DeathScreen");
    }

    void FlashHealthBarForDamage()
    {
        // TODO: gradient colors?!
        var health = (int) CurrentHealth;
        if (health == 4)
        {
            healthSliderFillImage.color = Color.yellow;
        }else if (health == 3)
        {
            healthSliderFillImage.color = Color.yellow;
        } else if (health == 2)
        {
            healthSliderFillImage.color = Color.red;
        }else if (health == 1)
        {
            healthSliderFillImage.color = Color.red;
        }
        else
        {
            healthSliderFillImage.color = originalHealthBarColor;
        }
           
    }

    void UpdateHealthBar()
    {
        healthSlider.value = CurrentHealth;
    }

}
