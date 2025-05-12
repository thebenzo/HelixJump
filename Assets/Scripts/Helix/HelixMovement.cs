using UnityEngine;
using UnityEngine.InputSystem;

public class HelixMovement : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 42.0f;

    private Vector2 _mouseDelta;
    private bool _leftMouseButtonDown;

    // Input action messages
    public void OnRotate(InputValue input)
    {
        _mouseDelta = input.Get<Vector2>();
    }

    public void OnRotateButton(InputValue input)
    {
        _leftMouseButtonDown = input.Get<float>() == 1;
    }

    void Update()
    {
        // Apply Y rotation to the helix only if player is holding left mouse button
        if (_leftMouseButtonDown)
        {
            float rotationY = _mouseDelta.x * _rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, -rotationY, Space.World);
        }
    }
}
