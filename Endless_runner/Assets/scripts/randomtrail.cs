using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomtrail : MonoBehaviour
{
    private TrailRenderer tr;
    private float duration;
    private float timestamp;
    void Start()
    {
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timestamp + duration)
        {
            duration = Random.Range(0.05f, 0.3f);
            timestamp = Time.time;
            tr.emitting = !tr.emitting;
        }
    }
}
