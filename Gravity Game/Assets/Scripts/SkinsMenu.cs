using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinsMenu : MonoBehaviour
{
    public GameObject skinsButtonPrefab;
    public GameObject skinsButtonContainer;
    public string skinName;
    

    private void Start()
    {
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Skins");
        foreach (Sprite thumbnail in thumbnails)
        {
            
            GameObject container = Instantiate(skinsButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = thumbnail;
            container.transform.SetParent(skinsButtonContainer.transform, false);

             skinName = thumbnail.name;
            container.GetComponent<Button>().onClick.AddListener(() => SkinLoad(LevelNumber.skinPick));

        }
    }

    private void SkinLoad(string skinNumber)
    {
        skinName = skinNumber;
        LevelNumber.skinPick = skinNumber;
    }
}