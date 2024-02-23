using UnityEngine;

namespace Classes
{
    public class NormalNote
    {
        public NormalNote(int _line, int _length, bool _bool, GameObject _object)
        {
            line = _line;
            length = _length;
            isAirial = _bool;
            noteObject = _object;
        }
        public int line { get; }
        public int length { get; }
        public bool isAirial { get; }
        public GameObject noteObject { get; }
    }
    public class ScratchNote
    {
        public ScratchNote(int _value, int _length, bool _isLeft, bool _isShift, GameObject _object)
        {
            value = _value;
            length = _length;
            isLeft = _isLeft;
            isShift = _isShift;
            noteObject = _object;
        }
        public int value { get; }
        public int length { get; }
        public bool isLeft { get; }
        public bool isShift { get; }
        public GameObject noteObject { get; }
    }
    public class SpeedNote
    {
        
    }
    public class EffectNote
    {

    }
}