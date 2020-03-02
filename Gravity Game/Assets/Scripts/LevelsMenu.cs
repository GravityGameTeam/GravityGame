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
    
    
    public void Start()
    {
        Debug.Log("Farthest level unlocked: " + PlayerData.farthestLevel);
        //procedurally generates each level button in a row
        int n = 0;
        bool done = false;
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
        while (done == false)
        {

            foreach (Sprite thumbnail in thumbnails)
            {
                int.TryParse(thumbnail.name, out int i);
                if (i == (n + 1))
                {
                    GameObject container = Instantiate(levelsButtonPrefab) as GameObject;
                    container.GetComponent<Image>().sprite = thumbnail;
                    container.transform.SetParent(levelsButtonContainer.transform, false);

                    string sceneName = thumbnail.name;
                    container.GetComponent<Button>().onClick.AddListener(() => LevelLoad(sceneName));
                    n++;

                    //won't load levels that haven't been unlocked
                    if (n >= PlayerData.farthestLevel)
                    {
                        done = true;
                        break;
                        
                    }
                }

                if (n >= (PlayerData.numberOfLevels-1))
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


    
    
    
}
