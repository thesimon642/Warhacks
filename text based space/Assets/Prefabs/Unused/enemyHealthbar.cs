using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealthbar : MonoBehaviour
{
    [SerializeField]
    private EnemyController attachedEnemy;
    private float maxHealth;
    private float currentHealth;
    [SerializeField]
    private Slider healthSlider;
    void Update()
    {
        maxHealth = attachedEnemy.maxHP;
        currentHealth = attachedEnemy.currentHP;
        healthSlider.value = currentHealth/maxHealth;
    }
}
