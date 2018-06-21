using System.Collections.Generic;
using System.Text;

namespace Room
{
    class LEDPattern
    {
        private List<List<LEDState>> states = new List<List<LEDState>>();

        public void GenerateLoop(StringBuilder sb)
        {
            int max = 0;
            foreach (var list in states)
                if (list.Count > max)
                    max = list.Count;

            for (int i = 0; i < max; i++)
                for (int j = 0; j < LEDCodeGenerator.Leds.Count; j++)
                    if (states[j].Count > i)
                        LEDCodeGenerator.Leds[j].ApplyState(sb, states[j][i]);
        }
    }
}
