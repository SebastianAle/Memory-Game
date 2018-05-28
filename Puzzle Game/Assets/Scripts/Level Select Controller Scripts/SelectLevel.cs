using UnityEngine;
using System.Collections;

public class SelectLevel : MonoBehaviour 
{
	[SerializeField]
	private GameManager gameManager;

	[SerializeField]
	private LoadPuzzleGame loadPuzzleGame;

	[SerializeField]
	private GameObject selectPuzzleMenuPanel, puzzlelevelSelectPanel;

	[SerializeField]
	private Animator selectPuzzleMenuAnim, puzzlelevelSelectAnim;

	private string selectedPuzzle;


	public void BackToPuzzleSelectMenu()
	{
		StartCoroutine (ShowPuzzleSelectMenu ());
	}

	public void SelectPuzzleLevel()
	{
		int level = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

		gameManager.SetLevel (level);

		loadPuzzleGame.LoadPuzzle (level, selectedPuzzle);
	}

	IEnumerator ShowPuzzleSelectMenu()
	{
		selectPuzzleMenuPanel.SetActive (true);
		selectPuzzleMenuAnim.Play ("SlideIn");
		puzzlelevelSelectAnim.Play ("SlideOut");
		yield return new WaitForSeconds (1f);
		puzzlelevelSelectPanel.SetActive (false);
	}

	public void SetSelectedPuzzle(string selectedPuzzle)
	{
		this.selectedPuzzle = selectedPuzzle;
	}










}
