﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour {

    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) 
	{	
		
		if (other.gameObject.CompareTag ("Sword"))
        {
           
            DragonAttack.EnemyHealth -= 0.01f;

        }
			
		else if (other.gameObject.CompareTag ("PlayerBeam"))
			DragonAttack.EnemyHealth -= 0.01f;
	}


}
