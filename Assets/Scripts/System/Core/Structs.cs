using UnityEngine;

namespace Structs
{
    public struct NoteData
    {
        public int noteMs;
        public int noteLine;
        public int noteLength;
        public int animationID;
    }
    public struct ShiftNoteData
    {
        public int noteMs;
        public int shiftPower;
        public int[] noteLength;
    }
    public struct BpmNoteData
    {
        public int noteMs;
        public double gameBpm;
        public double gameSpeed;
    }
    public struct EffectNoteData
    {
        public int noteMs;
        public int effectValue;
        public string effectName;
    }
}