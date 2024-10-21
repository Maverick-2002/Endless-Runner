using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] Environment;
    public float PosZ;
    public bool creatingSection = false;
    public int SecNo;
    private float timeElapsed;

    // Update is called once per frame
    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(LevelGenerate());
        }
        Difficulty();
    }
    IEnumerator LevelGenerate()
    {
        SecNo = Random.Range(0, Environment.Length);
        GameObject newSection = Instantiate(Environment[SecNo], new Vector3(0, 0, PosZ), Quaternion.identity);
        PosZ += 100;
        yield return new WaitForSeconds(7f);
        creatingSection = false;
    }
    void Difficulty()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= 30)
        {
            timeElapsed = 0f;
            PlatformMovement.MoveSpeed *= 1.2f;
            UIManager.Instance.DifficultyUI();
            print(PlatformMovement.MoveSpeed);
        }
    }
}
