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
    private CharacterMana _characterMana;

    public float JumpStrength;
    public bool SuperJump;

    void Start()
    {
        MvtScript = gameObject.GetComponent<CharacterMovement>();
        AttackScript = GetComponent<CharacterAttack>();
        _characterMana = GetComponent<CharacterMana>();
    }

    //Fonction appelée pour sauter.
    public void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!MvtScript.Dashing && !AttackScript.IsAttacking)
            if (IsGrounded())
            {
                SuperJump = false;
                rb.velocity = Vector2.up * JumpStrength;
            }
    }

    public void OnSuperJump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {

        if (!MvtScript.Dashing && !AttackScript.IsAttacking && _characterMana.Mana > _characterMana.SuperJumpRequirement)
            if (IsGrounded())
            {
                _characterMana.Mana -=  _characterMana.SuperJumpRequirement;
                SuperJump = true;
                rb.velocity = Vector2.up * JumpStrength * 1.5f;
            }
    }

    //Fonction retournant si le joueur est sur le sol.
    public bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(0.25f, 0.5f), 0, groundLayer);
    }
}
