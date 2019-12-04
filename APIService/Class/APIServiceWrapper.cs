using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIService
{
    public class APIServiceWrapper : IAPIServiceWrapper
    {
        public async Task<string> GetHotelDetailsList(int destinationId, int nights, string authCode,string ApiUrl)
        {
            string apiResponse = "";
            try
            {
                /// Calling the API through HttpClient
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(ApiUrl))
                    {
                        apiResponse = await response.Content.ReadAsStringAsync();
                    }

                }
                return apiResponse;
            }
            catch(Exception ex)
            {
                return "";
            }
            
        }
    }
}
