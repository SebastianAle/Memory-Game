using UnityEngine;
using System.Collections;

public class SelectPuzzle : MonoBehaviour 
{
	[SerializeField]
	private GameManager gameManager;
	
	[SerializeField]
	private SelectLevel selectLevel;

	[SerializeField]
	private GameObject selectPuzzleMenuPanel, puzzlelevelSelectPanel;

	[SerializeField]
	private Animator selectPuzzleMenuAnim, puzzlelevelSelectAnim;

	private string selectedPuzzle;

	public void SelectedPuzzle()
	{
		selectedPuzzle = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

		gameManager.SetSelectedPuzzle (selectedPuzzle);

		selectLevel.SetSelectedPuzzle (selectedPuzzle);

		StartCoroutine (ShowPuzzleLevelSelectMenu ());

	}

	IEnumerator ShowPuzzleLevelSelectMenu()
	{
		puzzlelevelSelectPanel.SetActive (true);
		selectPuzzleMenuAnim.Play ("SlideOut");
		puzzlelevelSelectAnim.Play ("SlideIn");
		yield return new WaitForSeconds (1f);
		selectPuzzleMenuPanel.SetActive (false);
	}
}
