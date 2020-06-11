using UnityEngine;

public sealed class LorryMovement : MonoBehaviour
{
    private float _speed = 5.0f;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }
}