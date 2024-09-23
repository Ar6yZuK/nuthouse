using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
	[SerializeField] private GameObject panelToShow;
	[SerializeField] private ShadowMovement shadowMovement;
	[SerializeField] private Door doorToEnterShadow;

	private void Start()
	{
		StartCoroutine(OnStartCoroutine());
	}

	private IEnumerator OnStartCoroutine()
	{
		float time = Time.timeScale;
		Time.timeScale = 0f;
		
		shadowMovement.DoorToEnter = null;
		panelToShow.SetActive(true);
		yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
		Time.timeScale = time;
		panelToShow.SetActive(false);
		shadowMovement.DoorToEnter = doorToEnterShadow;
	}
}