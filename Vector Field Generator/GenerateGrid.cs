using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using org.mariuszgromada.math.mxparser;

public class GenerateGrid : MonoBehaviour
{
    public GameObject Grid;
    public GameObject Axis;
    private GameObject[,] graph = new GameObject[50, 50];
    private GameObject[] xAxis = new GameObject[50];
    private GameObject[] yAxis = new GameObject[50];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 50; i++){
            for(int j = 0; j < 50; j++){
                graph[i, j] = Instantiate(Grid);
                graph[i, j].transform.position = new Vector2(i - 20, j - 20);
                if(j == 0){
                    xAxis[i] = Instantiate(Axis, new Vector3(i, j, 0), Quaternion.identity);
                }
                
                if(i == 0){
                    yAxis[j] = Instantiate(Axis, new Vector3(i, j, 0), Quaternion.AngleAxis(90, Vector3.forward));
                }
            }
        }   
    }
}
