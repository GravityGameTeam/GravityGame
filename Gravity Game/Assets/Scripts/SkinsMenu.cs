using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinsMenu : MonoBehaviour
{
    public GameObject skinsButtonPrefab;
    public GameObject skinsButtonContainer;
    
    private void Start()
    {
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Skins");
        foreach (Sprite thumbnail in thumbnails)
        {
            GameObject container = Instantiate(skinsButtonPrefab);
            container.GetComponent<Image>().sprite = thumbnail;
            container.transform.SetParent(skinsButtonContainer.transform, false);

            string skinName = thumbnail.name;
            container.GetComponent<Button>().onClick.AddListener(() => SkinLoad(skinName));
        }
    }

    private void SkinLoad(string skinName)
    {
        LevelNumber.skinPick = skinName;
        Debug.Log(LevelNumber.skinPick);
    }
}