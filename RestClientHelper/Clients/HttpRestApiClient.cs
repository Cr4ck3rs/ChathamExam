using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestClientHelper.Abstractions;
using Newtonsoft.Json;

namespace RestClientHelper.Clients
{
    /// <summary>
    /// REST Caller implementation using an HTTP Client
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class HttpRestApiClient<T> : IRestClient<T>
	{
        public async Task<T> CallListEndPoint(string query)
        {
            // We can use gzip so let's benefit from it
            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            //Get the query using a REST call and if successful, deserialize it into the desired type
            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync().
                        ContinueWith<T>(getTask => JsonConvert.DeserializeObject<T>(getTask.Result));
                }
            }

            //Else just return the default type's value
            return default(T);
        }
    }
}
