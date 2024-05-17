using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class MusicData : MonoBehaviour
{
    [Header("##Unchange Data")]
    public int MusicID;
    public Sprite[] Jackets = new Sprite[5];
    public string MusicTitle;
    public string MusicArtist;
    public int insertDate = 000000;
    public int insertVersion = 0;
    public double LowestBpm = 120;
    public double HighestBpm = -1;
    public MusicGameData[] musicGameDatas = new MusicGameData[3];

    [ContextMenu("InitMusicGameData")]
    public void InitMusicGameData()
    {
        musicGameDatas = GetComponents<MusicGameData>();
        if (musicGameDatas.Length == 0)
        {
            gameObject.AddComponent<MusicGameData>();
            gameObject.AddComponent<MusicGameData>();
            gameObject.AddComponent<MusicGameData>();
            musicGameDatas = GetComponents<MusicGameData>();
            musicGameDatas[0].lineMode = Enums.LineMode.Line4;
            musicGameDatas[1].lineMode = Enums.LineMode.Line5;
            musicGameDatas[2].lineMode = Enums.LineMode.Line6;
        }
        else if (musicGameDatas.Length != 3)
        {
            throw new Exception("musicUserData Error");
        }
        else { musicGameDatas.OrderBy(item => item.lineMode); }
    }
}
