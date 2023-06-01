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
//design pattern: Decorator -> structural design pattern
//add (decorates) to the object withouth changing its original structure.
// structure-> main object is an interface, classes of that objects extendes that interface, decorator extend the main obj, main obj composites the decorator
// all decorations extends the decorator
// imp n java
//public class
//
//
//design pattern: flyweight || fly ?? creational and could be structual
//make  objects with unique values, when trying an object with a value that is used before a reference to an existing object rather than creating a new object every time.
//
// strategy, command, observer, factory, state
//
