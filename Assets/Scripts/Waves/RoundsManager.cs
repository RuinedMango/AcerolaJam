using UnityEngine;

public class RoundsManager : MonoBehaviour
{
    public int round;
    public GameObject[] rifts;
    private static RoundsManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Found 2 Round manager instances");
        }
        instance = this;
    }

    public static RoundsManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        rifts = GameObject.FindGameObjectsWithTag("Rift");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy") == null)
        {
            round++;
            startRound();
        }
        rifts = GameObject.FindGameObjectsWithTag("Rift");
    }

    public void startRound(){
        foreach(GameObject rift in rifts)
        {
            rift.GetComponentInChildren<NephlemRifts>().StartRound(round);
        }
    }
}
