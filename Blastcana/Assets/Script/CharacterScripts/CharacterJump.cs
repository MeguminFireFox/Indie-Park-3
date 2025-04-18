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
    public float JumpStrength;

    void Start()
    {
        MvtScript = gameObject.GetComponent<CharacterMovement>();
    }

    //Fonction appeléee pour sauter.
    public void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log(IsGrounded());
        if (!MvtScript.Dashing)
            if (IsGrounded())
            {
                rb.velocity = Vector2.up * JumpStrength;
            }
    }

    public bool IsGrounded()
    {
        //return Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer);

        return Physics2D.OverlapBox(groundCheck.position, new Vector2(0.25f, 0.5f), 0, groundLayer);
    }
}
