using SlotMachineConsole.Models;

namespace SlotMachineConsole.Core
{
    public class ResultFactory
    {
        public IMatchResult ProduceTruthy(char winChar, double winCoef)
        {
            return new RowResult(true, winChar, winCoef);
        }

        public IMatchResult ProduceFalsy()
        {
            return new RowResult(false, 'o', 0);
        }
    }
}
