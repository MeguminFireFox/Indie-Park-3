using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    public bool Enabled = false;
    private BoxCollider2D _attackcollision;
    private int Damage = 1;
    void Start()
    {
        _attackcollision = GetComponent<BoxCollider2D>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Enabled)
        {
            if (other.TryGetComponent(out Damageable damageable))
            {
                Debug.Log("Hittt");
                damageable.Hit(Damage);
            }
        }
    }
}
