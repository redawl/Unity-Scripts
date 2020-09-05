using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private bool toggle = true;
    public void Restart(){
        SceneManager.LoadScene("SampleScene");
    }

    public void toggleTime(){
        if(toggle == true){
            Application.targetFrameRate = 0;
        }
        else{
            Application.targetFrameRate = -1;
        }
        toggle = !toggle;
        print(toggle);
    }

    public void quitsort(){
        Application.Quit();
    }
}
