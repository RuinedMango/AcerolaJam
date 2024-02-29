using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10;
    public float range = 100f;

    public float scatter;

    SimpleAI ai;
    public Transform forwrd;

    [SerializeField]
    bool fireReady;
    public float fireRate;

    public int bulletAmount;

    public bool auto;

    public GameObject bullet;
    public GameObject bulletHole;


    void Start()
    {
        fireReady = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if (!auto && Input.GetButtonDown("Fire1") && fireReady)
            {
                fireReady = false;
                Shoot();
            }
            if (auto && Input.GetButton("Fire1") && fireReady)
            {
                fireReady = false;
                Shoot();
            }
            for (int i = 0; i < bulletAmount; i++)
            {
                Destroy(GameObject.Find("BulletHole(Clone)"));
            }
        }
    }
    void Shoot()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            Instantiate(bullet, this.transform.position, this.transform.rotation);
        }
        Invoke(nameof(resetFireState), fireRate);
    }
    void resetFireState()
    {
        fireReady = true;

    }
}
