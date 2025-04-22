using System.Collections.Generic;
using UnityEngine;

public class RichLevelSkin : MonoBehaviour
{
    [SerializeField] private List<RichlevelSkinPair> richLevelSkins;

    public void SetSkin(RichLevel richLevel)
    {
        foreach (var pair in richLevelSkins)
        {
            pair.skin.SetActive(pair.richLevel == richLevel);
        }
    }
}

[System.Serializable]
public class RichlevelSkinPair
{
    public RichLevel richLevel;
    public GameObject skin;
}
