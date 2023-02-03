using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioMorty : MonoBehaviour
{
    public void CambiarEscena()
    {
        SceneManager.LoadScene("Morty");
    }
}