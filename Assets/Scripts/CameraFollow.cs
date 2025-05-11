using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;

    [SerializeField]
    private Vector3 _cameraOffset = new Vector3(-2.0f, 1.1f, 0.0f);

    [SerializeField]
    private float _easeSpeed = 0.125f;

    [SerializeField]
    private float _verticalDampingZone = 0.4f;

    private float _currentY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentY = _target.transform.position.y + _cameraOffset.y;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LateUpdate()
    {
        Vector3 targetPos = _target.transform.position + _cameraOffset;

        if (Mathf.Abs(targetPos.y - _currentY) > _verticalDampingZone)
        {
            _currentY = Mathf.Lerp(_currentY, targetPos.y, _easeSpeed * Time.deltaTime);

            transform.position = new Vector3(targetPos.x, _currentY, targetPos.z);
        }
    }
}
