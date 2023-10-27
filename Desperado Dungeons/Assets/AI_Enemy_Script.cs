using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AI_Enemy_Script : MonoBehaviour
{
    public Playable_Character_Script player;
    public AudioManager audioSource;
    public Animator animator;
    public Transform enemyGFX;
    public Transform attackPointBandit;
    public LayerMask playerLayer;

    public float speed;
    public float attackRange = 0.16f;
    public int attackDamage = 10;
    public float attackRate = 2f; 
    float nextAttackTime = 0f;

    private float distance;


    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<Playable_Character_Script>();
        animator.SetFloat("Speed", Mathf.Abs(speed));

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance > 0.375f && distance < 2)
        {
            speed = 1;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            if (direction.x >= .01f)
            {
                enemyGFX.localScale = new Vector3(-.3f, .3f, 1f);
            }
            else if (direction.x <= -.01f)
            {
                enemyGFX.localScale = new Vector3(.3f, .3f, 1f);
            }
        }
        else if(distance<=.375f)
        {
            speed = 0;
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 3f / attackRate;
            }
        }
        else if(distance >= 2)
        {
            speed = 0;
        }

        //if attack range > distance, set attack true? 
        //then learn how to time attacks ig?
    }

    void Attack()
    {
        animator.SetTrigger("CanAttack");

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPointBandit.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            FindObjectOfType<AudioManager>().PlaySound("EnemySwordAttack");
            player.GetComponent<Playable_Character_Script>().TakeDamage(attackDamage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPointBandit == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPointBandit.position, attackRange);
    }

}
