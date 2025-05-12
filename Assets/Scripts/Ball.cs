using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _bounceVelocity = 3.5f;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip _bounce;
    [SerializeField] private AudioClip _death;

    [Header("Events")]
    public UnityEvent ballPassed;
    public UnityEvent touchedDangerZone;

    private Rigidbody _ballRigidbody;
    private AudioSource _audioSource;

    void Awake()
    {
        _ballRigidbody = gameObject.GetComponent<Rigidbody>();
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Bounce ball in upward direction
        if (collision.gameObject.CompareTag("Platform"))
        {
            Vector3 velocity = _ballRigidbody.linearVelocity;
            _ballRigidbody.linearVelocity = new Vector3(velocity.x, _bounceVelocity, velocity.z);
            _audioSource.PlayOneShot(_bounce);
        }
        // Invoke event in case the pad is of Danger Type
        else if (collision.gameObject.CompareTag("Danger"))
        {
            _audioSource.PlayOneShot(_death);
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
