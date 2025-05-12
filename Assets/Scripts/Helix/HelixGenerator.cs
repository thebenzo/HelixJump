using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _helixPad;
    [SerializeField] private int _initialPadCount = 6;
    [SerializeField] private float _yOffset = -0.3f;

    // Object pool of instantiated helix pads (alternatively, we can use dequeue)
    private List<GameObject> _helixPads = new List<GameObject>();

    private float _yStartPos = 1.15f;
    private float _yCurrentPos;
    private int _padIndex = 0;

    private Transform _helixCylinder;
    private Transform _padParent;

    void Awake()
    {
        _helixCylinder = transform.GetChild(0);
        _padParent = transform.GetChild(1);
        _yCurrentPos = _yStartPos;
    }

    void Start()
    {
        for (int i = 0; i < _initialPadCount; i++)
        {
            // Spawn pad and add it to pool
            _yCurrentPos += _yOffset;
            Vector3 spawnPos = new Vector3(0, _yCurrentPos, 0);
            GameObject pad = Instantiate(_helixPad, _padParent);
            pad.transform.localPosition = spawnPos;

            // Ensure the first pad has no danger tile at ball spawn position;
            if (i == 0)
            {
                pad.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                pad.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
            }

            _helixPads.Add(pad);
        }
    }

    public void UpdateHelixPads()
    {
        // Iterate over pads without going out of bounds of the list
        GameObject currPad = _helixPads[_padIndex++ % _initialPadCount];

        currPad.SetActive(false);

        // Move passed helix pad to bottom
        _yCurrentPos += _yOffset;
        currPad.transform.localPosition = new Vector3(0, _yCurrentPos, 0);

        // Shift Helix Cylinder Mesh down by an offset
        _helixCylinder.localPosition += new Vector3(0, _yOffset, 0);

        currPad.SetActive(true);
    }
}
