using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicHolder : MonoBehaviour
{
    public static List<MusicHolder> holders;
    enum HolderType { Grid, List };

    private MusicData musicData;
    public bool isAvailable = false;

    [SerializeField] HolderType holderType;

    [SerializeField] SpriteRenderer JacketRenderer;
    [SerializeField] SpriteRenderer[] RankRenderers;
    [SerializeField] SpriteRenderer[] MedalRenderers;

    [SerializeField] TextMeshPro MusicTitle;
    [SerializeField] TextMeshPro MusicArtist;
    [SerializeField] TextMeshPro MusicBpm;
    
    [SerializeField] DiffHolder DiffHolders;

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

        JacketRenderer.sprite = musicData.Jackets[dataIndex > 4 ? 4 : dataIndex];
        if (holderType == HolderType.Grid)
        {
            RankRenderers[0].sprite = SpriteManger.GetRankSpriteByScore(gameData.HighScore[dataIndex]); 
            MedalRenderers[0].sprite = SpriteManger.GetClearSprite(gameData.ClearMode[dataIndex]);
            DiffHolders.ApplyDiff(musicData.musicGameDatas[lineIndex].diff[dataIndex], dataIndex);
        }
        else if (holderType == HolderType.List)
        {
            for (int i = 0; i < 5; i++)
            {
                RankRenderers[i].sprite = SpriteManger.GetRankSpriteByScore(gameData.HighScore[i]);
                MedalRenderers[i].sprite = SpriteManger.GetClearSprite(gameData.ClearMode[i]);
            }
        }
        else { throw new System.Exception(""); }

        MusicTitle.text = musicData.MusicTitle;
        MusicArtist.text = musicData.MusicArtist;
        MusicBpm.text = string.Format("BPM|{0}{1}",
            musicData.LowestBpm, musicData.HighestBpm == -1 ?
                string.Empty : string.Format(" - {0}", musicData.HighestBpm )
        );
    }
}
    