using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        }
    }
}
