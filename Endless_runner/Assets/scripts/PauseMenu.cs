using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private GameObject player;
    public void resume()
    {
        GameObject.FindGameObjectWithTag("pause").SetActive(false);
        Time.timeScale = 1f;
        GameManager.getInstance().paused = false;
    }

    public void restart()
    {
        GameManager.getInstance().score = 0;
        player.transform.position = spawnPoint.transform.position;
        //show count down
        GameManager.getInstance().pauseMenu.transform.GetChild(0).gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("pause").SetActive(false);
        GameManager.getInstance().paused = false;
        GameManager.getInstance().isPlaying = true;
        Time.timeScale = 1f;
        SectionSpawner.zPos = 290f;
        GameObject [] sectionsRem = GameObject.FindGameObjectsWithTag("section");
        foreach(GameObject sec in sectionsRem)
        {
            Destroy(sec);
        }
    }

    public void mainMenu()
    {
        GameManager.getInstance().score = 0;
        player.GetComponent<Player>().points.gameObject.SetActive(false);
        gameObject.SetActive(false);
        player.transform.position = spawnPoint.transform.position;
        Time.timeScale = 1f;
        GameManager.getInstance().pauseMenu.transform.GetChild(0).gameObject.SetActive(true);
        Player.anim.Play("idle1");//change to idles array.
        GameManager.getInstance().isPlaying = false;
        GameManager.getInstance().paused = false;
        GameManager.getInstance().mainMenu.SetActive(true);
        SectionSpawner.zPos = 290f;
        GameObject[] sectionsRem = GameObject.FindGameObjectsWithTag("section");
        foreach (GameObject sec in sectionsRem)
        {
            Destroy(sec);
        }
    }

}
