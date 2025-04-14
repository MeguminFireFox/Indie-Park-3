using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileClass : MonoBehaviour
{
    public GameObject Owner;
    //Vitesse du proj. Se modifie sur le prefab.
    public float Speed;
    // A cacher dans l'inspecteur.
    public int Direction;
    // Paramètre correspondant a la direction dans laquelle est orienté le sprite du projectile.
    const string _facingDirectionParameter = "FacingDirection";

    /// <summary>
    /// Movement des projectiles rectilignes.
    /// </summary>
    public void Movement()
    {
        Rigidbody2D _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector2(Speed * Direction, _rigidbody.velocity.y);
    }
    
    /// <summary>
    /// Ajuste l'orientation du sprite du projectile en fonction de l'orientation.
    /// </summary>
    public void SpriteDirection()
    {
        Animator _animator = GetComponent<Animator>();
        _animator.SetBool(_facingDirectionParameter, Direction > 0);
    }
    
    /// <summary>
    /// Appelée lorsqu'un projectile entre en collision.
    /// </summary>
    public abstract void OnCollison();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Owner != other.gameObject)
        {
            OnCollison();
        }
    }
}
