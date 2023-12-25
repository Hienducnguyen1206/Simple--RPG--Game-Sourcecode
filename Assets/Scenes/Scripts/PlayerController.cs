using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class PlayerController: MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public bool isMoving = false; 
    public Animator animator;
    public bool isDead = false;
    public bool isAttacking = false;
    public int maxHeath = 100;
    public int currentHeath;
    public GameObject myObject;
    public RectTransform menuImage;
    public PlayerAttack playerAttack;





    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        playerAttack = GetComponent<PlayerAttack>();
        currentHeath = maxHeath;

    }

    void Update()
{
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    animator.SetFloat("moveX", moveHorizontal);
    animator.SetFloat("moveY", moveVertical);

    Vector3 moveDirection = new Vector3(moveHorizontal, moveVertical, 0f);

    if (playerAttack.isAttacking)
    {
        moveDirection *= 0; 
    }
    else
    {
        float adjustedSpeed = moveSpeed;

        if (moveHorizontal != 0 && moveVertical != 0)
        {
            float reducedSpeed = moveSpeed / Mathf.Sqrt(2);
            adjustedSpeed = reducedSpeed; 
        }

        moveDirection *= adjustedSpeed;
    }

    transform.position += moveDirection * Time.deltaTime;

    isMoving = (moveHorizontal != 0 || moveVertical != 0);
    animator.SetBool("isMoving", isMoving);

    if (moveHorizontal < 0)
    {
        spriteRenderer.flipX = true;
    }
    else if (moveHorizontal > 0)
    {
        spriteRenderer.flipX = false;
    }
}



    public void TakeDamage(int damage)
    {
        currentHeath -= damage;
        Debug.Log("Player Take Dame");
        if (currentHeath <= 0)
        {
            
            Die();
            GameOverMenu();
        }
    }


    void Die()
    {
       
        
            Debug.Log(" Died");
            isDead = true; 

            animator.SetTrigger("isDead");
            animator.SetTrigger("isBuried");

            this.enabled = false;

            myObject.GetComponent<BoxCollider2D>().enabled = false;        
    }

    void DestroyObject()
    {
        if (myObject != null)
        {
            Destroy(myObject);
        }
    }

    public void GameOverMenu()
    {
        StartCoroutine(MoveGameOverMenu());
    }
    IEnumerator MoveGameOverMenu()
    {
        float duration = 0.7f;
        float elapsedTime = 0f;
        Vector2 startPosition = menuImage.anchoredPosition;
        Vector2 targetPosition = new Vector2(startPosition.x, 0);

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            menuImage.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / duration);
            yield return null;
        }

        menuImage.anchoredPosition = targetPosition;
    }








}