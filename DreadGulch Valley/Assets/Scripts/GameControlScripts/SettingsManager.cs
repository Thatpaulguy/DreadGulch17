using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour
{
    //a reference to the fullscreen toggle field
    public Toggle fullscreenToggle;

    //a reference to the dropdown for resolution selection
    public Dropdown resolutionDropdown;

    //a reference to the slider that controls the music volume
    public Slider musicVolumeSlider;

    //an array of all the monitors possible resolutions
    public Resolution[] resolutions;

    //a variable to hold the stored GameSettings values
    public GameSettings gameSettings;

    ////a reference to the audio component for the music
    public AudioSource musicSource;

    //a reference to the button that saves out the gameSettings data
    public Button saveButton;

    void Start()
    {

    }

    void OnEnable()
    {
        //initializes a new GameSettings object to hold the gameSettings values
        gameSettings = new GameSettings();

        //subscribed listeners for any change in the variables values

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreen(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { ResolutionChoice(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { MusicLevelChange(); });
        saveButton.onClick.AddListener(delegate { OnSaveButtonClick(); });

        //passes all possible resolutions into the resolutions variable
        resolutions = Screen.resolutions;

        //steps through each resolution in resolutions
        foreach(Resolution resolution in resolutions)
        {
            //adds the name of each possible resolution to the resolutions dropdown
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        LoadSettings();
    }

    //a function call for when the save button is clicked to save the gameSettings data
    public void OnSaveButtonClick()
    {
        SaveSettings();
    }

    //a function to set the fullscreen value
    public void OnFullscreen()
    {
       gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    //a function to set the resolution selected
    public void ResolutionChoice()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = resolutionDropdown.value;
    }

    //a function to set the music volume
    public void MusicLevelChange()
    {
        musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
    }

    //a function to save the gameSettings data
    public void SaveSettings()
    {
        //converts GameSettings data into a Json file and stores it into a variable
        string gameSettingsJsonData = JsonUtility.ToJson(gameSettings, true);

        //writes all the data in the Json file variable (gameSettingsJsonData) out to disk in the selected file path
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", gameSettingsJsonData);
    }

    //a function to read in and set the gameSettings values
    public void LoadSettings()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesettings.json"))
        {
            //reads in the disk stored GameSettings data and stores it back ingameSettings
            gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

            //sets all the value from gameSettings
            musicVolumeSlider.value = gameSettings.musicVolume;
            resolutionDropdown.value = gameSettings.resolutionIndex;
            fullscreenToggle.isOn = gameSettings.fullscreen;

            //makes sure the resolution dropdown shows all the proper resolutions
            resolutionDropdown.RefreshShownValue();
        }
    }

}
