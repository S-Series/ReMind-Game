using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffHolder : MonoBehaviour
{
    [SerializeField] SpriteRenderer Plate;
    [SerializeField] SpriteRenderer[] sprites;
    public void Enable(bool isEnable)
    {
        Plate.enabled = isEnable;
        sprites[0].enabled = isEnable;
        sprites[1].enabled = isEnable;
    }
    public void ApplyDiff(int diff)
    {
        sprites[0].sprite = SpriteDict.GetNumSprite(Mathf.FloorToInt(diff / 10f));
        sprites[1].sprite = SpriteDict.GetNumSprite(diff % 10);
        sprites[0].color = new Color32(255, 255, 255, (byte)(diff < 10 ? 100 : 255));
    }
}
