using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Damageable : MonoBehaviour
{
    public int MaxHp = 1;
    public UnityEvent<int, int> OnHit;
    int Hp;

    //Fonction appelée quand un damageable est détecté par une collision de dégâts. Invoque un UnityEvent.
    public void Hit(int damage)
    {
        Hp -= damage;
        OnHit?.Invoke(Hp, damage);
    }

    void Start()
    {
        Hp = MaxHp;
    }
}
