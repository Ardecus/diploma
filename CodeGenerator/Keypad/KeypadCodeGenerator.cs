using System.Collections.Generic;
using System.Text;

namespace Room
{
    class KeypadCodeGenerator : ICodeGenerator
    {
        private Dictionary<string, string> values;

        public void SetValue(string key, string value)
        {
            values[key] = value;
        }
        
        public void DeleteValue(string key)
        {
            values.Remove(key);
        }
        
        //void GenerateDeclaration(StringBuilder sb) { }
        //void GenerateSetup(StringBuilder sb) { }
        void GenerateLoop(StringBuilder sb)
        {
            sb.Append("switch (command)\n{\n");
            foreach (var pair in values)
            {
                sb.Append("\tcase ");
                sb.Append(pair.Key);
                sb.Append("\t : \n");
                // TODO
                // Send command pair.Value
                sb.AppendLine("\tbreak;");
            }
            sb.AppendLine("}");
        }
        
        public StringBuilder Generate()
        {
            var sb = new StringBuilder();
            //GenerateDeclaration(sb);
            sb.AppendLine("void setup()\n{)");
            //GenerateSetup(sb);
            sb.AppendLine("}\n\nvoid loop()\n{");
            GenerateLoop(sb);
            sb.AppendLine("}");
            return sb;
        }
    }
}
