using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPart : MonoBehaviour
{   private GameModeManager gameModeManager;
    // Start is called before the first frame update
    void Start()
    {
        gameModeManager=GameObject.Find("GameModeManager").GetComponent<GameModeManager>();
    }
    private void OnEnable(){
        GetComponent<Renderer>().material.color=Color.black;
    }

    // Update is called once per frame
    public void HitDeathPart(){
        if(gameModeManager.currentGameMode!=GameModeManager.GameMode.Survival){
             GameManager.singleton.RestartLevel();
        }
       
    }
   
}
