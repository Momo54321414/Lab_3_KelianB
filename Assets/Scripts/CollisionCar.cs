using System.Collections;
using UnityEngine;

public class CollisionCar : MonoBehaviour
{
    // Création des variables du script.
    private GestionJeu _gestionJeu;
    private Player _player;

    // Instanciation de _gestionJeu et _player au lancement du script.
    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _player = FindObjectOfType<Player>();
    }

    // Le joueur retourne au départ, et devient noir pendant 1 seconde, s'il percute une voiture.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _player.GetComponent<MeshRenderer>().material.color = Color.black;
            _player.transform.position = new Vector3(0f, 0.5f, -28f);
            _gestionJeu.AugmenterPointage();
            StartCoroutine(cooldown());
        }
    }

    // Temps d'attente d'une seconde avant le retour à l'état "non-touché" du joueur.
    private IEnumerator cooldown()
    {
        yield return new WaitForSeconds(1f);
        _player.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}