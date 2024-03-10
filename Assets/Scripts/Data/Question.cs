using System;
using System.Collections.Generic;

namespace Data
{
    [Serializable]
    public struct Question
    {
        public string Text;
        public string Answer;

        public List<string> BadAnswers;
    }
}