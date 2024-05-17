using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class SpriteDict : MonoBehaviour
{
    [SerializeField] Sprite[] _numSprite;
    private static Sprite[] NumSprite;

    [SerializeField] Sprite[] _numSpriteSp;
    private static Sprite[] NumSpriteSp;

    [SerializeField] Sprite[] _rankSprite;
    private static Sprite[] RankSprite;

    [SerializeField] Sprite[] _APmSprite;
    private static Sprite[] APmSprite;

    private void Awake()
    {
        NumSprite = _numSprite;
        NumSpriteSp = _numSpriteSp;
        RankSprite = _rankSprite;
        APmSprite = _APmSprite;
    }

    public static Sprite GetNumSprite(int Num, bool isSpecial = false)
    {
        return isSpecial ? NumSpriteSp[Num] : NumSprite[Num];
    }
    public static Sprite GetRankSprite(int index)
    {
        return RankSprite[index];
    }
    public static Sprite GetRankSpriteByScore(int score)
    {
        int index;  
        if (score == 10000000) { index = 0; }
        else if (score >= 9900000) { index = 1; }
        else if (score >= 9800000) { index = 2; }
        else if (score >= 9700000) { index = 3; }
        else if (score >= 9600000) { index = 4; }
        else if (score >= 9500000) { index = 5; }
        else if (score >= 9250000) { index = 6; }
        else if (score >= 9000000) { index = 7; }
        else { index = 8; }
        return RankSprite[index];
    }
    public static Sprite GetApSprite(ResultAP resultAP)
    {
        if (resultAP == ResultAP.AM) { return APmSprite[0]; }
        else if (resultAP == ResultAP.PM) { return APmSprite[1]; }
        else { return null; }
    }
}
