using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 20f;
    private float jumpForce = 16f;
    private float turnSpeed = 16f;

    //gravity
    private float gravityScale = 1.6f;
    private float globalGravity = -9.81f;

    private int currentLane;
    private float laneOffset = 7;
    private bool isGrounded = true;

    public static Animator anim;

    //crouching
    private CapsuleCollider coll;

    //projectile
    [SerializeField]
    private GameObject kunai;
    [SerializeField]
    private Transform attackPoint;

    public TextMeshProUGUI points;

    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<CapsuleCollider>();
        currentLane = 1;
        rb.useGravity = false;
        anim.Play("idle1");
        //gameObject.transform.GetChild(1).gameObject.SetActive(false);
        points.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.getInstance().isPlaying)
        {
            points.text = "Score: " + GameManager.getInstance().score;

            Vector3 gravity = globalGravity * gravityScale * Vector3.up;
            rb.AddForce(gravity, ForceMode.Acceleration);

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.getInstance().paused = !GameManager.getInstance().paused;
                
            }

            if (GameManager.getInstance().paused)
            {
                Time.timeScale = 0f;
                GameManager.getInstance().pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                GameManager.getInstance().pauseMenu.SetActive(false);
            }

            move();
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
                jump();
            if(Input.GetKeyDown(KeyCode.Z))
            {
                Instantiate(kunai, attackPoint.position, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded)
                crouch();
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

    void crouch()
    {
        anim.Play("roll");
        coll.center = new Vector3(0f, -0.3862723f, 0f);
        coll.height = 1.227459f;
        StartCoroutine("crouchCount");
    }

    IEnumerator crouchCount()
    {
        yield return new WaitForSeconds(1f);
        coll.center = new Vector3(0f, 0f, 0f);
        coll.height = 2;
        anim.Play("Run");
    }

    void death()
    {
        Time.timeScale = 0;
        //stop audio
        GameManager.getInstance().pauseMenu.transform.GetChild(0).gameObject.SetActive(false);
        GameManager.getInstance().pauseMenu.SetActive(true);
        GameManager.getInstance().isPlaying = false;
        GameManager.getInstance().paused = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            print("Dead");
            death();
            // anim.Play("Stumble Backwards");
            GameManager.getInstance().isPlaying = false;
        }

        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
            anim.Play("Run");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "section")
        {
            FindObjectOfType<SectionSpawner>().spawn();
            destroySec(other.gameObject);
        }
        else if (other.gameObject.tag== "sectionStay")
        {
            FindObjectOfType<SectionSpawner>().spawn();
        }
        else if (other.gameObject.tag == "petal")
        {
            GameManager.getInstance().score++;
            Destroy(other.gameObject);
        }
    }

    IEnumerator destroySec(GameObject sec)
    {
        yield return new WaitForSeconds(3f);
        Destroy(sec);
    }
}
