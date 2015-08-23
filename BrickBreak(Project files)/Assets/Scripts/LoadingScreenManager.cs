using UnityEngine;
using System.Collections;

public class LoadingScreenManager : MonoBehaviour {
	public Animator animPanel1;
	public Animator animPanel2;

	float totalTime=0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Application.LoadLevel("scene03");
		}
		totalTime += Time.deltaTime;
		if (totalTime > 2.5) {
			animPanel1.SetBool("animStart",true);
			animPanel2.SetBool("animStart1",true);
		}
		if (totalTime > 5) {
			Application.LoadLevel("scene03");
		}
	}
}
