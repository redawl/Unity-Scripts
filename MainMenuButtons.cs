using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public void LaunchGrapher(){
        SceneManager.LoadScene("DiffEq");
    }

    public void LaunchVector(){
        SceneManager.LoadScene("VectorField");
    }
}
