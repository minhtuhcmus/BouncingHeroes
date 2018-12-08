using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkKeyRandom : MonoBehaviour {

	public static checkKeyRandom instance;
	public BoxCollider2D[] allCollider;
		
	void Start () {
		allCollider = GetComponentsInChildren<BoxCollider2D>();
		//Debug.Log("test");
		//checkKey( new Vector3( -2.7f,0.5f,0f));
	}
	void Awake()
	{
		if (instance == null)
			instance = this;
	}
	
	public bool checkKey(Vector3 checkPoint){
		//Debug.Log("1 test" + allCollider.Length);
		foreach (BoxCollider2D e in allCollider){
			//Debug.Log("2 test");
			if (e.bounds.Contains( checkPoint))
			{
				Debug.Log("key true +++++++++");
				//TransformPoint(Vector3.zero));
				return false;
			}
		}
		Debug.Log(" key faile--------");
		return true;
	}
}
