using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace MorseCodeLibraryTests
{
    public class MorseCodeLibraryTests
    {
        private readonly MorseCode _morseCode;

        public MorseCodeLibraryTests()
        {
            _morseCode = new MorseCode();
            
        }
        
        
        [Theory]
        [InlineData("···· · −·−−   ·−−− ··− −·· ·","HEY JUDE")] // HEY JUDE
        public void MorseCode_CorrectlyReturnsScenario(string morseCode,string decodedWord)
        {
            var word = _morseCode.Get(morseCode);
           Assert.Equal(decodedWord, word);
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

            private MorseCodeEncodingHelper _morseCodeEncodingHelper;

            public MorseCode()
            {
                _morseCodeEncodingHelper = new MorseCodeEncodingHelper();
            }
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

        public class MorseCodeEncodingHelper
        {
            public static Dictionary<string, string> SpecialServiceCodes = new Dictionary<string, string>()
            {
                {"···−−−···","SOS"},
            };

            public static Dictionary<string, char> MorseDictionary = new Dictionary<string, char>()
            {
                {"·−",'A'},
                {"−···",'B'},
                {"−·−·",'C'},
                {"−··",'D'},
                {"·",'E'},
                {"··−·",'F'},
                {"−−·",'G'},
                {"····",'H'},
                {"··",'I'},
                {"·−−−",'J'},
                {"−·−",'K'},
                {"·−··",'L'},
                {"−−",'M'},
                {"−·",'N'},
                {"−−−",'O'},
                {"·−−·",'P'},
                {"−−·−",'Q'},
                {"·−·",'R'},
                {"···",'S'},
                {"−",'T'},
                {"··−",'U'},
                {"···−",'V'},
                {"·−−",'W'},
                {"−··−",'X'},
                {"−·−−",'Y'},
                {"−−··",'Z'},
                {"·−−−−",'1'},
                {"··−−−",'2'},
                {"···−−",'3'},
                {"····−",'4'},
                {"·····",'5'},
                {"−····",'6'},
                {"−−···",'7'},
                {"−−−··",'8'},
                {"−−−−·",'9'},
                {"-----",'0'},
            };
        }
    }
}
