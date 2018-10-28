using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	public SpriteRenderer m_arrow;
	public _3CSettings settings;
	public float m_fPreviousDistance = 0.0f;
	public float m_fScalePerSec = 0.1f;

	// Use this for initialization
	void Start () {
		m_arrow = GetComponent<SpriteRenderer>();
		m_arrow.transform.localScale = new Vector3(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//BUG : WRONG CALCULATION - ARROW SCALE NOT LIKE EXPECTED
	public void Scale(float fDistance){
		float arrowScale = fDistance * settings.arrowScaleSpeed;
		// Debug.Log("[Minh] Max arrowScale:" + fDistance);
		if(arrowScale < settings.arrowMaxScale) {
			//Debug.Log("[Minh] arrowScale:" + arrowScale);
			m_arrow.transform.localScale = new Vector3(settings.arrowOriScaleX, arrowScale);
			ChangeColor(arrowScale);
		}
		else {
			m_arrow.transform.localScale = new Vector3(settings.arrowOriScaleX, settings.arrowMaxScale);
			ChangeColor(arrowScale);
		}
	}

	public void ChangeColor(float arrowScale){
		float eachPartOfDistance = settings.arrowMaxScale ;
		if(arrowScale < settings.arrowMaxScale * 0.5f){
			m_arrow.color = Color.green;
		}
		else if(arrowScale <  settings.arrowMaxScale * 0.75f){
			m_arrow.color = Color.yellow;
		}
		else {
			m_arrow.color = Color.red;
		}
	}

	public void ScaleBack(){
		m_arrow.transform.localScale = new Vector3(settings.arrowOriScaleX, settings.arrowOriScaleY);
		m_arrow.color = Color.white;
		m_fPreviousDistance = 0.0f;
	}
}
