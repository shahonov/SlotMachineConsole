﻿using System;
using SlotMachineConsole.Core;
using SlotMachineConsole.Models;

namespace SlotMachineConsole
{
    public class Startup
    {
        private readonly Engine _engine;

        public Startup()
        {
            this._engine = new Engine();
        }

        public void Go()
        {
            var user = this.CreateUser();
            var stake = this.SetStake(user);

            var bookie = new Bookie(user, stake);

            this.Loop(bookie);
        }

        private void Loop(Bookie bookie)
        {
            while (bookie.User.CoverStake(bookie.SpinStake))
            {
                Console.WriteLine("---------- User Amount: " + bookie.User.Amount);

                var winAmount = this.GetWinAmount(bookie);
                if (winAmount > 0)
                {
                    bookie.User.Amount += winAmount;
                }

                Console.WriteLine("----------- Win Amount: " + winAmount);
                Console.WriteLine("---------- User Amount: " + bookie.User.Amount);

                if (bookie.User.Amount == 0)
                {
                    break;
                }

                bookie.SpinStake = this.SetStake(bookie.User);
            }

            Console.WriteLine("**-----GAME OVER-----**");
        }

        private User CreateUser()
        {
            Console.Write("Enter deposit amount: ");
            var amount = double.Parse(Console.ReadLine());
            var user = new User(amount);

            return user;
        }

        private double SetStake(User user)
        {
            Console.Write("Enter spin stake: ");
            var stake = double.Parse(Console.ReadLine());
            while (user.Amount - stake < 0)
            {
                Console.WriteLine("Insufficient funds. Enter lower stake.");
                Console.Write("Enter spin stake: ");
                stake = double.Parse(Console.ReadLine());
            }

            return stake;
        }

        private double GetWinAmount(Bookie bookie)
        {
            bookie.User.Amount -= bookie.SpinStake;
            var winCoef = this._engine.Spin();
            var winAmount = string.Format("{0:0.00}", winCoef * bookie.SpinStake);

            return double.Parse(winAmount);
        }
    }
}
