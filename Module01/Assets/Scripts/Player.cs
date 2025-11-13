using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif
using UnityEngine.InputSystem;

public class Player_movements : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float acceleration = 20f;
    [SerializeField] float jumpForce = 6f;
    [SerializeField] CharacterController controller;
    [SerializeField] Key keyToSelect;

    public static CharacterController who;

    private Vector3 velocity = Vector3.zero;
    private bool touch = true;
    private float gravity = -20f;

    void Reset()
    {
        if (controller == null) controller = GetComponent<CharacterController>();
    }

    void Start()
    {
    }

    void Update()
    {
        touch = controller != null && controller.isGrounded;
        if (Keyboard.current != null && Keyboard.current[keyToSelect].isPressed)
        {
            who = controller;
        }
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Keyboard.current == null)
            return;
        float inputX = 0f;
        if (who == controller)
        {
            if (Keyboard.current.aKey.isPressed)
                inputX -= 1f;
            if (Keyboard.current.dKey.isPressed)
                inputX += 1f;
        }
        float targetVelX = inputX * moveSpeed;
        Vector3 currentVel = velocity;
        Vector3 targetVel = new Vector3(targetVelX, currentVel.y, 0f);

        float t = 1f - Mathf.Exp(-acceleration * Time.deltaTime);
        velocity = Vector3.Lerp(currentVel, targetVel, t);

        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            if (velocity.y < 0f)
                velocity.y = -1f;
            if (who == controller && Keyboard.current.spaceKey.wasPressedThisFrame)
                velocity.y = jumpForce;
        }

        Vector3 moveDelta = velocity * Time.deltaTime;
        moveDelta.z = 0f;
        controller.Move(moveDelta);
        Vector3 pos = transform.position;
        if (pos.y < -1f)
		{
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
		}
        if (pos.z != 0f)
            transform.position = new Vector3(pos.x, pos.y, 0f);
    }
}
