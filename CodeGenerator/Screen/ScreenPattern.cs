using System.Collections.Generic;
using System.Text;

namespace Room
{
    class ScreenPattern
    {
        private List<ScreenState> states = new List<ScreenState>();

        //public void GenerateDeclaration(StringBuilder sb) { }
        //public void GenerateSetup(StringBuilder sb) { }
        public void GenerateLoop(StringBuilder sb)
        {
            foreach (var state in states)
                state.GenerateLoop(sb);
        }
    }
}
