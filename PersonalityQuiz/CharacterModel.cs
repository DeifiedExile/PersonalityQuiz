using System.Collections.Generic;
using System.Security;
using Newtonsoft.Json;

namespace PersonalityQuiz
{
    //class CharacterModel
    //{
    //    public CharacterModel(string name, string description, string imageUrl)
    //    {
    //        Name = name;
    //        Description = description;
    //        ImageUrl = imageUrl;
    //    }

    //    public string Name { get; private set; }
    //    public string Description { get; private set; }
    //    public string ImageUrl { get; private set; }

    //    static CharacterModel()
    //    {
    //        All = new List<CharacterModel>
    //        {
    //            new CharacterModel("Gollum", "Twisted Recluse", "Gollum_Render.png"),
    //            new CharacterModel("Aragorn", "Reluctant Leader", "Aragorn_profile.jpg"),
    //            new CharacterModel("Sauron", "Evil Conqueror", "Sauron_2.jpg"),
    //            new CharacterModel("Gandalf", "Benevolent Wizard", "Gandalf_the_Grey.jpg"),

    //        };
    //    }

    //    public static IList<CharacterModel> All { private set; get; }

    //}
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CharacterModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "race")]
        public string Race { get; set; }

        [JsonProperty(PropertyName = "_id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName ="wikiUrl")]
        public string Wiki { get; set; }
        
        

    }
}
