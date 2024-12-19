using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;
using Structs;

public class ChartLoader : MonoBehaviour
{
    public static SaveData Load(int musicId, int difId)
    {
        SaveData ret;
        TextAsset data;

        try { data = Resources.Load(string.Format("/{0:d4}/{1:d4}", musicId, difId)) as TextAsset; }
        catch { throw new System.Exception("File Loading Error"); }

        ret = JsonUtility.FromJson<SaveData>(data.ToString());
        return ret;
    }
}

public class ChartData
{
    public int ChartID;
    public int noteLine;
    public string[] noteDatas;
}


