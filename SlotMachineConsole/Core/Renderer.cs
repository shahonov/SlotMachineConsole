using System;
using System.Collections.Generic;

namespace SlotMachineConsole.Core
{
    public class Renderer
    {
        private readonly Matcher _matcher;

        public Renderer()
        {
            this._matcher = new Matcher();
        }

        public void Render(List<List<char>> slots)
        {
            var totalCoef = 0d;
            foreach (var row in slots)
            {
                var matchResult = this._matcher.IsMatch(row[0], row[1], row[2]);
                if (matchResult.IsMatch)
                {
                    Console.WriteLine($"| {row[0]}---{row[1]}---{row[2]} | WIN COEF: {matchResult.WinCoefficient}");
                    totalCoef += matchResult.WinCoefficient;
                }
                else
                {
                    Console.WriteLine($"| {row[0]} | {row[1]} | {row[2]} |");
                }
            }

            if (totalCoef > 0)
            {
                Console.WriteLine($"---------------------------");
                Console.WriteLine($"------- TOTAL WIN COEF: {totalCoef}");
            }
        }
    }
}
