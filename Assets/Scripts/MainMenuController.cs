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


	// INSTRUCTIONS
	public Button instructionsButton;
	public Canvas instructionsCanvas;

	public Button instructionsButton1;
	public Canvas instructionsCanvas1;

	public Button instructionsButton2;
	public Canvas instructionsCanvas2;

	// Initialization
	void Start () 
	{
		startButton = startButton.GetComponent<Button> ();
		optionsButton = optionsButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
		backButton = backButton.GetComponent<Button> ();
		startMenu = startMenu.GetComponent<Canvas> ();
		optionsMenu = optionsMenu.GetComponent<Canvas> ();
		exitMenu = exitMenu.GetComponent<Canvas> ();
		creditsCanvas = creditsCanvas.GetComponent<Canvas> ();
		startMenu.enabled = false;
		optionsMenu.enabled = false;
		exitMenu.enabled = false;
		creditsCanvas.enabled = false;

		// INSTRUCTIONS
		instructionsButton = instructionsButton.GetComponent<Button> ();
		instructionsCanvas = instructionsCanvas.GetComponent<Canvas> ();
		instructionsCanvas.enabled = false;

		instructionsButton1 = instructionsButton1.GetComponent<Button> ();
		instructionsCanvas1 = instructionsCanvas1.GetComponent<Canvas> ();
		instructionsCanvas1.enabled = false;

		instructionsButton2 = instructionsButton2.GetComponent<Button> ();
		instructionsCanvas2 = instructionsCanvas2.GetComponent<Canvas> ();
		instructionsCanvas2.enabled = false;
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
		instructionsCanvas1.enabled = false;
		instructionsCanvas2.enabled = false;

	}

	// FUNCTIONS FOR INSTRUCTIONS PAGES -----------

	public void instructionsPress()
	{
		startMenu.enabled = false;
		optionsMenu.enabled = false;
		exitMenu.enabled = false;
		creditsCanvas.enabled = false;
		instructionsCanvas.enabled = true;
	}

	public void nextInstruction1(){
		//backPress ();
		instructionsCanvas.enabled = false;
		instructionsCanvas.enabled = false;
		instructionsCanvas1.enabled = true;
	}

	public void nextInstruction2(){
		instructionsCanvas.enabled = false;
		instructionsCanvas1.enabled = false;
		instructionsCanvas2.enabled = true;
	}

	// END FUNCTIONS FOR INSTRUCTIONS PAGES -----------


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
