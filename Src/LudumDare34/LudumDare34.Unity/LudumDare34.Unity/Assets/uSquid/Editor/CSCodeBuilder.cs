using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uSquid.Editor
{
    public class CSCodeBuilder
    {
        public void AppendLine()
        {
            AppendLine(string.Empty);
        }
        public void AppendLine(string line)
        {
            for (int i = 0; i < _tabIndent; i++)
            {
                _stringBuilder.Append('\t');
            }

            _stringBuilder.Append(line);
            _stringBuilder.Append(Environment.NewLine);
        }

        public void BeginBlock()
        {
            AppendLine("{");
            _tabIndent++;
        }

        public void EndBlock()
        {
            _tabIndent--;
            AppendLine("}");
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }

        private int _tabIndent = 0;
        private StringBuilder _stringBuilder = new StringBuilder();
    }
}
