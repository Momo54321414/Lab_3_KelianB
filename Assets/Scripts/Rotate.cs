using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Permet à l'objet de se retourner sur un axe précis à une vitesse fixe en permanence.
    void FixedUpdate()
    {
        transform.Rotate(0f, 4f, 0f);
    }
}