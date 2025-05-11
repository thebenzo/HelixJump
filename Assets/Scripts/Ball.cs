using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float bounceVelocity = 3.5f;

    private Rigidbody _ballRigidbody;

    public UnityEvent ballPassed;

    void Awake()
    {
        _ballRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Vector3 velocity = _ballRigidbody.linearVelocity;
            _ballRigidbody.linearVelocity = new Vector3(velocity.x, bounceVelocity, velocity.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreTrigger"))
        {
            ballPassed?.Invoke();
        }
    }
}
