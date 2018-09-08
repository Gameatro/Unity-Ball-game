using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			Playercontroller pc;
			if (pc = other.GetComponent<Playercontroller> ())
				pc.Damage (-10);
		}
	}
}

