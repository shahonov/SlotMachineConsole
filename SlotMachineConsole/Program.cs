using SlotMachineConsole.Core;
using SlotMachineConsole.Models;
using System;
using System.Collections.Generic;

namespace SlotMachineConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var all = new List<List<char>>()
            {
                new List<char>() { 'A', 'A', 'A' },
                new List<char>() { 'B', 'B', '*' },
                new List<char>() { 'B', 'B', 'P' },
                new List<char>() { 'B', 'B', 'A' },
                new List<char>() { '*', 'A', 'A' },
            };
            var a = new Renderer();
            a.Render(all);

            var engine = new Engine();

            Console.Write("Enter deposit amount: ");
            var amount = decimal.Parse(Console.ReadLine());
            var user = new User(amount);

            Console.Write("Enter spin stake: ");
            var stake = decimal.Parse(Console.ReadLine());
            while (user.Deposit - stake >= 0)
            {
                engine.Spin();
                Console.Write("Enter spin stake: ");
                stake = decimal.Parse(Console.ReadLine());
            }

            var e = new Engine();
        }
    }
}
