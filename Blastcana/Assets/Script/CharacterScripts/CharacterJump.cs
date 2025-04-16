using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterJump : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private TilemapCollider2D Tilemap;
    public float JumpStrength;

    public void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log(Physics2D.OverlapCircle(groundCheck.position, 0.2f) == Tilemap);
        if (IsGrounded())
        {
            rb.velocity = Vector2.up * JumpStrength;
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(0.31f,0.02f),0) == Tilemap;
    }
}
