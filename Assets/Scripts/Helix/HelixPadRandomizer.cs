using UnityEngine;

public class HelixPadRandomizer : MonoBehaviour
{
    [SerializeField]
    [Range(2, 5)]
    private int _partsToModify = 5;

    void OnEnable()
    {
        // Count of pads to hide or set to danger type
        int count = Random.Range(1, _partsToModify);

        for (int i = 0; i < count; i++)
        {
            // Randomly select one pad bit out of 8
            int childIndex = Mathf.FloorToInt(Random.Range(0, 7));

            // Always hide the first part to make sure player has at least one gap to fall through
            if (i == 0)
            {
                transform.GetChild(childIndex).gameObject.SetActive(false);
                continue;
            }

            // Half chance of the selected child either to be disabled or set to Danger pad
            if (Random.value < 0.5)
            {
                transform.GetChild(childIndex).gameObject.SetActive(false);
            }
            else
            {
                // Set platform part to Danger
                transform.GetChild(childIndex).GetChild(0).gameObject.SetActive(false);
            }
            
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
