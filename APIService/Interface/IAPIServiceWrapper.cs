using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIService
{
    public interface IAPIServiceWrapper
    {
        Task<string> GetHotelDetailsList(int destinationId, int nights,string authCode, string ApiUrl);
    }
}
