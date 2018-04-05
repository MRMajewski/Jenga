using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {


    float AxisX;
    float AxisY;

    public float distance = 30f; //odległość od środka 

    public float speed = 5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float deltaX= Input.GetAxis("Mouse X"); // aktualna pozycja kursora
        float deltaY = Input.GetAxis("Mouse Y");

        AxisX += deltaY * speed;
        AxisY += deltaX * speed;


        var rotation = Quaternion.Euler(AxisX, AxisY, 0);
        transform.position = rotation * Vector3.up * distance;

        transform.LookAt(Vector3.zero);
    }
}
