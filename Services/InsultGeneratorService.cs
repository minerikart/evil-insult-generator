using Evil_Insult_Generator.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Runtime.Serialization.Json;

namespace Evil_Insult_Generator.Services
{
    public class InsultGeneratorService
    {
        public HttpClient httpClient;
        public InsultGeneratorService() 
        {
            this.httpClient = new HttpClient();
        }

        Root theInsult = new();

        public async Task<Root> GetInsultAsync()
        {

            var url = "https://evilinsult.com/generate_insult.php?lang=en&type=json";
            HttpResponseMessage message = await httpClient.GetAsync(url);

            if(message.IsSuccessStatusCode)
            {
                //EL CODIGO QUE FUNCIONA//
                HttpContent content = message.Content;
                string mycontent = await content.ReadAsStringAsync();
                theInsult = JsonConvert.DeserializeObject<Root>(mycontent);
            }



            return theInsult;
        } 
    }
}
