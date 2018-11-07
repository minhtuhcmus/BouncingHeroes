using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpTransition : MonoBehaviour {
	// Use this for initialization
	public static LevelUpTransition instance;
	void Start () {

	}
	
	// Update is called once per frame
	//NOTE : NEED TO FIND THE WAY TO DESTROY COMPLETED MAP
	void Update () {
		if(door.instance.isDestroyed){
			Vector3 startPosition = gameObject.transform.position;
			Vector3 endPosition = new Vector3(gameObject.transform.position.x, -15);
			gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, 0.01f);
		}
	}
	
	void Awake(){
		if (instance == null)
			instance = this;
	}
}
