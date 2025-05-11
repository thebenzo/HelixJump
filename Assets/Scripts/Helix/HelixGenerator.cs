using System.Collections;
using System.Collections.Generic;
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

    private int it = 0;

    private List<GameObject> _helixPads = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < _initialPadCount; i++)
        {
            _yPos += _yOffset;
            Vector3 spawnPos = new Vector3(0, _yPos, 0);
            GameObject pad = GameObject.Instantiate(_helixPad, transform.GetChild(1));
            pad.transform.localPosition = spawnPos;
            _helixPads.Add(pad);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHelixPads()
    {
        GameObject currPad = _helixPads[it++ % _initialPadCount];
        currPad.SetActive(false);

        _yPos += _yOffset;
        Vector3 newPos = new Vector3(0, _yPos, 0);
        currPad.transform.localPosition = newPos;

        Transform helixCylinder = transform.GetChild(0);
        helixCylinder.localPosition = new Vector3(helixCylinder.localPosition.x, helixCylinder.localPosition.y - 0.3f, helixCylinder.localPosition.z);

        currPad.SetActive(true);
    }
}
