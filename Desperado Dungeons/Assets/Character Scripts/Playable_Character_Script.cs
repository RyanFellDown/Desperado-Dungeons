using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playable_Character_Script : MonoBehaviour
{
    [SerializeField] Rigidbody2D RG;
    public Animator animator;
    public InventoryManager inventory;
    public DeathScreen playerIsDeadSet;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public HealthBar healthBar;
    private static bool doesPlayerExist;

    public float attackRange = 0.5f;                        //range of attacks
    public int attackDamage = 40;                           //damage per attack
    public float attackRate = 2;                            //rate at which player attacks
    public float moveSpeed = 0;                             //speed player moves at
    public int maxHealth = 100;                             //max health player can have
    public int currentHealth;                               //current health player has
    float nextAttackTime = 0;                               //time before next attack

    //[SerializeField] private TrailRenderer trailRender;     //renders trail for dash
    //private bool dashTrue = true;                           
    private bool isDashing;                                 //if dashing, then true, else false;
    //private float dashingPower = 25f;                       //this is the main variable to change for dash power.
    //private float dashingTime = 0.4f;                       //amount of time the player dashes for.
    //private float dashingCooldown = 1f;                     //how long between dashes

    [SerializeField] private GameObject shield;
    private bool isShielded;
    private bool canBeShieled;

    private void Start()
    {
        isShielded = false;
        canBeShieled = true;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        if (!doesPlayerExist)
        {
            doesPlayerExist = true;
            DontDestroyOnLoad(transform.gameObject);
            healthBar = FindObjectOfType<HealthBar>();
        }
        else
        {
            Destroy(gameObject);
        }
    }


    //From here...
    /*
    private void Awake()
    {
        inventory = GetComponent<InventoryManager>();
    }
    */

    public void DropItem(Item2D item)
    {
        Vector2 spawnLocationItem = transform.position;
        Vector2 spawnOffset = Random.insideUnitCircle * .325f;
        //weird how this is kinda fucking up where it spawns and destroying dropped objects...
        //could just resort to selling items anyways.

        Item2D droppedItem = Instantiate(item, spawnLocationItem + spawnOffset, Quaternion.identity);
        droppedItem.rigid2D.AddForce(spawnOffset * .2f, ForceMode2D.Impulse);
    }
    public void DropItem(Item2D item, int numberToDrop)
    {
        for(int x = 0; x<numberToDrop; x++)
        {
            DropItem(item);
        }
    }

    //...to here, is functions to do with UI inventory and GUI.


    void Update()
    {
        //update the healthbar and the object healthBar refers to so data saves between scenes.
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);

        ShieldPlayer();

        if (DialougeManager.isActive == true)
        {
            animator.SetFloat("Speed", 0);
            return;
        }

        MoveGameObject();

        animator.SetFloat("Speed", Mathf.Abs(moveSpeed));

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            animator.SetBool("Ouch", true);
            TakeDamage(20);
        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        if (isDashing)
        {
            return;
        }
        
        /*
        if(Input.GetKeyDown(KeyCode.LeftShift) && dashTrue)
        {
            StartCoroutine(Dash());
        }
        */

        //PlayerPrefs.SetInt("Current Health", currentHealth);

        /*
         * This is for Top Down Shooting, WIP rn
        private void FixedUpdate()
        {
            Vector2 lookDirection = mousePos - RG.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
            RG.rotation = angle;
        }
        */
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.tag == "Dummy")
            {
                FindObjectOfType<AudioManager>().PlaySound("HitEffectSound");
                enemy.GetComponent<Dummy>().TakeDamage(attackDamage);
            }
            if (enemy.gameObject.tag == "BanditHeavy")
            {
                FindObjectOfType<AudioManager>().PlaySound("HitEffectSound");
                enemy.GetComponent<BanditScript>().TakeDamage(attackDamage);
            }
            if (enemy.gameObject.tag == "Archer")
            {
                FindObjectOfType<AudioManager>().PlaySound("HitEffectSound");
                enemy.GetComponent<EnemyShooting>().TakeDamage(attackDamage);
            }
            if (enemy.gameObject.tag == "DragonBoss")
            {
                FindObjectOfType<AudioManager>().PlaySound("HitEffectSound");
                enemy.GetComponent<Dragon_Boss>().TakeDamage(attackDamage);
            }
            
        }
    }

    void ShieldPlayer()
    {
        if (Input.GetKey(KeyCode.Mouse1) && !isShielded && canBeShieled)
        {
            Debug.Log("player is shielded!");
            animator.SetTrigger("Shield");
            shield.SetActive(true);
            isShielded = true;
            Invoke("ShieldOff", .75f);
        }
        else if(!canBeShieled)
        {
            Debug.Log("player cannot be shielded!");
        }
    }

    void ShieldOff()
    {
        Debug.Log("shield is off");
        shield.SetActive(false);
        isShielded = false;
        canBeShieled = false;
        Invoke("ShieldCanWork", 1f);
    }

    void ShieldCanWork()
    {
        canBeShieled = true;
        Debug.Log("shield can work now");
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    void MoveGameObject()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.localScale = new Vector3(-0.3f, 0.3f, 1);
            moveSpeed = 1.5f;
            RG.transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            moveSpeed = 1.5f;
            RG.transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveSpeed = 1.5f;
            RG.transform.Translate(Vector2.up * verticalInput * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveSpeed = 1.5f;
            RG.transform.Translate(Vector2.up * verticalInput * Time.deltaTime * moveSpeed);
        }
        if(!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            moveSpeed = 0;
        }
        /*
        if(moveSpeed > 0)
        {
            FindObjectOfType<AudioManager>().PlaySound("Player Sound");
        }
        */
    }

    public void TakeDamage(int damage)
    {

        if (!isShielded) {
            animator.SetTrigger("Ouch");
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamageArrow(int damage)
    {
        if (!isShielded)
        {
            animator.SetTrigger("Ouch");
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        FindObjectOfType<AudioManager>().PlaySound("PlayerDied");
        animator.SetBool("IsDead", true);
        int playerCoins = FindObjectOfType<CoinCounter>().NumberOfCoins();
        FindObjectOfType<CoinCounter>().SubtractCoins(playerCoins);
        playerIsDeadSet.playerIsDead = true;
    }

    public void RegainHealth(int addHealth)
    {
        if(currentHealth < maxHealth) {
            currentHealth += addHealth;
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            healthBar.SetHealth(currentHealth);
        }
    }

    /*
    private IEnumerator Dash()
    {
        dashTrue = false;
        isDashing = true;
        float originalGravity = RG.gravityScale;
        RG.gravityScale = 0f;
        RG.velocity = new Vector2(transform.localScale.x * dashingPower * -1, 0f);
        trailRender.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trailRender.emitting = false;
        RG.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        dashTrue = true;
    }
    */
    /*
    //This function saves the player's data.
    public void SavePlayer()
    { 

        SavingScript.PlayerSave(this);
    }

    //This function loads the player's data.
    public void LoadPlayer()
    {
        PlayerData data = SavingScript.LoadPlayer();

        currentHealth = data.currentHealth;
    }
    */

}
