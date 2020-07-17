namespace SlotMachineConsole.Models
{
    public class User
    {
        public User(decimal deposit)
        {
            this.Deposit = deposit;
        }

        public decimal Deposit { get; set; }
    }
}
