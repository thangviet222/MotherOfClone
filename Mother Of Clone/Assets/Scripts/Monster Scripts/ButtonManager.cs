using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    public AudioSource backgroundMusic;
    public GameObject pausePanel;

    public static bool isPausing;

    private void Start()
    {
        pausePanel.GetComponent<GameObject>();
    }

    public void OnOffMusic()
    {
        if (backgroundMusic.volume > 0)
        {
            gameObject.GetComponent<Image>().color = Color.gray; 
            backgroundMusic.volume = 0;
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.white;
            backgroundMusic.volume = 1;
        }
    }

    public void OnOffPause()
    {
        if (!isPausing)
        {
            gameObject.GetComponent<Image>().color = Color.gray;
            pausePanel.SetActive(true);
            isPausing = true;
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.white;
            pausePanel.SetActive(false);
            isPausing = false;
        }
    }
}
