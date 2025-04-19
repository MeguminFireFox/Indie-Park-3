using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private Rigidbody2D rb;
    private CharacterMovement MvtScript;
    private CharacterJump JumpScript;
    private CharacterAttack AttackScript;
    private CharacterDash DashScript;
    const string _xMovementParameter = "XMovement";
    const string _yVelocityParameter = "YVelocity";
    const string _isGroundedParameter = "IsGrounded";
    const string _AttackingParameter = "IsAttacking";
    const string _DashParameter = "IsAttacking";

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        MvtScript = GetComponent<CharacterMovement>();
        JumpScript = GetComponent<CharacterJump>();
        AttackScript = GetComponent<CharacterAttack>();
        DashScript = GetComponent<CharacterDash>();
    }
    //Trigger de l'attaque pour l'animator.
    public void OnAttack(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _animator.SetTrigger(_AttackingParameter);
    }

    //Trigger du dash pour l'animator.
    public void OnDash(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (DashScript.TouchedGround && !AttackScript.IsAttacking)
        {
            _animator.SetTrigger(_AttackingParameter);
        }
    }
    // Update du sprite en fonction de son mouvement.
    void FixedUpdate()
    {
        _animator.SetFloat(_xMovementParameter, MvtScript.Movement.x);
        _animator.SetBool(_isGroundedParameter, JumpScript.IsGrounded());
        _animator.SetFloat(_yVelocityParameter, rb.velocity.y);

    }
    public void OnHit()
    {
        //conséquences.
    }
}
