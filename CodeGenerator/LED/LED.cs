using System.Text;

namespace Room
{
    class LED
    {
        private int RedPin { get; set; }
        private int GreenPin { get; set; }
        private int BluePin { get; set; }
        private int CommonPin { get; set; }
        private bool Anode { get; set; }

        public void GenerateSetup(StringBuilder sb, int tabs = 1)
        {
            sb.Append('\t', tabs);
            sb.Append("pinMode(");
            sb.Append(RedPin);
            sb.Append(", OUTPUT);\n");
            sb.Append('\t', tabs);
            sb.Append("pinMode(");
            sb.Append(GreenPin);
            sb.Append(", OUTPUT);\n");
            sb.Append('\t', tabs);
            sb.Append("pinMode(");
            sb.Append(BluePin);
            sb.Append(", OUTPUT);\n");
            sb.Append('\t', tabs);
            sb.Append("pinMode(");
            sb.Append(CommonPin);
            sb.Append(", OUTPUT);\n");

            if (Anode)
                SetDefaultLevelAnode(sb, tabs);
        }

        private void SetDefaultLevelAnode(StringBuilder sb, int tabs = 1)
        {
            sb.Append('\t', tabs);
            sb.Append("digitalWrite(");
            sb.Append(RedPin);
            sb.Append(", HIGH);\n");
            sb.Append('\t', tabs);
            sb.Append("digitalWrite(");
            sb.Append(GreenPin);
            sb.Append(", HIGH);\n");
            sb.Append('\t', tabs);
            sb.Append("digitalWrite(");
            sb.Append(BluePin);
            sb.Append(", HIGH);\n");
            sb.Append('\t', tabs);
            sb.Append("digitalWrite(");
            sb.Append(CommonPin);
            sb.Append(", HIGH);\n");
        }

        public void ApplyState(StringBuilder sb, LEDState state, int tabs = 1)
        {
            if (Anode)
                ApplyStateAnode(sb, state, tabs);
            else
                ApplyStateCathode(sb, state, tabs);
        }

        private void ApplyStateAnode(StringBuilder sb, LEDState state, int tabs = 1)
        {
            sb.Append('\t', tabs);
            sb.Append("analogWrite(");
            sb.Append(RedPin);
            sb.Append(", 255-");
            sb.Append(state.Red);
            sb.Append(");\n");
            sb.Append('\t', tabs);
            sb.Append("analogWrite(");
            sb.Append(GreenPin);
            sb.Append(", 255-");
            sb.Append(state.Green);
            sb.Append(");\n");
            sb.Append('\t', tabs);
            sb.Append("analogWrite(");
            sb.Append(BluePin);
            sb.Append(", 255-");
            sb.Append(state.Blue);
            sb.Append(");\n");
            sb.Append('\t', tabs);
            sb.Append("digitalWrite(");
            sb.Append(CommonPin);
            sb.Append(", HIGH);\n");
            sb.Append('\t', tabs);
            sb.Append("delay(");
            sb.Append(state.Duration);
            sb.Append(");\n");
        }

        private void ApplyStateCathode(StringBuilder sb, LEDState state, int tabs = 1)
        {
            sb.Append('\t', tabs);
            sb.Append("analogWrite(");
            sb.Append(RedPin);
            sb.Append(", ");
            sb.Append(state.Red);
            sb.Append(");\n");
            sb.Append('\t', tabs);
            sb.Append("analogWrite(");
            sb.Append(GreenPin);
            sb.Append(", ");
            sb.Append(state.Green);
            sb.Append(");\n");
            sb.Append('\t', tabs);
            sb.Append("analogWrite(");
            sb.Append(BluePin);
            sb.Append(", ");
            sb.Append(state.Blue);
            sb.Append(");\n");
            sb.Append('\t', tabs);
            sb.Append("digitalWrite(");
            sb.Append(CommonPin);
            sb.Append(", HIGH);\n");
            sb.Append('\t', tabs);
            sb.Append("delay(");
            sb.Append(state.Duration);
            sb.Append(");\n");
        }
    }
}
