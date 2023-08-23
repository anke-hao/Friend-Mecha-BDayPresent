using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 5;
    Animator animator;
    bool invincible = false;
    GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (gameObject.tag == "Boss") {
            invincible = true;
        }
    }

    public void setInvincibility(bool value) {
        invincible = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() {
        
    }

    public void wasHit() {
        if (!invincible) {
            health--;
        }
        
        if (health == 0) {
            StartCoroutine(destroyTimer());
        }
    }
    
    IEnumerator destroyTimer()
    {
        door = GameObject.FindGameObjectWithTag("Door");
        door.GetComponent<OpenDoor>().enemies--;
        animator.SetTrigger("death");
        float animLength = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        float timeScale;
        if (gameObject.tag == "Boss" || gameObject.tag == "BigBoss") {
            timeScale = 1.2f;
        } else {
            timeScale = 2f;
        }
        yield return new WaitForSeconds(animLength * timeScale);
        Destroy(gameObject);
    }
}
