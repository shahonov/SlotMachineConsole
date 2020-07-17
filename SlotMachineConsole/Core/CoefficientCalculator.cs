using System;

namespace SlotMachineConsole.Core
{
    public class CoefficientCalculator
    {
        private double _appleCoef = 0.4;
        private double _bananaCoef = 0.6;
        private double _pineappleCoef = 0.8;

        public double Calculate(char symbol, int wildcards)
        {
            if (symbol == 'A')
            {
                return this.CalcMatch(this._appleCoef, wildcards);
            }
            else if (symbol == 'B')
            {
                return this.CalcMatch(this._bananaCoef, wildcards);
            }
            else if (symbol == 'P')
            {
                return this.CalcMatch(this._pineappleCoef, wildcards);
            }
            else if (symbol == '*')
            {
                return 0;
            }
            else
            {
                throw new Exception($"Invalid symbol was passed to {nameof(CoefficientCalculator)}");
            }
        }

        private double CalcMatch(double baseCoef, int wildcards)
        {
            if (wildcards == 0)
            {
                return baseCoef * 3;
            } 
            else if (wildcards == 1)
            {
                return baseCoef * 2;
            } 
            else if (wildcards == 2)
            {
                return baseCoef;
            }
            else
            {
                return 0;
            }
        }
    }
}
