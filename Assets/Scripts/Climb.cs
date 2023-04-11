using UnityEngine;
using UnityEngine.SceneManagement;

public class Climb : MonoBehaviour
{
    private Player _player;

    // Instanciation de la variable _player.
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    // Activation du changement de physique requis pour grimper l'échelle lorsqu'on touche le trigger.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _player.startClimb();
        }
    }

    // Fin du changement de physique requis pour grimper l'échelle, selon certains niveaux, lorsqu'on sort de la zone trigger.
    private void OnTriggerExit(Collider other)
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex == 1 && other.gameObject.tag == "Player")
        {
            _player.endClimb();
        }
    }
}