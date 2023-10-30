using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeaderBoard : MonoBehaviour
{   
    [System.Serializable]
    public class PlayerScore{
        public string playerName;
        public int score;
    }
    public Text leaderboardText;
    public InputField playerNameInput;
    private List<PlayerScore> playerScores=new List<PlayerScore>();
    private const int maxScores=10;
    // Start is called before the first frame update
    void Start()
    {
        LoadScores();
        UpdateLeaderboardText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int score,string playerName){
        
        //string playerName=playerNameInput.text;
        PlayerScore playerScore=new PlayerScore{playerName=playerName,score=score};
        playerScores.Add(playerScore);
        playerScores.Sort((a,b)=>b.score.CompareTo(a.score));

        if(playerScores.Count>maxScores){
            playerScores.RemoveAt(maxScores);
        }
        SaveScores();
        UpdateLeaderboardText();
    }
    void LoadScores(){
        playerScores.Clear();
        for(int i=1;i<=maxScores;i++){
            string playerName=PlayerPrefs.GetString("PlayerName" +i,"");
            int score=PlayerPrefs.GetInt("HighScore" +i,0);

            if(!string.IsNullOrEmpty(playerName)&& score>0){
                playerScores.Add(new PlayerScore{playerName=playerName,score=score});

            }
        }
    }
    void SaveScores(){
        for(int i=1;i<=playerScores.Count;i++){
            PlayerPrefs.SetString("PlayerName" +i,playerScores[i-1].playerName);
            PlayerPrefs.SetInt("HighScore" +i,playerScores[i-1].score);
        }
        PlayerPrefs.Save();
    }
    void UpdateLeaderboardText(){
        leaderboardText.text="Leaderboard:\n";
        for(int i=0;i<playerScores.Count;i++){
            leaderboardText.text+=(i+1) + ". " + playerScores[i].playerName + ": " + playerScores[i].score + "\n";
        }
    }
}
