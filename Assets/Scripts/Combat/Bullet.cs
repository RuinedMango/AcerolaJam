using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed;
    private float damage;
    private bool isTrigger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damage = GameObject.Find("Player").GetComponentInChildren<Gun>().damage;
        if(GetComponent<Collider2D>() != null)
        {
            isTrigger = GetComponent<Collider2D>().isTrigger;
        }
        else
        {
            isTrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(!isTrigger)
        {
            if (collider.gameObject.GetComponent<SimpleAI>() == null)
            {
                return;
            }
            else
            {
                collider.gameObject.GetComponent<SimpleAI>().Damage(damage);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<SimpleAI>() == null)
        {
            return;
        }
        else
        {
            collider.gameObject.GetComponent<SimpleAI>().Damage(damage);
        }
    }
}
