using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pasueMenu;
    private bool isPuased;
    public void PauseMenuOpen(){
        pasueMenu.SetActive(true);
        Time.timeScale = 0f;
        isPuased = true;
    }

    public void PauseMenuClose(){
        pasueMenu.SetActive(false);
        Time.timeScale = 1f;
        isPuased = false;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPuased)
            {
               PauseMenuClose(); 
            }
            else
            {
                PauseMenuOpen();
            }
        }
    }
}
