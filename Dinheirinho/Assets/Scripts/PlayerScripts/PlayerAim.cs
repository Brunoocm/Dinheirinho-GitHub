using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    Animator anim => GetComponent<Animator>();
    void Start()
    {
        
    }

    void Update()
    {
        MousePos();
    }

    void MousePos()
    {
        Vector2 mouse = Input.mousePosition;

        Vector2 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        Vector2 finalPos = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);

        anim.SetFloat("Horizontal", finalPos.x);
        anim.SetFloat("Vertical", finalPos.y);
    }
}
