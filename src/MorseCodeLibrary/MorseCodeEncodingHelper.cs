using System.Collections.Generic;

namespace MorseCodeLibrary
{
    public class MorseCodeEncodingHelper
    {
        public static Dictionary<string, string> SpecialServiceCodes = new Dictionary<string, string>()
        {
            {"···−−−···", "SOS"},
        };

        public static Dictionary<string, char> MorseDictionary = new Dictionary<string, char>()
        {
            {"·−", 'A'},
            {"−···", 'B'},
            {"−·−·", 'C'},
            {"−··", 'D'},
            {"·", 'E'},
            {"··−·", 'F'},
            {"−−·", 'G'},
            {"····", 'H'},
            {"··", 'I'},
            {"·−−−", 'J'},
            {"−·−", 'K'},
            {"·−··", 'L'},
            {"−−", 'M'},
            {"−·", 'N'},
            {"−−−", 'O'},
            {"·−−·", 'P'},
            {"−−·−", 'Q'},
            {"·−·", 'R'},
            {"···", 'S'},
            {"−", 'T'},
            {"··−", 'U'},
            {"···−", 'V'},
            {"·−−", 'W'},
            {"−··−", 'X'},
            {"−·−−", 'Y'},
            {"−−··", 'Z'},
            {"·−−−−", '1'},
            {"··−−−", '2'},
            {"···−−", '3'},
            {"····−", '4'},
            {"·····", '5'},
            {"−····", '6'},
            {"−−···", '7'},
            {"−−−··", '8'},
            {"−−−−·", '9'},
            {"-----", '0'},
        };
    }
}