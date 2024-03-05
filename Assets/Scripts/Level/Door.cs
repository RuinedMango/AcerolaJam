using UnityEngine;

public class Door : MonoBehaviour
{
    public Quaternion origRot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        origRot = gameObject.transform.parent.rotation;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameObject.transform.parent.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.transform.parent.rotation = origRot;
        }
    }
}
