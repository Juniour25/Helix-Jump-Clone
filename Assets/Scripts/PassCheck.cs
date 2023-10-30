using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        GameManager.singleton.AddScore(2);
        FindObjectOfType<BallController>().perfectPass++;
        Debug.Log("Perfect Pass is Increased");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
