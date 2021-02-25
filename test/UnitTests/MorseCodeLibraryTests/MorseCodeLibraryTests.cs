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
        [InlineData("···· · −·−−   ·−−− ··− −·· ·")]
        public void MorseCode_CorrectlyReturnsScenario(string morseCode)
        {
        }


        [Theory]
        [InlineData("···−−−···")]
        public void MorseCode_CorrectlyReadsServiceCodes(string serviceCode)
        {
        }


        public class MorseCode
        {
            private int _wordSpace = 3;
            public string Get(string input)
            {
                return "";
            }
        }

        public class MorseCodeEncodingHelper
        {
            public static Dictionary<char, string> MorseDictionary = new Dictionary<char, string>()
            {
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
