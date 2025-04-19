using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] BoxCollider2D BoxCol;
    private CharacterMovement MvtScript;
    private AttackCollision _attackCollision;
    public bool IsAttacking;
    public float Reach;
    void Start()
    {
        MvtScript = GetComponent<CharacterMovement>();
        _attackCollision = BoxCol.GetComponent<AttackCollision>();
    }

    //Fonction appelée pour lancer l'attaque de mêlée.
    public void OnAttack(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        StartCoroutine(AttackRoutine());
    }
    //Coroutine de l'attaque qui permet au Box collider devant le joueur d'infliger des dégâts..
    IEnumerator AttackRoutine()
    {
        IsAttacking = true;
        _attackCollision.Enabled = true;
        BoxCol.transform.position = rb.position + Vector2.right * Reach * MvtScript.Direction;
        yield return new WaitForSeconds(2f);
        _attackCollision.Enabled = false;
        IsAttacking = false; 
    }
}
