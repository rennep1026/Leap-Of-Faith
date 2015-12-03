using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuController : MonoBehaviour 
{
	public Button startButton;
	public Button optionsButton;
	public Button exitButton;
	public Button backButton;
	public Canvas startMenu;
	public Canvas optionsMenu;
	public Canvas exitMenu;
	public Canvas creditsCanvas;

	public Button instructionsButton;
	public Canvas instructionsCanvas;


	// Initialization
	void Start () 
	{
		startButton = startButton.GetComponent<Button> ();
		optionsButton = optionsButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
		backButton = backButton.GetComponent<Button> ();

		// -- added by Ciarra 12/3/15, revert if broken
		instructionsButton = instructionsButton.GetComponent<Button> ();
		instructionsCanvas = instructionsCanvas.GetComponent<Canvas> ();
		instructionsCanvas.enabled = false;
		// -- end of add by Ciarra 12/3/15

		startMenu = startMenu.GetComponent<Canvas> ();
		optionsMenu = optionsMenu.GetComponent<Canvas> ();
		exitMenu = exitMenu.GetComponent<Canvas> ();
		creditsCanvas = creditsCanvas.GetComponent<Canvas> ();
		startMenu.enabled = false;
		optionsMenu.enabled = false;
		exitMenu.enabled = false;
		creditsCanvas.enabled = false;
	}

	public void startPress()
	{
		startMenu.enabled = true;
		optionsMenu.enabled = false;
		exitMenu.enabled = false;
		creditsCanvas.enabled = false;
	}

	public void optionsPress()
	{
		startMenu.enabled = false;
		optionsMenu.enabled = true;
		exitMenu.enabled = false;
		creditsCanvas.enabled = false;
	}

	public void exitPress()
	{
		startMenu.enabled = false;
		optionsMenu.enabled = false;
		exitMenu.enabled = true;
		creditsCanvas.enabled = false;
	}

	public void backPress()
	{
		startMenu.enabled = false;
		optionsMenu.enabled = false;
		exitMenu.enabled = false;
		creditsCanvas.enabled = false;
		instructionsCanvas.enabled = false;
	}

	public void instructionsPress()
	{
		startMenu.enabled = false;
		optionsMenu.enabled = false;
		exitMenu.enabled = false;
		creditsCanvas.enabled = false;
		instructionsCanvas.enabled = true;
	}


	public void StartLevel()
	{
		Application.LoadLevel (1);
	}

	public void ShowCredits()
	{
		creditsCanvas.enabled = true;
	}

	public void ExitGame()
	{
		Application.Quit ();
	}
}
