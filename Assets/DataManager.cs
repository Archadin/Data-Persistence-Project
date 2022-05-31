using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    [HideInInspector] public int highScore = 0;
    [HideInInspector] public string scoreOwner = string.Empty;
    [HideInInspector] public string currentPlayer = string.Empty;
    public ColorPalette CurrentPalette;
    public List<ColorPalette> colorPalettes = new List<ColorPalette>();
    private SaveData data;
    private PaletteData paletteData;
    public int HighScore { get => highScore; set => highScore = value; }

    private void Awake()
    {
        data = new SaveData();
        paletteData = new PaletteData();
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        Load();
        LoadPalette();
    }

    private class SaveData
    {
        public int highScore;
        public string scoreOwner;
        public string CurrentPalette;
    }

    private class PaletteData
    {
        public string CurrentPalette;
    }

    #region Save/Load

    public void Save()
    {
        print("Saving!");

        data.highScore = highScore;
        data.scoreOwner = scoreOwner;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/Brick.json", json);
    }

    public void Load()
    {
        print("Loading!");
        string path = Application.persistentDataPath + "/Brick.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            scoreOwner = data.scoreOwner;
        }
    }

    #endregion Save/Load

    #region Save/Load Palette

    public void SavePalette()
    {
        print("Saving!");

        paletteData.CurrentPalette = CurrentPalette.ID;
        string json = JsonUtility.ToJson(paletteData);

        File.WriteAllText(Application.persistentDataPath + "/BrickPalette.json", json);
    }

    public void LoadPalette()
    {
        print("Loading Palette!");
        string path = Application.persistentDataPath + "/BrickPalette.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            paletteData = JsonUtility.FromJson<PaletteData>(json);

            CurrentPalette = colorPalettes.Find(x => x.ID == paletteData.CurrentPalette);
        }
    }

    #endregion Save/Load Palette
}