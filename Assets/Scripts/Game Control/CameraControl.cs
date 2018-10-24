using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	public static CameraControl instance;

	void Awake()
	{
		if (instance == null)
			instance = this;
	}
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void ZoomOut(){
		this.GetComponent<Camera>().orthographicSize += 1;
	}

	public void ZoomBack(){
		this.GetComponent<Camera>().orthographicSize = 5;
	}
}
