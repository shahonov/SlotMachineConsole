using SlotMachineConsole.Models;

namespace SlotMachineConsole.Core
{
    public class Matcher
    {
        private readonly ResultFactory _factory;
        private readonly CoefficientCalculator _coefficientCalculator;

        public Matcher()
        {
            this._factory = new ResultFactory();
            this._coefficientCalculator = new CoefficientCalculator();
        }

        public IMatchResult IsMatch(char a, char b, char c)
        {
            if (a == b && b == c)
            {
                var coef = this._coefficientCalculator.Calculate(a, 0);
                return this._factory.ProduceTruthy(a, coef);
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

            return this._factory.ProduceFalsy();
        }

        private IMatchResult IsOneWildcardMatch(char a, char b, char c)
        {
            if (a == '*' && b == c)
            {
                var coef = this._coefficientCalculator.Calculate(b, 1);
                return this._factory.ProduceTruthy(b, coef);
            }

            if (b == '*' && a == c)
            {
                var coef = this._coefficientCalculator.Calculate(a, 1);
                return this._factory.ProduceTruthy(a, coef);
            }

            if (c == '*' && a == b)
            {
                var coef = this._coefficientCalculator.Calculate(a, 1);
                return this._factory.ProduceTruthy(a, coef);
            }

            return this._factory.ProduceFalsy();
        }

        private IMatchResult IsTwoWildcardsMatch(char a, char b, char c)
        {
            if (a == '*' && b == '*')
            {
                var coef = this._coefficientCalculator.Calculate(c, 2);
                return this._factory.ProduceTruthy(c, coef);
            }

            if (b == '*' && c == '*')
            {
                var coef = this._coefficientCalculator.Calculate(a, 2);
                return this._factory.ProduceTruthy(a, coef);
            }

            if (c == '*' && a == '*')
            {
                var coef = this._coefficientCalculator.Calculate(b, 2);
                return this._factory.ProduceTruthy(b, coef);
            }

            return this._factory.ProduceFalsy();
        }
    }
}
