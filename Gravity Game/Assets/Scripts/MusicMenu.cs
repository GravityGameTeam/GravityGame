using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicMenu : MonoBehaviour
{
    public GameObject MusicButtonPrefab;
    public GameObject MusicButtonContainer;
    public GameObject MusicPlayer;

    private void Start()
    {
        //procedurally generates each music button in a row
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Music");
        foreach (Sprite thumbnail in thumbnails)
        {
            GameObject container = Instantiate(MusicButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = thumbnail;
            container.transform.SetParent(MusicButtonContainer.transform, false);

            string track = thumbnail.name;
            container.GetComponent<Button>().onClick.AddListener(() => MusicLoad(track));
        }
    }

    //sets the target level using PlayerData, then switches scenes. Game scene loads level on Start.
    private void MusicLoad(string track)
    {
        //assigns selectedLevel based on name of image file in button clicked
        int trackToLoad;
        int.TryParse(track, out trackToLoad);
        MusicPlayer.GetComponent<MusicChanger>().SetTrack(trackToLoad);

        //changes music
        //SceneManager.LoadScene("Game");
        Debug.Log("Loaded music");
        Debug.Log(track);
    }
}