using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [SerializeField] private float bounceVelocity = 3.5f;

    private Rigidbody _ballRigidbody;

    public UnityEvent ballPassed;
    public UnityEvent touchedDangerZone;

    void Awake()
    {
        _ballRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Bounce ball in upward direction
        if (collision.gameObject.CompareTag("Platform"))
        {
            Vector3 velocity = _ballRigidbody.linearVelocity;
            _ballRigidbody.linearVelocity = new Vector3(velocity.x, bounceVelocity, velocity.z);
        }
        // Invoke event in case the pad is of Danger Type
        else if (collision.gameObject.CompareTag("Danger"))
        {
            touchedDangerZone?.Invoke();
        }
    }

    // Event for when ball passes a pad
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreTrigger"))
        {
            ballPassed?.Invoke();
        }
    }
}
