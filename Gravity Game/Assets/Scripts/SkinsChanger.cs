using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsChanger : MonoBehaviour
{
    public GameObject player;
    
    //This should be a switch statement? Probably.
    //It updates the player's appearance based on PlayerData once Game loads.
    public void Start()
    {
        if (PlayerData.skinPick == "Skins_0")
        {
            player.GetComponent<Renderer> ().material.color =  new Color(0,0.25f,1);
        }
        
        if (PlayerData.skinPick == "Skins_1")
        {
            player.GetComponent<Renderer> ().material.color =  new Color(1,0.6f,0);
        }
        
        if (PlayerData.skinPick == "Skins_2")
        {
            player.GetComponent<Renderer> ().material.color =  new Color(1,0,0.2352f);
        }
        
        if (PlayerData.skinPick == "Skins_3")
        {
            player.GetComponent<Renderer> ().material.color =  new Color(0,1,0.0156f);
        }
        
        if (PlayerData.skinPick == "Skins_4")
        {
            player.GetComponent<Renderer> ().material.color =  new Color(0,1,0.9176f);
        }
        
        if (PlayerData.skinPick == "Skins_5")
        {
            player.GetComponent<Renderer> ().material.color =  new Color(1,0,0.8823f);
        }
        
        if (PlayerData.skinPick == "Skins_6")
        {
            player.GetComponent<Renderer> ().material.color =  new Color(0.3450f,0.4392f,0.8470f);
        }
        
        if (PlayerData.skinPick == "Skins_7")
        {
            player.GetComponent<Renderer> ().material.color =  new Color(0.0941f,0.5215f,0.1411f);
        }
        
        if (PlayerData.skinPick == "Skins_8")
        {
            player.GetComponent<Renderer> ().material.color =  new Color(0.9333f,1,0);
        }
        
        if (PlayerData.skinPick == "Skins_9")
        {
            player.GetComponent<Renderer> ().material.color =  new Color(0.4352f,0.2274f,0.7764f);
        }
        
        if (PlayerData.skinPick == "Skins_10")
        {
            player.GetComponent<Renderer> ().material.color =  new Color(0.9098f,0.5921f,0.7882f);
        }
        
        if (PlayerData.skinPick == "Skins_11")
        {
            player.GetComponent<Renderer> ().material.color =  new Color(0,0.1137f,0.5254f);
        }
        
        if (PlayerData.skinPick == "Skins_12")
        {
            player.GetComponent<Renderer> ().material.color =  new Color(0.4980f,0,0);
        }
        
        if (PlayerData.skinPick == "Skins_13")
        {
            player.GetComponent<Renderer> ().material.color =  new Color(0.6392f,0.6196f,0);
        }
        
        if (PlayerData.skinPick == "Skins_14")
        {
            player.GetComponent<Renderer> ().material.color =  new Color(1,1,1);
        }
        
        if (PlayerData.skinPick == "Skins_15")
        {
            player.GetComponent<Renderer> ().material.color =  new Color(0,0,0);
        }
    }
}
