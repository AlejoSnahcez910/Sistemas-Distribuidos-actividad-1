using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioRick : MonoBehaviour
{
   public void CambiarEscena()
    {
        SceneManager.LoadScene("Rick");
    }
}
