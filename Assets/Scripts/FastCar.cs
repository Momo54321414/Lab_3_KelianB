using System.Collections;
using UnityEngine;

public class FastCar : MonoBehaviour
{
    // Démarrage de la méthode loop au lancement du script.
    void Start()
    {
        StartCoroutine(loop());
    }

    // Loop infini permettant aux voitures de bouger, et de revenir à leur case départ lors de la fin du mouvement pour recommencer.
    private IEnumerator loop()
    {
        yield return new WaitForSeconds(Random.Range(0, 6));

        while (true)
        {
            for (int i = 0; i < 37; i++)
            {
                yield return new WaitForSeconds(0.02f);
                transform.Translate(new Vector3(0f, -2f, 0f));
            }

            transform.Translate(new Vector3(0f, 74f, 0f));
        }
    }
}