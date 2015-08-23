using UnityEngine;
using System.Collections;

public class AndroidKeyConfig : MonoBehaviour {
	static bool keyCreated=false;
	// Use this for initialization
	void Start () {
		if (!keyCreated) {
			DontDestroyOnLoad (this.gameObject);
			keyCreated = true;
		}
		else {
			Destroy(this.gameObject);	
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(Application.loadedLevel==0){
				Application.Quit();
			}
			else if(Application.loadedLevel==2){
				Application.LoadLevel(0);
			}
		}
	}
}
