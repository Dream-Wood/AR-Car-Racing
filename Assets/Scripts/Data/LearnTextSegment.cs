using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public struct LearnTextSegment
    {
        public string Title;
        [TextArea] public string Text;
    }
}