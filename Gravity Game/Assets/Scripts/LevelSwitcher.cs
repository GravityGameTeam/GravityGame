using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    public List<GameObject> levelPrefabs = new List<GameObject>();
    private List<GameObject> levels = new List<GameObject>();
    
    void Start()
    {
        foreach (GameObject levelPrefab in levelPrefabs)
        {
            GameObject newLevel = Instantiate(levelPrefab);
            levels.Add(newLevel);
        }
        SelectLevel(PlayerData.selectedLevel);
    }

    public void HideLevels()
    {
        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }
    }

    public void SelectLevel(int levelNumber)
    {
        HideLevels();
        levels[levelNumber - 1].SetActive(true);
        PlayerData.spawnPoint = levels[levelNumber - 1].GetComponentInChildren<SetSpawnPoint>().GetSpawnPoint();
    }

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
