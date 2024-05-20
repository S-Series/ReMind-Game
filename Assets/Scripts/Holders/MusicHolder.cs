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
    
    [SerializeField] DiffHolder DiffHolder;

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
        RankRenderer.sprite = SpriteManger.GetRankSpriteByScore(gameData.HighScore[dataIndex]);
        APmRenderer.sprite = SpriteManger.GetClearSprite(gameData.ClearMode[dataIndex]);

        MusicTitle.text = musicData.MusicTitle;
        MusicArtist.text = musicData.MusicArtist;
        MusicBpm.text = string.Format("{0}{1}",
            musicData.LowestBpm, musicData.HighestBpm == -1 ?
                string.Empty : string.Format(" - {0}", musicData.HighestBpm )
        );
    }
}
