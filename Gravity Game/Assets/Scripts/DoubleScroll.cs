using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class DoubleScroll : MonoBehaviour
{
    public GameObject levelsButtonContainer;
    public Vector3 rectPosition;
    public GameObject starsImagePrefab;
    public GameObject starsImageContainer;

    private int startIndex;
    private int endIndex;

    public void Update()
    {
        //Change the current horizontal scroll position.
        rectPosition = levelsButtonContainer.transform.position;
        rectPosition.z = 100;
        rectPosition.y -= 3;
        starsImageContainer.transform.position = rectPosition;
    }

    public void LoadStars()
    {
        Debug.Log("Deleting children of StarContainer");
        foreach (Transform child in starsImageContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("StarPictures");
        for (int i = PlayerData.startIndex; i <= PlayerData.endIndex; i++)
        {
            if (i > PlayerData.farthestLevel)
            {
                break;
            }

            GameObject container = Instantiate(starsImagePrefab) as GameObject;
            container.GetComponent<Image>().sprite = thumbnails[Scoring.starsPerLevel[i]];
            container.transform.SetParent(starsImageContainer.transform, false);
        }
    }
}