using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using org.mariuszgromada.math.mxparser;
using System;
using UnityEngine.UI;

public class VectorFieldGen : MonoBehaviour
{
    Argument x = new Argument("x");
    Argument y = new Argument("y");

    GameObject [,] vectors = new GameObject[62, 62];//For storing all the current vectors

    public InputField xInput;
    public InputField yInput;
    Expression xPrime;
    Expression yPrime;

    public GameObject vector;
    public GameObject point;

    public void Generate(){
        xPrime = new Expression(xInput.text, x, y);
        yPrime = new Expression(yInput.text, x, y);
        float currY = -30;
        float currX = -30;
        for(int i = 0; i < 60; i++){
            currY = -30;
            for(int j = 0; j < 60; j++){
                x.setArgumentValue(currX);
                y.setArgumentValue(currY);
                double currxPrime = xPrime.calculate();
                double curryPrime = yPrime.calculate();
                double angle = 0;
                if(currxPrime == 0){
                    if(curryPrime > 0)
                        angle = 90;
                    else
                        angle = -90;
                }
                else{
                    angle = Math.Atan(curryPrime / currxPrime) * (180 / Math.PI);
                    if(currxPrime <= 0){
                        angle += 180;
                    }
                }

                if(currxPrime != 0 || curryPrime != 0){
                    vectors[i, j] = Instantiate(vector);
                    vectors[i, j].transform.position = new Vector2(currX, currY);
                    vectors[i, j].transform.RotateAround(vectors[i, j].transform.position, new Vector3(0, 0, 1), (float)angle);
                }
                else{
                    vectors[i, j] = Instantiate(point);
                    vectors[i, j].transform.position = new Vector2(currX, currY);
                }
                currY++;
            }
            currX++;
        }
    }

    void DestroyVectors(){
        for(int i = 0; i < 60; i++){
            for(int j = 0; j < 60; j++){
                Destroy(vectors[i, j]);
            }
        }
    }

    public void Redraw(){
        DestroyVectors();
        Generate();
    }
}
