using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStart : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerData.loadStartScreen == false)
        {
            startScreen.SetActive(false);
            mainMenu.SetActive(true);
        }
    }


}
