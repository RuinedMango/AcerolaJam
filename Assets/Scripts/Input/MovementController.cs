using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        xDir = controls.actions.FindAction("MoveX").ReadValue<float>();
        yDir = controls.actions.FindAction("MoveY").ReadValue<float>();
        Vector3 WorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 Difference = WorldPoint - transform.position;
        Difference.Normalize();

        float RotationZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;
        body.transform.rotation = Quaternion.Euler(0f, 0f, RotationZ - 90);
    }

    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }

        HandleMove();
    }

    private void HandleMove()
    {
        body.velocityX = xDir * (moveSpeed * 100) * Time.fixedDeltaTime;
        body.velocityY = yDir * (moveSpeed * 100) * Time.fixedDeltaTime;
    }
}
