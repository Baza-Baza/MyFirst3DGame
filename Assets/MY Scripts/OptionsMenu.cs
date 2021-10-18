using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject [] panels;
    [SerializeField] private Toggle[] togglesAntiAliasians;
    [SerializeField] private GameObject fogStorm;
    private GameObject  mainCamera;
    public  Slider sliderBrighness;
    public Slider ambienceLevel;
    public Slider sfxLevel;
    public Toggle fogToggle;
    public AudioMixer ambienceMixer;
    public AudioMixer sfxMixer;
    private bool fogOn = true;
    private int antiState = 4;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
       Cursor.visible =true;
        Time.timeScale = 0;
        for (int i = 0; i< panels.Length; i++)
        {
            if (i == 0)
            {
                panels[i].SetActive(true);
            }
            else if (i > 0)
            {
                panels[i].SetActive(false);
            }
        }
        panels[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        Time.timeScale = 0;
    }
    public void LightValue()
    {
        RenderSettings.ambientIntensity = sliderBrighness.value;
    }
    public void Volume(int sliderNumber)
    {
        switch (sliderNumber)
        {
            case 1:
                ambienceMixer.SetFloat("Volume", ambienceLevel.value);
                break;
            case 2:
                sfxMixer.SetFloat("Volume", sfxLevel.value);
                break;
        }
    }
    public void AntiAliasingSwitch(int numberToggle)
    {
        if (togglesAntiAliasians[numberToggle-1].isOn == true)
        {
            switch (numberToggle)
            {
                case 1:
                    mainCamera.GetComponent<PostProcessLayer>().antialiasingMode = PostProcessLayer.Antialiasing.None;                   
                    break;
                case 2:
                    mainCamera.GetComponent<PostProcessLayer>().antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
                    break;
                case 3:
                    mainCamera.GetComponent<PostProcessLayer>().antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
                    break;
                case 4:
                    mainCamera.GetComponent<PostProcessLayer>().antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
                    break;
            }
            for (int i = 0; i < togglesAntiAliasians.Length; i++)
            {
                if (i != numberToggle-1)
                {
                    togglesAntiAliasians[i].isOn = false;
                }
            }

        }
    }
    public void OpenPanel(int buttonNumber)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        panels[buttonNumber - 1].SetActive(true);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void FogState()
    {
        if (fogToggle.isOn == true)
        {
            if (fogOn == true)
            {
                mainCamera.GetComponent<PostProcessLayer>().fog.enabled = false;
                fogStorm.SetActive(false);
                fogOn = false;
            }
            else if (fogOn == false)
            {
                mainCamera.GetComponent<PostProcessLayer>().fog.enabled = true;
                fogStorm.SetActive(true);
                fogOn = true;
            }
        }
        if (fogToggle.isOn == false)
        {
            if (fogOn == true)
            {
                mainCamera.GetComponent<PostProcessLayer>().fog.enabled = false;
                fogStorm.SetActive(false);
                fogOn = false;
            }
            else if (fogOn == false)
            {
                mainCamera.GetComponent<PostProcessLayer>().fog.enabled = true;
                fogStorm.SetActive(true);
                fogOn = true;
            }
        }
    }
}

