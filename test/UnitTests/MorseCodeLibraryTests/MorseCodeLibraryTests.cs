using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MorseCodeLibraryTests
{
    public class MorseCodeLibraryTests
    {
        private MorseCode _morseCode;
        private MorseCodeEncodingHelper _morseCodeEncodingHelper;

        public MorseCodeLibraryTests()
        {
            _morseCode = new MorseCode();
            _morseCodeEncodingHelper = new MorseCodeEncodingHelper();
        }
        
        
        [Theory]
        [InlineData("···· · −·−−   ·−−− ··− −·· ·")] // HEY JUDE
        public void MorseCode_CorrectlyReturnsScenario(string morseCode)
        {
            _morseCode.Get(morseCode);
        }


        [Theory]
        [InlineData("···−−−···")]
        public void MorseCode_CorrectlyReadsServiceCodes(string serviceCode)
        {
            var sos=_morseCode.Get(serviceCode);

            Assert.Equal("SOS",sos);
        }


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
                
                return "";
            }

            public bool IsServiceCode(string serviceCode)
            {
                return MorseCodeEncodingHelper.SpecialServiceCodes.ContainsKey(serviceCode);
            }
        }

        public class MorseCodeEncodingHelper
        {
            public static Dictionary<string, string> SpecialServiceCodes = new Dictionary<string, string>()
            {
                {"···−−−···","SOS"},
            };

            public static Dictionary<string, char> MorseDictionary = new Dictionary<string, char>()
            {
                {".-",'A'},
                {"-...",'B'},
                {"-.-.",'C'},
                {"-..",'D'},
                {".",'E'},
                {"..-.",'F'},
                {"--.",'G'},
                {"....",'H'},
                {"..",'I'},
                {".---",'J'},
                {"-.-",'K'},
                {".-..",'L'},
                {"--",'M'},
                {"-.",'N'},
                {"---",'O'},
                {".--.",'P'},
                {"--.-",'Q'},
                {".-.",'R'},
                {"...",'S'},
                {"-",'T'},
                {"..-",'U'},
                {"...-",'V'},
                {".--",'W'},
                {"-..-",'X'},
                {"-.--",'Y'},
                {"--..",'Z'},
                {".----",'1'},
                {"..---",'2'},
                {"...--",'3'},
                {"....-",'4'},
                {".....",'5'},
                {"-....",'6'},
                {"--...",'7'},
                {"---..",'8'},
                {"----.",'9'},
                {"-----",'0'},
            };

            private readonly Encoding _ascii = Encoding.ASCII;
            private readonly Encoding _defaultEncoding = Encoding.Default;
            public string FromAsciiEncoding(string input)
            {
                return EncodeTo(_ascii, _defaultEncoding, input);
            }

            public string ToAsciiEncoding(string input)
            {
                throw new NotImplementedException(); // EncodeBack
            }

            private string EncodeTo(Encoding currentEncoding,Encoding requiredEncoding,string input = "")
            {
                byte[] currentEncodingBytes = currentEncoding.GetBytes(input);

                // Perform the conversion from one encoding to the other and write to the byteArray.
                byte[] convertedBytes = Encoding.Convert(currentEncoding, requiredEncoding, currentEncodingBytes);
                char[] convertedChars = new char[requiredEncoding.GetCharCount(convertedBytes, 0, convertedBytes.Length)];
                requiredEncoding.GetChars(convertedBytes, 0, convertedBytes.Length, convertedChars, 0);

                return new string(convertedChars);
            }
        }
    }
}
