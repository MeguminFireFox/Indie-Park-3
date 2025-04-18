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
    private bool TouchedGround;

    void Start()
    {
        MvtScript = gameObject.GetComponent<CharacterMovement>();
    }

    //Fonction appeléee pour dash.
    public void OnDash(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (TouchedGround)
        {
            if (!MvtScript.Dashing)
            {
                StartCoroutine(DashingRoutine());
            }
        }
    }

    /// <summary>
    /// Coroutine s'occupant du dash du joueur).
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

    void FixedUpdate()
    {
        if (!TouchedGround)
            if (Physics2D.OverlapBox(groundCheck.position, new Vector2(0.25f, 0.5f), 0, groundLayer))
            {
                TouchedGround = true;
            }
    }
}
