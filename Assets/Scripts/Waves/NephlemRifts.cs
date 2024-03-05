using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class NephlemRifts : MonoBehaviour
{
    private GameObject ppmanager;
    private Camera playerCam;
    public float power;
    public float shakePower;
    Vector3 originalPos;
    public GameObject[] enemies;

    private ChromaticAberration kromer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCam = GameObject.Find("PlayerCam").GetComponent<Camera>();
        originalPos = playerCam.transform.localPosition;
        ppmanager = GameObject.Find("PPManager");
        ppmanager.GetComponent<Volume>().profile.TryGet<ChromaticAberration>(out kromer);
        kromer.intensity.overrideState = true;
    }

    public void StartRound(int round)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            kromer.intensity.value = power;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            kromer.intensity.value = Random.Range(0, shakePower);
            playerCam.transform.localPosition = originalPos + Random.insideUnitSphere * shakePower * Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            kromer.intensity.value = 0;
        }
        playerCam.transform.localPosition = originalPos;
    }
}
