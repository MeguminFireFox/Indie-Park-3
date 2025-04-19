using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterJump : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private CharacterMovement MvtScript;
    private CharacterAttack AttackScript;
    public float JumpStrength;

    void Start()
    {
        MvtScript = gameObject.GetComponent<CharacterMovement>();
        AttackScript = GetComponent<CharacterAttack>();

    }

    //Fonction appeléee pour sauter.
    public void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!MvtScript.Dashing  && !AttackScript.IsAttacking)
            if (IsGrounded())
            {
                rb.velocity = Vector2.up * JumpStrength;
            }
    }

    //Fonction retournant si le joueur est sur le sol.
    public bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(0.25f, 0.5f), 0, groundLayer);
    }
}
