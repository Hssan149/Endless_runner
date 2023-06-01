using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 20f;
    private float jumpForce = 5f;
    private float turnSpeed = 14f;

    private int currentLane;
    private float laneOffset = 7;
    private bool isGrounded = true;

    [SerializeField]
    private Animator anim;

    private bool isPlaying = true;



    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        currentLane = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            move();
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
                jump();
        }
    }

    private void move()
    {
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        //Vector3 sides = transform.right * Time.deltaTime * turnSpeed * Input.GetAxisRaw("Horizontal");
        rb.MovePosition(rb.position + movement);

        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
        {
            currentLane++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--;
        }


        float xToGo = (currentLane - 1) * laneOffset;
        Vector3 taregtPosition = new Vector3(xToGo, rb.position.y, rb.position.z);

        rb.MovePosition(Vector3.MoveTowards(rb.position, taregtPosition, turnSpeed * Time.deltaTime));
    }

    void jump()
    {
        print(isGrounded);
        isGrounded = false;
        Vector3 up = transform.up * jumpForce;
        rb.AddForce(up, ForceMode.Impulse);
        anim.Play("Jump");

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            print("Dead");
           // anim.Play("Stumble Backwards");
            isPlaying = false;
        }

        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
            anim.Play("Running");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "section")
        {
            FindObjectOfType<SectionSpawner>().spawn();
            Destroy(other.gameObject);
        }
    }
}
