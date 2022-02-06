using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ContratosShop : MonoBehaviour
{
    public EffectsContratos effectsContratos;

    public GameObject contrato;

    int randContract;

    private void Start()
    {
        RandomContract();
    }

    public void RandomContract()
    {
        randContract = Random.Range(0, 5);

        if (effectsContratos.boolean[randContract])
        {
            RandomContract();
        }
        else
        {
            AssignImage();
        }
    }

    void AssignImage()
    {
        switch (randContract)
        {
            case 0:
                contrato.GetComponent<Image>().sprite = effectsContratos.acabouLuz.sprite;

                break;
            case 1:
                contrato.GetComponent<Image>().sprite = effectsContratos.skillDrunk.sprite;

                break;
            case 2:
                contrato.GetComponent<Image>().sprite = effectsContratos.skillPoision.sprite;

                break;
            case 3:
                contrato.GetComponent<Image>().sprite = effectsContratos.skillDanoArea.sprite;

                break;
            case 4:
                contrato.GetComponent<Image>().sprite = effectsContratos.skillHoraExtra.sprite;

                break;
        }
    }

    public void Aceita()
    {
        effectsContratos.boolean[randContract] = true;
        Invoke("DesligaContrato", 1);
    }

    void DesligaContrato()
    {
        gameObject.SetActive(false);
    }

    public void Recusa()
    {
        //
    }
}
