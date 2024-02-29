using UnityEngine;
using UnityEngine.AI;

public class SimpleAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public float health;
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
    }
    public void Damage(float damage)
    {
        health -= damage;
    }
}
