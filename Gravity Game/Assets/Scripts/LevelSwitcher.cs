using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitcher : MonoBehaviour
{
    public List<GameObject> levels = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        SelectLevel(1);
    }

    // Update is called once per frame
    public void ClearLevels()
    {
        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }
    }

    public void SelectLevel(int level)
    {
        ClearLevels();
        levels[level - 1].SetActive(true);
    }
}
