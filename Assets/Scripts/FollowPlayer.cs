using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //set the values in the inspector
    public Transform target; //drag and stop player object in the inspector
    private bool isFacingRight = true;
    public float within_range;
    public float speed;

    Animator animator;
    bool activated = false;
    
    void Start() {
        animator = GetComponent<Animator>();
    }

    private void flipSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 transformScale = transform.localScale;
        transformScale.x *= -1;
        transform.localScale = transformScale;
        foreach (Transform child in transform){
            if (child.gameObject.name != "bossOutline") {
                Vector3 childScale = child.transform.localScale;
                childScale.x *= -1;
                child.transform.localScale = childScale;
            }
        }
    }

    public void Update() {
        //get the distance between the player and enemy (this object)
        float dist = Vector2.Distance(target.position, transform.position);
        //check if it is within the range you set
        if(dist <= within_range) {
            if (gameObject.tag == "Boss") {
                if (activated == false) {
                    StartCoroutine(Activate());
                    // animator.SetTrigger("activate");
                    // activated = true;
                } 
            }
            if (gameObject.tag == "BigBoss") {
                animator.SetTrigger("run");
                Animator outline = transform.GetChild(0).gameObject.GetComponent<Animator>();
                outline.SetTrigger("run");
            }
            //move to target(player) 
            if (gameObject.tag != "Boss" || activated) {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed);      
                if(target.position.x > transform.position.x && !isFacingRight) //if the target is to the right of enemy and the enemy is not facing right
                    flipSprite();
                if(target.position.x < transform.position.x && isFacingRight)
                    flipSprite();
            }
        }
        else {
            animator.SetTrigger("idle");
            activated = false;
            if (gameObject.tag == "BigBoss") {
                Animator outline = transform.GetChild(0).gameObject.GetComponent<Animator>();
                outline.SetTrigger("idle");
            }
        }
    }

    IEnumerator Activate()
    {
        animator.SetTrigger("activate");
        float animLength = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        yield return new WaitForSeconds(animLength);
        GetComponent<EnemyController>().setInvincibility(false);        
        activated = true;

    }

}
