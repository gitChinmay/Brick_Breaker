using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	

	GameObject soundCarrier;

	public Button soundButton;
	static bool isSoundON=true;
	Image soundImg;
	
	AudioSource src;
	// Use this for initialization
	void Start () {
		soundCarrier=GameObject.Find("SoundCarrier");
		soundImg = soundButton.GetComponent<Image> ();
		if(isSoundON)
			soundImg.sprite = Resources.Load<Sprite> ("soundON");
		else
			soundImg.sprite = Resources.Load<Sprite> ("soundOFF");
		src = soundCarrier.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void onClickPlay(){
		Application.LoadLevel("scene02");
	}

	public void onClickSound(){
		if (isSoundON) {
			isSoundON = false;
			soundImg.sprite = Resources.Load<Sprite> ("soundOFF");
			src.Pause();
		} 
		else {
			isSoundON=true;
			soundImg.sprite = Resources.Load<Sprite> ("soundON");
			src.Play();
		}
	}
}
