using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
	private const string Floor = "Floor";
	
	private Rigidbody2D _rb;
	
	[SerializeField] private float speed = 3f;
	
	private bool _canUp = true;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
	}
	
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag(Floor))
			_canUp = false;
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag(Floor))
			_canUp = true;
	}

	private void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = _canUp ? Input.GetAxis("Vertical") : -1f;
		Vector2 moveVector = new Vector2(horizontal, vertical).normalized;

		_rb.MovePosition(_rb.position + moveVector * (speed * Time.fixedDeltaTime));

		if(horizontal is not 0)
			Rotate();
		
		return;
		void Rotate()
		{
			bool rotateLeft = horizontal < 0;
			Quaternion rotation = transform.rotation;
			rotation.y = rotateLeft ? 180 : 0;
			transform.rotation = rotation;
		}
	}
}