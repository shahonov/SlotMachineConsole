using System;
using System.Collections.Generic;

namespace SlotMachineConsole.Core
{
    public class Spinner
    {
        private readonly Matcher _matcher;

        public Spinner()
        {
            this._matcher = new Matcher();
        }

        public double Go(List<List<char>> slots)
        {
            var totalCoef = 0d;
            foreach (var row in slots)
            {
                var matchResult = this._matcher.IsMatch(row[0], row[1], row[2]);
                if (matchResult.IsMatch)
                {
                    Console.Write("| ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{row[0]}---{row[1]}---{row[2]}");
                    Console.ResetColor();
                    Console.Write(" | ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"WIN COEF: {matchResult.WinCoefficient}");
                    Console.ResetColor();
                    totalCoef += matchResult.WinCoefficient;
                }
                else
                {
                    Console.Write("| ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{row[0]} | {row[1]} | {row[2]}");
                    Console.ResetColor();
                    Console.WriteLine(" |");
                }
            }

            if (totalCoef > 0)
            {
                Console.WriteLine($"---------------------------");
                Console.Write("------- ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"TOTAL WIN COEF: {totalCoef}");
                Console.ResetColor();
            }

            return totalCoef;
        }
    }
}
