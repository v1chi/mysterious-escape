using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private HealthPlayer health;
    public Slider healthBar;
    public Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<HealthPlayer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = health.maxHealth;
        healthBar.value = health.health;
        hpText.text = "HP: " + health.health + "/" + health.maxHealth;
    }
}
