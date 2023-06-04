using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEffect : MonoBehaviour
{
    private GameObject follow;
    void Start()
    {
        follow=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(follow.transform.position.x, 18.84212f, follow.transform.position.z);
    }
}
