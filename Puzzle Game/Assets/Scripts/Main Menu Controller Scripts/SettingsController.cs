using UnityEngine;
using System.Collections;

public class SettingsController : MonoBehaviour 
{
	[SerializeField]
	private GameObject settingsPanel;

	[SerializeField]
	private Animator settingsPanelAnim;


	// Use this for initialization
	public void OpenSettingsPanel () 
	{
		settingsPanel.SetActive (true);
		settingsPanelAnim.Play ("SlideIn");
	}
	
	// Update is called once per frame
	public void CloseSettingsPanel () 
	{
		StartCoroutine (CloseSettings ());
	}

	IEnumerator CloseSettings()
	{
		settingsPanelAnim.Play ("SlideOut");
		yield return new WaitForSeconds (1f);
		settingsPanel.SetActive (false);
	}
}
