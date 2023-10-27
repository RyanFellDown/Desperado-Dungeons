using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Animator dummyAnimation;
    [SerializeField] HealthBarEnemy healthBar;
    public int maxHealth = 120;
    public int currentHealth;
    private float timer;

    //[SerializeField] public GameObject damageTextPrefab;

    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBarEnemy>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 3)
        {
            timer = 0;
            currentHealth = maxHealth;
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        //Show the enemy animation taking damage.
        dummyAnimation.SetTrigger("TookDamage");

        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }
}
