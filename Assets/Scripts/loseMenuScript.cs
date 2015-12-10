using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class loseMenuScript : MonoBehaviour {
	public Button quitButton;
	public Button retryButton;
    public AudioSource bgMusicForOff;
	private SimplePlatformController controller;

	// Use this for initialization
	void Start () {
		quitButton = quitButton.GetComponent<Button> ();
		retryButton = retryButton.GetComponent<Button> ();
        bgMusicForOff = bgMusicForOff.gameObject.GetComponent<AudioSource>();
        bgMusicForOff.enabled = false;
		GameObject controllerObject = GameObject.FindWithTag("Player");
		controller = controllerObject.GetComponent<SimplePlatformController> ();
	}

	public void quitPress()
	{
        Application.LoadLevel(0);
	}

	public void retryPress()
	{
		Application.LoadLevel(controller.level_no);
	}
}
