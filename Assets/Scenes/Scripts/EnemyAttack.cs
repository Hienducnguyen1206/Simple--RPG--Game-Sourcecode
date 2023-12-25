using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask playerLayers;
    public int attackDamage = 40;
   
    public EnemyController enemyController;
    public Transform player;
    bool canAttack = true;
    public float attackCooldown = 2.0f;
    float attackTimer = 0.0f;

    public AudioSource woodSwordSlashSound;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();
        woodSwordSlashSound = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (!canAttack && !enemyController.isDead )
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackCooldown)
            {
                canAttack = true;
                attackTimer = 0.0f;
            }
        }
        else
        {
           
            AutoAttack();
            canAttack = false;
        }
    }

    void AutoAttack()
    {
        if (!enemyController.isDead)
        {
            if (transform.position == null || player.position == null) {
                return;
            }
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer <= attackRange)
            {
                animator.SetTrigger("Hehe");
                
            }
        }
    }

    void PlaySwordSound()
    {
        woodSwordSlashSound.Play();
    }

    void DamageToPlayer()
    {
        Debug.Log("Damage");
        Collider2D hitPlayer = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayers);
        if (hitPlayer != null)
        {
            hitPlayer.GetComponent<PlayerController>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
