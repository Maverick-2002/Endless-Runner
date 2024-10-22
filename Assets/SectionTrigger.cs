using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    // Array of map prefabs to spawn randomly from
    public GameObject[] mapPrefabs;

    // List to store references to the first three platforms (manually placed in the scene)
    public GameObject[] initialPlatforms;

    // Reference to the last spawned platform
    private GameObject lastMap;

    // Offset for new maps (104 units along the Z-axis)
    public float mapOffset = 104f;

    // Tag to detect when the map crosses (set this to the tag you want to compare)
    public string triggerTag = "Destroy"; // Make sure to set this to the appropriate tag

    // Start is called before the first frame update
    void Start()
    {
        // If there are at least 3 initial platforms, set the last one as the lastMap
        if (initialPlatforms.Length >= 3)
        {
            // Assume the last manually placed platform is the third one
            lastMap = initialPlatforms[initialPlatforms.Length - 1];
        }
        else
        {
            Debug.LogError("Not enough initial platforms assigned!");
        }
    }

    // Method called when an object enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has the specified tag
        if (other.CompareTag(triggerTag))
        {
            print("Trigger called");

            // Get the position of the last map (third or the most recently spawned one)
            Vector3 lastMapPosition = lastMap.transform.position;

            // Calculate the new map's position (add 104 units to the last map's Z position)
            Vector3 newMapPosition = new Vector3(lastMapPosition.x, lastMapPosition.y, lastMapPosition.z + mapOffset);

            // Randomly select ONE map from the array
            GameObject randomMap = mapPrefabs[Random.Range(0, mapPrefabs.Length)];

            // Spawn the selected map at the calculated position
            lastMap = Instantiate(randomMap, newMapPosition, Quaternion.identity);
        }
    }
}
