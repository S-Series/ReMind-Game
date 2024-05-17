using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicHolder : MonoBehaviour
{
    public static List<MusicHolder> holders;

    private MusicData musicData;
    public bool isAvailable = false;
    [SerializeField] SpriteRenderer JacketRenderer;
    [SerializeField] SpriteRenderer RankRenderer;
    [SerializeField] SpriteRenderer APmRenderer;
    [SerializeField] TextMeshPro MusicTitle;
    [SerializeField] TextMeshPro MusicArtist;
    [SerializeField] TextMeshPro MusicBpm;
    [SerializeField] SpriteRenderer[] HighScore;
    [SerializeField] DiffHolder[] DiffHolders;

    private void Awake()
    {
        holders = new List<MusicHolder>();
    }
    public void ApplyMusicData(MusicData data)
    {
        musicData = data;
        UpdateHolder();
    }
    public void UpdateHolder()
    {
        int dataIndex, lineIndex;
        dataIndex = MusicSelectSystem.s_DiffIndex;
        lineIndex = (int)MusicSelectSystem.s_LineMode - 4;
        MusicGameData gameData = musicData.musicGameDatas[lineIndex];
        for (int i = 0; true; i++)
        {
            if (i == 5) { isAvailable = false; return; }
            if (gameData.diff[dataIndex] != -1) { break; }

            dataIndex--;
            if (dataIndex < 0) { dataIndex += 5; }
        }
        isAvailable = true;
        JacketRenderer.sprite = musicData.Jackets[dataIndex];
        RankRenderer.sprite = SpriteDict.GetRankSpriteByScore(gameData.HighScore[dataIndex]);
        APmRenderer.sprite = SpriteDict.GetApSprite(gameData.ClearAP[dataIndex]);
        MusicTitle.text = musicData.MusicTitle;
        MusicArtist.text = musicData.MusicArtist;
        MusicBpm.text = string.Format("{0}{1}",
            musicData.LowestBpm, musicData.HighestBpm == -1 ?
                string.Empty : string.Format(" - {0}", musicData.HighestBpm )
        );
        bool colorTrigger = false;
        char[] datas = gameData.HighScore[dataIndex].ToString().ToCharArray();
        for (int i = 0; i < 8; i++)
        {
            if (datas[i] != 0) { colorTrigger = true; }
            HighScore[i].sprite = SpriteDict.GetNumSprite(System.Convert.ToInt32(datas[0]));
            HighScore[i].color = new Color32(255, 255, 255, (byte)(colorTrigger ? 255: 100));
        }
        for (int i = 0; i < 5; i++)
        {
            DiffHolders[i].Enable(gameData.diff[i] == -1 ? false : true);
            DiffHolders[i].ApplyDiff(gameData.diff[i]);
        }
    }
}
