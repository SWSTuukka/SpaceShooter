using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool paused = false;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
           if(paused == true)
            {
                paused = false;
            }
           else if(paused == false)
            {
                paused = true;
            }
        }



        if(paused == true)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if(paused != true)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
