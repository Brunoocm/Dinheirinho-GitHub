using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public UnityEvent evento;
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
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            evento.Invoke();
        }
    }
}
