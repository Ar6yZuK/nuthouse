using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI textShownWhenStay;
	[SerializeField] private Camera cameraToDisable;
	[SerializeField] private string cameraTagToEnable;
	[SerializeField] private int doorIdToEnter;
	[SerializeField] private int doorId;
	
	private Door[] _doors;
	private Camera[] _cameras;

	private void Start()
	{
		_doors = FindObjectsOfType<Door>();
		_cameras = FindObjectsOfType<Camera>(true);
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") )
			textShownWhenStay.enabled = true;
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
			textShownWhenStay.enabled = false;
	}
	public void Enter(Player playerToEnter)
	{
		Enter(playerToEnter.gameObject);
        
		cameraToDisable.enabled = false;
		SetEnabled(GetCameraByTag(cameraTagToEnable), true);
		return;

		static void SetEnabled(Camera camera, bool enabled)
		{
			Debug.Assert(camera);
			camera.enabled = enabled;
		}
	}
	public void Enter(GameObject objectToEnter)
    {
		AudioDontDestroy.DoorAudio.Play();

		// When completed we already on new scene. And getting objects from new scene
		Door doorToEnter = GetDoorById(doorIdToEnter);
		Debug.Assert(doorToEnter);
		objectToEnter.transform.position = doorToEnter.transform.position;
	}
	
	[CanBeNull]
	private Camera GetCameraByTag(string cameraTag)
	{
		for (var i = 0; i < _cameras.Length; i++)
		{
			if(_cameras[i].CompareTag(cameraTag))
				return _cameras[i];
		}

		return null;
	}
	[CanBeNull]
	private Door GetDoorById(int id)
	{
		Door doorToEnter = null;
		for (var i = 0; i < _doors.Length; i++)
		{
			if (_doors[i].doorId == id)
				doorToEnter = _doors[i];
		}

		return doorToEnter;
	}
}