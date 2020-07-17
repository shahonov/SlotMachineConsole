using SlotMachineConsole.Models;

namespace SlotMachineConsole.Core
{
    public class Matcher
    {
        private readonly CoefficientCalculator _coefficientCalculator;

        public Matcher()
        {
            this._coefficientCalculator = new CoefficientCalculator();
        }

        public RowResult IsMatch(char a, char b, char c)
        {
            if (a == b && b == c)
            {
                var coef = this._coefficientCalculator.Calculate(a, 0);
                return new RowResult(true, a, coef);
            }

            var oneWildMatch = this.IsOneWildcardMatch(a, b, c);
            if (oneWildMatch.IsMatch)
            {
                return oneWildMatch;
            }

            var twoWildsMatch = this.IsTwoWildcardsMatch(a, b, c);
            if (twoWildsMatch.IsMatch)
            {
                return twoWildsMatch;
            }

            return new RowResult(false, 'o', 0);
        }

        private RowResult IsOneWildcardMatch(char a, char b, char c)
        {
            if (a == '*' && b == c)
            {
                var coef = this._coefficientCalculator.Calculate(b, 1);
                return new RowResult(true, b, coef);
            }

            if (b == '*' && a == c)
            {
                var coef = this._coefficientCalculator.Calculate(a, 1);
                return new RowResult(true, a, coef);
            }

            if (c == '*' && a == b)
            {
                var coef = this._coefficientCalculator.Calculate(a, 1);
                return new RowResult(true, a, coef);
            }

            return new RowResult(false, 'o', 0);
        }

        private RowResult IsTwoWildcardsMatch(char a, char b, char c)
        {
            if (a == '*' && b == '*')
            {
                var coef = this._coefficientCalculator.Calculate(c, 2);
                return new RowResult(true, c, coef);
            }

            if (b == '*' && a == c)
            {
                var coef = this._coefficientCalculator.Calculate(c, 2);
                return new RowResult(true, c, coef);
            }

            if (c == '*' && a == b)
            {
                var coef = this._coefficientCalculator.Calculate(a, 2);
                return new RowResult(true, a, coef);
            }

            return new RowResult(false, 'o', 0);
        }
    }
}
