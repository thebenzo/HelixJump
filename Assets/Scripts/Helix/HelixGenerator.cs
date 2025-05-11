using UnityEngine;

public class HelixGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _helixPad;

    [SerializeField]
    private int _initialPadCount = 6;

    [SerializeField]
    private float _yOffset = -0.3f;

    private float _yPos = 1.15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < _initialPadCount; i++)
        {
            _yPos += _yOffset;
            Vector3 spawnPos = new Vector3(0, _yPos, 0);
            GameObject pad = GameObject.Instantiate(_helixPad, transform);
            pad.transform.localPosition = spawnPos;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
