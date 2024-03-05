using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D body;
    public PlayerInput controls;
    public float moveSpeed;

    private float xDir = 0;
    private float yDir = 0;

    private void OnEnable()
    {
        controls.ActivateInput();
    }

    private void OnDisable()
    {
        controls.DeactivateInput();
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            body.velocity = Vector3.zero;
            body.freezeRotation = true;
            return;
        }

        body.freezeRotation = false;
        HandleMove();
    }
    private void HandleMove()
    {
        body.velocityX = xDir * (moveSpeed * 100) * Time.fixedDeltaTime;
        body.velocityY = yDir * (moveSpeed * 100) * Time.fixedDeltaTime;
        xDir = controls.actions.FindAction("MoveX").ReadValue<float>();
        yDir = controls.actions.FindAction("MoveY").ReadValue<float>();
        Vector3 WorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 Difference = WorldPoint - transform.position;
        Difference.Normalize();

        float RotationZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;
        body.transform.rotation = Quaternion.Euler(0f, 0f, RotationZ - 90);
    }
}
