using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Fireball : ProjectileClass
{
    void Start()
    {
        SpriteDirection();
    }

    void FixedUpdate()
    {
        Movement();
    }
public override void OnCollison()
    {
        throw new System.NotImplementedException();
        //Fait spawn une explosion + returne dans la pool.
    }
}
