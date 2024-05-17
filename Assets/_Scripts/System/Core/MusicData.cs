using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class MusicData : MonoBehaviour
{
    [Header("##Unchange Data")]
    [SerializeField] int MusicID;
    [SerializeField] Sprite[] Jackets = new Sprite[5];
    [SerializeField] string MusicTitle;
    [SerializeField] string MusicArtist;
    [SerializeField] string[] ChartEffecter4 = new string[5];
    [SerializeField] string[] ChartEffecter5 = new string[5];
    [SerializeField] int insertDate = 000000;
    [SerializeField] int insertVersion = 0;
    [SerializeField] MusicGameData[] musicUserDatas = new MusicGameData[3];

    [ContextMenu("InitMusicGameData")]
    public void InitMusicGameData()
    {
        musicUserDatas = GetComponents<MusicGameData>();
        if (musicUserDatas.Length == 0)
        {
            gameObject.AddComponent<MusicGameData>();
            gameObject.AddComponent<MusicGameData>();
            gameObject.AddComponent<MusicGameData>();
            musicUserDatas = GetComponents<MusicGameData>();
            musicUserDatas[0].lineMode = Enums.LineMode.Line4;
            musicUserDatas[1].lineMode = Enums.LineMode.Line5;
            musicUserDatas[2].lineMode = Enums.LineMode.Line6;
        }
        else if (musicUserDatas.Length != 3)
        {
            throw new Exception("musicUserData Error");
        }
        else { musicUserDatas.OrderBy(item => item.lineMode); }
    }
}
