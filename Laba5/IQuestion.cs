using System.Collections.Generic;

namespace Laba5
{
    internal interface IQuestion
    {
        public string _question { get; set; }
        public List<string> _answers { get; set; }
    }
}
