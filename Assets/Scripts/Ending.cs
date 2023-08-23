using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    GameObject player;
    GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ending());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ending()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        
        yield return new WaitForSeconds(3);
        player.GetComponent<Animator>().Play("friendLeave");
        player2.GetComponent<Animator>().Play("ankeLeave");
        float animLength = player.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;
        yield return new WaitForSeconds(0.5f);
        player.SetActive(false);
        player2.SetActive(false);
    }
}
