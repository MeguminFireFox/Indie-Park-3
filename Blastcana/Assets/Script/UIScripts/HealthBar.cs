using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    [SerializeField] private Damageable _damageable;

    [SerializeField] private Image Health;

    private float EmptyBar;

    // Start is called before the first frame update
    void Start()
    {
        Health.fillAmount = 1;
        EmptyBar = 1/_damageable.MaxHp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
