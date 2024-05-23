using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class SpriteManger : MonoBehaviour
{
    [SerializeField] Sprite[] _numSprite;
    private static Sprite[] NumSprite;

    [SerializeField] Sprite[] _numSpriteSp;
    private static Sprite[] NumSpriteSp;

    [SerializeField] Sprite[] _rankSprite;
    private static Sprite[] RankSprite;

    [SerializeField] Sprite[] _clearSprite;
    private static Sprite[] ClearSprite;

    private void Awake()
    {
        NumSprite = _numSprite;
        NumSpriteSp = _numSpriteSp;
        RankSprite = _rankSprite;
        ClearSprite = _clearSprite;
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
        float accuracy = score / 100000f;

        if (accuracy >= 100.0) { index = 00; }      //$ Rank : MAX
        else if (accuracy >= 99.5) { index = 01; }  //$ Rank : EX+
        else if (accuracy >= 99.0) { index = 02; }  //$ Rank : EX
        else if (accuracy >= 98.5) { index = 03; }  //$ Rank : SS+
        else if (accuracy >= 98.0) { index = 04; }  //$ Rank : SS
        else if (accuracy >= 97.5) { index = 05; }  //$ Rank : S+
        else if (accuracy >= 97.0) { index = 06; }  //$ Rank : S
        else if (accuracy >= 96.0) { index = 07; }  //$ Rank : AA+
        else if (accuracy >= 95.0) { index = 08; }  //$ Rank : AA
        else if (accuracy >= 92.5) { index = 09; }  //$ Rank : A+
        else if (accuracy >= 90.0) { index = 10; }  //$ Rank : A
        else if (accuracy >= 85.0) { index = 11; }  //$ Rank : B+
        else if (accuracy >= 80.0) { index = 12; }  //$ Rank : B
        else if (accuracy >= 75.0) { index = 13; }  //$ Rank : C
        else if (accuracy != 00.0) { index = 14; }  //$ Rank : D
        else { return null; }                       //# Non Played

        return RankSprite[index];
    }
    public static Sprite GetClearSprite(ClearGuage resultAP)
    {
        if (resultAP == ClearGuage.AM) { return ClearSprite[0]; }
        else if (resultAP == ClearGuage.PM) { return ClearSprite[1]; }
        else { return null; }
    }
}
