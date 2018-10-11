using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour {
    private float minY = 1000;
    private float maxY = 2000;
    private float range = 200;
    public int side = 0;
    private bool isEnable = false;

    public _3CSettings settings;
    public RaycastHit2D hit;

    private bool isRunToA = false;
    private Vector3 pos_A;
    private Vector3 pos_B;
    private float speed = 0.5f;


    public void intit(float minY, float maxY, float range, int side)
    {
        float worldToPixels = ((Screen.height / 2.0f) / Camera.main.orthographicSize);
        if(side == 0) {
            side -= 1;
        }

        this.minY = minY;
        this.maxY = maxY;
        this.side = side;
        this.range = range;

        float safeZone_Top = settings.screenHeight - settings.safeZoneTop;
        float safeZone_Bottom = settings.safeZoneBottom;

        if(maxY + range / 2 > safeZone_Top) {
            maxY = safeZone_Top - range / 2;
            if(maxY < minY) {
                minY = maxY;
            }
        }

        if(minY - range / 2 < safeZone_Bottom) {
            minY = safeZone_Bottom + range / 2;
            if(minY > maxY) {
                maxY = minY;
            }
        }

        Vector3 position_Random = new Vector3((side * settings.screenWidth / 2) / worldToPixels, (Random.Range(minY, maxY) - settings.screenHeight / 2) / worldToPixels, 0.0f);
        pos_A = position_Random - new Vector3(0, range / worldToPixels / 2, 0);
        pos_B = position_Random + new Vector3(0, range / worldToPixels / 2, 0);
        Debug.Log("position:" + position_Random);
        Debug.Log(pos_A);
        Debug.Log(pos_B);

        if (Random.Range(0, 2) == 0)
        {
            transform.position = pos_B;
            StartCoroutine(MoveToA());
        }
        else
        {
            transform.position = pos_A;
            StartCoroutine(MoveToB());
        }

        setEnable(true);
    }

    public void setEnable(bool isEnable)
    {
        this.isEnable = isEnable;
    }

    // Use this for initialization
    void Awake () {
        transform.position = new Vector3(5000, 5000, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (isEnable == false) return;
        
        transform.Rotate(new Vector3(0.0f,0.0f,2.0f), 3600.0f * Time.deltaTime);
		if(isRunToA)
        {
            //Debug.LogWarning("MoveToA");
            int layer_Mark = 1 << LayerMask.NameToLayer("Wall");
            if(hit = Physics2D.Raycast(new Vector2(0, transform.position.y), new Vector2(this.side, 0), 10, layer_Mark)) {
                // Debug.Log(hit.transform.name);
                transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x, pos_A.y, pos_A.z), speed * Time.deltaTime);
                transform.position = new Vector2(hit.point.x, transform.position.y);
            }
        }
        else
        {
            //Debug.LogWarning("MoveToB");
            int layer_Mark = 1 << LayerMask.NameToLayer("Wall");
            if(hit = Physics2D.Raycast(new Vector2(0, transform.position.y), new Vector2(this.side, 0), 10, layer_Mark)) {
                // Debug.Log(hit.transform.name);
                transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x, pos_B.y, pos_B.z), speed * Time.deltaTime);
                transform.position = new Vector2(hit.point.x, transform.position.y);
            }
        }
    }

    public IEnumerator MoveToA()
    {
        isRunToA = true;
        //Debug.LogWarning("MoveToA");
        yield return new WaitForSeconds(speed * 6);
        StartCoroutine(MoveToB());
    }

    public IEnumerator MoveToB()
    {
        isRunToA = false;
        //Debug.LogWarning("MoveToB");
        yield return new WaitForSeconds(speed * 6);
        StartCoroutine(MoveToA());
    }
}
