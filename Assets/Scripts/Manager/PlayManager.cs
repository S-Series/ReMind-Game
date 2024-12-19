using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;
using Structs;

public class PlayManager : MonoBehaviour
{
    public static PlayManager s_this;
    public static List<NoteData> asdf;

    private void Awake()
    {
        if (s_this == null) { s_this = this; }
        else { throw new System.Exception("Multiple PlayManager"); }
    }

    public static void GetChartData(int musicId, int difId)
    {
        SaveData saveData;
        saveData = ChartLoader.Load(musicId, difId);

        //$
    }
}


