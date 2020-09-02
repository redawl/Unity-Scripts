using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    Camera Main;
    Transform MainTransform;
    Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        Main = GetComponent<Camera>();
        MainTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) == false){
            temp = Input.mousePosition + new Vector3(0, 0, -20f);
        }
        if(Main.orthographicSize + Input.mouseScrollDelta.y > 0 && Main.orthographicSize + Input.mouseScrollDelta.y < 15)
            Main.orthographicSize += Input.mouseScrollDelta.y;

        if(Input.GetMouseButton(0)){
            MainTransform.position += ((temp - Input.mousePosition) / (1 / (Main.orthographicSize / 400))) + new Vector3(0, 0, temp.z / (1 / (Main.orthographicSize / 400)));
            temp = Input.mousePosition;
        }
    }
}
