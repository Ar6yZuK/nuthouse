using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Room : MonoBehaviour
{
	private BoxCollider2D _leftWall;
	private BoxCollider2D _bottomWall;
	private BoxCollider2D _rightWall;
	private BoxCollider2D _topWall;
	
	[SerializeField] private SpriteRenderer spriteSizeOfRoom;

	private void Awake()
	{
		_leftWall =   this.AddComponent<BoxCollider2D>();
		_rightWall =  this.AddComponent<BoxCollider2D>();
		_topWall =    this.AddComponent<BoxCollider2D>();
		_bottomWall = this.AddComponent<BoxCollider2D>();
	}
	private void Start()
	{
		Vector3 size = spriteSizeOfRoom.bounds.size;
		Debug.Log($"Room {SceneManager.GetSceneAt(0).name}: {size}");
		float xCenter = size.x / 2;
		float yCenter = size.y / 2;
		
		const float wallSize = 0.3f;
		_leftWall.offset = new(-xCenter, 0);
		_leftWall.size = new(wallSize, size.y);

		_rightWall.offset = new(xCenter, 0);
		_rightWall.size = new(wallSize, size.y);
		
		_topWall.offset = new(0, yCenter);
		_topWall.size = new(size.x, wallSize);

		_bottomWall.offset = new(0, -yCenter);
		_bottomWall.size = new(size.x, wallSize);
	}
}
