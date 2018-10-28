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
		float width = Screen.width;
		float height = Screen.height;
		gameObject.GetComponent<Camera>().aspect = Mathf.RoundToInt(width/height * 100f) / 100f;
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

    public void Transition()
    {
        this.GetComponent<Camera>().transform.position += new Vector3(0, 10); 
    }
}
