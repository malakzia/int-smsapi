using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using SMS.API;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {

//        "{
//  "customerid": "8dab-f6aa-909a-4d13-a11d-8456e3436710",
//  "key": "de3543e3-02f2-4c7d-a721-ab274f50f601",
//  "secret": "ff463aca181f3627f7aa0694b3b054c4274c3ec7b95bb3ce2e97cb063fc02a59"
//}"
        public async Task<ActionResult> Index()
        {
            
            var smsApi = new SMSAPI();


            //var result = await smsApi.SendSmsAsync("923136766611", "You are invited");
            //await smsApi.SendSmsAsync("16172752616", "You are invited");


            //ViewBag.Secret = result;
            //var apiInstance = new AuthApi();
            //var customerid = "8dab-f6aa-909a-4d13-a11d-8456e3436710";  // string | The Customer ID

            //try
            //{
            //    ApiKeyResponse result = apiInstance.KeySecret(customerid);
            //    ViewBag.Secret = result.ToJ;
            //}
            //catch (Exception e)
            //{
            //    Debug.Print("Exception when calling AuthApi.KeySecret: " + e.Message);
            //}

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}