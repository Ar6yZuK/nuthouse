using JetBrains.Annotations;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShadowMovement : MonoBehaviour
{
	[SerializeField] private bool destroyOnDoorEnter;
	[SerializeField] [CanBeNull] private Door doorToEnter;
	[SerializeField] private float speed = 3f;
	
	private Rigidbody2D _rb;
	
	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (doorToEnter && other.TryGetComponent(out Door door) && door == doorToEnter)
		{
			door.Enter(gameObject);
			doorToEnter = null;
			if (destroyOnDoorEnter)
				Destroy(gameObject);
		}
	}
	private void FixedUpdate()
	{
		if (doorToEnter)
			_rb.MovePosition(_rb.position + (Vector2)doorToEnter.transform.position * (speed * Time.fixedDeltaTime));
	}
}
