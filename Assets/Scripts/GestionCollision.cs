using System.Collections;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    // Création des variables du script.
    private GestionJeu _gestionJeu;
    private bool _touche = false;
    private Color _color;

    // Instanciation de _gestionJeu lors du lancement du script.
    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
    }

    // Rendre l'objet touché rouge si l'objet de la collision est le joueur ET que l'objet n'est pas en état "touché".
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && !_touche)
        {
            _touche = true;
            _color = gameObject.GetComponent<MeshRenderer>().material.color;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            _gestionJeu.AugmenterPointage();
            StartCoroutine(cooldown());
        }
    }

    // Temps d'attente de 4 secondes avant le retour à l'état "non-touché" de l'objet.
    private IEnumerator cooldown()
    {
        yield return new WaitForSeconds(4f);
        gameObject.GetComponent<MeshRenderer>().material.color = _color;
        _touche = false;
    }
}