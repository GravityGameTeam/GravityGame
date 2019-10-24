using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    public bool appear = true;
    
    public GameObject menuPanel;
    // Start is called before the first frame update
    public void Start()
    {
        gameObject.active = appear;
        menuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D node)
    {
        Debug.Log("Collided");
        appear = false;
        if (node.gameObject.tag == "EndPortal")
        {
            gameObject.active = appear;
            LevelBeat();

        } ;
    }

    public void LevelBeat()
    {
        menuPanel.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
