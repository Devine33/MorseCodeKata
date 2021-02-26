using MorseCodeLibrary;
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
    }
}
