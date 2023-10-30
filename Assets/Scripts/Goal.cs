using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{   private HelixController helixController;
    // Start is called before the first frame update
    void Start()
    {
        helixController=GameObject.Find("Helix").GetComponent<HelixController>();
    }
    void OnCollisionEnter(Collision collision){
        if(helixController.isGameActive){
            GameManager.singleton.NextLevel();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
