using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public bool IsSpecial = false;
    public bool Enabled = true;

    public Material NormalMaterial;
    public Material SpecialMaterial;

    void Start () {
        SetMaterial();
        Enabled = true;
}

    private void OnValidate() //funckja zadziała gdy zajdzie zmiana w inspektorze
    {
        SetMaterial();
    }

    void SetMaterial() // usawiamy materiał
    {
        var targetMaterial = IsSpecial ? SpecialMaterial : NormalMaterial; //sprawdzenie jaki to materiał

        var renderer = GetComponent<Renderer>();
        renderer.material = targetMaterial; // pobranie i przypisanie rendera

        //można skrócić i będzie tak o:
        //GetComponent<Renderer>().mateirial = IsSpecial ? SpecialMaterial : NormalMaterial;
    }

      private void OnMouseDrag()
        {
        if (FindObjectOfType<GameController>().IsPlaying == false) return;
        // w trakcie trwania korutyny gracz nie może nic zrobić, tzn podczas odliczania


        var cameraPosition = FindObjectOfType<Camera>().transform.position; // pobieramy pozycję kamery
        var direction = (cameraPosition - transform.position).normalized; // kierunek uzyskujemy odejmując pozycje kamery od pozycji klocka
        //normalize zwraca wektor o stałej długości

        GetComponent<Rigidbody>().AddForce(direction* 100f);

        }

}
