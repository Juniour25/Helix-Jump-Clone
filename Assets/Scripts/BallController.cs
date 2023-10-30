using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{   private bool ignoreNextCollision;
    public Rigidbody rb;
    public float impulseForce=5f;
    private Vector3 startPos;
    public int perfectPass=0;
    public bool isSuperSpeedActive;
    public float health=100f;
    public Slider healthSlider;
    private GameModeManager gameModeManager;
    public AudioSource bounce;
    public GameObject splashPaint;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos=transform.position;
        gameModeManager=GameObject.Find("GameModeManager").GetComponent<GameModeManager>();
    }
    

    // Update is called once per frame
    
     public void OnCollisionEnter(Collision collision){
        if(gameModeManager.currentGameMode==GameModeManager.GameMode.Survival){
            healthSlider.gameObject.SetActive(true);
            if(collision.gameObject.GetComponent<DeathPart>()){
                health-=10f;
                healthSlider.value=health;
                if(health<=0f){
                    GameManager.singleton.RestartLevel();
                    health=100f;
                    healthSlider.value=health;
                }
            }
        }
        else{
            healthSlider.gameObject.SetActive(false);
            DeathPart deathPart=collision.transform.GetComponent<DeathPart>();
            if(deathPart){
                deathPart.HitDeathPart();
            }
        }
        if(ignoreNextCollision){
            return;
        }
        if(isSuperSpeedActive){
            if(!collision.transform.GetComponent<Goal>()){
                Destroy(collision.gameObject);
                //Destroy(collision.transform.parent.gameObject);
                Debug.Log("Destroyed Platform");
            }
        }
        else{
            DeathPart deathPart=collision.transform.GetComponent<DeathPart>();
            if(deathPart){
                deathPart.HitDeathPart();
            }
        }
        rb.velocity=Vector3.zero;
        bounce.Play();
        Vector3 splashPosition=transform.position+new Vector3(0,-0.1f,0);
        GameObject Splash=Instantiate(splashPaint,splashPosition,transform.rotation);
        Splash.transform.parent=collision.gameObject.transform;
        rb.AddForce(Vector3.up*impulseForce,ForceMode.Impulse);
        ignoreNextCollision=true;
        Invoke("AllowCollision",.2f);
        perfectPass=0;
        isSuperSpeedActive=false;
        
    }
    private void AllowCollision(){
        ignoreNextCollision=false;
    }
    public void ResetBall(){
        transform.position=startPos;
    }
    private void Update(){
        splashPaint.GetComponent<Renderer>().sharedMaterial.color=this.gameObject.GetComponent<Renderer>().material.color;
        if(perfectPass>=3 && !isSuperSpeedActive){
            isSuperSpeedActive=true;
            rb.AddForce(Vector3.down*10,ForceMode.Impulse);
        }
        
    }
        
    
    
}
