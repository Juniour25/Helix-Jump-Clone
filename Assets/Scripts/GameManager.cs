using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{   public int best;
    public int score;
    public int currentStage=0;
    public static GameManager singleton;
    private GameModeManager gameModeManager;
    private HelixController helixController;
    private loadInterstitial loadInt;
    //private AdsManager adsManager;
    //private LeaderBoard leaderboard;
    

    public float timer=60f;
    public Text timerText;
    // Start is called before the first frame update
    void Awake()
    {   
        if(singleton==null){
            singleton=this;
        }
        else if(singleton !=this){
            Destroy(gameObject);
        }
        best=PlayerPrefs.GetInt("HighScore");
        helixController=GameObject.Find("Helix").GetComponent<HelixController>();
        gameModeManager=GameObject.Find("GameModeManager").GetComponent<GameModeManager>();
        loadInt=GameObject.Find("AdsManager").GetComponent<loadInterstitial>();
        //adsManager=GameObject.Find("AdsManager").GetComponent<AdsManager>();
        //leaderboard=GameObject.Find("UI").GetComponent<LeaderBoard>();
        //string playerName=leaderboard.playerNameInput.text;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameModeManager!=null && gameModeManager.currentGameMode==GameModeManager.GameMode.Timetrial && helixController.isGameActive){
    
            timerText.gameObject.SetActive(true);
            timer-=Time.deltaTime;
            timerText.text=string.Format("Time:{0:00}",timer);
            if(timer<=0f){
                RestartLevel();
                timer=60f;
                
            }
        }
        else{
            timerText.gameObject.SetActive(false);
        }
        
    }
    public void NextLevel(){
        currentStage++;
        FindObjectOfType<BallController>().ResetBall();
        
        Debug.Log("Next Level Called");
        for(int i=0;i<helixController.allStages.Count;i++){
            if(currentStage==helixController.allStages.Count){
                helixController.isGameActive=false;
                loadInt.ShowAd();
                currentStage=0;
                //FindObjectOfType<HelixController>().LoadStage(currentStage);
                break;
            }
            else{
                FindObjectOfType<HelixController>().LoadStage(currentStage);
            }
        }
        
    }
    public void RestartLevel(){
        Debug.Log("Game Over");
        
        //adsManager.LoadInterstitial();
        //adsManager.ShowInterstitial();
        //singleton.score=0;
        FindObjectOfType<BallController>().ResetBall();
        //reload stage
        FindObjectOfType<HelixController>().LoadStage(currentStage);
        

    }
    public void AddScore(int scoreToAdd){
        score+=scoreToAdd;
        if(score>best){
            best=score;
            //store highscore in player prefs
            PlayerPrefs.SetInt("HighScore",score);
            //string playerName=leaderboard.playerNameInput.text;
            
            //leaderboard.AddScore(best, playerName);

        }
    }
}
