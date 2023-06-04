using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public bool isPlaying = true;
    public bool paused = false;
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject settings;
    public int score = 0;

    public GameObject camera1;

    public static GameManager getInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<GameManager>();
            if (instance == null)
            {
                GameObject go = new GameObject();
                go.name = "GameManager";
                instance = go.AddComponent<GameManager>();
                DontDestroyOnLoad(go);
            }
        }
        return instance;

    }

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);//to disable destroying on loading a new scene, and it will stay maintained in all scenes.
        }
    }

    private void Start()
    {
        camera1.GetComponent<Animator>().enabled = false;
        isPlaying = false;
        mainMenu.SetActive(true);
        AudioManager.Instance.playMusic("sakuraBloom");
    }

    public void startGame()
    {
        camera1.GetComponent<Animator>().enabled = true;
        StartCoroutine("playAnim");
    }

    IEnumerator playAnim()
    {
        yield return new WaitForSeconds(7.5f);
        camera1.GetComponent<Animator>().enabled = false;
        Player.anim.Play("Run");
        getInstance().isPlaying = true;
    }

    private void Update()
    {
    }

}
