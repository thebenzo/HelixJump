using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [Header("Position Settings")]
    [SerializeField] private Vector3 _cameraOffset = new Vector3(-2.0f, 1.1f, 0.0f);
    [SerializeField] private float _verticalDampingZone = 0.4f;
    [SerializeField] private float _easeSpeed = 0.125f;

    private float _currentY;

    void Start()
    {
        _currentY = _target.position.y + _cameraOffset.y;
    }

    void LateUpdate()
    {
        Vector3 targetPos = _target.position + _cameraOffset;

        if (Mathf.Abs(targetPos.y - _currentY) > _verticalDampingZone)
        {
            _currentY = Mathf.Lerp(_currentY, targetPos.y, _easeSpeed * Time.deltaTime);
        }

        transform.position = new Vector3(targetPos.x, _currentY, targetPos.z);
    }
}
