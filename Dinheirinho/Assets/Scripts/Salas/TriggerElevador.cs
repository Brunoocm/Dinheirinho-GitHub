using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerElevador : MonoBehaviour
{
    public GameObject lojaObj;
    public ControleSalas controleSalas;
    public AcordosShop acordosShop;
    public Animator elevadorDir;
    public Animator transicao;
    public GameObject pos;
    GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(!controleSalas.isShop) StartCoroutine(OpenLojaWait());
        }
    }

    IEnumerator OpenLojaWait()
    {
        elevadorDir.SetTrigger("Close");
        transicao.SetTrigger("TelaPreta");
        controleSalas.isShop = true;
        yield return new WaitForSeconds(1f);
        player.transform.position = pos.transform.position;
        lojaObj.SetActive(true);
        acordosShop.OpenShop();
    }
}
