using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class DoubleScroll : MonoBehaviour
{
    public GameObject levels;
    public GameObject stars;
    public Vector3 rectPosition;
    public GameObject starsImagePrefab;
    public GameObject starsImageContainer;

    public void Update()
    {
        //Change the current horizontal scroll position.
        rectPosition = levels.transform.position;
        rectPosition.z = 100;
        rectPosition.y -= 3;
        stars.transform.position = rectPosition;
    }

    public void Start()
    {
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("StarPictures");
        for (int i = 1; i <= PlayerData.farthestLevel; i++)
        {
            if (Scoring.starsPerLevel[i] == 1)
            {
                GameObject container = Instantiate(starsImagePrefab) as GameObject;
                //container.GetComponent<Image>().sprite = ;
                container.transform.SetParent(starsImageContainer.transform, false);

            }
        }
    }
}