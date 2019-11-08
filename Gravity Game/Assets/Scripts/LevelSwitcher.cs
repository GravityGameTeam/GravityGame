using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    public List<GameObject> levelPrefabs = new List<GameObject>();

    private List<GameObject> levels = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject levelPrefab in levelPrefabs)
        {
            GameObject newLevel = Instantiate(levelPrefab);
            newLevel.SetActive(false);
            levels.Add(newLevel);
        }
    }

    // Update is called once per frame
    public void ClearLevels()
    {
        /*
        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }
        */
    }

    public void SelectLevel(int levelNumber)
    {
        levels[levelNumber - 1].SetActive(true);
        SceneManager.MoveGameObjectToScene(levels[levelNumber - 1], SceneManager.GetSceneByName("Game"));
        Debug.Log("Moved level object?");
        
        //ClearLevels();
        //levels[level - 1].SetActive(true);
    }

    public void InstantiateLevels()
    {
        for (int i = 0; i < levelPrefabs.Count; i ++)
        {
            levels[i] = Instantiate(levelPrefabs[i]);
        }
    }
}
