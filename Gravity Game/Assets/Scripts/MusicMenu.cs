using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicMenu : MonoBehaviour
{
    public GameObject MusicButtonPrefab;
    public GameObject MusicButtonContainer;
    public Slider VolumeSlider;

    private void Start()
    {
        //procedurally generates each music button in a row
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Music");
        foreach (Sprite thumbnail in thumbnails)
        {
            GameObject container = Instantiate(MusicButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = thumbnail;

            string track = thumbnail.name;
            container.GetComponent<Button>().onClick.AddListener(() => MusicLoad(track));
            
            container.transform.SetParent(MusicButtonContainer.transform, false);
        }
    }

    //sets the target level using PlayerData, then switches scenes. Game scene loads level on Start.
    private void MusicLoad(string track)
    {
        //assigns selectedLevel based on name of image file in button clicked
        int trackToLoad;
        int.TryParse(track, out trackToLoad);
        //MusicPlayer.GetComponent<MusicChanger>().SetTrack(trackToLoad);
        PlayerData.musicTrack = trackToLoad;

        //changes music
        //SceneManager.LoadScene("Game");
        Debug.Log("Loaded music");
        Debug.Log(track);
    }
    
    public void OnValueChanged() //This method is here because the volume slider needs to activate a method in a script attached to a GameObject that isn't shunted into a DDOL. 
    {
        PlayerData.volume = VolumeSlider.value;
    }
}