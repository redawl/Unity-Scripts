using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class sorting : MonoBehaviour
{
    public GameObject data;
    public RestartButton timeController;
    GameObject [] grouping = new GameObject[1000];
    float [] colors = new float[1000];
    bool bubble = true;
    bool insertion = true;
    int index = 1;

    bool selection = true;
    int selindex = 0;

    int len;
    // Start is called before the first frame update
    void Start()
    {
        len = colors.Length;
        System.Random rand = new System.Random();
        for(int i = 0; i < len; i++){
            grouping[i] = Instantiate(data);
            colors[i] = rand.Next(1, 345);
            SetColor(grouping[i], colors[i]);
            grouping[i].transform.position = new Vector2(i, 0);
        }
    }

    void Update(){
        /*** Bubble Sort ***/
        if (bubble == false)
        {
            Time.timeScale = 0.01f;
            bubble = true;
            for (int i = 0; i < len - 1; i++)
            {
                if (colors[i] > colors[i + 1])
                {
                    swapColors(i, i + 1);
                    SetColor(grouping[i], colors[i]);
                    SetColor(grouping[i + 1], colors[i + 1]);
                    bubble = false;
                }
            }
        }
        Time.timeScale = 1;

        /*** Insertion Sort ***/
        if(!insertion && index < len){
            int i = index;
            while(i > 0 && colors[i - 1] > colors[i]){
                swapColors(i, i - 1);
                SetColor(grouping[i], colors[i]);
                i--;
            }
            index++;
        }

        /*** Selection Sort ***/
        if(!selection){
            if(selindex < len){
                int smallest = 0;
                for(int j = selindex; j < len; j++){
                    if(colors[j] < colors[smallest]){
                        smallest = j;
                    }
                }
                swapColors(selindex, smallest);
                SetColor(grouping[selindex], colors[selindex]);
                SetColor(grouping[smallest], colors[smallest]);
                selindex++;
            }
        }
    }
    void SetColor(GameObject obj, float color){
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        renderer.color = Color.HSVToRGB(color / 345, 1, .5f);
    }

    void swapColors(int a, int b){
        float temp = colors[a];
        colors[a] = colors[b];
        colors[b] = temp;
    }

    public void bubblesort(){
        bubble = !bubble;
    }

    public void insertionsort(){
        insertion = !insertion;
    }

    public void selectionsort(){
        selection = !selection;
    }

    public void quitgame() => Application.Quit();
}
