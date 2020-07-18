namespace SlotMachineConsole.Models
{
    public interface IMatchResult
    {
        bool IsMatch { get; set; }

        char WinChar { get; set; }

        double WinCoefficient { get; set; }
    }
}
