using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class Room : MonoBehaviour
{
	private BoxCollider2D _leftWall;
	private BoxCollider2D _bottomWall;
	private BoxCollider2D _rightWall;
	private BoxCollider2D _topWall;

	[SerializeField] private SpriteRenderer spriteSizeOfRoom;
	[SerializeField] private float wallSize = 0.3f;

	[ContextMenu("Remove all walls(destroys all BoxCollider2D components)")]
	private void RemoveAllBoxColliders2D()
	{
		var walls = GetComponents<BoxCollider2D>();
		for (int i = 0; i < walls.Length; i++)
		{
			DestroyImmediate(walls[i]);
		}
	}
	[ContextMenu("Add walls")]
	private void AddBoxColliders2D()
	{
		List<BoxCollider2D> walls = new();
		GetComponents(walls);
		if (walls.Count > 4)
		{
			Debug.LogWarning("BoxCollider2Ds more than 4. Do not adding more walls");
		}
		else if (walls.Count is not 4)
		{
			int wallsNeedToAdd = 4 - walls.Count;
			Debug.LogWarning($"BoxCollider2Ds is not 4. Adding {wallsNeedToAdd} walls");

			for (int i = 0; i < wallsNeedToAdd; i++)
				walls.Add(this.AddComponent<BoxCollider2D>());
		}

		_leftWall = walls[0];
		_rightWall = walls[1];
		_topWall = walls[2];
		_bottomWall = walls[3];
		
		SetSizes();
	}
	private void SetSizes()
	{
		Vector3 size = spriteSizeOfRoom.bounds.size;
		Debug.Log($"Room {SceneManager.GetActiveScene().name}: {size}");
		float xCenter = size.x / 2;
		float yCenter = size.y / 2;

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