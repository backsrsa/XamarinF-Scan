using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ScannerMot.Models;

namespace ScannerMot.Services
{
   public class ApiService
    {
        public async Task<List<Service>> GetAllServicesTask()
        {
            using (HttpClient client = new HttpClient())
            {
                // string url = "http://192.168.20.140:8084/api/services";
                string url = $"http://192.168.20.55:8086/api/services/lastservicesbyhotel/{"R1"}";
                // client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
                var result = await client.GetAsync(url);

                string data = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<Service>>(data);
                }
                else
                    return new List<Service>();
            }
        }

        public async Task<Service> CreateServiceTask(Service newService)
        {
            using (HttpClient client = new HttpClient())
            {
                // string url = "http://192.168.20.140:8084/api/services";
                string url = "http://192.168.20.55:8086/api/services";
                //client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");

                string content = JsonConvert.SerializeObject(newService);
                StringContent body = new StringContent(content, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, body);

                string data = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Service>(data);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
