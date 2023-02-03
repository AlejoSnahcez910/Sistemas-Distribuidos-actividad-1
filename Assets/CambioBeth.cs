using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioBeth : MonoBehaviour
{
    public void CambiarEscena()
    {
        SceneManager.LoadScene("Beth");
    }
}