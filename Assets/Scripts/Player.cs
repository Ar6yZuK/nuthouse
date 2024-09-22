using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
	[CanBeNull] private Door _stayWithDoor;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.TryGetComponent(out Door door))
		{
			_stayWithDoor = door;
			Debug.Log($"Stay on door {_stayWithDoor?.name}");
		}
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Door"))
		{
			Debug.Log($"Stop stay on door {_stayWithDoor?.name}");
			_stayWithDoor = null;
		}
	}
	private void Update()
	{
		if (_stayWithDoor && Input.GetKeyDown(KeyCode.Space))
			_stayWithDoor?.Enter(this);
	}
}