using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _horizontalMovement;
    private float _verticalMovement;
    private Vector3 _movement;
    [SerializeField] private float _baseSpeed = 50f;
    [SerializeField] private float _boostedSpeed = 100f;
    [SerializeField] private float _boostDuration = 3f;

    private float _currentSpeed;
    private bool _isBoosted = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _currentSpeed = _baseSpeed;
    }

    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");

        _movement = new Vector3(_horizontalMovement, 0f, _verticalMovement);
        _movement.Normalize();
        _movement *= _currentSpeed * Time.deltaTime;
        _movement.y = _rb.linearVelocity.y;

        if (_rb != null)
        {
            _rb.linearVelocity = _movement;
        }
    }
    public void ActivateSpeedBoost()
    {
        if (!_isBoosted)
        {
            StartCoroutine(SpeedBoostCoroutine());
        }
    }

    private IEnumerator SpeedBoostCoroutine()
    {
        _isBoosted = true;
        _currentSpeed = _boostedSpeed;

        yield return new WaitForSeconds(_boostDuration);

        _currentSpeed = _baseSpeed;
        _isBoosted = false;
    }
}
