using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject[] sections;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Procedural Generation"))
        {
            int randomIndex = Random.Range(0, sections.Length);
            GameObject selectedSection = sections[randomIndex];
            Instantiate(selectedSection, new Vector3(0, 0, 141), Quaternion.identity);
        }
    }
}
