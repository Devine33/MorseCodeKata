namespace MorseCodeLibrary
{
    public class MorseCode
    {
        private readonly string _wordSpace = "   ";
        private readonly string _letterSpace = " ";

        public string Get(string input)
        {
            if (IsServiceCode(input))
            {
                return MorseCodeEncodingHelper.SpecialServiceCodes[input];
            }

            var words = input.Split(_wordSpace);
            string morseCodeSentence = "";

            foreach (var word in words)
            {
                var letters = word.Split(_letterSpace);
                foreach (var letter in letters)
                {
                    if (MorseCodeEncodingHelper.MorseDictionary.ContainsKey(letter))
                    {
                        morseCodeSentence += MorseCodeEncodingHelper.MorseDictionary[letter];
                    }
                }

                morseCodeSentence += " ";
            }

            return morseCodeSentence.TrimEnd();
        }

        public bool IsServiceCode(string serviceCode)
        {
            return MorseCodeEncodingHelper.SpecialServiceCodes.ContainsKey(serviceCode);
        }
    }
}