using UnityEngine;
using System.Collections;

public class KeepMusicAlive : MonoBehaviour {

	static bool musicAliveCreated=false;
	AudioClip[] audios;
	public AudioSource src;
	// Use this for initialization
	void Start () {
		if (!musicAliveCreated) {
			DontDestroyOnLoad (this.gameObject);
			musicAliveCreated = true;
			audios=Resources.LoadAll<AudioClip>("Music");
			src =GetComponent<AudioSource> ();
			src.clip = audios [Random.Range(0,3)];
			src.Play ();
		}
		else {
			Destroy(this.gameObject);	
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
