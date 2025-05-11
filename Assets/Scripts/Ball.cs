using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float bounceVelocity = 3.5f;

    private Rigidbody _ballRigidbody;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreTrigger"))
        {
            Debug.Log("Yay");
        }
    }
}
