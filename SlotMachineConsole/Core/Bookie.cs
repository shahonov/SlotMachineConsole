using SlotMachineConsole.Models;

namespace SlotMachineConsole.Core
{
    public class Bookie
    {
        public Bookie(User user, double spinStake)
        {
            this.User = user;
            this.SpinStake = spinStake;
        }

        public double SpinStake { get; set; }

        public User User { get; set; }
    }
}
