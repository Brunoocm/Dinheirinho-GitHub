using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadA(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
