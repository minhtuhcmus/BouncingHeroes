﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "3CSettings", menuName = "3CSettings", order = 1)]
[ExecuteInEditMode]
public class _3CSettings : ScriptableObject {
    [HideInInspector]
    public int screenWidth = 750;
    [HideInInspector]
    public int screenHeight = 1334;

    [Header("Safe Zone")]
    [SerializeField]
    public float safeZoneTop = 100.0f;
    [SerializeField]
    public float safeZoneBottom = 200.0f;

    [Header("Character Default Position X")]
    [SerializeField]
    public float charDefaultX = -0.507f;

    [Header("Character Default Position Y")]
    [SerializeField]
    public float charDefaultY = 0.283f;
    

    [Header("Max Distance")]
    [SerializeField]
    public float maxDistance = 300f;

     [Header("Arrow Scale Speed")]
    [SerializeField]
    public float arrowScaleSpeed = 0.25f;

    [Header("Max Force")]
    [SerializeField]
    public float maxForce = 300f;

    public float distancePerPart;

    [Header("Force Parts")]
    [SerializeField]
    public List<float> parts = new List<float>();

    [Header("Time Reach Full Force")]
    [SerializeField]
    public float reachFullForceTime = 5.0f;

    [Header("Minimum Distance Percent From Last Parts")]
    [SerializeField]
    public float minimumDistancePercent = 0.2f;

    [Header("First Part Percent From Player Force")]
    [SerializeField]
    public float firstPartPercentPlayerForce = 0.3f;

    [Header("Time Percent Reach First Part")]
    [SerializeField]
    public float timePercentFirstPart = 0.2f;

    [Header("Second Part Percent From Player Force")]
    [SerializeField]
    public float secondPartPercentPlayerForce = 0.7f;

    [Header("Time Percent Reach Second Part")]
    [SerializeField]
    public float timePercentSecondPart = 0.8f;

    [Header("Time Reach 0")]
    [SerializeField]
    public float timeReach0 = 3f;

    [Header("Arrow Max Scale")]
    [SerializeField]
    public float arrowMaxScale = 0.650f;


    [Header("Arrow Origin Scale X")]
    [SerializeField]
    public float arrowOriScaleX = 0.0f;

    [Header("Arrow Origin Scale Y")]
    [SerializeField]
    public float arrowOriScaleY = 0.0f;
    // Use this for initialization
    void Start () {
		// screenWidth = Screen.width;
		// screenHeight = Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnValidate()
    {
        Debug.Log("a");
        float size = parts.Count;
        float percentPerPart = 100.0f / size;
        for (int i = 0; i < size; i++)
        {
            parts[i] = i * percentPerPart + percentPerPart;
           
        }
        distancePerPart = maxDistance / size;
    }
}
