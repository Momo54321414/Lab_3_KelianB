using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRight : MonoBehaviour
{
    // Cr�ation de la variable _rb.
    private Rigidbody _rb;

    // Instanciation de la variable _rb et lancement du loop lors du lancement du script.
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        StartCoroutine(loop());
    }

    // Loop infini permettant � la balle d'�tre lanc�e dans une direction pr�cise.
    private IEnumerator loop()
    {
        while (true)
        {
            this.transform.position = new Vector3(-6.5f, 1.7f, 10f);

            _rb.AddForce(new Vector3(0f, 0f, 2500f));

            yield return new WaitForSeconds(2f);
        }
    }
}