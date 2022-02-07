using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DARKTROXA : MonoBehaviour
{
    public string name;
    int dark;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dark == 3)
        {
            SceneManager.LoadScene(name);

        }
    }

    public void Dark()
    {
        dark++;
    }
}
