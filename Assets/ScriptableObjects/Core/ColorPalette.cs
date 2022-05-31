using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "ColorPalatte", menuName = "SO/Palette")]
public class ColorPalette : ScriptableObject
{
    public string ID;
    public Color[] colors = new Color[3];
}
