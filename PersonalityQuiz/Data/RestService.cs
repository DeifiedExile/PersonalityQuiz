using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityQuiz.Data
{
    public class RestService : IRestService
    {
        HttpClient _client;
        public List<CharacterModel> Characters { get; private set; }
        public RestService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
        }

        //public void SetAuthToken()
        //{
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
        //}
        public async Task<List<CharacterModel>> RefreshDataAsync()
        {
            Characters = new List<CharacterModel>();
            int test = 1;
            //var uri = new Uri(string.Format(Constants.CharacterUrl, string.Empty));

            try
            {

                //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
                //SetAuthToken();
                foreach (string id in Constants.CharacterIDs)
                {
                    test++;
                    var uri = new Uri(string.Format((Constants.CharacterUrl + id), string.Empty));
                    var response = await _client.GetAsync(uri);
                    if(response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        CharacterModel character = JsonConvert.DeserializeObject<CharacterModel>(content);
                        Characters.Add(character);
                    }
                }
            }
            catch( Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Characters;
        }


    }
}
