using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;

    Rigidbody2D rigidbody2d;
    float horizontal; 
    float vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);
    private bool isFacingRight = true;

    public GameObject projectilePrefab;

   // Start is called before the first frame update
   void Start()
   {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
   }

   // Update is called once per frame
   void Update()
   {
       if(name == "Player") {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            if(Input.GetKeyDown(KeyCode.C))
            {
                Shoot();
            }
       } else if (name == "Anke") {
            if(Input.anyKey) {
                if(Input.GetKey(KeyCode.I)) {
                    vertical = speed;
                }
                if(Input.GetKey(KeyCode.K)) {
                    vertical = -speed;
                }
                if(Input.GetKey(KeyCode.J)) {
                    horizontal = -speed;
                }
                if(Input.GetKey(KeyCode.L)) {
                    horizontal = speed;
                }
                if(Input.GetKeyDown(KeyCode.N))
                {
                    Shoot();
                }
            } else {
                horizontal = 0f;
                vertical = 0f;
            }
       }   
   }

   private void flipSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 transformScale = transform.localScale;
        transformScale.x *= -1;
        transform.localScale = transformScale;
        foreach (Transform child in transform){
            Vector3 childScale = child.transform.localScale;
            childScale.x *= -1;
            child.transform.localScale = childScale;
        }
    }

   void FixedUpdate()
    {
        Vector2 move = new Vector2(horizontal, vertical);
        float moveFactor = horizontal * Time.fixedDeltaTime;

        if (moveFactor > 0 && !isFacingRight)    flipSprite();
        else if(moveFactor < 0 && isFacingRight) flipSprite();
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
                
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    void Shoot()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Shoot(lookDirection, 300);

        animator.SetTrigger("Shoot");
    }
}
