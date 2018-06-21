using System.Text;

namespace Room
{
    class ScreenState
    {
        public string Text { get; set; }
        public double Time { get; set; }

        public void GenerateLoop(StringBuilder sb)
        {
            sb.Append("\tlcd.print(\"");
            sb.Append(Text);
            sb.Append("\");\n\tdelay(");
            sb.Append(Time);
            sb.AppendLine(");");
        }
    }
}
