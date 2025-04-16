using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    private Vector2 Movement;
    public float PlayerSpeed;

    public int Direction;


    // Update is called once per frame
    public void OnWalk(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
        Direction = (int)Mathf.Sign(Movement.x);
        rb.velocity = new Vector2(PlayerSpeed * Movement.x, rb.velocity.y);

    }
    public void OnRun(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {

        Movement = context.ReadValue<Vector2>();
        Direction = (int)Mathf.Sign(Movement.x);
        rb.velocity = new Vector2(PlayerSpeed * Movement.x * 1.25f, rb.velocity.y);

    }

}
