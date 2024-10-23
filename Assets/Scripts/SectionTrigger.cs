using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject[] mapPrefabs;
    public GameObject[] initialPlatforms;
    private GameObject lastMap;
    public float mapOffset = 104f;
    public string triggerTag = "Destroy";

    void Start()
    {
        if (initialPlatforms.Length >= 3)
        {
            lastMap = initialPlatforms[initialPlatforms.Length - 1];
        }
        else
        {
            Debug.LogError("Not enough initial platforms assigned!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            Vector3 lastMapPosition = lastMap.transform.position;
            Vector3 newMapPosition = new Vector3(lastMapPosition.x, lastMapPosition.y, lastMapPosition.z + mapOffset);
            GameObject randomMap = mapPrefabs[Random.Range(0, mapPrefabs.Length)];
            lastMap = Instantiate(randomMap, newMapPosition, Quaternion.identity);
        }
    }
}
