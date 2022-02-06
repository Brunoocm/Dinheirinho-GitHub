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

    public AudioSource audioSource;
    public AudioClip trilhaCombate;
    public AudioClip trilhaLoja;

    private float timer;
    private float volume;
    private bool decrease;
    GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        volume = audioSource.volume;

    }

    void Update()
    {
        playLojaAudio();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!controleSalas.isShop)
            {
                StartCoroutine(OpenLojaWait());
                decrease = true;
            }
        }
    }

    IEnumerator OpenLojaWait()
    {
        elevadorDir.SetTrigger("Close");
        transicao.SetTrigger("TelaPreta");
        yield return new WaitForSeconds(1f);
        controleSalas.isShop = true;
        player.transform.position = pos.transform.position;
        lojaObj.SetActive(true);
        acordosShop.OpenShop();
    }

    public void playLojaAudio()
    {

        if(decrease)
        {
            if(audioSource.volume > 0)
            {
                audioSource.volume -= Time.deltaTime * 0.2f;
            }
            else
            {
                if (audioSource.clip == trilhaCombate)
                {
                    audioSource.clip = trilhaLoja;
                    audioSource.Play();
                    decrease = false;
                }
                else if (audioSource.clip == trilhaLoja)
                {
                    audioSource.clip = trilhaCombate;
                    audioSource.Play();
                    decrease = false;
                }

            }
        }
        else
        {
            if(audioSource.volume < volume)
            {
                audioSource.volume += Time.deltaTime * 0.2f;
            }
        }
    }

    public void PlayRoomAudio()
    {
        decrease = true;
    }

}
