using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	//Vector3 iniPos;
	Vector3 newPos;

	LineRenderer BGLine;
	float startWidth;
	float endWidth;

	bool limitReached=false;

	int x=0;
	// Use this for initialization
	void Awake(){
		BGLine = GetComponent<LineRenderer> ();
		startWidth=-8.26f;
		endWidth = 2.75f;
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(x++%100==0)
			newPos=transform.position + Random.insideUnitSphere/4;
		transform.position = Vector3.Lerp (transform.position, newPos,Time.smoothDeltaTime);
		if (!limitReached) {
			startWidth -= 0.01f;
			endWidth += 0.01f;
		}
		else {
			startWidth += 0.01f;
			endWidth-=0.01f;
		}
		BGLine.SetWidth (Mathf.Clamp (startWidth, -10f, -8f), Mathf.Clamp(endWidth,2f,4f));
		if (startWidth < -10f)
			limitReached = true;
		else if(startWidth > -8f){
			limitReached = false;
		}
	}
}
