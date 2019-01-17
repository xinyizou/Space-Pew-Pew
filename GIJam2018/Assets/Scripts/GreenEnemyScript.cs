using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemyScript : MonoBehaviour {

	void Start(){
        
    }
	
	void Update(){
        
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        if((PlayerMovement.pierceCount + PlayerMovement.spreadCount + PlayerMovement.bombCount)<9)
        PlayerMovement.spreadCount++;
    }
}
