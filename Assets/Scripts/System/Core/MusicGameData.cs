using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class MusicGameData : MonoBehaviour
{
    public LineMode lineMode = LineMode.Line4;
    public GuageMode[] ClearMode = new GuageMode[5];
    public ResultAP[] ClearAP = new ResultAP[5];

    public int[] diff = new int[5] { -1, -1, -1, -1, -1};
    public int[] HighScore = new int[5];
    public double[] rating = new double[5];
    public bool[] isHidden = { false, false, false, false, false };
    public string[] ChartEffecter = new string[5];
}
