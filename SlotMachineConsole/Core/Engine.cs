using System;
using System.Collections.Generic;
using System.Linq;

namespace SlotMachineConsole.Core
{
    public class Engine
    {
        private readonly Renderer _renderer;
        private readonly Matcher _matcher;
        private List<char> _symbols;
        private readonly List<List<char>> _slots;

        public Engine()
        {
            this.InitSymbols();
            this._slots = new List<List<char>>
            {
                new List<char>() { 'o', 'o', 'o' },
                new List<char>() { 'o', 'o', 'o' },
                new List<char>() { 'o', 'o', 'o' },
                new List<char>() { 'o', 'o', 'o' }
            };
        }

        public void Spin()
        {
            for (var i = 0; i < this._slots.Count; i++)
            {
                for (var ii = 0; ii < this._slots[i].Count; ii++)
                {
                    var rnd = new Random();
                    var index = rnd.Next(0, 100);
                    var symbol = this._symbols[index];
                    this._slots[i][ii] = symbol;
                }
            }
        }

        private void InitSymbols()
        {
            this._symbols = new List<char>();
            this.AddApples();
            this.AddBananas();
            this.AddPineapples();
            this.AddWildcards();
        }

        private void AddApples()
        {
            var apples = this.FillChars(45, 'A');
            this._symbols.AddRange(apples);
        }

        private void AddBananas()
        {
            var bananas = this.FillChars(35, 'B');
            this._symbols.AddRange(bananas);
        }

        private void AddPineapples()
        {
            var pineapples = this.FillChars(15, 'P');
            this._symbols.AddRange(pineapples);
        }

        private void AddWildcards()
        {
            var wildcards = this.FillChars(5, '*');
            this._symbols.AddRange(wildcards);
        }

        private char[] FillChars(int length, char symbol)
        {
            var chars = new char[length];
            for (var i = 0; i < length; i++)
            {
                chars[i] = symbol;
            }

            return chars;
        }
    }
}
