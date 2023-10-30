using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameModeUI : MonoBehaviour
{   
    private GameModeManager gameModeManager;

    private HelixController helixController;

    public Button normalButton;
    public Button timeTrialButton;
    public Button survivalButton;
    public GameObject menu;

    void Awake(){
        helixController=GameObject.Find("Helix").GetComponent<HelixController>();
        gameModeManager=GameObject.Find("GameModeManager").GetComponent<GameModeManager>();
        normalButton.onClick.AddListener(()=>ChangeGameMode("Normal"));
        timeTrialButton.onClick.AddListener(()=>ChangeGameMode("Timetrial"));
        survivalButton.onClick.AddListener(()=>ChangeGameMode("Survival"));
    }
    public void ChangeGameMode(string mode){
        switch(mode){
            case "Normal":
                //SceneManager.LoadScene("Main");
                gameModeManager.currentGameMode=GameModeManager.GameMode.Normal;
                helixController.isGameActive=true;
                GameObject.Find("TextScore").SetActive(true);
                GameObject.Find("TextBest").SetActive(true);
                
                break;
            case "Timetrial":
                //SceneManager.LoadScene("Main");
                gameModeManager.currentGameMode=GameModeManager.GameMode.Timetrial;
                helixController.isGameActive=true;
                GameObject.Find("TextScore").SetActive(true);
                GameObject.Find("TextBest").SetActive(true);
                
                break;
            case "Survival":
                //SceneManager.LoadScene("Main");
                gameModeManager.currentGameMode=GameModeManager.GameMode.Survival;
                helixController.isGameActive=true;
                GameObject.Find("TextScore").SetActive(true);
                GameObject.Find("TextBest").SetActive(true);
                
                break;
            default:
                break;
        }
    }
    void Update(){
        if(!helixController.isGameActive){
            menu.gameObject.SetActive(true);
            
            //GameObject.Find("timeText").SetActive(false);
        }
        if(helixController.isGameActive){
            menu.gameObject.SetActive(false);
            
        }
    }

    
    
}
