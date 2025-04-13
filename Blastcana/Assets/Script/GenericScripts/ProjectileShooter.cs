using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{


    [SerializeField] GameObject Owner;
    [SerializeField] GameObject ProjectilePrefab;

    private float direction;

    public void OnFire(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
      /*  if(Owner.TryGetComponent(out CharacterAttack characterscript)){
        direction = characterscript.direction;
        }
        else if(Owner.TryGetComponent(out MonsterRange monsterscript)){
        direction = monsterscript.direction;
        }
        */
        var proj = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);

    }
}