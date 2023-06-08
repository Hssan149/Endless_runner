using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] sections;
    public static float zPos = 290f;

    public void spawn()
    {
        GameObject temp = sections[Random.Range(0, 2)];
        Instantiate(temp, new Vector3(0f, 0f, zPos), Quaternion.identity);
        zPos += 147;
    }
}
