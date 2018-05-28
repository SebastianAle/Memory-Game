using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	[SerializeField]
	private List<Button> puzzleButtons = new List<Button> ();

	private List<Animator> puzzleButtonAnimators = new List<Animator> ();

	[SerializeField]
	private List<Sprite> gamePuzzleSprite = new List<Sprite>();

	private int level;
	private string selectedPuzzle;

	public void PickACard()
	{
		Debug.Log ("The selected Button is " + UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
//		int index = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
//
//		StartCoroutine (TurnCardUp(
//			puzzleButtonAnimators[index],
//			puzzleButtons[index],
//			gamePuzzleSprite[index]
//		));
	}

	void AddListeners ()
	{
		foreach (Button btn in puzzleButtons) 
		{
			btn.onClick.RemoveAllListeners ();
			btn.onClick.AddListener (() => PickACard());
		}
	}

	IEnumerator TurnCardUp(Animator anim, Button btn, Sprite cardImage)
	{
		anim.Play ("TurnUp");
		yield return new WaitForSeconds (.4f);
		btn.image.sprite = cardImage;
	}

	public void SetButtonsAndAnimators (List<Button> buttons, List<Animator> animators) 
	{
		this.puzzleButtons = buttons;
		this.puzzleButtonAnimators = animators;

		AddListeners ();
	}

	public void SetGamePuzzleSprites (List<Sprite> gamePuzzleSprite) 
	{
		this.gamePuzzleSprite = gamePuzzleSprite;
	}

	public void SetLevel (int level) 
	{
		this.level = level;
	}

	public void SetSelectedPuzzle (string selectedPuzzle) 
	{
		this.selectedPuzzle = selectedPuzzle;
	}
}
