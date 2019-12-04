using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using CheapTravel.Models;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using APIService;

namespace CheapTravel.Controllers
{
    public class HotelController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger Log;
        private readonly IAPIServiceWrapper ObjServiceWrapper;

        public HotelController(IConfiguration _config, IAPIServiceWrapper _ObjServiceWrapper, ILogger<HotelController> _Log) 
        {
            Configuration = _config;
            ObjServiceWrapper = _ObjServiceWrapper;
            Log = _Log;

        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetHotels(int destinationId,int nights)
        {
            try
            {
                var ApiUrl = Configuration.GetSection("APIUrl").Value;
                string AuthCode = Configuration.GetSection("AuthCode").Value;
                string apiResponse = "";
                ApiUrl += "findBargain?destinationId=" + Convert.ToString(destinationId) + "&nights=" + Convert.ToString(nights) + "&code=" + Convert.ToString(AuthCode);
                
                /// Calling Api Service to get JSON Data
                apiResponse = await ObjServiceWrapper.GetHotelDetailsList(destinationId, nights, AuthCode, ApiUrl);
                if(!string.IsNullOrEmpty(apiResponse))
                {
                    /// Show Log Information
                    Log.LogInformation(apiResponse);
                    /// Write Log into a File
                    Logger.WriteLog(apiResponse);
                    var RateType = Configuration.GetSection("RateType").Value.Split(",");
                    var ObjHotelList = JsonConvert.DeserializeObject<List<HotelModel>>(apiResponse).Select(x => new
                    {
                        HotelName = x.hotel == null ? "" : x.hotel.name,
                        BoardType = x.rates.Select(y => y.boardType),
                        RateType = x.rates.Select(y => y.rateType),
                        Rate = x.rates.Select(y => y.rateType == RateType[0] ? Math.Round((y.value * nights), 2) : Math.Round(y.value, 2))
                    }).ToList();
                    return Json(ObjHotelList);
                }
                else
                {
                    return Json("");
                }
               
            }
            catch (Exception ex)
            {
                /// Show Error Log Information
                Log.LogError(ex.Message);
                /// Write Log into a File
                Logger.WriteErrorLog(ex.Message);

                return Json(null);
            }
            
        }
    }
}