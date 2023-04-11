using System.Collections;
using UnityEngine;

public class Hover : MonoBehaviour
{
    // Démarrage de la méthode loop au lancement du script.
    private void Start()
    {
        StartCoroutine(loop());
    }

    // Loop infini permettant à la plateforme de bouger, et de revenir à sa case départ lors de la fin du mouvement pour recommencer.
    private IEnumerator loop()
    {
        while (true)
        {
            for (int i = 0; i < 20; i++)
            {
                yield return new WaitForSeconds(0.1f);
                transform.Translate(new Vector3(0f, 0.05f, 0f));
            }
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < 20; i++)
            {
                yield return new WaitForSeconds(0.1f);
                transform.Translate(new Vector3(0f, -0.05f, 0f));
            }
        }
    }
}