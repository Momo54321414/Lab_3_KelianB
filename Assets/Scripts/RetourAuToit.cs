using UnityEngine;

public class RetourAuToit : MonoBehaviour
{
    // Création de la variable _player.
    private GestionJeu _gestionJeu;
    private Player _player;

    // Instanciation de la variable _player lors du lancement du script.
    void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _player = FindObjectOfType<Player>();
    }

    // Le joueur est téléporte sur un toit, choisi selon où il tombe.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(gameObject.tag == "Zone1")
            {
                _player.transform.position = new Vector3(-8f, 8.5f, -19.3f);
            }
            else
            {
                _player.transform.position = new Vector3(8.65f, 8.5f, 28f);
            }
        _gestionJeu.AugmenterPointage();
        }
    }
}