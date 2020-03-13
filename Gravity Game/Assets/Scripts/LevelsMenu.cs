using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    public GameObject levelsButtonPrefab;
    public GameObject levelsButtonContainer;
    public GameObject starsText;
    public int starsTotal = 0;

    private int startIndex;
    private int endIndex;

    public void Start()
    {
        LoadButtons();
    }
    
    public void LoadButtons()
    {
        Debug.Log("Deleting children of ScrollRect");
        foreach (Transform child in levelsButtonContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        
        Debug.Log("Farthest level unlocked: " + PlayerData.farthestLevel);
        //procedurally generates each level button in a row
        bool done = false;
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");

        Array.Sort(thumbnails, delegate(Sprite thumbnail1, Sprite thumbnail2)
        {
            return Int32.Parse(thumbnail1.name).CompareTo(Int32.Parse(thumbnail2.name));
        });
        Debug.Log("sorted thumbnails");
        
        while (done == false)
        {
            Debug.Log("entered level loading loop");
            
            foreach (Sprite thumbnail in thumbnails)
            {
                Debug.Log("Entered foreach");
                int.TryParse(thumbnail.name, out int i);
                Debug.Log("Parsed level " + i);
                
                Debug.Log("Preparing for if. i is " + i + ", startIndex is " + startIndex);
                if (i >= startIndex && i <= PlayerData.farthestLevel)
                {
                    Debug.Log("Level is correct!");
                    
                    GameObject container = Instantiate(levelsButtonPrefab) as GameObject;
                    container.GetComponent<Image>().sprite = thumbnail;
                    container.transform.SetParent(levelsButtonContainer.transform, false);

                    string sceneName = thumbnail.name;
                    container.GetComponent<Button>().onClick.AddListener(() => LevelLoad(sceneName));
                    
                    //won't load levels that haven't been unlocked or exceed endIndex
                    if (i >= PlayerData.farthestLevel || i >= endIndex)
                    {
                        Debug.Log("Loop broken at i = " + i + ". farthestLevel is " + PlayerData.farthestLevel + ", endIndex is " + endIndex);
                        done = true;
                        break;
                    }
                }
                else
                {
                    Debug.Log("Level load of " + i + " failed");
                }

                if (i >= (PlayerData.numberOfLevels-1) || i >= endIndex )
                {
                    done = true;
                }
            }
        }
        
        Debug.Log("sum is" + Scoring.Sum());
        starsTotal = Scoring.Sum();
        string starsTotalString = starsTotal.ToString();
        starsText.GetComponent<TextMeshProUGUI>().text = starsTotalString;
    }

    //sets the target level using PlayerData, then switches scenes. Game scene loads level on Start.
    private static void LevelLoad(string sceneName)
    {
        //assigns selectedLevel based on name of image file in button clicked
        int.TryParse(sceneName, out PlayerData.selectedLevel);

        //loads level
        SceneManager.LoadScene("Game");
        Debug.Log("Loaded scene");
        Debug.Log(sceneName);
    }

    public void setIndices(int newStartIndex, int newEndIndex)
    {
        startIndex = newStartIndex;
        endIndex = newEndIndex;
        LoadButtons();
    }
}
