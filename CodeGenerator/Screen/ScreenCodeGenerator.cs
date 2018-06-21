using System.Collections.Generic;
using System.Text;

namespace Room
{
    class ScreenCodeGenerator : ICodeGenerator
    {
        // Screen size
        private static int screenWidth;
        private static int screenHeight;

        // Pins
        private static int rs = 12; // reset
        private static int en = 11; // enable
        private static int d4 = 5;
        private static int d5 = 4;
        private static int d6 = 3;
        private static int d7 = 2;

        private Dictionary<string, ScreenPattern> values;
        public void SetValue(string key, ScreenPattern value)
        {
            values[key] = value;
        }
        
        public void DeleteValue(string key)
        {
            values.Remove(key);
        }

        public void SetParameters(int width, int height, int inrs, int inen, int ind4, int ind5, int ind6, int ind7)
        {
            screenWidth = width;
            screenHeight = height;

            rs = inrs;
            en = inen;
            d4 = ind4;
            d5 = ind5;
            d6 = ind6;
            d7 = ind7;
        }

        void GenerateDeclaration(StringBuilder sb)
        {
            sb.Append("const int rs = ");
            sb.Append(rs);
            sb.Append(";\nconst int en = ");
            sb.Append(en);
            sb.Append(";\nconst int d4 = ");
            sb.Append(d4);
            sb.Append(";\nconst int d5 = ");
            sb.Append(d5);
            sb.Append(";\nconst int d6 = ");
            sb.Append(d6);
            sb.Append(";\nconst int d7 = ");
            sb.Append(d7);
            sb.Append("static string command;");
            sb.AppendLine(";/nLiquidCrystal lcd(rs, en, d4, d5, d6, d7);");
        }
        
        void GenerateSetup(StringBuilder sb)
        {
            sb.Append("\tlcd.begin(");
            sb.Append(screenWidth);
            sb.Append(", ");
            sb.Append(screenHeight);
            sb.Append(");\n\tlcd.display();\n}\n");
        }

        void GenerateLoop(StringBuilder sb)
        {
            sb.Append("switch (command)\n{\n");
            foreach (var pair in values)
            {
                sb.Append("\tcase ");
                sb.Append(pair.Key);
                sb.Append("\t : \n");
                pair.Value.GenerateLoop(sb);
                sb.AppendLine("\tbreak;");
            }
            sb.AppendLine("}");
        }

        public StringBuilder Generate()
        {
            var sb = new StringBuilder();
            GenerateDeclaration(sb);
            sb.AppendLine("void setup()\n{)");
            GenerateSetup(sb);
            sb.AppendLine("}\n\nvoid loop()\n{");
            GenerateLoop(sb);
            sb.AppendLine("}");
            return sb;
        }
    }
}
