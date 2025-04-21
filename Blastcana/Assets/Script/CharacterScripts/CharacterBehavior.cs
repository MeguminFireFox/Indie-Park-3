using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBehavior : MonoBehaviour
{
    [SerializeField] private Image HealthBar;
    [SerializeField] private Damageable _damageable;
    [SerializeField] private Animator _animator;
    private Rigidbody2D rb;
    private CharacterMovement MvtScript;
    private CharacterJump JumpScript;
    private CharacterAttack AttackScript;
    private CharacterDash DashScript;
    private CharacterMana ManaScript;
    const string _xMovementParameter = "XMovement";
    const string _yVelocityParameter = "YVelocity";
    const string _isGroundedParameter = "IsGrounded";
    const string _attackingParameter = "IsAttacking";
    const string _superAttackingParameter = "IsSuperAttacking";
    const string _DashParameter = "IsDashing";
    const string _superDashParameter = "IsSuperDashing";
    const string _superJumpParameter = "SuperJump";
    const string _firingParameter = "IsFiring";


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        MvtScript = GetComponent<CharacterMovement>();
        JumpScript = GetComponent<CharacterJump>();
        AttackScript = GetComponent<CharacterAttack>();
        DashScript = GetComponent<CharacterDash>();
        ManaScript = GetComponent<CharacterMana>();
    }
    // Update du sprite en fonction de son mouvement.
    void FixedUpdate()
    {
        _animator.SetFloat(_xMovementParameter, MvtScript.Movement.x);
        _animator.SetBool(_superJumpParameter, JumpScript.SuperJump);
        _animator.SetBool(_isGroundedParameter, JumpScript.IsGrounded());
        _animator.SetFloat(_yVelocityParameter, rb.velocity.y);

    }

    //Trigger de l'attaque pour l'animator.
    public void OnAttack(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!AttackScript.IsAttacking)
        _animator.SetTrigger(_attackingParameter);
    }
    public void OnSuperAttack(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!AttackScript.IsAttacking && ManaScript.Mana >= ManaScript.SuperAttackRequirement)
            _animator.SetTrigger(_superAttackingParameter);
    }

    //Trigger du dash pour l'animator.
    public void OnDash(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (DashScript.TouchedGround && !AttackScript.IsAttacking)
        {
            _animator.SetTrigger(_DashParameter);
        }
    }
    public void OnSuperDash(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (DashScript.TouchedGround && !AttackScript.IsAttacking && ManaScript.Mana >= ManaScript.SuperDashRequirement)
        {
            _animator.SetTrigger(_superDashParameter);
        }
    }

    public void OnFire(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (ManaScript.Mana >= ManaScript.FireRequirement)
        {
            _animator.SetTrigger(_firingParameter);
        }
    }

    public void OnHit(int Hp, int damage)
    {
        HealthBar.fillAmount = (float) Hp / (float) _damageable.MaxHp;
        if (Hp <= 0)
        {
            Destroy(gameObject);
            // anim.
        }
    }
}
