using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioJerry : MonoBehaviour
{
    public void CambiarEscena()
    {
        SceneManager.LoadScene("Jerry");
    }
}
