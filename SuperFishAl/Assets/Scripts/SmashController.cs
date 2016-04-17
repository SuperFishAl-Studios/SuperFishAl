using UnityEngine;

public class SmashController : MonoBehaviour
{
    public GameObject Explosion;

    private ParticleSystem particles;

    // Use this for initialization
    void Start()
    {
        this.particles = this.Explosion.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.otherCollider.gameObject.transform.parent.tag == "Destructable")
            {
                var explode = Instantiate(this.Explosion, contact.otherCollider.transform.position, new Quaternion());
                Destroy(contact.otherCollider.gameObject.transform.parent.gameObject);
            }
            else if (contact.otherCollider.tag == "Destructable")
            {
                var explode = Instantiate(this.Explosion, contact.otherCollider.transform.position, new Quaternion());
                Destroy(contact.otherCollider.gameObject);
            }
            if (contact.collider.gameObject.transform.parent.tag == "Destructable")
            {
                var explode = Instantiate(this.Explosion, contact.collider.transform.position, new Quaternion());
                Destroy(contact.collider.gameObject.transform.parent.gameObject);
            }
            if (contact.collider.tag == "Destructable")
            {
                var explode = Instantiate(this.Explosion, contact.collider.transform.position, new Quaternion());
                Destroy(contact.collider.gameObject);
            }
        }
    }
}
