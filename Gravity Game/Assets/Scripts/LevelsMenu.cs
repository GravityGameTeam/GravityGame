using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    public GameObject levelsButtonPrefab;
    public GameObject levelsButtonContainer;

    private void Start()
    {
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
        foreach (Sprite thumbnail in thumbnails)
        {
            GameObject container = Instantiate(levelsButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = thumbnail;
            container.transform.SetParent(levelsButtonContainer.transform,false);

            string sceneName = thumbnail.name;
            container.GetComponent<Button>().onClick.AddListener(() => LevelLoad(sceneName));
        }
    }

    private void LevelLoad(string sceneName)
    {
        LevelNumber.selectedLevel = 1;
        SceneManager.LoadScene("Game");
        Debug.Log("Loaded scene");
        Debug.Log(sceneName);
    }
}
