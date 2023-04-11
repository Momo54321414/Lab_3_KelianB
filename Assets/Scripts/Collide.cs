using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Collide : MonoBehaviour
{
    // Instanciation des variables du script.
    [SerializeField] private List<GameObject> _listePieges = new List<GameObject>();
    private List<Rigidbody> _listeRb = new List<Rigidbody>();
    private bool isActv = false;

    // On remplit la liste des pièges lors du lancement du script.
    private void Start()
    {
        foreach(var piege in _listePieges)
        {
            _listeRb.Add(piege.GetComponent<Rigidbody>());
        }
    }

    // Laisser tomber les objets de la liste lors du toucher de la zone trigger.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isActv)
        {
            isActv = true;
            foreach(var rb in _listeRb)
            {
                rb.useGravity = true;
                rb.AddForce(new Vector3(0f, 200f, 400f));
            }
        }
    }
}