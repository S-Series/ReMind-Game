using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicInfoDisplay : MonoBehaviour
{
    [SerializeField] SpriteRenderer MusicJacket;
    [SerializeField] SpriteRenderer MusicFrame;
    [SerializeField] SpriteRenderer PlayRank;
    [SerializeField] SpriteRenderer PlayMedal;

    [SerializeField] TextMeshPro MusicTitle;
    [SerializeField] TextMeshPro MusicArtist;
    [SerializeField] TextMeshPro MusicBPM;

    [SerializeField] SpriteRenderer[] HighScore; //# [0][1][2][3][4][5][6][7]
    [SerializeField] DiffHolder[] Difficultys;
    [SerializeField] SpriteRenderer[] DiffIndexBoxes;

    public void UpdateMusicInfo(MusicData data)
    {
        int index, lineIndex, difficulty;
        index = MusicSelectSystem.s_DiffIndex;
        lineIndex = (int)MusicSelectSystem.s_LineMode;

        for (int i = 0, j = index; i < 5; i++, j++)
        {
            Difficultys[i].ApplyDiff(data.musicGameDatas[lineIndex].diff[i], i);
            if (i == index)
            {
                
            }
        }
    }
}
