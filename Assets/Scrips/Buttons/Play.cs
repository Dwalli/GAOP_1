using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public void GotoScene(string sceneName){
       SceneManager.LoadScene(sceneName); 
    }

    public void QuitApp(){
        Application.Quit();
        Debug.Log("Game has been closed");
    }
    public void Pause(string sceneName){
        
    }
    public void LevelSelectBack(){
        
    }
    public void ControlsBack(){
        
    }
    public void ControlsTo(){
        
    }
}
