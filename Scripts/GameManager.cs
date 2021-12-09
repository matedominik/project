using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private int totalRedInHouse, totalGreenInHouse, totalBlueInHouse, totalYellowInHouse;

	public GameObject frameRed, frameGreen, frameYellow, frameBlue;
	public GameObject redPlayerI_Border,redPlayerII_Border,redPlayerIII_Border,redPlayerIV_Border;
	public GameObject greenPlayerI_Border,greenPlayerII_Border,greenPlayerIII_Border,greenPlayerIV_Border;
	public GameObject bluePlayerI_Border,bluePlayerII_Border,bluePlayerIII_Border,bluePlayerIV_Border;
	public GameObject yellowPlayerI_Border,yellowPlayerII_Border,yellowPlayerIII_Border,yellowPlayerIV_Border;

	public Vector3 redPlayerI_Pos,redPlayerII_Pos,redPlayerIII_Pos,redPlayerIV_Pos;
	public Vector3 greenPlayerI_Pos,greenPlayerII_Pos,greenPlayerIII_Pos,greenPlayerIV_Pos;
	public Vector3 bluePlayerI_Pos,bluePlayerII_Pos,bluePlayerIII_Pos,bluePlayerIV_Pos;
	public Vector3 yellowPlayerI_Pos,yellowPlayerII_Pos,yellowPlayerIII_Pos,yellowPlayerIV_Pos;

	public Transform diceRoll;
	public Transform redDiceRollPos, greenDiceRollPos, blueDiceRollPos, yellowDiceRollPos;

	public Button RedPlayerI_Button, RedPlayerII_Button,RedPlayerIII_Button, RedPlayerIV_Button;
	public Button GreenPlayerI_Button, GreenPlayerII_Button,GreenPlayerIII_Button, GreenPlayerIV_Button;
	public Button BluePlayerI_Button, BluePlayerII_Button,BluePlayerIII_Button, BluePlayerIV_Button;
	public Button YellowPlayerI_Button, YellowPlayerII_Button,YellowPlayerIII_Button, YellowPlayerIV_Button;

	public GameObject blueScreen, greenScreen, redScreen, yellowScreen;

	private string playerTurn = "RED";
	private string currentPlayer = "none";
	private string currentPlayerName = "none";

	public GameObject redPlayerI,redPlayerII,redPlayerIII,redPlayerIV;
	public GameObject greenPlayerI,greenPlayerII,greenPlayerIII,greenPlayerIV;
	public GameObject bluePlayerI,bluePlayerII,bluePlayerIII,bluePlayerIV;
	public GameObject yellowPlayerI,yellowPlayerII,yellowPlayerIII,yellowPlayerIV;

	private int redPlayerI_Steps,redPlayerII_Steps,redPlayerIII_Steps,redPlayerIV_Steps;
	private int greenPlayerI_Steps,greenPlayerII_Steps,greenPlayerIII_Steps,greenPlayerIV_Steps;
	private int bluePlayerI_Steps,bluePlayerII_Steps,bluePlayerIII_Steps,bluePlayerIV_Steps;
	private int yellowPlayerI_Steps,yellowPlayerII_Steps,yellowPlayerIII_Steps,yellowPlayerIV_Steps;

	private int selectDiceNumAnimation;

	public GameObject dice1_Roll_Animation;
	public GameObject dice2_Roll_Animation;
	public GameObject dice3_Roll_Animation;
	public GameObject dice4_Roll_Animation;
	public GameObject dice5_Roll_Animation;
	public GameObject dice6_Roll_Animation;

	public List<GameObject> redMovementBlocks = new List<GameObject>();
	public List<GameObject> greenMovementBlocks = new List<GameObject>();
	public List<GameObject> yellowMovementBlocks = new List<GameObject>();
	public List<GameObject> blueMovementBlocks = new List<GameObject>();

	public GameObject confirmScreen;
	public GameObject gameCompletedScreen;

	private System.Random randomNo;

	public Button DiceRollButton;

	public void ExitMethod()
	{
		confirmScreen.SetActive (true);
	}

	public void noMethod()
	{
		confirmScreen.SetActive (false);
	}

	public void yesMethod()
	{
		SceneManager.LoadScene ("mainmenu");
	}

	IEnumerator GameCompletedRoutine()
	{
		yield return new WaitForSeconds (1.5f);
		gameCompletedScreen.SetActive (true);
	}

	public void yesGameCompleted()
	{
		SceneManager.LoadScene ("gameplay");
	}

	public void noGameCompleted()
	{
		SceneManager.LoadScene ("mainmenu");
	}

	private void InitializeDice()
	{
		DiceRollButton.interactable = true;

		dice1_Roll_Animation.SetActive (false);
		dice2_Roll_Animation.SetActive (false);
		dice3_Roll_Animation.SetActive (false);
		dice4_Roll_Animation.SetActive (false);
		dice5_Roll_Animation.SetActive (false);
		dice6_Roll_Animation.SetActive (false);

		switch (MainMenuManager.howManyPlayers) 
		{
		case 2:
			if (totalRedInHouse > 3) 
			{
				redScreen.SetActive (true);					
				StartCoroutine ("GameCompletedRoutine");
				playerTurn = "NONE";
			}

			if (totalGreenInHouse > 3) 
			{
				greenScreen.SetActive (true);
				StartCoroutine ("GameCompletedRoutine");
				playerTurn = "NONE";
			}
			break;

		case 3:
			if (totalRedInHouse > 3 && totalBlueInHouse < 4 && totalYellowInHouse < 4 && playerTurn == "RED") 
			{
				redScreen.SetActive (true);
				StartCoroutine ("GameCompletedRoutine");
				playerTurn = "NONE";
			}

			if (totalBlueInHouse > 3 && totalRedInHouse < 4 && totalYellowInHouse < 4 && playerTurn == "BLUE") 
			{
				blueScreen.SetActive (true);
				StartCoroutine ("GameCompletedRoutine");
				playerTurn = "NONE";
			}

			if (totalYellowInHouse > 3 && totalRedInHouse < 4 && totalBlueInHouse < 4 && playerTurn == "YELLOW") 
			{
				yellowScreen.SetActive (true);
				StartCoroutine ("GameCompletedRoutine");
				playerTurn = "NONE";				
			}
			break;

		case 4:
			
			if (totalRedInHouse > 3 && totalBlueInHouse < 4 && totalGreenInHouse < 4 && totalYellowInHouse < 4 && playerTurn == "RED") 
			{
				redScreen.SetActive (true);					
				StartCoroutine ("GameCompletedRoutine");
				playerTurn = "NONE";
			}

			if (totalBlueInHouse > 3 && totalRedInHouse < 4 && totalGreenInHouse < 4 && totalYellowInHouse < 4 && playerTurn == "BLUE") 
			{
				blueScreen.SetActive (true);
				StartCoroutine ("GameCompletedRoutine");
				playerTurn = "NONE";
			}

			if (totalGreenInHouse > 3 && totalRedInHouse < 4 && totalBlueInHouse < 4 && totalYellowInHouse < 4 && playerTurn == "GREEN") 
			{
				greenScreen.SetActive (true);					
				StartCoroutine ("GameCompletedRoutine");
				playerTurn = "NONE";
			}

			if (totalYellowInHouse > 3 && totalRedInHouse < 4 && totalBlueInHouse < 4 && totalGreenInHouse < 4 && playerTurn == "YELLOW") 
			{
				yellowScreen.SetActive (true);					
				StartCoroutine ("GameCompletedRoutine");
				playerTurn = "NONE";				
			}
			break;
		}

		if (currentPlayerName.Contains ("RED PLAYER")) 
		{
			if (currentPlayerName == "RED PLAYER I") {
				currentPlayer = RedPlayerI.redPlayerI_ColName;
			}
			if (currentPlayerName == "RED PLAYER II") {
				currentPlayer = RedPlayerII.redPlayerII_ColName;
			}
			if (currentPlayerName == "RED PLAYER III") {
				currentPlayer = RedPlayerIII.redPlayerIII_ColName;
			}
			if (currentPlayerName == "RED PLAYER IV") {
				currentPlayer = RedPlayerIV.redPlayerIV_ColName;
			}
		}

		if (currentPlayerName.Contains ("GREEN PLAYER")) 
		{
			if (currentPlayerName == "GREEN PLAYER I") {
				currentPlayer = GreenPlayerI.greenPlayerI_ColName;
			}
			if (currentPlayerName == "GREEN PLAYER II") {
				currentPlayer = GreenPlayerII.greenPlayerII_ColName;
			}
			if (currentPlayerName == "GREEN PLAYER III") {
				currentPlayer = GreenPlayerIII.greenPlayerIII_ColName;
			}
			if (currentPlayerName == "GREEN PLAYER IV") {
				currentPlayer = GreenPlayerIV.greenPlayerIV_ColName;
			}
		}

		if (currentPlayerName.Contains ("BLUE PLAYER")) 
		{
			if (currentPlayerName == "BLUE PLAYER I") {
				currentPlayer = BluePlayerI.bluePlayerI_ColName;
			}
			if (currentPlayerName == "BLUE PLAYER II") {
				currentPlayer = BluePlayerII.bluePlayerII_ColName;
			}
			if (currentPlayerName == "BLUE PLAYER III") {
				currentPlayer = BluePlayerIII.bluePlayerIII_ColName;
			}
			if (currentPlayerName == "BLUE PLAYER IV") {
				currentPlayer = BluePlayerIV.bluePlayerIV_ColName;
			}
		}

		if (currentPlayerName.Contains ("YELLOW PLAYER")) 
		{
			if (currentPlayerName == "YELLOW PLAYER I") {
				currentPlayer = YellowPlayerI.yellowPlayerI_ColName;
			}
			if (currentPlayerName == "YELLOW PLAYER II") {
				currentPlayer = YellowPlayerII.yellowPlayerII_ColName;
			}
			if (currentPlayerName == "YELLOW PLAYER III") {
				currentPlayer = YellowPlayerIII.yellowPlayerIII_ColName;
			}
			if (currentPlayerName == "YELLOW PLAYER IV") {
				currentPlayer = YellowPlayerIV.yellowPlayerIV_ColName;
			}
		}
		/*
		if (currentPlayerName != "none") {
			switch (MainMenuManager.howManyPlayers) {
			case 2:
				if (currentPlayerName.Contains ("RED PLAYER")) {
					if (currentPlayer == GreenPlayerI.greenPlayerI_ColName && (currentPlayer != "Star" && GreenPlayerI.greenPlayerI_ColName != "Star")) {
						greenPlayerI.transform.position = greenPlayerI_Pos;
						GreenPlayerI.greenPlayerI_ColName = "none";
						greenPlayerI_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == GreenPlayerII.greenPlayerII_ColName && (currentPlayer != "Star" && GreenPlayerII.greenPlayerII_ColName != "Star")) {
						greenPlayerII.transform.position = greenPlayerII_Pos;
						GreenPlayerII.greenPlayerII_ColName = "none";
						greenPlayerII_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == GreenPlayerIII.greenPlayerIII_ColName && (currentPlayer != "Star" && GreenPlayerIII.greenPlayerIII_ColName != "Star")) {
						greenPlayerIII.transform.position = greenPlayerIII_Pos;
						GreenPlayerIII.greenPlayerIII_ColName = "none";
						greenPlayerIII_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == GreenPlayerIV.greenPlayerIV_ColName && (currentPlayer != "Star" && GreenPlayerIV.greenPlayerIV_ColName != "Star")) {
						greenPlayerIV.transform.position = greenPlayerIV_Pos;
						GreenPlayerIV.greenPlayerIV_ColName = "none";
						greenPlayerIV_Steps = 0;
						playerTurn = "RED";
					}
				} 
				if (currentPlayerName.Contains ("GREEN PLAYER")) {
					if (currentPlayer == RedPlayerI.redPlayerI_ColName && (currentPlayer != "Star" && RedPlayerI.redPlayerI_ColName != "Star")) {
						redPlayerI.transform.position = redPlayerI_Pos;
						RedPlayerI.redPlayerI_ColName = "none";
						redPlayerI_Steps = 0;
						playerTurn = "GREEN";
					}
					if (currentPlayer == RedPlayerII.redPlayerII_ColName && (currentPlayer != "Star" && RedPlayerII.redPlayerII_ColName != "Star")) {
						redPlayerII.transform.position = redPlayerII_Pos;
						RedPlayerII.redPlayerII_ColName = "none";
						redPlayerII_Steps = 0;
						playerTurn = "GREEN";
					}
					if (currentPlayer == RedPlayerIII.redPlayerIII_ColName && (currentPlayer != "Star" && RedPlayerIII.redPlayerIII_ColName != "Star")) {
						redPlayerIII.transform.position = redPlayerIII_Pos;
						RedPlayerIII.redPlayerIII_ColName = "none";
						redPlayerIII_Steps = 0;
						playerTurn = "GREEN";
					}
					if (currentPlayer == RedPlayerIV.redPlayerIV_ColName && (currentPlayer != "Star" && RedPlayerIV.redPlayerIV_ColName != "Star")) {
						redPlayerIV.transform.position = redPlayerIV_Pos;
						RedPlayerIV.redPlayerIV_ColName = "none";
						redPlayerIV_Steps = 0;
						playerTurn = "GREEN";
					}
				}
				break;

			case 3:
				if (currentPlayerName.Contains ("RED PLAYER")) {
					if (currentPlayer == YellowPlayerI.yellowPlayerI_ColName && (currentPlayer != "Star" && YellowPlayerI.yellowPlayerI_ColName != "Star")) {
						yellowPlayerI.transform.position = yellowPlayerI_Pos;
						YellowPlayerI.yellowPlayerI_ColName = "none";
						yellowPlayerI_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == YellowPlayerII.yellowPlayerII_ColName && (currentPlayer != "Star" && YellowPlayerII.yellowPlayerII_ColName != "Star")) {
						yellowPlayerII.transform.position = yellowPlayerII_Pos;
						YellowPlayerII.yellowPlayerII_ColName = "none";
						yellowPlayerII_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == YellowPlayerIII.yellowPlayerIII_ColName && (currentPlayer != "Star" && YellowPlayerIII.yellowPlayerIII_ColName != "Star")) {
						yellowPlayerIII.transform.position = yellowPlayerIII_Pos;
						YellowPlayerIII.yellowPlayerIII_ColName = "none";
						yellowPlayerIII_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == YellowPlayerIV.yellowPlayerIV_ColName && (currentPlayer != "Star" && YellowPlayerIV.yellowPlayerIV_ColName != "Star")) {
						yellowPlayerIV.transform.position = yellowPlayerIV_Pos;
						YellowPlayerIV.yellowPlayerIV_ColName = "none";
						yellowPlayerIV_Steps = 0;
						playerTurn = "RED";
					}

					if (currentPlayer == BluePlayerI.bluePlayerI_ColName && (currentPlayer != "Star" && BluePlayerI.bluePlayerI_ColName != "Star")) {
						bluePlayerI.transform.position = bluePlayerI_Pos;
						BluePlayerI.bluePlayerI_ColName = "none";
						bluePlayerI_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == BluePlayerII.bluePlayerII_ColName && (currentPlayer != "Star" && BluePlayerII.bluePlayerII_ColName != "Star")) {
						bluePlayerII.transform.position = bluePlayerII_Pos;
						BluePlayerII.bluePlayerII_ColName = "none";
						bluePlayerII_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == BluePlayerIII.bluePlayerIII_ColName && (currentPlayer != "Star" && BluePlayerIII.bluePlayerIII_ColName != "Star")) {
						bluePlayerIII.transform.position = bluePlayerIII_Pos;
						BluePlayerIII.bluePlayerIII_ColName = "none";
						bluePlayerIII_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == BluePlayerIV.bluePlayerIV_ColName && (currentPlayer != "Star" && BluePlayerIV.bluePlayerIV_ColName != "Star")) {
						bluePlayerIV.transform.position = bluePlayerIV_Pos;
						BluePlayerIV.bluePlayerIV_ColName = "none";
						bluePlayerIV_Steps = 0;
						playerTurn = "RED";
					}
				}

				if (currentPlayerName.Contains ("YELLOW PLAYER")) {
					if (currentPlayer == RedPlayerI.redPlayerI_ColName && (currentPlayer != "Star" && RedPlayerI.redPlayerI_ColName != "Star")) {
						redPlayerI.transform.position = redPlayerI_Pos;
						RedPlayerI.redPlayerI_ColName = "none";
						redPlayerI_Steps = 0;
						playerTurn = "YELLOW";
					}
					if (currentPlayer == RedPlayerII.redPlayerII_ColName && (currentPlayer != "Star" && RedPlayerII.redPlayerII_ColName != "Star")) {
						redPlayerII.transform.position = redPlayerII_Pos;
						RedPlayerII.redPlayerII_ColName = "none";
						redPlayerII_Steps = 0;
						playerTurn = "YELLOW";
					}
					if (currentPlayer == RedPlayerIII.redPlayerIII_ColName && (currentPlayer != "Star" && RedPlayerIII.redPlayerIII_ColName != "Star")) {
						redPlayerIII.transform.position = redPlayerIII_Pos;
						RedPlayerIII.redPlayerIII_ColName = "none";
						redPlayerIII_Steps = 0;
						playerTurn = "YELLOW";
					}
					if (currentPlayer == RedPlayerIV.redPlayerIV_ColName && (currentPlayer != "Star" && RedPlayerIV.redPlayerIV_ColName != "Star")) {
						redPlayerIV.transform.position = redPlayerIV_Pos;
						RedPlayerIV.redPlayerIV_ColName = "none";
						redPlayerIV_Steps = 0;
						playerTurn = "YELLOW";
					}

					if (currentPlayer == BluePlayerI.bluePlayerI_ColName && (currentPlayer != "Star" && BluePlayerI.bluePlayerI_ColName != "Star")) {
						bluePlayerI.transform.position = bluePlayerI_Pos;
						BluePlayerI.bluePlayerI_ColName = "none";
						bluePlayerI_Steps = 0;
						playerTurn = "YELLOW";
					}
					if (currentPlayer == BluePlayerII.bluePlayerII_ColName && (currentPlayer != "Star" && BluePlayerII.bluePlayerII_ColName != "Star")) {
						bluePlayerII.transform.position = bluePlayerII_Pos;
						BluePlayerII.bluePlayerII_ColName = "none";
						bluePlayerII_Steps = 0;
						playerTurn = "YELLOW";
					}
					if (currentPlayer == BluePlayerIII.bluePlayerIII_ColName && (currentPlayer != "Star" && BluePlayerIII.bluePlayerIII_ColName != "Star")) {
						bluePlayerIII.transform.position = bluePlayerIII_Pos;
						BluePlayerIII.bluePlayerIII_ColName = "none";
						bluePlayerIII_Steps = 0;
						playerTurn = "YELLOW";
					}
					if (currentPlayer == BluePlayerIV.bluePlayerIV_ColName && (currentPlayer != "Star" && BluePlayerIV.bluePlayerIV_ColName != "Star")) {
						bluePlayerIV.transform.position = bluePlayerIV_Pos;
						BluePlayerIV.bluePlayerIV_ColName = "none";
						bluePlayerIV_Steps = 0;
						playerTurn = "YELLOW";
					}
				}

				if (currentPlayerName.Contains ("BLUE PLAYER")) {
					if (currentPlayer == RedPlayerI.redPlayerI_ColName && (currentPlayer != "Star" && RedPlayerI.redPlayerI_ColName != "Star")) {
						redPlayerI.transform.position = redPlayerI_Pos;
						RedPlayerI.redPlayerI_ColName = "none";
						redPlayerI_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == RedPlayerII.redPlayerII_ColName && (currentPlayer != "Star" && RedPlayerII.redPlayerII_ColName != "Star")) {
						redPlayerII.transform.position = redPlayerII_Pos;
						RedPlayerII.redPlayerII_ColName = "none";
						redPlayerII_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == RedPlayerIII.redPlayerIII_ColName && (currentPlayer != "Star" && RedPlayerIII.redPlayerIII_ColName != "Star")) {
						redPlayerIII.transform.position = redPlayerIII_Pos;
						RedPlayerIII.redPlayerIII_ColName = "none";
						redPlayerIII_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == RedPlayerIV.redPlayerIV_ColName && (currentPlayer != "Star" && RedPlayerIV.redPlayerIV_ColName != "Star")) {
						redPlayerIV.transform.position = redPlayerIV_Pos;
						RedPlayerIV.redPlayerIV_ColName = "none";
						redPlayerIV_Steps = 0;
						playerTurn = "BLUE";
					}

					if (currentPlayer == YellowPlayerI.yellowPlayerI_ColName && (currentPlayer != "Star" && YellowPlayerI.yellowPlayerI_ColName != "Star")) {
						yellowPlayerI.transform.position = yellowPlayerI_Pos;
						YellowPlayerI.yellowPlayerI_ColName = "none";
						yellowPlayerI_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == YellowPlayerII.yellowPlayerII_ColName && (currentPlayer != "Star" && YellowPlayerII.yellowPlayerII_ColName != "Star")) {
						yellowPlayerII.transform.position = yellowPlayerII_Pos;
						YellowPlayerII.yellowPlayerII_ColName = "none";
						yellowPlayerII_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == YellowPlayerIII.yellowPlayerIII_ColName && (currentPlayer != "Star" && YellowPlayerIII.yellowPlayerIII_ColName != "Star")) {
						yellowPlayerIII.transform.position = yellowPlayerIII_Pos;
						YellowPlayerIII.yellowPlayerIII_ColName = "none";
						yellowPlayerIII_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == YellowPlayerIV.yellowPlayerIV_ColName && (currentPlayer != "Star" && YellowPlayerIV.yellowPlayerIV_ColName != "Star")) {
						yellowPlayerIV.transform.position = yellowPlayerIV_Pos;
						YellowPlayerIV.yellowPlayerIV_ColName = "none";
						yellowPlayerIV_Steps = 0;
						playerTurn = "BLUE";
					}
				}
				break;

			case 4:
				if (currentPlayerName.Contains ("RED PLAYER")) {
					if (currentPlayer == GreenPlayerI.greenPlayerI_ColName && (currentPlayer != "Star" && GreenPlayerI.greenPlayerI_ColName != "Star")) {
						greenPlayerI.transform.position = greenPlayerI_Pos;
						GreenPlayerI.greenPlayerI_ColName = "none";
						greenPlayerI_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == GreenPlayerII.greenPlayerII_ColName && (currentPlayer != "Star" && GreenPlayerII.greenPlayerII_ColName != "Star")) {
						greenPlayerII.transform.position = greenPlayerII_Pos;
						GreenPlayerII.greenPlayerII_ColName = "none";
						greenPlayerII_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == GreenPlayerIII.greenPlayerIII_ColName && (currentPlayer != "Star" && GreenPlayerIII.greenPlayerIII_ColName != "Star")) {
						greenPlayerIII.transform.position = greenPlayerIII_Pos;
						GreenPlayerIII.greenPlayerIII_ColName = "none";
						greenPlayerIII_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == GreenPlayerIV.greenPlayerIV_ColName && (currentPlayer != "Star" && GreenPlayerIV.greenPlayerIV_ColName != "Star")) {
						greenPlayerIV.transform.position = greenPlayerIV_Pos;
						GreenPlayerIV.greenPlayerIV_ColName = "none";
						greenPlayerIV_Steps = 0;
						playerTurn = "RED";
					}

					if (currentPlayer == BluePlayerI.bluePlayerI_ColName && (currentPlayer != "Star" && BluePlayerI.bluePlayerI_ColName != "Star")) {
						bluePlayerI.transform.position = bluePlayerI_Pos;
						BluePlayerI.bluePlayerI_ColName = "none";
						bluePlayerI_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == BluePlayerII.bluePlayerII_ColName && (currentPlayer != "Star" && BluePlayerII.bluePlayerII_ColName != "Star")) {
						bluePlayerII.transform.position = bluePlayerII_Pos;
						BluePlayerII.bluePlayerII_ColName = "none";
						bluePlayerII_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == BluePlayerIII.bluePlayerIII_ColName && (currentPlayer != "Star" && BluePlayerIII.bluePlayerIII_ColName != "Star")) {
						bluePlayerIII.transform.position = bluePlayerIII_Pos;
						BluePlayerIII.bluePlayerIII_ColName = "none";
						bluePlayerIII_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == BluePlayerIV.bluePlayerIV_ColName && (currentPlayer != "Star" && BluePlayerIV.bluePlayerIV_ColName != "Star")) {
						bluePlayerIV.transform.position = bluePlayerIV_Pos;
						BluePlayerIV.bluePlayerIV_ColName = "none";
						bluePlayerIV_Steps = 0;
						playerTurn = "RED";
					}

					if (currentPlayer == YellowPlayerI.yellowPlayerI_ColName && (currentPlayer != "Star" && YellowPlayerI.yellowPlayerI_ColName != "Star")) {
						yellowPlayerI.transform.position = yellowPlayerI_Pos;
						YellowPlayerI.yellowPlayerI_ColName = "none";
						yellowPlayerI_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == YellowPlayerII.yellowPlayerII_ColName && (currentPlayer != "Star" && YellowPlayerII.yellowPlayerII_ColName != "Star")) {
						yellowPlayerII.transform.position = yellowPlayerII_Pos;
						YellowPlayerII.yellowPlayerII_ColName = "none";
						yellowPlayerII_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == YellowPlayerIII.yellowPlayerIII_ColName && (currentPlayer != "Star" && YellowPlayerIII.yellowPlayerIII_ColName != "Star")) {
						yellowPlayerIII.transform.position = yellowPlayerIII_Pos;
						YellowPlayerIII.yellowPlayerIII_ColName = "none";
						yellowPlayerIII_Steps = 0;
						playerTurn = "RED";
					}
					if (currentPlayer == YellowPlayerIV.yellowPlayerIV_ColName && (currentPlayer != "Star" && YellowPlayerIV.yellowPlayerIV_ColName != "Star")) {
						yellowPlayerIV.transform.position = yellowPlayerIV_Pos;
						YellowPlayerIV.yellowPlayerIV_ColName = "none";
						yellowPlayerIV_Steps = 0;
						playerTurn = "RED";
					}
				}

				if (currentPlayerName.Contains ("GREEN PLAYER")) {
					if (currentPlayer == RedPlayerI.redPlayerI_ColName && (currentPlayer != "Star" && RedPlayerI.redPlayerI_ColName != "Star")) {
						redPlayerI.transform.position = redPlayerI_Pos;
						RedPlayerI.redPlayerI_ColName = "none";
						redPlayerI_Steps = 0;
						playerTurn = "GREEN";
					}
					if (currentPlayer == RedPlayerII.redPlayerII_ColName && (currentPlayer != "Star" && RedPlayerII.redPlayerII_ColName != "Star")) {
						redPlayerII.transform.position = redPlayerII_Pos;
						RedPlayerII.redPlayerII_ColName = "none";
						redPlayerII_Steps = 0;
						playerTurn = "GREEN";
					}
					if (currentPlayer == RedPlayerIII.redPlayerIII_ColName && (currentPlayer != "Star" && RedPlayerIII.redPlayerIII_ColName != "Star")) {
						redPlayerIII.transform.position = redPlayerIII_Pos;
						RedPlayerIII.redPlayerIII_ColName = "none";
						redPlayerIII_Steps = 0;
						playerTurn = "GREEN";
					}
					if (currentPlayer == RedPlayerIV.redPlayerIV_ColName && (currentPlayer != "Star" && RedPlayerIV.redPlayerIV_ColName != "Star")) {
						redPlayerIV.transform.position = redPlayerIV_Pos;
						RedPlayerIV.redPlayerIV_ColName = "none";
						redPlayerIV_Steps = 0;
						playerTurn = "GREEN";
					}

					if (currentPlayer == BluePlayerI.bluePlayerI_ColName && (currentPlayer != "Star" && BluePlayerI.bluePlayerI_ColName != "Star")) {
						bluePlayerI.transform.position = bluePlayerI_Pos;
						BluePlayerI.bluePlayerI_ColName = "none";
						bluePlayerI_Steps = 0;
						playerTurn = "GREEN";
					}
					if (currentPlayer == BluePlayerII.bluePlayerII_ColName && (currentPlayer != "Star" && BluePlayerII.bluePlayerII_ColName != "Star")) {
						bluePlayerII.transform.position = bluePlayerII_Pos;
						BluePlayerII.bluePlayerII_ColName = "none";
						bluePlayerII_Steps = 0;
						playerTurn = "GREEN";
					}
					if (currentPlayer == BluePlayerIII.bluePlayerIII_ColName && (currentPlayer != "Star" && BluePlayerIII.bluePlayerIII_ColName != "Star")) {
						bluePlayerIII.transform.position = bluePlayerIII_Pos;
						BluePlayerIII.bluePlayerIII_ColName = "none";
						bluePlayerIII_Steps = 0;
						playerTurn = "GREEN";
					}
					if (currentPlayer == BluePlayerIV.bluePlayerIV_ColName && (currentPlayer != "Star" && BluePlayerIV.bluePlayerIV_ColName != "Star")) {
						bluePlayerIV.transform.position = bluePlayerIV_Pos;
						BluePlayerIV.bluePlayerIV_ColName = "none";
						bluePlayerIV_Steps = 0;
						playerTurn = "GREEN";
					}

					if (currentPlayer == YellowPlayerI.yellowPlayerI_ColName && (currentPlayer != "Star" && YellowPlayerI.yellowPlayerI_ColName != "Star")) {
						yellowPlayerI.transform.position = yellowPlayerI_Pos;
						YellowPlayerI.yellowPlayerI_ColName = "none";
						yellowPlayerI_Steps = 0;
						playerTurn = "GREEN";
					}
					if (currentPlayer == YellowPlayerII.yellowPlayerII_ColName && (currentPlayer != "Star" && YellowPlayerII.yellowPlayerII_ColName != "Star")) {
						yellowPlayerII.transform.position = yellowPlayerII_Pos;
						YellowPlayerII.yellowPlayerII_ColName = "none";
						yellowPlayerII_Steps = 0;
						playerTurn = "GREEN";
					}
					if (currentPlayer == YellowPlayerIII.yellowPlayerIII_ColName && (currentPlayer != "Star" && YellowPlayerIII.yellowPlayerIII_ColName != "Star")) {
						yellowPlayerIII.transform.position = yellowPlayerIII_Pos;
						YellowPlayerIII.yellowPlayerIII_ColName = "none";
						yellowPlayerIII_Steps = 0;
						playerTurn = "GREEN";
					}
					if (currentPlayer == YellowPlayerIV.yellowPlayerIV_ColName && (currentPlayer != "Star" && YellowPlayerIV.yellowPlayerIV_ColName != "Star")) {
						yellowPlayerIV.transform.position = yellowPlayerIV_Pos;
						YellowPlayerIV.yellowPlayerIV_ColName = "none";
						yellowPlayerIV_Steps = 0;
						playerTurn = "GREEN";
					}
				}

				if (currentPlayerName.Contains ("BLUE PLAYER")) {
					if (currentPlayer == RedPlayerI.redPlayerI_ColName && (currentPlayer != "Star" && RedPlayerI.redPlayerI_ColName != "Star")) {
						redPlayerI.transform.position = redPlayerI_Pos;
						RedPlayerI.redPlayerI_ColName = "none";
						redPlayerI_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == RedPlayerII.redPlayerII_ColName && (currentPlayer != "Star" && RedPlayerII.redPlayerII_ColName != "Star")) {
						redPlayerII.transform.position = redPlayerII_Pos;
						RedPlayerII.redPlayerII_ColName = "none";
						redPlayerII_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == RedPlayerIII.redPlayerIII_ColName && (currentPlayer != "Star" && RedPlayerIII.redPlayerIII_ColName != "Star")) {
						redPlayerIII.transform.position = redPlayerIII_Pos;
						RedPlayerIII.redPlayerIII_ColName = "none";
						redPlayerIII_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == RedPlayerIV.redPlayerIV_ColName && (currentPlayer != "Star" && RedPlayerIV.redPlayerIV_ColName != "Star")) {
						redPlayerIV.transform.position = redPlayerIV_Pos;
						RedPlayerIV.redPlayerIV_ColName = "none";
						redPlayerIV_Steps = 0;
						playerTurn = "BLUE";
					}

					if (currentPlayer == GreenPlayerI.greenPlayerI_ColName && (currentPlayer != "Star" && GreenPlayerI.greenPlayerI_ColName != "Star")) {
						greenPlayerI.transform.position = greenPlayerI_Pos;
						GreenPlayerI.greenPlayerI_ColName = "none";
						greenPlayerI_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == GreenPlayerII.greenPlayerII_ColName && (currentPlayer != "Star" && GreenPlayerII.greenPlayerII_ColName != "Star")) {
						greenPlayerII.transform.position = greenPlayerII_Pos;
						GreenPlayerII.greenPlayerII_ColName = "none";
						greenPlayerII_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == GreenPlayerIII.greenPlayerIII_ColName && (currentPlayer != "Star" && GreenPlayerIII.greenPlayerIII_ColName != "Star")) {
						greenPlayerIII.transform.position = greenPlayerIII_Pos;
						GreenPlayerIII.greenPlayerIII_ColName = "none";
						greenPlayerIII_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == GreenPlayerIV.greenPlayerIV_ColName && (currentPlayer != "Star" && GreenPlayerIV.greenPlayerIV_ColName != "Star")) {
						greenPlayerIV.transform.position = greenPlayerIV_Pos;
						GreenPlayerIV.greenPlayerIV_ColName = "none";
						greenPlayerIV_Steps = 0;
						playerTurn = "BLUE";
					}

					if (currentPlayer == YellowPlayerI.yellowPlayerI_ColName && (currentPlayer != "Star" && YellowPlayerI.yellowPlayerI_ColName != "Star")) {
						yellowPlayerI.transform.position = yellowPlayerI_Pos;
						YellowPlayerI.yellowPlayerI_ColName = "none";
						yellowPlayerI_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == YellowPlayerII.yellowPlayerII_ColName && (currentPlayer != "Star" && YellowPlayerII.yellowPlayerII_ColName != "Star")) {
						yellowPlayerII.transform.position = yellowPlayerII_Pos;
						YellowPlayerII.yellowPlayerII_ColName = "none";
						yellowPlayerII_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == YellowPlayerIII.yellowPlayerIII_ColName && (currentPlayer != "Star" && YellowPlayerIII.yellowPlayerIII_ColName != "Star")) {
						yellowPlayerIII.transform.position = yellowPlayerIII_Pos;
						YellowPlayerIII.yellowPlayerIII_ColName = "none";
						yellowPlayerIII_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == YellowPlayerIV.yellowPlayerIV_ColName && (currentPlayer != "Star" && YellowPlayerIV.yellowPlayerIV_ColName != "Star")) {
						yellowPlayerIV.transform.position = yellowPlayerIV_Pos;
						YellowPlayerIV.yellowPlayerIV_ColName = "none";
						yellowPlayerIV_Steps = 0;
						playerTurn = "BLUE";
					}
				}

				if (currentPlayerName.Contains ("YELLOW PLAYER")) {
					if (currentPlayer == RedPlayerI.redPlayerI_ColName && (currentPlayer != "Star" && RedPlayerI.redPlayerI_ColName != "Star")) {
						redPlayerI.transform.position = redPlayerI_Pos;
						RedPlayerI.redPlayerI_ColName = "none";
						redPlayerI_Steps = 0;
						playerTurn = "YELLOW";
					}
					if (currentPlayer == RedPlayerII.redPlayerII_ColName && (currentPlayer != "Star" && RedPlayerII.redPlayerII_ColName != "Star")) {
						redPlayerII.transform.position = redPlayerII_Pos;
						RedPlayerII.redPlayerII_ColName = "none";
						redPlayerII_Steps = 0;
						playerTurn = "YELLOW";
					}
					if (currentPlayer == RedPlayerIII.redPlayerIII_ColName && (currentPlayer != "Star" && RedPlayerIII.redPlayerIII_ColName != "Star")) {
						redPlayerIII.transform.position = redPlayerIII_Pos;
						RedPlayerIII.redPlayerIII_ColName = "none";
						redPlayerIII_Steps = 0;
						playerTurn = "YELLOW";
					}
					if (currentPlayer == RedPlayerIV.redPlayerIV_ColName && (currentPlayer != "Star" && RedPlayerIV.redPlayerIV_ColName != "Star")) {
						redPlayerIV.transform.position = redPlayerIV_Pos;
						RedPlayerIV.redPlayerIV_ColName = "none";
						redPlayerIV_Steps = 0;
						playerTurn = "YELLOW";
					}

					if (currentPlayer == GreenPlayerI.greenPlayerI_ColName && (currentPlayer != "Star" && GreenPlayerI.greenPlayerI_ColName != "Star")) {
						greenPlayerI.transform.position = greenPlayerI_Pos;
						GreenPlayerI.greenPlayerI_ColName = "none";
						greenPlayerI_Steps = 0;
						playerTurn = "YELLOW";
					}
					if (currentPlayer == GreenPlayerII.greenPlayerII_ColName && (currentPlayer != "Star" && GreenPlayerII.greenPlayerII_ColName != "Star")) {
						greenPlayerII.transform.position = greenPlayerII_Pos;
						GreenPlayerII.greenPlayerII_ColName = "none";
						greenPlayerII_Steps = 0;
						playerTurn = "YELLOW";
					}
					if (currentPlayer == GreenPlayerIII.greenPlayerIII_ColName && (currentPlayer != "Star" && GreenPlayerIII.greenPlayerIII_ColName != "Star")) {
						greenPlayerIII.transform.position = greenPlayerIII_Pos;
						GreenPlayerIII.greenPlayerIII_ColName = "none";
						greenPlayerIII_Steps = 0;
						playerTurn = "YELLOW";
					}
					if (currentPlayer == GreenPlayerIV.greenPlayerIV_ColName && (currentPlayer != "Star" && GreenPlayerIV.greenPlayerIV_ColName != "Star")) {
						greenPlayerIV.transform.position = greenPlayerIV_Pos;
						GreenPlayerIV.greenPlayerIV_ColName = "none";
						greenPlayerIV_Steps = 0;
						playerTurn = "YELLOW";
					}

					if (currentPlayer == BluePlayerI.bluePlayerI_ColName && (currentPlayer != "Star" && BluePlayerI.bluePlayerI_ColName != "Star")) {
						bluePlayerI.transform.position = bluePlayerI_Pos;
						BluePlayerI.bluePlayerI_ColName = "none";
						bluePlayerI_Steps = 0;
						playerTurn = "YELLOW";
					}
					if (currentPlayer == BluePlayerII.bluePlayerII_ColName && (currentPlayer != "Star" && BluePlayerII.bluePlayerII_ColName != "Star")) {
						bluePlayerII.transform.position = bluePlayerII_Pos;
						BluePlayerII.bluePlayerII_ColName = "none";
						bluePlayerII_Steps = 0;
						playerTurn = "YELLOW";
					}
					if (currentPlayer == BluePlayerIII.bluePlayerIII_ColName && (currentPlayer != "Star" && BluePlayerIII.bluePlayerIII_ColName != "Star")) {
						bluePlayerIII.transform.position = bluePlayerIII_Pos;
						BluePlayerIII.bluePlayerIII_ColName = "none";
						bluePlayerIII_Steps = 0;
						playerTurn = "YELLOW";
					}
					if (currentPlayer == BluePlayerIV.bluePlayerIV_ColName && (currentPlayer != "Star" && BluePlayerIV.bluePlayerIV_ColName != "Star")) {
						bluePlayerIV.transform.position = bluePlayerIV_Pos;
						BluePlayerIV.bluePlayerIV_ColName = "none";
						bluePlayerIV_Steps = 0;
						playerTurn = "YELLOW";
					}
				}
				break;				
			}
		}
		*/
		switch (MainMenuManager.howManyPlayers) 
		{
		case 2:
			if (playerTurn == "RED") 
			{
				diceRoll.position = redDiceRollPos.position;

				frameRed.SetActive (true);
				frameGreen.SetActive (false);
			}

			if (playerTurn == "GREEN") 
			{
				diceRoll.position = greenDiceRollPos.position;

				frameRed.SetActive (false);
				frameGreen.SetActive (true);
			}

			RedPlayerI_Button.interactable = false;
			RedPlayerII_Button.interactable = false;
			RedPlayerIII_Button.interactable = false;
			RedPlayerIV_Button.interactable = false;

			GreenPlayerI_Button.interactable = false;
			GreenPlayerII_Button.interactable = false;
			GreenPlayerIII_Button.interactable = false;
			GreenPlayerIV_Button.interactable = false;

			//Deactivating their borders as well
			redPlayerI_Border.SetActive (false);
			redPlayerII_Border.SetActive (false);
			redPlayerIII_Border.SetActive (false);
			redPlayerIV_Border.SetActive (false);

			greenPlayerI_Border.SetActive (false);
			greenPlayerII_Border.SetActive (false);
			greenPlayerIII_Border.SetActive (false);
			greenPlayerIV_Border.SetActive (false);

			break;

		case 3:
			if (playerTurn == "RED") 
			{
				diceRoll.position = redDiceRollPos.position;

				frameRed.SetActive (true);
				frameBlue.SetActive (false);
				frameYellow.SetActive (false);					
			}
			if (playerTurn == "YELLOW") 
			{
				diceRoll.position = yellowDiceRollPos.position;

				frameRed.SetActive (false);
				frameBlue.SetActive (false);
				frameYellow.SetActive (true);					
			}
			if (playerTurn == "BLUE") 
			{
				diceRoll.position = blueDiceRollPos.position;

				frameRed.SetActive (false);
				frameBlue.SetActive (true);
				frameYellow.SetActive (false);					
			}

			RedPlayerI_Button.interactable = false;
			RedPlayerII_Button.interactable = false;
			RedPlayerIII_Button.interactable = false;
			RedPlayerIV_Button.interactable = false;

			YellowPlayerI_Button.interactable = false;
			YellowPlayerII_Button.interactable = false;
			YellowPlayerIII_Button.interactable = false;
			YellowPlayerIV_Button.interactable = false;

			BluePlayerI_Button.interactable = false;
			BluePlayerII_Button.interactable = false;
			BluePlayerIII_Button.interactable = false;
			BluePlayerIV_Button.interactable = false;

			redPlayerI_Border.SetActive (false);
			redPlayerII_Border.SetActive (false);
			redPlayerIII_Border.SetActive (false);
			redPlayerIV_Border.SetActive (false);

			yellowPlayerI_Border.SetActive (false);
			yellowPlayerII_Border.SetActive (false);
			yellowPlayerIII_Border.SetActive (false);
			yellowPlayerIV_Border.SetActive (false);

			bluePlayerI_Border.SetActive (false);
			bluePlayerII_Border.SetActive (false);
			bluePlayerIII_Border.SetActive (false);
			bluePlayerIV_Border.SetActive (false);

			break;

		case 4:
			if (playerTurn == "RED") 
			{
				diceRoll.position = redDiceRollPos.position;

				frameRed.SetActive (true);
				frameGreen.SetActive (false);
				frameBlue.SetActive (false);
				frameYellow.SetActive (false);					
			}
			if (playerTurn == "GREEN") 
			{
				diceRoll.position = greenDiceRollPos.position;

				frameRed.SetActive (false);
				frameGreen.SetActive (true);
				frameBlue.SetActive (false);
				frameYellow.SetActive (false);					
			}
			if (playerTurn == "BLUE") 
			{
				diceRoll.position = blueDiceRollPos.position;

				frameRed.SetActive (false);
				frameGreen.SetActive (false);
				frameBlue.SetActive (true);
				frameYellow.SetActive (false);					
			}
			if (playerTurn == "YELLOW") 
			{
				diceRoll.position = yellowDiceRollPos.position;

				frameRed.SetActive (false);
				frameGreen.SetActive (false);
				frameBlue.SetActive (false);
				frameYellow.SetActive (true);					
			}

			RedPlayerI_Button.interactable = false;
			RedPlayerII_Button.interactable = false;
			RedPlayerIII_Button.interactable = false;
			RedPlayerIV_Button.interactable = false;

			GreenPlayerI_Button.interactable = false;
			GreenPlayerII_Button.interactable = false;
			GreenPlayerIII_Button.interactable = false;
			GreenPlayerIV_Button.interactable = false;

			BluePlayerI_Button.interactable = false;
			BluePlayerII_Button.interactable = false;
			BluePlayerIII_Button.interactable = false;
			BluePlayerIV_Button.interactable = false;

			YellowPlayerI_Button.interactable = false;
			YellowPlayerII_Button.interactable = false;
			YellowPlayerIII_Button.interactable = false;
			YellowPlayerIV_Button.interactable = false;

			redPlayerI_Border.SetActive (false);
			redPlayerII_Border.SetActive (false);
			redPlayerIII_Border.SetActive (false);
			redPlayerIV_Border.SetActive (false);

			yellowPlayerI_Border.SetActive (false);
			yellowPlayerII_Border.SetActive (false);
			yellowPlayerIII_Border.SetActive (false);
			yellowPlayerIV_Border.SetActive (false);

			bluePlayerI_Border.SetActive (false);
			bluePlayerII_Border.SetActive (false);
			bluePlayerIII_Border.SetActive (false);
			bluePlayerIV_Border.SetActive (false);

			greenPlayerI_Border.SetActive (false);
			greenPlayerII_Border.SetActive (false);
			greenPlayerIII_Border.SetActive (false);
			greenPlayerIV_Border.SetActive (false);

			break;
		}
	}

	public void DiceRoll()
	{
		DiceRollButton.interactable = false;

		selectDiceNumAnimation = randomNo.Next (1,7);
		//selectDiceNumAnimation = 6;

		switch (selectDiceNumAnimation) 
		{
		case 1:
			dice1_Roll_Animation.SetActive (true);
			dice2_Roll_Animation.SetActive (false);
			dice3_Roll_Animation.SetActive (false);
			dice4_Roll_Animation.SetActive (false);
			dice5_Roll_Animation.SetActive (false);
			dice6_Roll_Animation.SetActive (false);
			break;

		case 2:
			dice1_Roll_Animation.SetActive (false);
			dice2_Roll_Animation.SetActive (true);
			dice3_Roll_Animation.SetActive (false);
			dice4_Roll_Animation.SetActive (false);
			dice5_Roll_Animation.SetActive (false);
			dice6_Roll_Animation.SetActive (false);
			break;

		case 3:
			dice1_Roll_Animation.SetActive (false);
			dice2_Roll_Animation.SetActive (false);
			dice3_Roll_Animation.SetActive (true);
			dice4_Roll_Animation.SetActive (false);
			dice5_Roll_Animation.SetActive (false);
			dice6_Roll_Animation.SetActive (false);
			break;

		case 4:
			dice1_Roll_Animation.SetActive (false);
			dice2_Roll_Animation.SetActive (false);
			dice3_Roll_Animation.SetActive (false);
			dice4_Roll_Animation.SetActive (true);
			dice5_Roll_Animation.SetActive (false);
			dice6_Roll_Animation.SetActive (false);
			break;

		case 5:
			dice1_Roll_Animation.SetActive (false);
			dice2_Roll_Animation.SetActive (false);
			dice3_Roll_Animation.SetActive (false);
			dice4_Roll_Animation.SetActive (false);
			dice5_Roll_Animation.SetActive (true);
			dice6_Roll_Animation.SetActive (false);
			break;

		case 6:
			dice1_Roll_Animation.SetActive (false);
			dice2_Roll_Animation.SetActive (false);
			dice3_Roll_Animation.SetActive (false);
			dice4_Roll_Animation.SetActive (false);
			dice5_Roll_Animation.SetActive (false);
			dice6_Roll_Animation.SetActive (true);
			break;
		}

		StartCoroutine ("PlayersNotInitialized");
	}

	IEnumerator PlayersNotInitialized()
	{
		yield return new WaitForSeconds (0.8f);
		// Game Start Initial position of each player (Red, Green, Blue, Yellow)
		switch(playerTurn)
		{
			case "RED":

				//==================== CONDITION FOR BORDER GLOW

				if ((redMovementBlocks.Count - redPlayerI_Steps) >= selectDiceNumAnimation && redPlayerI_Steps > 0 && (redMovementBlocks.Count > redPlayerI_Steps)) {
					redPlayerI_Border.SetActive (true);
					RedPlayerI_Button.interactable = true;
				}
				else {
					redPlayerI_Border.SetActive (false);
					RedPlayerI_Button.interactable = false;
				}

				if ((redMovementBlocks.Count - redPlayerII_Steps) >= selectDiceNumAnimation && redPlayerII_Steps > 0 && (redMovementBlocks.Count > redPlayerII_Steps)) {
					redPlayerII_Border.SetActive (true);
					RedPlayerII_Button.interactable = true;
				}
				else {
					redPlayerII_Border.SetActive (false);
					RedPlayerII_Button.interactable = false;
				}

				if ((redMovementBlocks.Count - redPlayerIII_Steps) >= selectDiceNumAnimation && redPlayerIII_Steps > 0 && (redMovementBlocks.Count > redPlayerIII_Steps)) {
					redPlayerIII_Border.SetActive (true);
					RedPlayerIII_Button.interactable = true;
				}
				else {
					redPlayerIII_Border.SetActive (false);
					RedPlayerIII_Button.interactable = false;
				}

				if ((redMovementBlocks.Count - redPlayerIV_Steps) >= selectDiceNumAnimation && redPlayerIV_Steps > 0 && (redMovementBlocks.Count > redPlayerIV_Steps)) {
					redPlayerIV_Border.SetActive (true);
					RedPlayerIV_Button.interactable = true;
				}
				else {
					redPlayerIV_Border.SetActive (false);
					RedPlayerIV_Button.interactable = false;
				}

				//========================= PLAYERS BORDER GLOW WHEN OPENING

				if (selectDiceNumAnimation == 6 && redPlayerI_Steps == 0) {
					redPlayerI_Border.SetActive (true);
					RedPlayerI_Button.interactable = true;
				}
				if (selectDiceNumAnimation == 6 && redPlayerII_Steps == 0) {
					redPlayerII_Border.SetActive (true);
					RedPlayerII_Button.interactable = true;
				}				
				if (selectDiceNumAnimation == 6 && redPlayerIII_Steps == 0) {
					redPlayerIII_Border.SetActive (true);
					RedPlayerIII_Button.interactable = true;
				}					
				if (selectDiceNumAnimation == 6 && redPlayerIV_Steps == 0) {
					redPlayerIV_Border.SetActive (true);
					RedPlayerIV_Button.interactable = true;
				}	
			
				if(!redPlayerI_Border.activeInHierarchy && !redPlayerII_Border.activeInHierarchy
					&& !redPlayerIII_Border.activeInHierarchy && !redPlayerIV_Border.activeInHierarchy)
				{
					RedPlayerI_Button.interactable = false;
					RedPlayerII_Button.interactable = false;
					RedPlayerIII_Button.interactable = false;
					RedPlayerIV_Button.interactable = false;

					switch (MainMenuManager.howManyPlayers)
					{
						case 2:
							playerTurn = "GREEN";
							InitializeDice();
							break;
						
						case 3:
							playerTurn = "BLUE";
							InitializeDice ();
							break;

						case 4:
							playerTurn = "BLUE";
							InitializeDice ();
							break;
					}
				}

				break;
			
			case "GREEN":

				//==================== CONDITION FOR BORDER GLOW

				if ((greenMovementBlocks.Count - greenPlayerI_Steps) >= selectDiceNumAnimation && greenPlayerI_Steps > 0 && (greenMovementBlocks.Count > greenPlayerI_Steps)) 
				{
					greenPlayerI_Border.SetActive (true);
					GreenPlayerI_Button.interactable = true;
				} 
				else 
				{
					greenPlayerI_Border.SetActive (false);
					GreenPlayerI_Button.interactable = false;
				}

				if ((greenMovementBlocks.Count - greenPlayerII_Steps) >= selectDiceNumAnimation && greenPlayerII_Steps > 0 && (greenMovementBlocks.Count > greenPlayerII_Steps)) 
				{
					greenPlayerII_Border.SetActive (true);
					GreenPlayerII_Button.interactable = true;
				} 
				else 
				{
					greenPlayerII_Border.SetActive (false);
					GreenPlayerII_Button.interactable = false;
				}

				if ((greenMovementBlocks.Count - greenPlayerIII_Steps) >= selectDiceNumAnimation && greenPlayerIII_Steps > 0 && (greenMovementBlocks.Count > greenPlayerIII_Steps)) 
				{
					greenPlayerIII_Border.SetActive (true);
					GreenPlayerIII_Button.interactable = true;
				} 
				else 
				{
					greenPlayerIII_Border.SetActive (false);
					GreenPlayerIII_Button.interactable = false;
				}

				if ((greenMovementBlocks.Count - greenPlayerIV_Steps) >= selectDiceNumAnimation && greenPlayerIV_Steps > 0 && (greenMovementBlocks.Count > greenPlayerIV_Steps)) 
				{
					greenPlayerIV_Border.SetActive (true);
					GreenPlayerIV_Button.interactable = true;
				} 
				else 
				{
					greenPlayerIV_Border.SetActive (false);
					GreenPlayerIV_Button.interactable = false;
				}

				//========================= PLAYERS BORDER GLOW WHEN OPENING

				if (selectDiceNumAnimation == 6 && greenPlayerI_Steps == 0) 
				{
					greenPlayerI_Border.SetActive (true);
					GreenPlayerI_Button.interactable = true;
				}
				if (selectDiceNumAnimation == 6 && greenPlayerII_Steps == 0) 
				{
					greenPlayerII_Border.SetActive (true);
					GreenPlayerII_Button.interactable = true;
				}				
				if (selectDiceNumAnimation == 6 && greenPlayerIII_Steps == 0) 
				{
					greenPlayerIII_Border.SetActive (true);
					GreenPlayerIII_Button.interactable = true;
				}					
				if (selectDiceNumAnimation == 6 && greenPlayerIV_Steps == 0) 
				{
					greenPlayerIV_Border.SetActive (true);
					GreenPlayerIV_Button.interactable = true;
				}
			
				if (!greenPlayerI_Border.activeInHierarchy && !greenPlayerII_Border.activeInHierarchy &&
					!greenPlayerIII_Border.activeInHierarchy && !greenPlayerIV_Border.activeInHierarchy) 
				{
					GreenPlayerI_Button.interactable = false;
					GreenPlayerII_Button.interactable = false;
					GreenPlayerIII_Button.interactable = false;
					GreenPlayerIV_Button.interactable = false;

					switch (MainMenuManager.howManyPlayers)
					{
						case 2:
							playerTurn = "RED";
							InitializeDice();
							break;

						case 3:
							//GREEN PLAYER IS NOT AVAILABLE
							break;

						case 4:
							playerTurn = "YELLOW";
							InitializeDice ();
							break;
					}
				}

				break;

			case "BLUE":

				//==================== CONDITION FOR BORDER GLOW

				if ((blueMovementBlocks.Count - bluePlayerI_Steps) >= selectDiceNumAnimation && bluePlayerI_Steps > 0 && (blueMovementBlocks.Count > bluePlayerI_Steps)) 
				{
					bluePlayerI_Border.SetActive (true);
					BluePlayerI_Button.interactable = true;
				} 
				else 
				{
					bluePlayerI_Border.SetActive (false);
					BluePlayerI_Button.interactable = false;
				}

				if ((blueMovementBlocks.Count - bluePlayerII_Steps) >= selectDiceNumAnimation && bluePlayerII_Steps > 0 && (blueMovementBlocks.Count > bluePlayerII_Steps)) 
				{
					bluePlayerII_Border.SetActive (true);
					BluePlayerII_Button.interactable = true;
				} 
				else 
				{
					bluePlayerII_Border.SetActive (false);
					BluePlayerII_Button.interactable = false;
				}

				if ((blueMovementBlocks.Count - bluePlayerIII_Steps) >= selectDiceNumAnimation && bluePlayerIII_Steps > 0 && (blueMovementBlocks.Count > bluePlayerIII_Steps)) 
				{
					bluePlayerIII_Border.SetActive (true);
					BluePlayerIII_Button.interactable = true;
				} 
				else 
				{
					bluePlayerIII_Border.SetActive (false);
					BluePlayerIII_Button.interactable = false;
				}

				if ((blueMovementBlocks.Count - bluePlayerIV_Steps) >= selectDiceNumAnimation && bluePlayerIV_Steps > 0 && (blueMovementBlocks.Count > bluePlayerIV_Steps)) 
				{
					bluePlayerIV_Border.SetActive (true);
					BluePlayerIV_Button.interactable = true;
				} 
				else 
				{
					bluePlayerIV_Border.SetActive (false);
					BluePlayerIV_Button.interactable = false;
				}

				//========================= PLAYERS BORDER GLOW WHEN OPENING

				if (selectDiceNumAnimation == 6 && bluePlayerI_Steps == 0) 
				{
					bluePlayerI_Border.SetActive (true);
					BluePlayerI_Button.interactable = true;
				}
				if (selectDiceNumAnimation == 6 && bluePlayerII_Steps == 0) 
				{
					bluePlayerII_Border.SetActive (true);
					BluePlayerII_Button.interactable = true;
				}				
				if (selectDiceNumAnimation == 6 && bluePlayerIII_Steps == 0) 
				{
					bluePlayerIII_Border.SetActive (true);
					BluePlayerIII_Button.interactable = true;
				}					
				if (selectDiceNumAnimation == 6 && bluePlayerIV_Steps == 0) 
				{
					bluePlayerIV_Border.SetActive (true);
					BluePlayerIV_Button.interactable = true;
				}

				if (!bluePlayerI_Border.activeInHierarchy && !bluePlayerII_Border.activeInHierarchy &&
					!bluePlayerIII_Border.activeInHierarchy && !bluePlayerIV_Border.activeInHierarchy) 
				{
					BluePlayerI_Button.interactable = false;
					BluePlayerII_Button.interactable = false;
					BluePlayerIII_Button.interactable = false;
					BluePlayerIV_Button.interactable = false;

					switch (MainMenuManager.howManyPlayers) {
					case 2:
						//BLUE PLAYER NOT AVAILABLE
						break;

					case 3:
						playerTurn = "YELLOW";
						InitializeDice ();
						break;

					case 4:
						playerTurn = "GREEN";
						InitializeDice ();
						break;
					}
				}

				break;

			case "YELLOW":

				//==================== CONDITION FOR BORDER GLOW ========================

				if ((yellowMovementBlocks.Count - yellowPlayerI_Steps) >= selectDiceNumAnimation && yellowPlayerI_Steps > 0 && (yellowMovementBlocks.Count > yellowPlayerI_Steps)) 
				{
					yellowPlayerI_Border.SetActive (true);
					YellowPlayerI_Button.interactable = true;
				} 
				else 
				{
					yellowPlayerI_Border.SetActive (false);
					YellowPlayerI_Button.interactable = false;
				}

				if ((yellowMovementBlocks.Count - yellowPlayerII_Steps) >= selectDiceNumAnimation && yellowPlayerII_Steps > 0 && (yellowMovementBlocks.Count > yellowPlayerII_Steps)) 
				{
					yellowPlayerII_Border.SetActive (true);
					YellowPlayerII_Button.interactable = true;
				} 
				else 
				{
					yellowPlayerII_Border.SetActive (false);
					YellowPlayerII_Button.interactable = false;
				}

				if ((yellowMovementBlocks.Count - yellowPlayerIII_Steps) >= selectDiceNumAnimation && yellowPlayerIII_Steps > 0 && (yellowMovementBlocks.Count > yellowPlayerIII_Steps)) 
				{
					yellowPlayerIII_Border.SetActive (true);
					YellowPlayerIII_Button.interactable = true;
				} 
				else 
				{
					yellowPlayerIII_Border.SetActive (false);
					YellowPlayerIII_Button.interactable = false;
				}

				if ((yellowMovementBlocks.Count - yellowPlayerIV_Steps) >= selectDiceNumAnimation && yellowPlayerIV_Steps > 0 && (yellowMovementBlocks.Count > yellowPlayerIV_Steps)) 
				{
					yellowPlayerIV_Border.SetActive (true);
					YellowPlayerIV_Button.interactable = true;
				} 
				else 
				{
					yellowPlayerIV_Border.SetActive (false);
					YellowPlayerIV_Button.interactable = false;
				}

				//========================= PLAYERS BORDER GLOW WHEN OPENING

				if (selectDiceNumAnimation == 6 && yellowPlayerI_Steps == 0) 
				{
					yellowPlayerI_Border.SetActive (true);
					YellowPlayerI_Button.interactable = true;
				}
				if (selectDiceNumAnimation == 6 && yellowPlayerII_Steps == 0) 
				{
					yellowPlayerII_Border.SetActive (true);
					YellowPlayerII_Button.interactable = true;
				}				
				if (selectDiceNumAnimation == 6 && yellowPlayerIII_Steps == 0) 
				{
					yellowPlayerIII_Border.SetActive (true);
					YellowPlayerIII_Button.interactable = true;
				}					
				if (selectDiceNumAnimation == 6 && yellowPlayerIV_Steps == 0) 
				{
					yellowPlayerIV_Border.SetActive (true);
					YellowPlayerIV_Button.interactable = true;
				}

				if (!yellowPlayerI_Border.activeInHierarchy && !yellowPlayerII_Border.activeInHierarchy &&
					!yellowPlayerIII_Border.activeInHierarchy && !yellowPlayerIV_Border.activeInHierarchy) 
				{
					YellowPlayerI_Button.interactable = false;
					YellowPlayerII_Button.interactable = false;
					YellowPlayerIII_Button.interactable = false;
					YellowPlayerIV_Button.interactable = false;

					switch (MainMenuManager.howManyPlayers) {
					case 2:
						//YELLOW PLAYER NOT AVAILABLE
						break;

					case 3:
						playerTurn = "RED";
						InitializeDice ();
						break;

					case 4:
						playerTurn = "RED";
						InitializeDice ();
						break;
					}
				}

				break;
		}
	}

	public void redPlayerI_UI()
	{
		redPlayerI_Border.SetActive (false);
		redPlayerII_Border.SetActive (false);
		redPlayerIII_Border.SetActive (false);
		redPlayerIV_Border.SetActive (false);

		RedPlayerI_Button.interactable = false;
		RedPlayerII_Button.interactable = false;
		RedPlayerIII_Button.interactable = false;
		RedPlayerIV_Button.interactable = false;

		if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerI_Steps) > selectDiceNumAnimation)
		{
			if (redPlayerI_Steps > 0) 
			{
				Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					redPlayer_Path [i] = redMovementBlocks [redPlayerI_Steps + i].transform.position;
				}

				redPlayerI_Steps += selectDiceNumAnimation;

				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "RED";
				} 
				else 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						playerTurn = "GREEN";
						break;

					case 3:
						playerTurn = "BLUE";
						break;

					case 4:
						playerTurn = "BLUE";
						break;
					}
				}

				currentPlayerName = "RED PLAYER I";

				if (redPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (redPlayerI, iTween.Hash ("path", redPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (redPlayerI, iTween.Hash ("position", redPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
			else
			{
				if (selectDiceNumAnimation == 6 && redPlayerI_Steps == 0) 
				{
					Vector3[] redPlayer_Path = new Vector3[1];
					redPlayer_Path [0] = redMovementBlocks [redPlayerI_Steps].transform.position;
					redPlayerI_Steps += 1;
					playerTurn = "RED";
					currentPlayerName = "RED PLAYER I";
					iTween.MoveTo (redPlayerI, iTween.Hash ("position", redPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		}

		else
		{
			if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerI_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					redPlayer_Path [i] = redMovementBlocks [redPlayerI_Steps + i].transform.position;
				}

				redPlayerI_Steps += selectDiceNumAnimation;

				playerTurn = "RED";

				if (redPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (redPlayerI, iTween.Hash ("path", redPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (redPlayerI, iTween.Hash ("position", redPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}

				totalRedInHouse += 1;
				RedPlayerI_Button.enabled = false;
			}
			else
			{
				if(redPlayerII_Steps + redPlayerIII_Steps + redPlayerIV_Steps == 0 && selectDiceNumAnimation != 6)
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						playerTurn = "GREEN";
						break;

					case 3:
						playerTurn = "BLUE";
						break;

					case 4:
						playerTurn = "BLUE";
						break;
					}

					InitializeDice ();
				}
			}
		}
	}

	public void redPlayerII_UI()
	{
		redPlayerI_Border.SetActive (false);
		redPlayerII_Border.SetActive (false);
		redPlayerIII_Border.SetActive (false);
		redPlayerIV_Border.SetActive (false);

		RedPlayerI_Button.interactable = false;
		RedPlayerII_Button.interactable = false;
		RedPlayerIII_Button.interactable = false;
		RedPlayerIV_Button.interactable = false;

		if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerII_Steps) > selectDiceNumAnimation)
		{
			if (redPlayerII_Steps > 0) 
			{
				Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					redPlayer_Path [i] = redMovementBlocks [redPlayerII_Steps + i].transform.position;
				}

				redPlayerII_Steps += selectDiceNumAnimation;

				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "RED";
				} 
				else 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						playerTurn = "GREEN";
						break;

					case 3:
						playerTurn = "BLUE";
						break;

					case 4:
						playerTurn = "BLUE";
						break;
					}
				}

				currentPlayerName = "RED PLAYER II";

				if (redPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (redPlayerII, iTween.Hash ("path", redPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (redPlayerII, iTween.Hash ("position", redPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
			else
			{
				if (selectDiceNumAnimation == 6 && redPlayerII_Steps == 0) 
				{
					Vector3[] redPlayer_Path = new Vector3[1];
					redPlayer_Path [0] = redMovementBlocks [redPlayerII_Steps].transform.position;
					redPlayerII_Steps += 1;
					playerTurn = "RED";
					currentPlayerName = "RED PLAYER II";
					iTween.MoveTo (redPlayerII, iTween.Hash ("position", redPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		}

		else
		{
			if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerII_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					redPlayer_Path [i] = redMovementBlocks [redPlayerII_Steps + i].transform.position;
				}

				redPlayerII_Steps += selectDiceNumAnimation;

				playerTurn = "RED";

				if (redPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (redPlayerII, iTween.Hash ("path", redPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (redPlayerII, iTween.Hash ("position", redPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}

				totalRedInHouse += 1;
				RedPlayerII_Button.enabled = false;
			}
			else
			{
				if(redPlayerI_Steps + redPlayerIII_Steps + redPlayerIV_Steps == 0 && selectDiceNumAnimation != 6)
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						playerTurn = "GREEN";
						break;

					case 3:
						playerTurn = "BLUE";
						break;

					case 4:
						playerTurn = "BLUE";
						break;
					}

					InitializeDice ();
				}
			}
		}
	}

	public void redPlayerIII_UI()
	{
		redPlayerI_Border.SetActive (false);
		redPlayerII_Border.SetActive (false);
		redPlayerIII_Border.SetActive (false);
		redPlayerIV_Border.SetActive (false);

		RedPlayerI_Button.interactable = false;
		RedPlayerII_Button.interactable = false;
		RedPlayerIII_Button.interactable = false;
		RedPlayerIV_Button.interactable = false;

		if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerIII_Steps) > selectDiceNumAnimation)
		{
			if (redPlayerIII_Steps > 0) 
			{
				Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					redPlayer_Path [i] = redMovementBlocks [redPlayerIII_Steps + i].transform.position;
				}

				redPlayerIII_Steps += selectDiceNumAnimation;

				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "RED";
				} 
				else 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						playerTurn = "GREEN";
						break;

					case 3:
						playerTurn = "BLUE";
						break;

					case 4:
						playerTurn = "BLUE";
						break;
					}
				}

				currentPlayerName = "RED PLAYER III";

				if (redPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (redPlayerIII, iTween.Hash ("path", redPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (redPlayerIII, iTween.Hash ("position", redPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
			else
			{
				if (selectDiceNumAnimation == 6 && redPlayerIII_Steps == 0) 
				{
					Vector3[] redPlayer_Path = new Vector3[1];
					redPlayer_Path [0] = redMovementBlocks [redPlayerIII_Steps].transform.position;
					redPlayerIII_Steps += 1;
					playerTurn = "RED";
					currentPlayerName = "RED PLAYER III";
					iTween.MoveTo (redPlayerIII, iTween.Hash ("position", redPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		}

		else
		{
			if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerIII_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					redPlayer_Path [i] = redMovementBlocks [redPlayerIII_Steps + i].transform.position;
				}

				redPlayerIII_Steps += selectDiceNumAnimation;

				playerTurn = "RED";

				if (redPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (redPlayerIII, iTween.Hash ("path", redPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (redPlayerIII, iTween.Hash ("position", redPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}

				totalRedInHouse += 1;
				RedPlayerIII_Button.enabled = false;
			}
			else
			{
				if(redPlayerI_Steps + redPlayerII_Steps + redPlayerIV_Steps == 0 && selectDiceNumAnimation != 6)
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						playerTurn = "GREEN";
						break;

					case 3:
						playerTurn = "BLUE";
						break;

					case 4:
						playerTurn = "BLUE";
						break;
					}

					InitializeDice ();
				}
			}
		}
	}

	public void redPlayerIV_UI()
	{
		redPlayerI_Border.SetActive (false);
		redPlayerII_Border.SetActive (false);
		redPlayerIII_Border.SetActive (false);
		redPlayerIV_Border.SetActive (false);

		RedPlayerI_Button.interactable = false;
		RedPlayerII_Button.interactable = false;
		RedPlayerIII_Button.interactable = false;
		RedPlayerIV_Button.interactable = false;

		if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerIV_Steps) > selectDiceNumAnimation)
		{
			if (redPlayerIV_Steps > 0) 
			{
				Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					redPlayer_Path [i] = redMovementBlocks [redPlayerIV_Steps + i].transform.position;
				}

				redPlayerIV_Steps += selectDiceNumAnimation;

				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "RED";
				} 
				else 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						playerTurn = "GREEN";
						break;

					case 3:
						playerTurn = "BLUE";
						break;

					case 4:
						playerTurn = "BLUE";
						break;
					}
				}

				currentPlayerName = "RED PLAYER IV";

				if (redPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (redPlayerIV, iTween.Hash ("path", redPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (redPlayerIV, iTween.Hash ("position", redPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
			else
			{
				if (selectDiceNumAnimation == 6 && redPlayerIV_Steps == 0) 
				{
					Vector3[] redPlayer_Path = new Vector3[1];
					redPlayer_Path [0] = redMovementBlocks [redPlayerIV_Steps].transform.position;
					redPlayerIV_Steps += 1;
					playerTurn = "RED";
					currentPlayerName = "RED PLAYER IV";
					iTween.MoveTo (redPlayerIV, iTween.Hash ("position", redPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		}

		else
		{
			if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerIV_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					redPlayer_Path [i] = redMovementBlocks [redPlayerIV_Steps + i].transform.position;
				}

				redPlayerIV_Steps += selectDiceNumAnimation;

				playerTurn = "RED";

				if (redPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (redPlayerIV, iTween.Hash ("path", redPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (redPlayerIV, iTween.Hash ("position", redPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}

				totalRedInHouse += 1;
				RedPlayerIV_Button.enabled = false;
			}
			else
			{
				if(redPlayerI_Steps + redPlayerII_Steps + redPlayerIII_Steps == 0 && selectDiceNumAnimation != 6)
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						playerTurn = "GREEN";
						break;

					case 3:
						playerTurn = "BLUE";
						break;

					case 4:
						playerTurn = "BLUE";
						break;
					}

					InitializeDice ();
				}
			}
		}
	}

	public void greenPlayerI_UI()
	{		
		greenPlayerI_Border.SetActive (false);
		greenPlayerII_Border.SetActive (false);
		greenPlayerIII_Border.SetActive (false);
		greenPlayerIV_Border.SetActive (false);

		GreenPlayerI_Button.interactable = false;
		GreenPlayerII_Button.interactable = false;
		GreenPlayerIII_Button.interactable = false;
		GreenPlayerIV_Button.interactable = false;

		if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerI_Steps) > selectDiceNumAnimation) 
		{ 
			if (greenPlayerI_Steps > 0) 
			{
				Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					greenPlayer_Path [i] = greenMovementBlocks [greenPlayerI_Steps + i].transform.position;
				}

				greenPlayerI_Steps += selectDiceNumAnimation;

				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "GREEN";
				} 
				else 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						playerTurn = "RED";
						break;

					case 3:
						//player is not available
						break;

					case 4:
						playerTurn = "YELLOW";
						break;
					}
				}

				currentPlayerName = "GREEN PLAYER I";

				if (greenPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (greenPlayerI, iTween.Hash ("path", greenPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (greenPlayerI, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && greenPlayerI_Steps == 0) 
				{
					Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];
					greenPlayer_Path [0] = greenMovementBlocks [greenPlayerI_Steps].transform.position;
					greenPlayerI_Steps += 1;
					playerTurn = "GREEN";
					currentPlayerName = "GREEN PLAYER I";
					iTween.MoveTo (greenPlayerI, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		} 
		else 
		{
			if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerI_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					greenPlayer_Path [i] = greenMovementBlocks [greenPlayerI_Steps + i].transform.position;
				}

				greenPlayerI_Steps += selectDiceNumAnimation;

				playerTurn = "GREEN";

				if (greenPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (greenPlayerI, iTween.Hash ("path", greenPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (greenPlayerI, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}

				totalGreenInHouse += 1;
				GreenPlayerI_Button.enabled = false;
			} 
			else 
			{
				if (greenPlayerII_Steps + greenPlayerIII_Steps + greenPlayerIV_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						playerTurn = "RED";
						break;

					case 3:
						//Player is not available
						break;

					case 4:
						playerTurn = "YELLOW";
						break;
					}
					InitializeDice ();
				}
			}
		}
	}

	public void greenPlayerII_UI()
	{
		greenPlayerI_Border.SetActive (false);
		greenPlayerII_Border.SetActive (false);
		greenPlayerIII_Border.SetActive (false);
		greenPlayerIV_Border.SetActive (false);

		GreenPlayerI_Button.interactable = false;
		GreenPlayerII_Button.interactable = false;
		GreenPlayerIII_Button.interactable = false;
		GreenPlayerIV_Button.interactable = false;

		if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerII_Steps) > selectDiceNumAnimation) 
		{ 
			if (greenPlayerII_Steps > 0) 
			{
				Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					greenPlayer_Path [i] = greenMovementBlocks [greenPlayerII_Steps + i].transform.position;
				}

				greenPlayerII_Steps += selectDiceNumAnimation;

				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "GREEN";
				} 
				else 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						playerTurn = "RED";
						break;

					case 3:
						//player is not available
						break;

					case 4:
						playerTurn = "YELLOW";
						break;
					}
				}

				currentPlayerName = "GREEN PLAYER II";

				if (greenPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (greenPlayerII, iTween.Hash ("path", greenPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (greenPlayerII, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && greenPlayerII_Steps == 0) 
				{
					Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];
					greenPlayer_Path [0] = greenMovementBlocks [greenPlayerII_Steps].transform.position;
					greenPlayerII_Steps += 1;
					playerTurn = "GREEN";
					currentPlayerName = "GREEN PLAYER II";
					iTween.MoveTo (greenPlayerII, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		} 
		else 
		{
			if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerII_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					greenPlayer_Path [i] = greenMovementBlocks [greenPlayerII_Steps + i].transform.position;
				}

				greenPlayerII_Steps += selectDiceNumAnimation;

				playerTurn = "GREEN";

				if (greenPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (greenPlayerII, iTween.Hash ("path", greenPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (greenPlayerII, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}

				totalGreenInHouse += 1;
				GreenPlayerII_Button.enabled = false;
			} 
			else 
			{
				if (greenPlayerI_Steps + greenPlayerIII_Steps + greenPlayerIV_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						playerTurn = "RED";
						break;

					case 3:
						//Player is not available
						break;

					case 4:
						playerTurn = "YELLOW";
						break;
					}
					InitializeDice ();
				}
			}
		}
	}

	public void greenPlayerIII_UI()
	{
		greenPlayerI_Border.SetActive (false);
		greenPlayerII_Border.SetActive (false);
		greenPlayerIII_Border.SetActive (false);
		greenPlayerIV_Border.SetActive (false);

		GreenPlayerI_Button.interactable = false;
		GreenPlayerII_Button.interactable = false;
		GreenPlayerIII_Button.interactable = false;
		GreenPlayerIV_Button.interactable = false;

		if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerIII_Steps) > selectDiceNumAnimation) 
		{ 
			if (greenPlayerIII_Steps > 0) 
			{
				Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					greenPlayer_Path [i] = greenMovementBlocks [greenPlayerIII_Steps + i].transform.position;
				}

				greenPlayerIII_Steps += selectDiceNumAnimation;

				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "GREEN";
				} 
				else 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						playerTurn = "RED";
						break;

					case 3:
						//player is not available
						break;

					case 4:
						playerTurn = "YELLOW";
						break;
					}
				}

				currentPlayerName = "GREEN PLAYER III";

				if (greenPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (greenPlayerIII, iTween.Hash ("path", greenPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (greenPlayerIII, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && greenPlayerIII_Steps == 0) 
				{
					Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];
					greenPlayer_Path [0] = greenMovementBlocks [greenPlayerIII_Steps].transform.position;
					greenPlayerIII_Steps += 1;
					playerTurn = "GREEN";
					currentPlayerName = "GREEN PLAYER III";
					iTween.MoveTo (greenPlayerIII, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		} 
		else 
		{
			if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerIII_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					greenPlayer_Path [i] = greenMovementBlocks [greenPlayerIII_Steps + i].transform.position;
				}

				greenPlayerIII_Steps += selectDiceNumAnimation;

				playerTurn = "GREEN";

				if (greenPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (greenPlayerIII, iTween.Hash ("path", greenPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (greenPlayerIII, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}

				totalGreenInHouse += 1;
				GreenPlayerIII_Button.enabled = false;
			} 
			else 
			{
				if (greenPlayerI_Steps + greenPlayerII_Steps + greenPlayerIV_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						playerTurn = "RED";
						break;

					case 3:
						//Player is not available
						break;

					case 4:
						playerTurn = "YELLOW";
						break;
					}
					InitializeDice ();
				}
			}
		}
	}

	public void greenPlayerIV_UI()
	{
		greenPlayerI_Border.SetActive (false);
		greenPlayerII_Border.SetActive (false);
		greenPlayerIII_Border.SetActive (false);
		greenPlayerIV_Border.SetActive (false);

		GreenPlayerI_Button.interactable = false;
		GreenPlayerII_Button.interactable = false;
		GreenPlayerIII_Button.interactable = false;
		GreenPlayerIV_Button.interactable = false;

		if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerIV_Steps) > selectDiceNumAnimation) 
		{ 
			if (greenPlayerIV_Steps > 0) 
			{
				Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					greenPlayer_Path [i] = greenMovementBlocks [greenPlayerIV_Steps + i].transform.position;
				}

				greenPlayerIV_Steps += selectDiceNumAnimation;

				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "GREEN";
				} 
				else 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						playerTurn = "RED";
						break;

					case 3:
						//player is not available
						break;

					case 4:
						playerTurn = "YELLOW";
						break;
					}
				}

				currentPlayerName = "GREEN PLAYER IV";

				if (greenPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (greenPlayerIV, iTween.Hash ("path", greenPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (greenPlayerIV, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && greenPlayerIV_Steps == 0) 
				{
					Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];
					greenPlayer_Path [0] = greenMovementBlocks [greenPlayerIV_Steps].transform.position;
					greenPlayerIV_Steps += 1;
					playerTurn = "GREEN";
					currentPlayerName = "GREEN PLAYER IV";
					iTween.MoveTo (greenPlayerIV, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		} 
		else 
		{
			if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerIV_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					greenPlayer_Path [i] = greenMovementBlocks [greenPlayerIV_Steps + i].transform.position;
				}

				greenPlayerIV_Steps += selectDiceNumAnimation;

				playerTurn = "GREEN";

				if (greenPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (greenPlayerIV, iTween.Hash ("path", greenPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (greenPlayerIV, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}

				totalGreenInHouse += 1;
				GreenPlayerIV_Button.enabled = false;
			} 
			else 
			{
				if (greenPlayerI_Steps + greenPlayerII_Steps + greenPlayerIII_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						playerTurn = "RED";
						break;

					case 3:
						//Player is not available
						break;

					case 4:
						playerTurn = "YELLOW";
						break;
					}
					InitializeDice ();
				}
			}
		}
	}

	public void bluePlayerI_UI()
	{
		bluePlayerI_Border.SetActive (false);
		bluePlayerII_Border.SetActive (false);
		bluePlayerIII_Border.SetActive (false);
		bluePlayerIV_Border.SetActive (false);

		BluePlayerI_Button.interactable = false;
		BluePlayerII_Button.interactable = false;
		BluePlayerIII_Button.interactable = false;
		BluePlayerIV_Button.interactable = false;

		if (playerTurn == "BLUE" && (blueMovementBlocks.Count - bluePlayerI_Steps) > selectDiceNumAnimation) 
		{ 
			if (bluePlayerI_Steps > 0) 
			{
				Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					bluePlayer_Path [i] = blueMovementBlocks [bluePlayerI_Steps + i].transform.position;
				}

				bluePlayerI_Steps += selectDiceNumAnimation;

				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "BLUE";
				} 
				else 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						//Player is not available
						break;

					case 3:
						playerTurn = "YELLOW";
						break;

					case 4:
						playerTurn = "GREEN";
						break;
					}
				}

				currentPlayerName = "BLUE PLAYER I";

				if (bluePlayer_Path.Length > 1) 
				{
					iTween.MoveTo (bluePlayerI, iTween.Hash ("path", bluePlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (bluePlayerI, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && bluePlayerI_Steps == 0) 
				{
					Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];
					bluePlayer_Path [0] = blueMovementBlocks [bluePlayerI_Steps].transform.position;
					bluePlayerI_Steps += 1;
					playerTurn = "BLUE";
					currentPlayerName = "BLUE PLAYER I";
					iTween.MoveTo (bluePlayerI, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		} 
		else 
		{
			if (playerTurn == "BLUE" && (blueMovementBlocks.Count - bluePlayerI_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					bluePlayer_Path [i] = blueMovementBlocks [bluePlayerI_Steps + i].transform.position;
				}

				bluePlayerI_Steps += selectDiceNumAnimation;

				playerTurn = "BLUE";

				if (bluePlayer_Path.Length > 1) 
				{
					iTween.MoveTo (bluePlayerI, iTween.Hash ("path", bluePlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (bluePlayerI, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}

				totalBlueInHouse += 1;
				BluePlayerI_Button.enabled = false;
			} 
			else 
			{
				if (bluePlayerII_Steps + bluePlayerIII_Steps + bluePlayerIV_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						// Player is not available...
						break;

					case 3:
						playerTurn = "YELLOW";
						break;

					case 4:
						playerTurn = "GREEN";
						break;
					}
					InitializeDice ();
				}
			}
		}
	}

	public void bluePlayerII_UI()
	{
		bluePlayerI_Border.SetActive (false);
		bluePlayerII_Border.SetActive (false);
		bluePlayerIII_Border.SetActive (false);
		bluePlayerIV_Border.SetActive (false);

		BluePlayerI_Button.interactable = false;
		BluePlayerII_Button.interactable = false;
		BluePlayerIII_Button.interactable = false;
		BluePlayerIV_Button.interactable = false;

		if (playerTurn == "BLUE" && (blueMovementBlocks.Count - bluePlayerII_Steps) > selectDiceNumAnimation) 
		{ 
			if (bluePlayerII_Steps > 0) 
			{
				Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					bluePlayer_Path [i] = blueMovementBlocks [bluePlayerII_Steps + i].transform.position;
				}

				bluePlayerII_Steps += selectDiceNumAnimation;

				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "BLUE";
				} 
				else 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						//Player is not available
						break;

					case 3:
						playerTurn = "YELLOW";
						break;

					case 4:
						playerTurn = "GREEN";
						break;
					}
				}

				currentPlayerName = "BLUE PLAYER II";

				if (bluePlayer_Path.Length > 1) 
				{
					iTween.MoveTo (bluePlayerII, iTween.Hash ("path", bluePlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (bluePlayerII, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && bluePlayerII_Steps == 0) 
				{
					Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];
					bluePlayer_Path [0] = blueMovementBlocks [bluePlayerII_Steps].transform.position;
					bluePlayerII_Steps += 1;
					playerTurn = "BLUE";
					currentPlayerName = "BLUE PLAYER II";
					iTween.MoveTo (bluePlayerII, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

				}
			}
		} 
		else 
		{
			if (playerTurn == "BLUE" && (blueMovementBlocks.Count - bluePlayerII_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					bluePlayer_Path [i] = blueMovementBlocks [bluePlayerII_Steps + i].transform.position;
				}

				bluePlayerII_Steps += selectDiceNumAnimation;

				playerTurn = "BLUE";

				if (bluePlayer_Path.Length > 1) 
				{
					iTween.MoveTo (bluePlayerII, iTween.Hash ("path", bluePlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (bluePlayerII, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}

				totalBlueInHouse += 1;
				BluePlayerII_Button.enabled = false;
			} 
			else 
			{
				if (bluePlayerI_Steps + bluePlayerIII_Steps + bluePlayerIV_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						// Player is not available...
						break;

					case 3:
						playerTurn = "YELLOW";
						break;

					case 4:
						playerTurn = "GREEN";
						break;
					}
					InitializeDice ();
				}
			}
		}
	}

	public void bluePlayerIII_UI()
	{
		bluePlayerI_Border.SetActive (false);
		bluePlayerII_Border.SetActive (false);
		bluePlayerIII_Border.SetActive (false);
		bluePlayerIV_Border.SetActive (false);

		BluePlayerI_Button.interactable = false;
		BluePlayerII_Button.interactable = false;
		BluePlayerIII_Button.interactable = false;
		BluePlayerIV_Button.interactable = false;

		if (playerTurn == "BLUE" && (blueMovementBlocks.Count - bluePlayerIII_Steps) > selectDiceNumAnimation) 
		{ 
			if (bluePlayerIII_Steps > 0) 
			{
				Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					bluePlayer_Path [i] = blueMovementBlocks [bluePlayerIII_Steps + i].transform.position;
				}

				bluePlayerIII_Steps += selectDiceNumAnimation;

				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "BLUE";
				} 
				else 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						//Player is not available
						break;

					case 3:
						playerTurn = "YELLOW";
						break;

					case 4:
						playerTurn = "GREEN";
						break;
					}
				}

				currentPlayerName = "BLUE PLAYER III";

				if (bluePlayer_Path.Length > 1) 
				{
					iTween.MoveTo (bluePlayerIII, iTween.Hash ("path", bluePlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (bluePlayerIII, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && bluePlayerIII_Steps == 0) 
				{
					Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];
					bluePlayer_Path [0] = blueMovementBlocks [bluePlayerIII_Steps].transform.position;
					bluePlayerIII_Steps += 1;
					playerTurn = "BLUE";
					currentPlayerName = "BLUE PLAYER III";
					iTween.MoveTo (bluePlayerIII, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

				}
			}
		} 
		else 
		{
			if (playerTurn == "BLUE" && (blueMovementBlocks.Count - bluePlayerIII_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					bluePlayer_Path [i] = blueMovementBlocks [bluePlayerIII_Steps + i].transform.position;
				}

				bluePlayerIII_Steps += selectDiceNumAnimation;

				playerTurn = "BLUE";

				if (bluePlayer_Path.Length > 1) 
				{
					iTween.MoveTo (bluePlayerIII, iTween.Hash ("path", bluePlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (bluePlayerIII, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}

				totalBlueInHouse += 1;
				BluePlayerIII_Button.enabled = false;
			} 
			else 
			{
				if (bluePlayerI_Steps + bluePlayerII_Steps + bluePlayerIV_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						// Player is not available...
						break;

					case 3:
						playerTurn = "YELLOW";
						break;

					case 4:
						playerTurn = "GREEN";
						break;
					}
					InitializeDice ();
				}
			}
		}
	}

	public void bluePlayerIV_UI()
	{
		bluePlayerI_Border.SetActive (false);
		bluePlayerII_Border.SetActive (false);
		bluePlayerIII_Border.SetActive (false);
		bluePlayerIV_Border.SetActive (false);

		BluePlayerI_Button.interactable = false;
		BluePlayerII_Button.interactable = false;
		BluePlayerIII_Button.interactable = false;
		BluePlayerIV_Button.interactable = false;

		if (playerTurn == "BLUE" && (blueMovementBlocks.Count - bluePlayerIV_Steps) > selectDiceNumAnimation) 
		{ 
			if (bluePlayerIV_Steps > 0) 
			{
				Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					bluePlayer_Path [i] = blueMovementBlocks [bluePlayerIV_Steps + i].transform.position;
				}

				bluePlayerIV_Steps += selectDiceNumAnimation;

				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "BLUE";
				} 
				else 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						//Player is not available
						break;

					case 3:
						playerTurn = "YELLOW";
						break;

					case 4:
						playerTurn = "GREEN";
						break;
					}
				}

				currentPlayerName = "BLUE PLAYER IV";

				if (bluePlayer_Path.Length > 1) 
				{
					iTween.MoveTo (bluePlayerIV, iTween.Hash ("path", bluePlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (bluePlayerIV, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && bluePlayerIV_Steps == 0) 
				{
					Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];
					bluePlayer_Path [0] = blueMovementBlocks [bluePlayerIV_Steps].transform.position;
					bluePlayerIV_Steps += 1;
					playerTurn = "BLUE";
					currentPlayerName = "BLUE PLAYER IV";
					iTween.MoveTo (bluePlayerIV, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		} 
		else 
		{
			if (playerTurn == "BLUE" && (blueMovementBlocks.Count - bluePlayerIV_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					bluePlayer_Path [i] = blueMovementBlocks [bluePlayerIV_Steps + i].transform.position;
				}

				bluePlayerIV_Steps += selectDiceNumAnimation;

				playerTurn = "BLUE";

				if (bluePlayer_Path.Length > 1) 
				{
					iTween.MoveTo (bluePlayerIV, iTween.Hash ("path", bluePlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (bluePlayerIV, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}

				totalBlueInHouse += 1;
				BluePlayerIV_Button.enabled = false;
			} 
			else 
			{
				if (bluePlayerI_Steps + bluePlayerII_Steps + bluePlayerIII_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						// Player is not available...
						break;

					case 3:
						playerTurn = "YELLOW";
						break;

					case 4:
						playerTurn = "GREEN";
						break;
					}
					InitializeDice ();
				}
			}
		}
	}

	public void yellowPlayerI_UI()
	{
		yellowPlayerI_Border.SetActive (false);
		yellowPlayerII_Border.SetActive (false);
		yellowPlayerIII_Border.SetActive (false);
		yellowPlayerIV_Border.SetActive (false);

		YellowPlayerI_Button.interactable = false;
		YellowPlayerII_Button.interactable = false;
		YellowPlayerIII_Button.interactable = false;
		YellowPlayerIV_Button.interactable = false;

		if (playerTurn == "YELLOW" && (yellowMovementBlocks.Count - yellowPlayerI_Steps) > selectDiceNumAnimation) 
		{ 
			if (yellowPlayerI_Steps > 0) 
			{
				Vector3[] yellowPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					yellowPlayer_Path [i] = yellowMovementBlocks [yellowPlayerI_Steps + i].transform.position;
				}

				yellowPlayerI_Steps += selectDiceNumAnimation;

				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "YELLOW";
				} 
				else 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						//Player is not available
						break;

					case 3:
						playerTurn = "RED";
						break;

					case 4:
						playerTurn = "RED";
						break;
					}
				}

				currentPlayerName = "YELLOW PLAYER I";

				if (yellowPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (yellowPlayerI, iTween.Hash ("path", yellowPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (yellowPlayerI, iTween.Hash ("position", yellowPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && yellowPlayerI_Steps == 0) 
				{
					Vector3[] yellowPlayer_Path = new Vector3[selectDiceNumAnimation];
					yellowPlayer_Path [0] = yellowMovementBlocks [yellowPlayerI_Steps].transform.position;
					yellowPlayerI_Steps += 1;
					playerTurn = "YELLOW";
					currentPlayerName = "YELLOW PLAYER I";
					iTween.MoveTo (yellowPlayerI, iTween.Hash ("position", yellowPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

				}
			}
		} 
		else 
		{
			if (playerTurn == "YELLOW" && (yellowMovementBlocks.Count - yellowPlayerI_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] yellowPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					yellowPlayer_Path [i] = yellowMovementBlocks [yellowPlayerI_Steps + i].transform.position;
				}

				yellowPlayerI_Steps += selectDiceNumAnimation;

				playerTurn = "YELLOW";

				if (yellowPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (yellowPlayerI, iTween.Hash ("path", yellowPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (yellowPlayerI, iTween.Hash ("position", yellowPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}

				totalYellowInHouse += 1;
				YellowPlayerI_Button.enabled = false;
			} 
			else 
			{
				if (yellowPlayerII_Steps + yellowPlayerIII_Steps + yellowPlayerIV_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						// Player is not available...
						break;

					case 3:
						playerTurn = "RED";
						break;

					case 4:
						playerTurn = "RED";
						break;
					}
					InitializeDice ();
				}
			}
		}
	}

	public void yellowPlayerII_UI()
	{
		yellowPlayerI_Border.SetActive (false);
		yellowPlayerII_Border.SetActive (false);
		yellowPlayerIII_Border.SetActive (false);
		yellowPlayerIV_Border.SetActive (false);

		YellowPlayerI_Button.interactable = false;
		YellowPlayerII_Button.interactable = false;
		YellowPlayerIII_Button.interactable = false;
		YellowPlayerIV_Button.interactable = false;

		if (playerTurn == "YELLOW" && (yellowMovementBlocks.Count - yellowPlayerII_Steps) > selectDiceNumAnimation) 
		{ 
			if (yellowPlayerII_Steps > 0) 
			{
				Vector3[] yellowPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					yellowPlayer_Path [i] = yellowMovementBlocks [yellowPlayerII_Steps + i].transform.position;
				}

				yellowPlayerII_Steps += selectDiceNumAnimation;

				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "YELLOW";
				} 
				else 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						//Player is not available
						break;

					case 3:
						playerTurn = "RED";
						break;

					case 4:
						playerTurn = "RED";
						break;
					}
				}


				currentPlayerName = "YELLOW PLAYER II";

				if (yellowPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (yellowPlayerII, iTween.Hash ("path", yellowPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (yellowPlayerII, iTween.Hash ("position", yellowPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && yellowPlayerII_Steps == 0) 
				{
					Vector3[] yellowPlayer_Path = new Vector3[selectDiceNumAnimation];
					yellowPlayer_Path [0] = yellowMovementBlocks [yellowPlayerII_Steps].transform.position;
					yellowPlayerII_Steps += 1;
					playerTurn = "YELLOW";

					currentPlayerName = "YELLOW PLAYER II";
					iTween.MoveTo (yellowPlayerII, iTween.Hash ("position", yellowPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

				}
			}
		} 
		else 
		{
			if (playerTurn == "YELLOW" && (yellowMovementBlocks.Count - yellowPlayerII_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] yellowPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					yellowPlayer_Path [i] = yellowMovementBlocks [yellowPlayerII_Steps + i].transform.position;
				}

				yellowPlayerII_Steps += selectDiceNumAnimation;

				playerTurn = "YELLOW";

				if (yellowPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (yellowPlayerII, iTween.Hash ("path", yellowPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (yellowPlayerII, iTween.Hash ("position", yellowPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}

				totalYellowInHouse += 1;
				YellowPlayerII_Button.enabled = false;
			} 
			else 
			{
				if (yellowPlayerI_Steps + yellowPlayerIII_Steps + yellowPlayerIV_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						// Player is not available...
						break;

					case 3:
						playerTurn = "RED";
						break;

					case 4:
						playerTurn = "RED";
						break;
					}
					InitializeDice ();
				}
			}
		}
	}

	public void yellowPlayerIII_UI()
	{
		yellowPlayerI_Border.SetActive (false);
		yellowPlayerII_Border.SetActive (false);
		yellowPlayerIII_Border.SetActive (false);
		yellowPlayerIV_Border.SetActive (false);

		YellowPlayerI_Button.interactable = false;
		YellowPlayerII_Button.interactable = false;
		YellowPlayerIII_Button.interactable = false;
		YellowPlayerIV_Button.interactable = false;

		if (playerTurn == "YELLOW" && (yellowMovementBlocks.Count - yellowPlayerIII_Steps) > selectDiceNumAnimation) 
		{ 
			if (yellowPlayerIII_Steps > 0) 
			{
				Vector3[] yellowPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					yellowPlayer_Path [i] = yellowMovementBlocks [yellowPlayerIII_Steps + i].transform.position;
				}

				yellowPlayerIII_Steps += selectDiceNumAnimation;

				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "YELLOW";
				} 
				else 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						//Player is not available
						break;

					case 3:
						playerTurn = "RED";
						break;

					case 4:
						playerTurn = "RED";
						break;
					}
				}

				currentPlayerName = "YELLOW PLAYER III";

				if (yellowPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (yellowPlayerIII, iTween.Hash ("path", yellowPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (yellowPlayerIII, iTween.Hash ("position", yellowPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && yellowPlayerIII_Steps == 0) 
				{
					Vector3[] yellowPlayer_Path = new Vector3[selectDiceNumAnimation];
					yellowPlayer_Path [0] = yellowMovementBlocks [yellowPlayerIII_Steps].transform.position;
					yellowPlayerIII_Steps += 1;
					playerTurn = "YELLOW";
					currentPlayerName = "YELLOW PLAYER III";
					iTween.MoveTo (yellowPlayerIII, iTween.Hash ("position", yellowPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

				}
			}
		} 
		else 
		{
			if (playerTurn == "YELLOW" && (yellowMovementBlocks.Count - yellowPlayerIII_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] yellowPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					yellowPlayer_Path [i] = yellowMovementBlocks [yellowPlayerIII_Steps + i].transform.position;
				}

				yellowPlayerIII_Steps += selectDiceNumAnimation;

				playerTurn = "YELLOW";

				if (yellowPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (yellowPlayerIII, iTween.Hash ("path", yellowPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (yellowPlayerIII, iTween.Hash ("position", yellowPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}

				totalYellowInHouse += 1;
				YellowPlayerIII_Button.enabled = false;
			} 
			else 
			{
				if (yellowPlayerI_Steps + yellowPlayerII_Steps + yellowPlayerIV_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						// Player is not available...
						break;

					case 3:
						playerTurn = "RED";
						break;

					case 4:
						playerTurn = "RED";
						break;
					}
					InitializeDice ();
				}
			}
		}
	}

	public void yellowPlayerIV_UI()
	{
		yellowPlayerI_Border.SetActive (false);
		yellowPlayerII_Border.SetActive (false);
		yellowPlayerIII_Border.SetActive (false);
		yellowPlayerIV_Border.SetActive (false);

		YellowPlayerI_Button.interactable = false;
		YellowPlayerII_Button.interactable = false;
		YellowPlayerIII_Button.interactable = false;
		YellowPlayerIV_Button.interactable = false;

		if (playerTurn == "YELLOW" && (yellowMovementBlocks.Count - yellowPlayerIV_Steps) > selectDiceNumAnimation) 
		{ 
			if (yellowPlayerIV_Steps > 0) 
			{
				Vector3[] yellowPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					yellowPlayer_Path [i] = yellowMovementBlocks [yellowPlayerIV_Steps + i].transform.position;
				}

				yellowPlayerIV_Steps += selectDiceNumAnimation;

				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "YELLOW";
				} 
				else 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						//Player is not available
						break;

					case 3:
						playerTurn = "RED";
						break;

					case 4:
						playerTurn = "RED";
						break;
					}
				}

				currentPlayerName = "YELLOW PLAYER IV";

				if (yellowPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (yellowPlayerIV, iTween.Hash ("path", yellowPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (yellowPlayerIV, iTween.Hash ("position", yellowPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && yellowPlayerIV_Steps == 0) 
				{
					Vector3[] yellowPlayer_Path = new Vector3[selectDiceNumAnimation];
					yellowPlayer_Path [0] = yellowMovementBlocks [yellowPlayerIV_Steps].transform.position;
					yellowPlayerIV_Steps += 1;
					playerTurn = "YELLOW";
					currentPlayerName = "YELLOW PLAYER IV";
					iTween.MoveTo (yellowPlayerIV, iTween.Hash ("position", yellowPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

				}
			}
		} 
		else 
		{
			if (playerTurn == "YELLOW" && (yellowMovementBlocks.Count - yellowPlayerIV_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] yellowPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					yellowPlayer_Path [i] = yellowMovementBlocks [yellowPlayerIV_Steps + i].transform.position;
				}

				yellowPlayerIV_Steps += selectDiceNumAnimation;

				playerTurn = "YELLOW";

				if (yellowPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (yellowPlayerIV, iTween.Hash ("path", yellowPlayer_Path, "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (yellowPlayerIV, iTween.Hash ("position", yellowPlayer_Path [0], "speed", 125,"time",2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}

				totalYellowInHouse += 1;
				YellowPlayerIV_Button.enabled = false;
			} 
			else 
			{
				if (yellowPlayerI_Steps + yellowPlayerII_Steps + yellowPlayerIII_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (MainMenuManager.howManyPlayers) 
					{
					case 2:
						// Player is not available...
						break;

					case 3:
						playerTurn = "RED";
						break;

					case 4:
						playerTurn = "RED";
						break;
					}
					InitializeDice ();
				}
			}
		}
	}
				
	// Start is called before the first frame update
	void Start()
	{
		QualitySettings.vSyncCount = 1;
		Application.targetFrameRate = 30;

		randomNo = new System.Random ();

		dice1_Roll_Animation.SetActive (false);
		dice2_Roll_Animation.SetActive (false);
		dice3_Roll_Animation.SetActive (false);
		dice4_Roll_Animation.SetActive (false);
		dice5_Roll_Animation.SetActive (false);
		dice6_Roll_Animation.SetActive (false);

		// Players initial positions.....
		redPlayerI_Pos = redPlayerI.transform.position;
		redPlayerII_Pos = redPlayerII.transform.position;
		redPlayerIII_Pos = redPlayerIII.transform.position;
		redPlayerIV_Pos = redPlayerIV.transform.position;

		greenPlayerI_Pos = greenPlayerI.transform.position;
		greenPlayerII_Pos = greenPlayerII.transform.position;
		greenPlayerIII_Pos = greenPlayerIII.transform.position;
		greenPlayerIV_Pos = greenPlayerIV.transform.position;

		bluePlayerI_Pos = bluePlayerI.transform.position;
		bluePlayerII_Pos = bluePlayerII.transform.position;
		bluePlayerIII_Pos = bluePlayerIII.transform.position;
		bluePlayerIV_Pos = bluePlayerIV.transform.position;

		yellowPlayerI_Pos = yellowPlayerI.transform.position;
		yellowPlayerII_Pos = yellowPlayerII.transform.position;
		yellowPlayerIII_Pos = yellowPlayerIII.transform.position;
		yellowPlayerIV_Pos = yellowPlayerIV.transform.position;

		// Deactivating Players Round Borders
		redPlayerI_Border.SetActive (false);
		redPlayerII_Border.SetActive (false);
		redPlayerIII_Border.SetActive (false);
		redPlayerIV_Border.SetActive (false);

		yellowPlayerI_Border.SetActive (false);
		yellowPlayerII_Border.SetActive (false);
		yellowPlayerIII_Border.SetActive (false);
		yellowPlayerIV_Border.SetActive (false);

		bluePlayerI_Border.SetActive (false);
		bluePlayerII_Border.SetActive (false);
		bluePlayerIII_Border.SetActive (false);
		bluePlayerIV_Border.SetActive (false);

		greenPlayerI_Border.SetActive (false);
		greenPlayerII_Border.SetActive (false);
		greenPlayerIII_Border.SetActive (false);
		greenPlayerIV_Border.SetActive (false);

		redScreen.SetActive (false);
		greenScreen.SetActive (false);
		yellowScreen.SetActive (false);
		blueScreen.SetActive (false);

		// Initilaizing players here....
		switch (MainMenuManager.howManyPlayers) 
		{ 
		case 2:
			playerTurn = "RED";

			frameRed.SetActive (true);
			frameGreen.SetActive (false);

			diceRoll.position = redDiceRollPos.position;
			bluePlayerI.SetActive (false);
			bluePlayerII.SetActive (false);
			bluePlayerIII.SetActive (false);
			bluePlayerIV.SetActive (false);

			yellowPlayerI.SetActive (false);
			yellowPlayerII.SetActive (false);
			yellowPlayerIII.SetActive (false);
			yellowPlayerIV.SetActive (false);

			break;

		case 3:
			playerTurn = "RED";

			frameRed.SetActive (true);
			frameBlue.SetActive (false);
			frameYellow.SetActive (false);

			diceRoll.position = redDiceRollPos.position;
			greenPlayerI.SetActive (false);
			greenPlayerII.SetActive (false);
			greenPlayerIII.SetActive (false);
			greenPlayerIV.SetActive (false);

			break;

		case 4:
			playerTurn = "RED";

			frameRed.SetActive (true);
			frameGreen.SetActive (false);
			frameBlue.SetActive (false);
			frameYellow.SetActive (false);				

			diceRoll.position = redDiceRollPos.position;
			// keep all players active
			break;
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}