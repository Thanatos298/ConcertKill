using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void Iniciar() {
        SceneManager.LoadScene("GrayBoxing");
    }

    public void Salir() {
        Application.Quit();
    }
}
