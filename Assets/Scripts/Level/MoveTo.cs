using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public Transform Move;
    public Transform To;
    public Vector3 plus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move.position = To.position + plus;
    }
}
