using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	private Rigidbody2D _rigidBody;
	private float _horizontalInput;
	private bool _isGrounded;

	[SerializeField] private float _jumpForce = 10f;
	[SerializeField] private float _moveSpeed = 5f;
	[SerializeField] private float _fallMultiplier = 2.5f;
	[SerializeField] private float _lowJumpMultiplier = 2f;
	[SerializeField] private Transform _groundCheck;
	[SerializeField] private float _groundCheckRadius = 0.2f;
	[SerializeField] private LayerMask _whatIsGround;

	private void Awake()
	{
		_rigidBody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		_isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _whatIsGround);

		if (_rigidBody.linearVelocity.y < 0)
		{
			_rigidBody.linearVelocity += Vector2.up * (Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime);
		}
		else if (_rigidBody.linearVelocity.y > 0 && !Input.GetButton("Jump"))
		{
			_rigidBody.linearVelocity += Vector2.up * (Physics2D.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime);
		}
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		Vector2 moveInput = context.ReadValue<Vector2>();
		_horizontalInput = moveInput.x;
	}

	public void OnJump(InputAction.CallbackContext context)
	{
		if (context.performed && _isGrounded)
		{
			_rigidBody.linearVelocity = new Vector2(_rigidBody.linearVelocity.x, 0f);
			_rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
		}
	}

	private void FixedUpdate()
	{
		Vector2 velocity = new Vector2(_horizontalInput * _moveSpeed, _rigidBody.linearVelocity.y);
		_rigidBody.linearVelocity = velocity;
	}

	private void OnDrawGizmosSelected()
	{
		if (_groundCheck != null)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
		}
	}
}