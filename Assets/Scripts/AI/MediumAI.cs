using UnityEngine;
using UnityEngine.AI;

public class MediumAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public float health;
    public float dodgeSpeed;
    private Transform bullet;
    private Collider2D bulletColliderDetector;
    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(GameObject.Find("Player").transform.position);
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        gameObject.transform.LookAt(GameObject.Find("Player").transform);
    }
    public void Damage(float damage)
    {
        health -= damage;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        bullet = collider.gameObject.transform;
        agent.gameObject.GetComponent<Rigidbody2D>().AddRelativeForceX(dodgeSpeed, ForceMode2D.Impulse);
        agent.gameObject.GetComponent<Rigidbody2D>().angularVelocity = Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0f, 2f);
    }
}
