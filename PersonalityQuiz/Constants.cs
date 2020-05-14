using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalityQuiz
{
    public class Constants
    {
        public static string BaseAddress = "https://the-one-api.herokuapp.com/v1";
        public static string CharacterUrl = BaseAddress + "/character/";
        public static string Token = "qgaqRL_MIn_58dZ4JvEA";
        public static List<String> CharacterIDs = new List<string>
        {
           "5cd99d4bde30eff6ebccfbe6", //Aragorn
           "5cd99d4bde30eff6ebccfea0", //Gandalf
           "5cd99d4bde30eff6ebccfe9e", //Gollum
           "5cd99d4bde30eff6ebccfea5" //Sauron
        }; 
    }
}
