using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControleSalas : MonoBehaviour
{
    [Header("GERAL")]
    public int levelAtual;
    public Layout[] layouts;


    [Header("INIMIGOS")]
    public bool hasEnemy;
    public GameObject ranged;
    public GameObject melee;
    public GameObject tank;
    public GameObject papel;

    [Header("PROGRESSÃO")]
    public Level[] levels;
    public NavMeshSurface2d navMesh;
    public Animator elevadorEsq;
    public Animator elevadorDir;


    [Header("DEBUG")]
    public Level currentLevel;
    private Layout currentLayout;
    public List<GameObject> inimigosDisponiveis;//tipos de inimigos que podem ser spawnados no level atual
    private int currentLevelNumber = 0;
    [HideInInspector] public bool isShop = true;
    private bool oneTime;
    private bool oneTime2;


    private void Awake()
    {
        StartCoroutine(StartGameplay());
    }
    private void Start()
    {
        navMesh.BuildNavMeshAsync();
    }

    private void Update()
    {
        levelAtual = currentLevelNumber;
        hasEnemy = FindObjectOfType<EnemyHealth>();

        //if (Input.GetKeyDown(KeyCode.N)) NextLevel();

        //if(!hasEnemy && !oneTime)
        //{
        //    if (!oneTime)
        //    {
        //        elevadorDir.SetTrigger("Open");
        //        FindObjectOfType<AudioManager>().Play("ChegadaElevador");
        //        oneTime = true;
        //    }
        //}
        //else if(isShop)
        //{
        //    elevadorDir.SetTrigger("Close");
        //}
        if(hasEnemy && isShop)
        {

        }
        else
        {
            if (!hasEnemy && !isShop && !oneTime)
            {
                elevadorDir.SetTrigger("Open");
                oneTime = true;
            }
            if (!hasEnemy && isShop && oneTime || hasEnemy && !isShop && oneTime)
            {
                isShop = false;
                elevadorDir.SetTrigger("Close");
                print("1");
                oneTime = false;
            }
        
        }
 
        //if (hasEnemy && isShop) 
    }

    public void NextLevel()
    {
        isShop = true;
        StartCoroutine(StartGameplay()); 

        //currentLevelNumber++;
        //currentLevel = levels[currentLevelNumber - 1];

        //currentLayout = layouts[Random.Range(0, layouts.Length)];
        //currentLayout.visual.SetActive(true);

        //SpawnEnemies();
    }

    public void BakeNavMesh()
    {
        navMesh.BuildNavMeshAsync();

    }

    private void SpawnEnemies()
    {
        inimigosDisponiveis.Clear();

        if (currentLevel.inimigos.melee) inimigosDisponiveis.Add(melee);
        if (currentLevel.inimigos.ranged) inimigosDisponiveis.Add(ranged);
        if (currentLevel.inimigos.tank) inimigosDisponiveis.Add(tank);
        if (currentLevel.inimigos.papel) inimigosDisponiveis.Add(papel);

        foreach (Transform spawnpoint in currentLayout.spawnpoints)
        {
            Instantiate(inimigosDisponiveis[Random.Range(0, inimigosDisponiveis.Count)], spawnpoint.position, spawnpoint.rotation);
        }
    }

    IEnumerator StartGameplay()
    {
        
        elevadorDir.SetTrigger("Close");

        //FindObjectOfType<AudioManager>().Play("ArCondicionado");

        currentLevelNumber++;
        currentLevel = levels[currentLevelNumber - 1];

        if(currentLayout != null)currentLayout.visual.SetActive(false);

        currentLayout = layouts[currentLevelNumber - 1];
        currentLayout.visual.SetActive(true);

        yield return new WaitForSeconds(1f);
        elevadorEsq.SetTrigger("Open");
        BakeNavMesh();
        yield return new WaitForSeconds(2f);

        SpawnEnemies();
        oneTime = false;

    }
}

[System.Serializable]
public class Level
{
    public string name;
    public Inimigos inimigos;
    public bool temContrato;

}

[System.Serializable]
public class Inimigos
{
    public bool ranged;
    public bool melee;
    public bool tank;
    public bool papel;
}