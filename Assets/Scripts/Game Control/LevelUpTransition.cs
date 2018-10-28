using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpTransition : MonoBehaviour {
	// Use this for initialization
	public static LevelUpTransition instance;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void Awake(){
		if (instance == null)
			instance = this;
	}

	public void LevelUp(){
		gameObject.transform.position = new Vector3(0, -15, 0);
	}
}
