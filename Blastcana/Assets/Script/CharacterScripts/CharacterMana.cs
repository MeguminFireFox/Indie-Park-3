using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMana : MonoBehaviour
{
    public int Mana;
    public int ManaMax;
     public int SuperAttackRequirement;
    public int SuperJumpRequirement;
    public int FireRequirement;
    public int SuperDashRequirement;

    void Start()
    {
        Mana = ManaMax;
    }

    void Update()
    {
        
    }
}
