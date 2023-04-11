using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionJeu : MonoBehaviour
{
    // Création de la variable pointage.
    private float _tempsDebut, _temps1, _temps2, _temps3, _score1, _score2, _score3;
    [SerializeField] private GameObject _menuInstructions = default;
    [SerializeField] private GameObject _interface = default;
    [SerializeField] private GameObject _menuPause = default;
    [SerializeField] private GameObject _menuFin = default;
    [SerializeField] private GameObject _UI = default;
    [SerializeField] private TMP_Text _txtFinCollisions = default;
    [SerializeField] private TMP_Text _txtFinTemps = default;
    [SerializeField] private TMP_Text _txtFinScore = default;
    [SerializeField] private Text _txtAccrochage = default;
    [SerializeField] private Text _txtTemps = default;
    private int _pts, _pts1, _pts2, _pts3;
    private bool _enPause = false, _aBouge = false;

    // Sauvegarde des données entre le passage des niveaux.
    private void Awake()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 0;
        _tempsDebut = Time.time;

        if (sceneIndex > 0)
        {
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(_UI);
        }
    }

    // Message indiquant le début du niveau actuel au lancement du script.
    private void Start()
    {
        Debug.Log("DÉBUT DU JEU");
    }

    // Mettre à jour l'interface à chaque frame du jeu.
    private void Update()
    {
        _txtAccrochage.text = "Collisions: " + _pts;
        _txtTemps.text = "Temps: " + (Time.time - _tempsDebut).ToString("f2");

        if (_aBouge == false && Input.GetKeyDown(KeyCode.W) && !_enPause)
        {
            Time.timeScale = 1;
            _aBouge = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !_enPause)
        {
            _enPause = true;
            _menuPause.active = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _enPause)
        {
            EnleverPause();
        }
    }

    // Afficher les statistiques finales de la partie.
    public void SetStatsFin()
    {
        _txtFinTemps.text = (Time.time - _tempsDebut).ToString("f2");
        _txtFinCollisions.text = _pts.ToString();
        _txtFinScore.text = ((Time.time - _tempsDebut) - _pts).ToString("f2");
    }

    // Afficher le menu de fin.
    public void AfficherFin()
    {
        _menuFin.active = true;
    }

    // Fermer le menu de fin.
    public void FermerFin()
    {
        _menuFin.active = false;
    }

    // Afficher le menu d'instructions.
    public void AfficherInstructions()
    {
        _menuInstructions.active = true;
    }

    // Fermer le menu d'instructions.
    public void FermerInstructions()
    {
        _menuInstructions.active = false;
    }

    // Cacher l'interface de base du joueur.
    public void CacherGUI()
    {
        _interface.active = false;
    }

    // Début la partie au niveau 1.
    public void debutPartie()
    {
        SceneManager.LoadScene(1);
    }

    // Quitter l'application.
    public void Quitter()
    {
        Application.Quit();
    }

    // Reprendre le cours du jeu.
    public void EnleverPause()
    {
        _menuPause.active = false;
        if (_aBouge) { Time.timeScale = 1; }
        _enPause = false;
    }

    // Tout réinitialiser lorsqu'on retourne au menu.
    public void RetourAuMenu()
    {
        Destroy(gameObject);
        Destroy(_UI);
        EnleverPause();
        FermerFin();
        resetPointage();
        SceneManager.LoadScene(0);
    }

    // Augmentation du pointage de 1.
    public void AugmenterPointage()
    {
        _pts++;
    }

    // Remetre le pointage à 0.
    public void resetPointage()
    {
        _pts = 0;
    }

    // Toutes les méthodes pour modifier et chercher les variables du script sont ci-dessous. Je n'ai pas mis de description individuelle car leur concept est répétitif.
    public int getPointage()
    {
        return _pts;
    }

    /*public void setTemps1(float t)
    {
        _temps1 = t;
    }

    public float getTemps1()
    {
        return _temps1;
    }

    public void setScore1(float s)
    {
        _score1 = s;
    }

    public float getScore1()
    {
        return _score1;
    }

    public void setPts1(int p)
    {
        _pts1 = p;
    }

    public int getPts1()
    {
        return _pts1;
    }

    public void setTemps2(float t)
    {
        _temps2 = t;
    }

    public float getTemps2()
    {
        return _temps2;
    }

    public void setScore2(float s)
    {
        _score2 = s;
    }

    public float getScore2()
    {
        return _score2;
    }

    public void setPts2(int p)
    {
        _pts2 = p;
    }

    public int getPts2()
    {
        return _pts2;
    }

    public void setTemps3(float t)
    {
        _temps3 = t;
    }

    public float getTemps3()
    {
        return _temps3;
    }

    public void setScore3(float s)
    {
        _score3 = s;
    }

    public float getScore3()
    {
        return _score3;
    }

    public void setPts3(int p)
    {
        _pts3 = p;
    }

    public int getPts3()
    {
        return _pts3;
    }*/
}