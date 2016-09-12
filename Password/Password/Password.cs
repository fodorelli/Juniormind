/*Scrie o func?ie care genereaza o parola de pâna la X caractere.
Func?ia ofera ca ?i op?iuni:
   Func?ia ofera ca ?i op?iuni:
    litere mici
    litere mari ?i numarul lor
    cifre ?i numarul lor
    simboluri ?i numarul lor
    sa nu includa caracterele similare: l, 1, I, o, 0, O
    sa nu includa caractere ambigue: {}[]()/\'"~,;.<>
*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Password
{
    [TestClass]
    public class Password
    {
        [TestMethod]
        public void SmallLetters()
        {
            var password = GeneratePassword(new Option(10, 1, 2, 3, false, true));
            Assert.AreEqual(4, CountCharacters(password, 'a', 'z'));
        }

        [TestMethod]
        public void CapitalLetters()
        {
            var password = GeneratePassword(new Option(10, 1, 2, 3, false, true));
            Assert.AreEqual(1, CountCharacters(password, 'A', 'Z'));
        }

        [TestMethod]
        public void Numbers()
        {
            var password = GeneratePassword(new Option(10, 1, 2, 3, false, true));
            Assert.AreEqual(2, CountCharacters(password, (char)0, (char)9));
        }

        [TestMethod]
        public void Symbols()
        {
            string symbols = "!#$%&()*,+-./:;<=>?@[\\]^_'`{|}~";
            var password = GeneratePassword(new Option(10, 1, 2, 3, false, true));
            Assert.AreEqual(3, CountSymbols(password, symbols));
        }

        [TestMethod]
        public void EliminateCharacters()
        {
            Assert.AreEqual("aaa", GenerateLettersAndNumbers(3, 'a', 'b', "c"));
        }

        [TestMethod]
        public void EliminateSymbols()
        {
            var symbols = "$&&";
            Assert.AreEqual("&&&", GenerateSymbols(3, symbols, "$"));
        }

        struct Option
        {
            public int PasswordLength;
            public int NoOfCapitalLetters;
            public int NoOfNumbers;
            public int NoOfSymbols;
            public bool EliminateSimilarCharacters;
            public bool EliminateAmbiguousCharacters;

            public Option(int PasswordLength, int NoOfCapitalLetters, int NoOfNumbers, int NoOfSymbols, bool EliminateSimilarCharacters, bool EliminateAmbiguousCharacters)
            {
                this.PasswordLength = PasswordLength;
                this.NoOfCapitalLetters = NoOfCapitalLetters;
                this.NoOfNumbers = NoOfNumbers;
                this.NoOfSymbols = NoOfSymbols;
                this.EliminateSimilarCharacters = EliminateSimilarCharacters;
                this.EliminateAmbiguousCharacters = EliminateAmbiguousCharacters;
            }
        }
        string GeneratePassword(Option options)
        {
            string password = string.Empty;
            string symbols = "!#$%&()*,+-./:;<=>?@[\\]^_'`{|}~";
            string similarCharacters = string.Empty, ambiguousCharacters = string.Empty;
            int NoOfSmallLetters = options.PasswordLength - options.NoOfCapitalLetters - options.NoOfNumbers - options.NoOfSymbols;

            if (options.EliminateSimilarCharacters)
                similarCharacters = "l1Io0O";

            password = GenerateLettersAndNumbers(NoOfSmallLetters, 'a', 'z' + 1, similarCharacters)
                     + GenerateLettersAndNumbers(options.NoOfCapitalLetters, 'A', 'Z' + 1, similarCharacters)
                     + GenerateLettersAndNumbers(options.NoOfNumbers, 0, 10, similarCharacters);

            if (options.EliminateAmbiguousCharacters)
                ambiguousCharacters = "{}[]()/\'~,;.<>";

            password += GenerateSymbols(options.NoOfSymbols, symbols, ambiguousCharacters);

            return ShufflePassword(password);
        }

        string GenerateLettersAndNumbers(int number, int start, int end, string charactersToEliminate)
        {
            Random random = new Random();
            string result = null;
            char[] eliminate = charactersToEliminate.ToCharArray(0, charactersToEliminate.Length);
            for (int i = 0; i < number; i++)
            {
                char character = (char)random.Next(start, end);
                while (Array.IndexOf(eliminate, character) >= 0)
                    character = (char)random.Next(start, end);
                result += character.ToString();
            }
            return result;
        }

        string GenerateSymbols(int number, string symbols, string charactersToEliminate)
        {
            string result = null;
            Random random = new Random();
            char[] eliminate = charactersToEliminate.ToCharArray(0, charactersToEliminate.Length);
            for (int i = 0; i < number; i++)
            {
                int position = random.Next(0, symbols.Length);
                while (Array.IndexOf(eliminate, symbols[position]) >= 0)
                    position = random.Next(0, symbols.Length);
                result += symbols[position];
            }
            return result;
        }

        int CountCharacters(string password, char first, char last)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
                if (password[i] >= first && password[i] <= last)
                    count++;
            return count;
        }

        int CountSymbols(string password, string symbols)
        {
            int count = 0;
            char[] symbol = symbols.ToCharArray(0, symbols.Length);
            for (int i = 0; i < password.Length; i++)
                if (Array.IndexOf(symbol, password[i]) >= 0)
                    count++;
            return count;
        }

        string ShufflePassword(string password)
        {
            Random rand = new Random();
            char[] finalPassword = password.ToCharArray();
            int contor = finalPassword.Length;
            while (contor > 1)
            {
                contor--;
                int k = rand.Next(contor + 1);
                var value = finalPassword[k];
                finalPassword[k] = finalPassword[contor];
                finalPassword[contor] = value;
            }
            return new string(finalPassword);
        }
    }
}

