using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    //menu
    [SerializeField] private TMP_Text Title;

    [SerializeField] private TMP_InputField username;
    [SerializeField] private TMP_Text Hiscore;
    [SerializeField] private Image start;
    [SerializeField] private Image settings;
    [SerializeField] private Image quit;

    //GO
    [SerializeField] private GameObject menuGO;

    [SerializeField] private GameObject settingsGO;

    //Settings
    [SerializeField] private TMP_Dropdown paletteSelector;

    public List<ColorPalette> colorPalettes = new List<ColorPalette>();

    //other
    private void Start()
    {
        if (DataManager.instance.scoreOwner != string.Empty)
        {
            Hiscore.gameObject.SetActive(true);
            Hiscore.text = $"Current HiScore is {DataManager.instance.highScore}, by {DataManager.instance.scoreOwner}!";
        }
        SetUIPalette();
    }

    public void StartGame()
    {
        if (!string.IsNullOrWhiteSpace(username.text))
        {
            DataManager.instance.currentPlayer = username.text;
            SceneManager.LoadScene("Main");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        menuGO.SetActive(false);
        settingsGO.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsGO.SetActive(false);
        menuGO.SetActive(true);
    }

    public void SetUIPalette()
    {
        if (DataManager.instance.CurrentPalette != null)
        {
            start.color = DataManager.instance.CurrentPalette.colors[0];
            settings.color = DataManager.instance.CurrentPalette.colors[1];
            quit.color = DataManager.instance.CurrentPalette.colors[2];
        }
    }

    public void SavePalette()
    {
        DataManager.instance.CurrentPalette = colorPalettes[paletteSelector.value];
        SetUIPalette();
        DataManager.instance.SavePalette();
    }
}