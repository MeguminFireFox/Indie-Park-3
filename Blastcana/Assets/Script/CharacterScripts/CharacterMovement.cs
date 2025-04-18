using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    private Vector2 Movement;
    public float PlayerSpeed;
    public bool Dashing = false;
    public int Direction;

    //Fonction appeléee pour le moubement directionnel.
    public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!Dashing)
        {
            Movement = context.ReadValue<Vector2>();
            rb.velocity = new Vector2(PlayerSpeed * Movement.x, rb.velocity.y);
            if (Movement.x < -0.3f || Movement.x > 0.3f)
            {
                Direction = (int)Mathf.Sign(Movement.x);
            }
        }

    }


}
