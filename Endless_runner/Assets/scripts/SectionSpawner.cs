using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] sections;
    private float zPos = 294f;

    public void spawn()
    {
        Instantiate(sections[Random.Range(0, 3)], new Vector3(0f, 0f, zPos), Quaternion.identity);
        zPos += 147;
    }
}
