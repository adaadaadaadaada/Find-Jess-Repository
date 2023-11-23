using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 3;
    public int currentHealth;

    public HealthBar healthBar;
    public EnemyMovement enemyMovement;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        enemyMovement.CaughtPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        void CaughtPlayer()
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
