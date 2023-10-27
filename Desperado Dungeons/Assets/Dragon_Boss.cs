using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dragon_Boss : MonoBehaviour
{
    [SerializeField] HealthBarEnemy healthBar;
    private GameObject player;
    //public GameObject spottedText;
    public GameObject projectile;
    public GameObject[] itemDrops;
    public Spotted spotted;
    public Transform fireBallPos;
    public Transform attackPointBoss;
    public Transform enemyGFX;
    public Animator dragonBossAnimation;
    public LayerMask playerLayer;


    public float attackRange = 0.3f;
    public int attackDamage = 40;
    public float speed;
    private float distance;
    private float timer;
    public int maxHealth = 400;
    public int currentHealth;
    public float attackRate = 2f;
    public bool dragonIsDead = false;
    float nextAttackTime = 0f;

    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBarEnemy>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //dragonBossAnimation.SetFloat("Speed", Mathf.Abs(speed));

        distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance > 0.75 && distance <=7)
        {
            //speed = 1;

            timer += Time.deltaTime;
            if (timer > 3)
            {
                timer = 0; //after two seconds, timer is restarted to 0 seconds
                Shoot();
            }
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            if (direction.x >= .01f)
            {
                enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (direction.x <= -.01f)
            {
                enemyGFX.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        else if (distance <= 0.75)
        {
            //speed = 0;
            if (Time.time >= nextAttackTime)
            {
                Scratch();
                nextAttackTime = Time.time + 3f / attackRate;
            }
            if (direction.x >= .01f)
            {
                enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (direction.x <= -.01f)
            {
                enemyGFX.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }


    void Shoot()
    {
        FindObjectOfType<AudioManager>().PlaySound("DragonFire");
        dragonBossAnimation.SetTrigger("CanShoot");
        Instantiate(projectile, fireBallPos.position, Quaternion.identity);
    }

    void Scratch()
    {
        dragonBossAnimation.SetTrigger("CanAttack");

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPointBoss.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            FindObjectOfType<AudioManager>().PlaySound("DragonBite");
            player.GetComponent<Playable_Character_Script>().TakeDamage(attackDamage);
        }

    }

    public void TakeDamage(int damage)
    {
        //If Player attacks and hits, damage from player is input here and subtracted from currentHealth.
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        //Show the enemy animation taking damage.
        dragonBossAnimation.SetTrigger("TookDamage");
        Debug.Log("Dragon took damage and animation was set");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Dragon boss died");
        FindObjectOfType<AudioManager>().PlaySound("DragonDied");

        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        //Show the death animation.
        dragonBossAnimation.SetBool("IsDead", true);

        //Drop item when dead.
        ItemDrop();

        //Make Sure you can't run into enemy collider anymore.
        GetComponent<Collider2D>().enabled = false;
        dragonIsDead = true;
        this.enabled = false;
    }

    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            //Randomly generates a number for the position of the coin, heart, and other drops
            var position = new Vector3(Random.Range(-0.3f, 0.3f), 0, Random.Range(-0.3f, 0.3f));

            //Instantiate spawns the items.
            Instantiate(itemDrops[i], transform.position + position, Quaternion.identity);
        }
    }

}
