using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Création des variables du script.
    private bool climb = false;
    private Rigidbody _rb;

    // Instanciation de la variable _rb et limite du FPS du jeu à 50 lors du lancement du script.
    private void Start()
    {
        Application.targetFrameRate = 50;
        _rb = GetComponent<Rigidbody>();
    }

    // Détecte le mouvement du joueur selon les touches enfoncées du clavier.
    private void FixedUpdate()
    {
        float positionX = Input.GetAxis("Horizontal");
        float positionZ = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(positionX, 0f, positionZ);

        if (!climb)
        {
            _rb.velocity = direction * Time.fixedDeltaTime * 500f;
        }
        else
        {
            transform.Translate(direction.normalized * Time.deltaTime * 8f);
        }
    }

    // Activation de la variable d'état "climb".
    public void startClimb()
    {
        climb = true;

    }

    // Fin de la variable d'état "climb".
    public void endClimb()
    {
        climb = false;

    }

    // Retire le joueur du jeu lorsque la partie est terminée.
    public void end()
    {
        gameObject.SetActive(false);
    }
}