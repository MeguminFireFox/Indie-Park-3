using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMana : MonoBehaviour
{
    [SerializeField] private Image ManaBar;
    public int Mana;
    public int ManaMax;
    public int SuperAttackRequirement;
    public int SuperJumpRequirement;
    public int FireRequirement;
    public int SuperDashRequirement;

    void Start()
    {
        Mana = ManaMax;
        ManaBar.fillAmount = 1;
        StartCoroutine(ManaRoutine());
    }

    void FixedUpdate()
    {
        ManaBar.fillAmount = (float)Mana / (float)ManaMax;
    }

    IEnumerator ManaRoutine()
    {
        if (Mana < 100)
        {
            Mana += 1;
        }
        yield return new WaitForSeconds(0.25f);
    }
}
