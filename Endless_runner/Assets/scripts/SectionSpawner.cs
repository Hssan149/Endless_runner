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
        //if(temp.name.Contains("section4")|| temp.name.Contains("section5")|| temp.name.Contains("section6"))
         //   Instantiate(temp, new Vector3(-39f, 5.62f, zPos), Quaternion.identity);
    //    else
            Instantiate(temp, new Vector3(0f, 0f, zPos), Quaternion.identity);
        zPos += 147;
    }
}
