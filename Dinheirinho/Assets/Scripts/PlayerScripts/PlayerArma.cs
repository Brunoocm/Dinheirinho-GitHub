using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArma : MonoBehaviour
{
    public float offset;
    public GameObject maleta;

    float angle;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = maleta.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + offset);

        if(maleta.transform.position.x > transform.position.x)
        {
            sprite.flipY = false;
        }
        else
        {
            sprite.flipY = true;
        }

        if (maleta.transform.position.y > transform.position.y)
        {
            sprite.sortingLayerName = "PlayerLayer";
        }
        else
        {
            sprite.sortingLayerName = "PorCimaPlayer";
        }
    }
}
