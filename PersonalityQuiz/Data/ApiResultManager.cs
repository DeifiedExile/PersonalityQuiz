using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityQuiz.Data
{
    public class ApiResultManager
    {
        IRestService restService;

        public ApiResultManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<CharacterModel>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }
    }
}
