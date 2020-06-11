using UnityEngine;

public sealed class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _moveVector;
    private int _laneNumber = 1;
    private int _lanesCount = 2;
    private bool _didChangeLastFrame = false;
    private float _speed = 5;
    private float _sideSpeed = 5;
    private readonly float _firstLanePos = 1.5f;
    private readonly float _laneDistance = -1.5f;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _moveVector = new Vector3(1, 0, 0);
    }

    private void Update()
    {
        _moveVector.x = _speed;
        _moveVector *= Time.deltaTime;

        float input = Input.GetAxis("Horizontal");

        if (Mathf.Abs(input) > 0.1f)
        {
            if (!_didChangeLastFrame)
            {
                _didChangeLastFrame = true;
                _laneNumber += (int)Mathf.Sign(input);
                _laneNumber = Mathf.Clamp(_laneNumber, 0, _lanesCount);
            }
        }
        else
        {
            _didChangeLastFrame = false;
        }

        Vector3 newPos = transform.position;
        newPos.z = Mathf.Lerp(newPos.z, _firstLanePos + (_laneNumber * _laneDistance), Time.deltaTime * _sideSpeed);
        transform.position = newPos;

        _characterController.Move(_moveVector);
    }
}