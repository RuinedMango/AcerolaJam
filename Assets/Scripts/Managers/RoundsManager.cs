using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundsManager : MonoBehaviour
{
    public int round;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemySpawn;
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

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startRound(){
        for(int i = 0; i < round * 3; i++){
            Instantiate (enemy, enemySpawn.transform);
            if(i >= 6){
                Instantiate(enemy2, enemySpawn.transform);
            }
            if(i >= 12){
            Instantiate(enemy3, enemySpawn.transform);
            }
        }
        round++;
    }
}
