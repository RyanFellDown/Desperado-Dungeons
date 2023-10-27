using UnityEngine;

public class BanditScript : MonoBehaviour
{
    public Animator animator;
    public AudioManager audioSource;
    public GameObject[] itemDrops;
    [SerializeField] HealthBarEnemy healthBar;
    public int maxHealth = 100;
    int currentHealth;

    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBarEnemy>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        //If Player attacks and hits, damage from player is input here and subtracted from currentHealth.
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        //Show the enemy animation taking damage.
        animator.SetTrigger("TookDamage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Heavy bandit enemy died");
        FindObjectOfType<AudioManager>().PlaySound("EnemyDied");

        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        //Show the death animation.
        animator.SetBool("IsDead", true);

        //Drop item when dead.
        ItemDrop();

        //Make Sure you can't run into enemy collider anymore.
        GetComponent<Collider2D>().enabled = false;
        GetComponent<AI_Enemy_Script>().enabled = false;
        this.enabled = false;
    }


    private void ItemDrop()
    {
        for(int i = 0; i<itemDrops.Length; i++)
        {
            //Randomly generates a number for the position of the coin, heart, and other drops
            var position = new Vector3(Random.Range(-0.3f, 0.3f), 0, Random.Range(-0.3f, 0.3f));


            //Instantiate spawns the items.
            Instantiate(itemDrops[i], transform.position + new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
