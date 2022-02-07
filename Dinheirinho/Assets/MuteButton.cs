using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour
{
    public static MuteButton value;

    private void Awake()
    {
        if (value == null)
        {
            value = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (value != this)
        {
            Destroy(gameObject);
        }
    }

    public void Mute()
    {
        //
    }

    public void Unmute()
    {
        //
    }
}
