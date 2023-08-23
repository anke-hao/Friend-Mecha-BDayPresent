using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    Animator door_1st_half;
    Animator door_2nd_half;

    // Start is called before the first frame update
    void Start()
    {
        door_1st_half  = transform.GetChild(0).gameObject.GetComponent<Animator>();
        door_2nd_half  = transform.GetChild(1).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D (Collider2D other) {
        PlayerController player = other.GetComponent<PlayerController>();
        if(player != null) {
            StartCoroutine(nextScene());
        }
    }

    IEnumerator nextScene() {
        yield return new WaitForSeconds(5);
        door_1st_half.SetTrigger("open");
        door_2nd_half.SetTrigger("open");
        float animLength = door_1st_half.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        yield return new WaitForSeconds(2);
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "FallQuarter") {
            SceneManager.LoadSceneAsync("WinterQuarter", LoadSceneMode.Single);
        } else if (scene.name == "WinterQuarter") {
            SceneManager.LoadSceneAsync("SpringQuarter", LoadSceneMode.Single);
        } else if (scene.name == "SpringQuarter") {
            SceneManager.LoadSceneAsync("EndScene", LoadSceneMode.Single);
            
        }
    }
}
