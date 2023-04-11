using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowLeft : MonoBehaviour
{
    // Création de la variable _rb.
    private Rigidbody _rb;

    // Instanciation de la variable _rb et lancement du loop lors du lancement du script.
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        StartCoroutine(loop());
    }

    // Loop infini permettant à la balle d'être lancée dans une direction précise.
    private IEnumerator loop()
    {
        while (true)
        {
            this.transform.position = new Vector3(-1.5f, 1.7f, -6.5f);

            _rb.AddForce(new Vector3(0f, 0f, -2500f));

            yield return new WaitForSeconds(2f);
        }
    }
}