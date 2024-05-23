using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager s_this;
    public static List<MusicData> s_musicDatas;

    private void Awake()
    {
        if (s_this == null) { s_this = this; }
    }
    private void Start()
    {
        MusicData[] datas;
        datas = GetComponentsInChildren<MusicData>();


    }
}
