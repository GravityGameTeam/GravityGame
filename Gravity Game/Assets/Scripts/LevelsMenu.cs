using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    public GameObject levelsButtonPrefab;
    public GameObject levelsButtonContainer;
    public Text textbox;


    private void Start()
    {
        Debug.Log("Farthest level unlocked: " + PlayerData.farthestLevel);
        //procedurally generates each level button in a row
        int n = 0;
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
        foreach (Sprite thumbnail in thumbnails)
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
                break;
            }
        }
        
        //textbox = GetComponent<Text>();
        //textbox.text = "abc";

    }

    //sets the target level using PlayerData, then switches scenes. Game scene loads level on Start.
    private void LevelLoad(string sceneName)
    {
        //assigns selectedLevel based on name of image file in button clicked
        int.TryParse(sceneName, out PlayerData.selectedLevel);

        //loads level
        SceneManager.LoadScene("Game");
        Debug.Log("Loaded scene");
        Debug.Log(sceneName);
    }
    
    
}
