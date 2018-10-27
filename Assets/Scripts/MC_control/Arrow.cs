using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	public SpriteRenderer m_arrow;
	public _3CSettings settings;
	public float m_fPreviousDistance = 0.0f;
	public float m_yScalePerSec = 0.1f;
	// Use this for initialization
	void Start () {
		m_arrow = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//BUG : WRONG CALCULATION - ARROW SCALE NOT LIKE EXPECTED
	public void Scale(float fDistance, int iForcePart){
		if(fDistance > m_fPreviousDistance){
			if(m_arrow.transform.localScale.y < settings.arrowMaxScale){
				m_arrow.transform.localScale += new Vector3(0, 0.1f, 0);
			}
		}
		else if(fDistance < m_fPreviousDistance){
			if(m_arrow.transform.localScale.y > 0){
				m_arrow.transform.localScale -= new Vector3(0, 0.1f, 0);
			}
		}
		m_fPreviousDistance = fDistance;
		ChangeColor(iForcePart);
	}

	public void ChangeColor(int iForcePart){
		if(iForcePart < settings.parts.Count / 3.0f){
			m_arrow.color = Color.green;
		}
		else if(iForcePart > settings.parts.Count / 3.0f && iForcePart < settings.parts.Count / 2.0f){
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
