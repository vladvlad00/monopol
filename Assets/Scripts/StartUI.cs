using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    public Camera cam;
    public float x = 0, y = 0, z = 0;

    void Start()
    {
    }

    
    void Update()
    {
            cam.transform.Translate(Vector3.right * Time.deltaTime * 100);
            cam.transform.LookAt(new Vector3(x,y,z));
    }

}
