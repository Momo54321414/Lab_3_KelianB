using UnityEngine;
using UnityEngine.SceneManagement;

public class Fin : MonoBehaviour
{
    // Création des variables du script.
    private GestionJeu _gestionJeu;
    private Player _player;
    private int _pointage = 0;
    private bool end = false;

    // Instanciation des objets _gestionJeu et _player lors du lancement du script.
    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _player = FindObjectOfType<Player>();
    }

    // Quitter le jeu en enfoncant ESCAPE lorsque la partie est terminée.
    private void FixedUpdate()
    {
        if(end == true)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    //Terminer le jeu si nous sommes déja au niveau 3. Sinon, charger le prochain niveau.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (sceneIndex == 1)
            {
                SceneManager.LoadScene(2);
                /*_gestionJeu.setTemps1(Time.time);
                _gestionJeu.setPts1(_gestionJeu.getPointage());
                _gestionJeu.setScore1(Time.time + _gestionJeu.getPointage());*/
            }
            else if (sceneIndex == 2)
            {
                SceneManager.LoadScene(3);
                /*_gestionJeu.setTemps2(Time.time - _gestionJeu.getTemps1());
                _gestionJeu.setPts2(_gestionJeu.getPointage() - _gestionJeu.getPts1());
                _gestionJeu.setScore2(_gestionJeu.getTemps2() + _gestionJeu.getPts2());*/
            }
            else
            {
                end = true;
                _player.end();
                gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                _gestionJeu.SetStatsFin();
                _gestionJeu.CacherGUI();
                _gestionJeu.AfficherFin();
                Debug.Log("GAME OVER");
                /*_gestionJeu.setTemps3(Time.time - _gestionJeu.getTemps2() - _gestionJeu.getTemps1());
                _gestionJeu.setPts3(_gestionJeu.getPointage() - _gestionJeu.getPts2() - _gestionJeu.getPts1());
                _gestionJeu.setScore3(_gestionJeu.getTemps3() + _gestionJeu.getPts3());
                Debug.Log("[NIVEAU 1] Score: " + _gestionJeu.getScore1() + " (Temps: " + _gestionJeu.getTemps1() + ") (Collisions: " + _gestionJeu.getPts1() + ")");
                Debug.Log("[NIVEAU 2] Score: " + _gestionJeu.getScore2() + " (Temps: " + _gestionJeu.getTemps2() + ") (Collisions: " + _gestionJeu.getPts2() + ")");
                Debug.Log("[NIVEAU 3] Score: " + _gestionJeu.getScore3() + " (Temps: " + _gestionJeu.getTemps3() + ") (Collisions: " + _gestionJeu.getPts3() + ")");
                Debug.Log("[TOTAL] Score: " + (Time.time + _gestionJeu.getPointage()) + " (Temps: " + Time.time + ") (Collisions: " + _gestionJeu.getPointage() + ")");*/
            }
        }
    }
}