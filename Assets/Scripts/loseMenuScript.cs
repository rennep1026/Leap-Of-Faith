using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class loseMenuScript : MonoBehaviour {
	public Button quitButton;
	public Button retryButton;
	// Use this for initialization
	void Start () {
		quitButton = quitButton.GetComponent<Button> ();
		retryButton = retryButton.GetComponent<Button> ();
	}

	public void quitPress()
	{
		Application.LoadLevel(0);
	}

	public void retryPress()
	{
		Application.LoadLevel(1);
	}
}
