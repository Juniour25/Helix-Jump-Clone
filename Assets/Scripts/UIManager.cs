using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   [SerializeField] private Text textScore;
    [SerializeField] private Text textBest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   if(GameManager.singleton!=null){
        textBest.text="HighScore:"+GameManager.singleton.best;
        textScore.text="Score:"+GameManager.singleton.score;
    }
        
    }
}
