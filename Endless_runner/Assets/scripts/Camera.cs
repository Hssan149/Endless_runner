using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform Player;

    private Vector3 offset;

    [SerializeField]
    private Animator anim;


    void Start()
    {
        offset = transform.position - Player.position + new Vector3(0f, 1.75f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + offset;
    }

    public void disableAnim()
    {
        anim.enabled = false;
    }
}
