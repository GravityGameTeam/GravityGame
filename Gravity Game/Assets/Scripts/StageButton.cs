using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageButton : MonoBehaviour
{
    public GameObject LevelManager;
    public int startIndex;
    public int endIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => LevelManager.GetComponent<LevelsMenu>().setIndices(startIndex, endIndex));
    }
}
