using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Permet � l'objet de se retourner sur un axe pr�cis � une vitesse fixe en permanence.
    void FixedUpdate()
    {
        transform.Rotate(0f, 4f, 0f);
    }
}