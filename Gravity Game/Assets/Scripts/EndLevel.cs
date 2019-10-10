using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    public bool appear = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.active = appear;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D node)
    {
        Debug.Log("Collided");
        appear = false;
        if (node.gameObject.tag == "EndPortal")
        {
            gameObject.active = appear;
            LevelBeat();

        } ;
    }

    void LevelBeat()
    {
        
        
        SceneManager.LoadScene("Menu");
    }
}
