using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    public List<GameObject> levelPrefabs = new List<GameObject>(); //stores the prefabs for instantiation
    private List<GameObject> levels = new List<GameObject>();
    
    //instantiates all the level prefabs on start, then picks the selected one
    void Start()
    {
        //instantiates levels and puts them in a list
        foreach (GameObject levelPrefab in levelPrefabs)
        {
            GameObject newLevel = Instantiate(levelPrefab);
            levels.Add(newLevel);
        }
        
        //enables the selected level using PlayerData
        SelectLevel(PlayerData.selectedLevel);
    }

    //hides using prefab list
    public void HideLevels()
    {
        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }
    }

    //takes argument, hides all prefabs, then activates only one.
    public void SelectLevel(int levelNumber)
    {
        HideLevels();
        levels[levelNumber - 1].SetActive(true);
        
        //sets spawn point using the SpawnPoint object in the chosen prefab
        PlayerData.spawnPoint = levels[levelNumber - 1].GetComponentInChildren<SetSpawnPoint>().GetSpawnPoint();
    }

    //if level beaten, advances selectedLevel by 1, then reloads
    public void NextLevel()
    {
        PlayerData.selectedLevel += 1;
        if (PlayerData.selectedLevel > levels.Count)
        {
            PlayerData.selectedLevel = 1;
        }
        SceneManager.LoadScene("Game");
    }
}
