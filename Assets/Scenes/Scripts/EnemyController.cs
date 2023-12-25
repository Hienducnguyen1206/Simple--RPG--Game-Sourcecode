using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Animator animator;
    private Transform target;
    private SpriteRenderer spriteRenderer;
    public bool isDead = false;
    public int maxHeath = 100;
    public int currentHeath;
    public GameObject myObject;
    private Vector3 initialPosition;
    private EnemyAttack enemyAttack;
    public float observationRange;
    public AudioSource hitAudio;



    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;



    void Start()
    {
        animator = GetComponent<Animator>();
        currentHeath = maxHeath;
        target = FindObjectOfType<PlayerController>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
        enemyAttack = FindAnyObjectByType<EnemyAttack>();
        observationRange = enemyAttack.attackRange - 0.08f;
    }

    public void TakeDamage(int damage)
    {
        currentHeath -= damage;
        hitAudio.Play();

        if (currentHeath <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (!isDead)
        {
            Debug.Log("Goblin Died");
            isDead = true;


            animator.SetTrigger("isDead");
            animator.SetTrigger("isBuried");

            this.enabled = false;

            myObject.GetComponent<BoxCollider2D>().enabled = false;



        }
    }


    void Update()
    {


        if (Vector3.Distance(transform.position, target.position) <= maxRange && Vector3.Distance(transform.position, target.position) >= observationRange)
        {
            FollowPlayer();
        }


        else if (Vector3.Distance(transform.position, target.position) > maxRange)
        {
            UnFollowPlayer();
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

    }

    public void FollowPlayer()

    {
        animator.SetBool("isMoving", true);

        animator.SetFloat("MoveX", target.position.x - transform.position.x);
        animator.SetFloat("MoveY", target.position.y - transform.position.y);
        if (target.position.x - transform.position.x < 0)
        {
            spriteRenderer.flipX = true;

        }
        else if (target.position.x - transform.position.x > 0)
        {
            spriteRenderer.flipX = false;

        }


        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void UnFollowPlayer()
    {
        animator.SetFloat("MoveX", initialPosition.x - transform.position.x);
        animator.SetFloat("MoveY", initialPosition.y - transform.position.y);
        if (initialPosition.x - transform.position.x < 0)
        {
            spriteRenderer.flipX = true;

        }
        else if (initialPosition.x - transform.position.x > 0)
        {
            spriteRenderer.flipX = false;

        }
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);
        if (transform.position == initialPosition)
        {
            animator.SetBool("isMoving", false);
        }
    }

    void DestroyObject()
    {
        if (myObject != null)
        {
            Debug.Log("Destroying object: ");
            Destroy(myObject);
        }
        else
        {
            Debug.LogWarning("Object to destroy is null!");
        }
    }


}