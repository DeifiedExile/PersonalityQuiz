using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace PersonalityQuiz
{
    class CharacterModel
    {
        public CharacterModel(string name, string description, string imageUrl)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }

        static CharacterModel()
        {
            All = new List<CharacterModel>
            {
                new CharacterModel("Gollum", "Twisted Recluse", "https://vignette.wikia.nocookie.net/lotr/images/e/e1/Gollum_Render.png/revision/latest?cb=20141218075509"),
                new CharacterModel("Aragorn", "Reluctant Leader", "https://vignette.wikia.nocookie.net/lotr/images/b/b6/Aragorn_profile.jpg/revision/latest/scale-to-width-down/333?cb=20170121121423"),
                new CharacterModel("Sauron", "Evil Conqueror", "https://vignette.wikia.nocookie.net/lotr/images/9/90/Sauron-2.jpg/revision/latest?cb=20110508182634"),
                new CharacterModel("Gandalf", "Benevolent Wizard", "https://vignette.wikia.nocookie.net/lotr/images/e/e7/Gandalf_the_Grey.jpg/revision/latest/scale-to-width-down/350?cb=20121110131754"),
                new CharacterModel("","","")
            };
        }

        public static IList<CharacterModel> All { private set; get; }

    }
}
