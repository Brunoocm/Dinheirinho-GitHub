using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleSalas : MonoBehaviour
{
    [Header("GERAL")]
    public int levelAtual;
    public Layout[] layouts;


    [Header("INIMIGOS")]
    public GameObject ranged;
    public GameObject melee;
    public GameObject tank;

    [Header("PROGRESSÃO")]
    public Level[] levels;


    [Header("DEBUG")]
    public Level currentLevel;
    private Layout currentLayout;
    public List<GameObject> inimigosDisponiveis;//tipos de inimigos que podem ser spawnados no level atual
    private int currentLevelNumber = 0;


    private void Awake()
    {
        NextLevel();
    }

    private void Update()
    {
        levelAtual = currentLevelNumber;
        if (Input.GetKeyDown(KeyCode.N)) NextLevel();
    }

    public void NextLevel()
    {
        currentLevelNumber++;
        currentLevel = levels[currentLevelNumber - 1];

        currentLayout = layouts[Random.Range(0, layouts.Length)];
        currentLayout.visual.SetActive(true);

        SpawnEnemies();
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