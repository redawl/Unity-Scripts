using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadScene : MonoBehaviour
{
    public Generator reloader;
    public void Restart(){
        reloader.DestroyGraph();
        reloader.Generate();
    }

    public void Quit(){
        Application.Quit();
    }
}
