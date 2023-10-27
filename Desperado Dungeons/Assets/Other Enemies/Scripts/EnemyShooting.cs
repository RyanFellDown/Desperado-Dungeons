using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] HealthBarEnemy healthBar;
    private GameObject player;
    public GameObject projectile;
    public GameObject[] itemDrops;
    public Transform projectilePos;
    public Animator enemyAnimation;
    public Transform enemyGFX;

    public float speed;
    private float distance;
    private float timer;
    public int maxHealth = 60;
    public int currentHealth;

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
        enemyAnimation.SetFloat("Speed", Mathf.Abs(speed));

        distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance > 2.75 && distance < 4.5)
        {
            speed = 1;
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
        else if(distance <= 2.75)
        {
            speed = 0;
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0; //after two seconds, timer is restarted to 0 seconds
                shoot();
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
        else if(distance > 4.5)
        {
            speed = 0;
        }
    }

    void shoot()
    {
        FindObjectOfType<AudioManager>().PlaySound("BowSound");
        enemyAnimation.SetTrigger("CanShoot");
        Instantiate(projectile, projectilePos.position, Quaternion.identity);
    }

    public void TakeDamage(int damage)
    {
        //If Player attacks and hits, damage from player is input here and subtracted from currentHealth.
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        //Show the enemy animation taking damage.
        enemyAnimation.SetTrigger("TookDamage");
        Debug.Log("Took damage and animation was set");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Archer enemy died");
        FindObjectOfType<AudioManager>().PlaySound("EnemyDied");

        //Show the death animation.
        enemyAnimation.SetBool("IsDead", true);

        //Drop item when dead.
        ItemDrop();

        //Make Sure you can't run into enemy collider anymore.
        GetComponent<Collider2D>().enabled = false;
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
