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
    [HideInInspector] public bool isShop;


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

        if(!hasEnemy && !isShop)
        {
            elevadorDir.SetTrigger("Open");
        }
        else
        {
            elevadorDir.SetTrigger("Close");
        }
    }

    public void NextLevel()
    {
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

        foreach (Transform spawnpoint in currentLayout.spawnpoints)
        {
            Instantiate(inimigosDisponiveis[Random.Range(0, inimigosDisponiveis.Count)], spawnpoint.position, spawnpoint.rotation);
        }
    }

    IEnumerator StartGameplay()
    {
        elevadorDir.SetTrigger("Close");
        currentLevelNumber++;
        currentLevel = levels[currentLevelNumber - 1];

        if(currentLayout != null)currentLayout.visual.SetActive(false);

        currentLayout = layouts[currentLevelNumber - 1];
        currentLayout.visual.SetActive(true);

        isShop = false;
        yield return new WaitForSeconds(1f);

        elevadorEsq.SetTrigger("Open");
        BakeNavMesh();
        yield return new WaitForSeconds(2f);
        
        SpawnEnemies();
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
}