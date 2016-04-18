using UnityEngine;

public class WhirlpoolController : MonoBehaviour
{
    private Rigidbody2D Body;

    // Use this for initialization
    void Start()
    {
        this.Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.Body.AddTorque(0.1f, ForceMode2D.Impulse);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Whirlpool" || other.gameObject.tag == "Boss" || other.gameObject.tag == "Enemy")
        {
            Destroy(other);
            this.transform.localScale = new Vector3(this.transform.localScale.x * 1.20f, this.transform.localScale.x * 1.20f, this.transform.localScale.z);
        }

        other.GetComponent<Rigidbody2D>().AddForce((transform.position - other.transform.position) * 25, ForceMode2D.Impulse);

        var health = other.transform.parent.GetComponent<HealthComponent>();
        if (health != null)
        {
            health.DecreaseHealth(.01f);
            Invoke("Release", 4f);
        }
    }

    void Release()
    {
        Destroy(gameObject);
    }
}
