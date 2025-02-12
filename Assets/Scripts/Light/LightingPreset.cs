using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = " Linging Preset", menuName = " Scritable/Linging Preset", order = 1)]

public class LightingPreset : ScriptableObject
{
    public Gradient AmbientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;

}
