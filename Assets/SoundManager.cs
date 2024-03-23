using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private Image soundOnIcon;
    [SerializeField] private Image soundOffIcon;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted",0);
            Load();
        }

        else
        {
            Load();
        }

        UpdateButtonicon();
        AudioListener.pause = muted;
    }

    // Update is called once per frame
    public void OnButtonPress()
    {
        if (muted== false)
        {
            muted = true;
            AudioListener.pause = true;
        }

        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButtonicon();
    }

    private void UpdateButtonicon()
    {
        if(muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }

        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted",muted ? 1 : 0);
    }
}
