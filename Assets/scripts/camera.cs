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
        SetCameraPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) // kamera porusza się gdy wcisniety jest prawy klawisz myszy
            SetCameraPosition();

    }

    void SetCameraPosition()
    {
        float deltaX = Input.GetAxis("Mouse X"); // aktualna pozycja kursora
        float deltaY = Input.GetAxis("Mouse Y");

        AxisX += deltaY * speed; // przyspieszamu ruch kamery
        AxisY += deltaX * speed;


        AxisX = Mathf.Clamp(AxisX, -85f, 0f);

        var rotation = Quaternion.Euler(AxisX, AxisY, 0);
        transform.position = rotation * Vector3.forward * distance;

        transform.LookAt(Vector3.up*5f); //kamera patrzy na punkt skierowany do góry powyzej o 5f
    }
}
