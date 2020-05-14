using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityQuiz.Data
{
    public interface IRestService
    {
        Task<List<CharacterModel>> RefreshDataAsync();
    }
}
