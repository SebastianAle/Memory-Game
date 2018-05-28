using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SetupPuzzleGame : MonoBehaviour 
{
	[SerializeField]
	private GameManager gameManager;

	private Sprite[] candySprites, transportSprites, fruitSprites;

	[SerializeField]
	private List<Sprite> gamePuzzles = new List<Sprite> ();

	private List<Button> puzzleButtons = new List<Button> ();

	private List<Animator> puzzleButtonAnimators = new List<Animator>();

	private int level;
	private string selectedPuzzle;

	private int looper;



	void Awake () 
	{
		candySprites = Resources.LoadAll<Sprite> ("Sprites/Game Assets/Candy");
		transportSprites = Resources.LoadAll<Sprite> ("Sprites/Game Assets/Transport");
		fruitSprites = Resources.LoadAll<Sprite> ("Sprites/Game Assets/Fruits");
	}
	

	void PrepareGameSprites () 
	{
		gamePuzzles.Clear ();
		gamePuzzles = new List<Sprite> ();

		int index = 0;

		switch (level) 
		{
		case 0:
			looper = 6;
			break;

		case 1:
			looper = 12;
			break;

		case 2:
			looper = 18;
			break;

		case 3:
			looper = 24;
			break;

		case 4:
			looper = 30;
			break;
		}

		switch (selectedPuzzle) 
		{
		case "Candy Puzzle":
			for (int i = 0; i < looper; i++) 
			{
				if (index == looper / 2) 
				{
					index = 0;
				}

				gamePuzzles.Add (candySprites[index]);

				index++;
			}
			break;

		case "Transport Puzzle":
			for (int i = 0; i < looper; i++) 
			{
				if (index == looper / 2) 
				{
					index = 0;
				}

				gamePuzzles.Add (transportSprites[index]);

				index++;
			}
			break;

		case "Fruit Puzzle":
			for (int i = 0; i < looper; i++) 
			{
				if (index == looper / 2) 
				{
					index = 0;
				}

				gamePuzzles.Add (fruitSprites[index]);

				index++;
			}
			break;
		}

		Shuffle (gamePuzzles);
	}

	void Shuffle(List<Sprite> list)
	{
		for (int i = 0; i < list.Count; i++) 
		{
			Sprite temp = list [i];
			int randomIndex = Random.Range (i, list.Count);
			list [i] = list [randomIndex];
			list [randomIndex] = temp;
		}
	}

	public void SetLevelAndPuzzle(int level, string selectedPuzzle)
	{
		this.level = level;
		this.selectedPuzzle = selectedPuzzle;

		PrepareGameSprites ();

		gameManager.SetGamePuzzleSprites (this.gamePuzzles);
	}

	public void SetPuzzleButtonsAndAnimators(List<Button> puzzleButtons, List<Animator> puzzleButtonAnimators)
	{
		this.puzzleButtons = puzzleButtons;
		this.puzzleButtonAnimators = puzzleButtonAnimators;

		gameManager.SetButtonsAndAnimators (puzzleButtons, puzzleButtonAnimators);
	}























}

























