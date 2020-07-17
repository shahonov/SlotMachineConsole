namespace SlotMachineConsole.Models
{
    public class RowResult
    {
        public RowResult(bool isMatch, char winChar, double winCoef)
        {
            this.IsMatch = isMatch;
            this.WinChar = winChar;
            this.WinCoefficient = double.Parse(string.Format("{0:0.00}", winCoef));
        }

        public bool IsMatch { get; set; }

        public char WinChar { get; set; }

        public double WinCoefficient { get; set; }
    }
}
