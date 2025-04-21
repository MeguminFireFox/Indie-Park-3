using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterDash : MonoBehaviour

{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public float DashStrength;
    private CharacterMovement MvtScript;
    private CharacterAttack AttackScript;
    private CharacterMana _characterMana;
    public bool TouchedGround;

    void Start()
    {
        MvtScript = GetComponent<CharacterMovement>();
        AttackScript = GetComponent<CharacterAttack>();
        _characterMana = GetComponent<CharacterMana>();
    }

    //Fonction appeléee pour dash.
    public void OnDash(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (TouchedGround && !AttackScript.IsAttacking)
        {
            if (!MvtScript.Dashing)
            {
                StartCoroutine(DashingRoutine());
            }
        }
    }

    /// <summary>
    /// Coroutine s'occupant du dash du joueur.
    /// </summary>
    /// <returns></returns>
    IEnumerator DashingRoutine()
    {
        TouchedGround = false;
        rb.velocity = new Vector2(DashStrength * Vector2.right.x * MvtScript.Direction, 0);
        MvtScript.Dashing = true;
        rb.gravityScale = 0;

        yield return new WaitForSeconds(0.3f);

        rb.gravityScale = 1;
        MvtScript.Dashing = false;
    }
    public void OnSuperDash(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("superdashhh");
        if (TouchedGround && !AttackScript.IsAttacking && _characterMana.Mana >= _characterMana.SuperDashRequirement)
        {
            if (!MvtScript.Dashing)
            {
                StartCoroutine(SuperDashingRoutine());
            }
        }
    }
    IEnumerator SuperDashingRoutine()
    {
        _characterMana.Mana -= _characterMana.SuperDashRequirement;
        TouchedGround = false;
        rb.velocity = new Vector2(DashStrength * Vector2.right.x * 1.25f * MvtScript.Direction, 0);
        MvtScript.Dashing = true;
        rb.gravityScale = 0;

        yield return new WaitForSeconds(0.3f);

        rb.gravityScale = 1;
        MvtScript.Dashing = false;
    }

    //Traque lorsque le joueur touche le sol, permettant la réutilisation du dash.
    void FixedUpdate()
    {
        if (!TouchedGround)
            if (Physics2D.OverlapBox(groundCheck.position, new Vector2(0.25f, 0.5f), 0, groundLayer))
            {
                TouchedGround = true;
            }
    }
}
