using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsMenu : MonoBehaviour
{
    public GameObject skinsButtonPrefab;
    public GameObject skinsButtonContainer;
    // Start is called before the first frame update
    private void Start()
    {

        /*private Sprite[] textures = Resources.LoadAll<Sprite>("Skins");
        foreach (Sprite texture in textures)
        {
            GameObject container = Instantiate(skinsButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = texture;
            container.transform.SetParent(skinsButtonContainer.transform,false);

        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
