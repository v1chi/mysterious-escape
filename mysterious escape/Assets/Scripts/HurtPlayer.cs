using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HurtPlayer : MonoBehaviour
{
    private bool reloading;
    private HealthManager healthMan;
    private float waitToHurt = 1f;
    private bool isTouching;
    [SerializeField]
    private int damageToGive= 10;

    void Start()
    {
        healthMan= FindObjectOfType<HealthManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
        /*if(reloading){
            waitToLoad-= Time.deltaTime;
            if( waitToLoad<= 0){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }*/
        

        if(isTouching){
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <=0){
                healthMan.HurtPlayer(damageToGive);
                waitToHurt =2f;

            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.tag=="Player"){
            //Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);
            //reloading= false;

        }
        
    }
    private void OnCollisionStay2D(Collision2D  other){
        isTouching= true;
    }
    private void OnCollisionExit2D(Collision2D other){
        if(other.collider.tag =="Player")
        isTouching = false;
        waitToHurt= 2f;
    }
}