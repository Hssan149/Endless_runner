using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    // Start is called before the first frame update
    public void goBack()//closed the audio settings menu
    {
        gameObject.SetActive(false);
        GameManager.getInstance().mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
