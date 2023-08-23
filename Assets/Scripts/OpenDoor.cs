using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    bool doorOpen = false;
    Animator animator;
    public int enemies;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other) {
        PlayerController player = other.GetComponent<PlayerController>();
        if(player != null && enemies <= 0 && doorOpen == false) {
            animator.SetTrigger("open");
            doorOpen = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
