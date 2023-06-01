using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    private float speed = 40f;
    void Start()
    {
        StartCoroutine(destroy());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.z += speed * Time.deltaTime;
        transform.position = temp;
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
