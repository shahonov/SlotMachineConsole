namespace SlotMachineConsole.Models
{
    public class User
    {
        private double _amount;

        public User(double deposit)
        {
            this.Amount = deposit;
        }

        public double Amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                var rounded = string.Format("{0:0.00}", value);
                this._amount = double.Parse(rounded);
            }
        }

        public bool CoverStake(double stake)
        {
            return this.Amount - stake >= 0;
        }
    }
}
