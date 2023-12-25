using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour 
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public PlayerController playerController;
    public bool isAttacking = false;

    public AudioSource swordSlashSound;

    private void Start()
    {
        swordSlashSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {       
         isAttacking = true;
        Attack();
        }

        
    }

    void Attack()
    {    
        
       
        animator.SetTrigger("Hehe");
        swordSlashSound.Play();

       
        
        
    }

    void Damage()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemys)
        {
            Debug.Log("We hit enemy" + enemy.name);
            enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);


        }

    }

    private void resetAtackStatus() 
    {
        isAttacking=false;
    }

    private void OnDrawGizmosSelected()
       
    {
        if (attackPoint == null)
            return;
      Gizmos.DrawWireSphere(attackPoint.position, attackRange);
   }
}
