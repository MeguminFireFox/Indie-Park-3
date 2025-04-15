using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : ProjectileClass
{
    void OnEnable()
    {
        SpriteDirection();
    }

    void FixedUpdate()
    {
        Movement();
    }

    public override void OnCollison()
    {
        //Fait spawn une explosion
       // GameObject Explosion = _objectPool.GetPooledObject();
        gameObject.SetActive(false);
    }
}
