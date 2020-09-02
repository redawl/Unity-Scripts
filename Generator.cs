//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using org.mariuszgromada.math.mxparser;

public class Generator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject point;

    public InputField input;

    public Text SyntaxError;
    public double initialX;
    public double stepSize;
    public static double xBound = 50;
    public double C1;
    public double C2;
    public double omega;
    public double p;
    private GameObject[] graph = new GameObject[(int)(100000)];

    void Start()
    {
        SyntaxError.enabled = false;
        Generate();
    }

    // Update is called once per frame
    public void Generate(){
        double currX = initialX;
        double y = 0;
        Argument x = new Argument("x");
        Expression e = new Expression(input.text, x);

        if(e.checkSyntax() == false){
            SyntaxError.enabled = true;
        }
        else{
            SyntaxError.enabled = false;
            for(int i = 0; i < (int)(xBound / stepSize); i++){
                x.setArgumentValue(currX);
                y = e.calculate();
                graph[i] = Instantiate(point);
                if(Double.IsNaN(y))
                    y = 0;
                graph[i].transform.position = new Vector2((float)currX, (float)y);
                currX += stepSize;
            }
        }
    }

    public void DestroyGraph(){
        for(int i = 0; i < (int)(xBound / stepSize); i++){
            Destroy(graph[i]);
        }
    }
}
