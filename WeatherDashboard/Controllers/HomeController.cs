using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WeatherDashboard.Models;
using System.Net;
using Newtonsoft.Json;

namespace WeatherDashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<ViewModelCiudadCoordenadas> CiudadesSonora = new List<ViewModelCiudadCoordenadas>();
            CiudadesSonora.Add(new ViewModelCiudadCoordenadas() { Ciudad = "Ciudad Obregon", Coordenadas = "27.4828,-109.9304" });
            CiudadesSonora.Add(new ViewModelCiudadCoordenadas() { Ciudad = "Hermosillo", Coordenadas = "29.08919,-110.96133" });
            CiudadesSonora.Add(new ViewModelCiudadCoordenadas() { Ciudad = "Navojoa", Coordenadas = "27.0727503,-109.4435958" });
            CiudadesSonora.Add(new ViewModelCiudadCoordenadas() { Ciudad = "Nogales", Coordenadas = "31.2910769,-110.936763" });

            List<ViewModelTempScale> temp = new List<ViewModelTempScale>();
            temp.Add(new ViewModelTempScale() {Metric= "Celcius", Simbol = "M" });
            temp.Add(new ViewModelTempScale() { Metric = "Kelvin", Simbol = "S" });
            temp.Add(new ViewModelTempScale() { Metric = "Fahrenheit", Simbol = "I" });


            ViewBag.Ciudades = CiudadesSonora;
            ViewBag.Temp = temp;
            return View();
        }

        [HttpPost]
        public JsonResult Clima(string Coordenadas, string units)
        {
           

            Coordenadas = Coordenadas ?? "27.4828,-109.9304";
            units = units ?? "M";  
            string unidad = ((units=="M") ? "°C" : ((units == "I") ? "°F" : "°K"));
            string unidades = ((units == "M") ? "Celcius" : ((units == "I") ? "Fahrenheit" : "Kelvin"));


            string[] c = Coordenadas.Split(',');
            string lat = c[0];
            string lon = c[1];
            List<ViewModelWeatherTable> WeatherInCity = new List<ViewModelWeatherTable>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://api.weatherbit.io/v2.0/forecast/daily?lat="+lat+"&lon="+lon+ "&units="+units+"&key=b95047f97c8244848a2847b1f203fab3");
                //HTTP GET
                var responseTask = client.GetAsync(client.BaseAddress.AbsoluteUri);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {


                    var readTask = result.Content.ReadAsStringAsync();//.ReadAsAsync<List<ViewModelWeather>>();
                    var weather = JsonConvert.DeserializeObject<ViewModelWeather>(readTask.Result);
                    foreach (var day in weather.data)
                    {
                            ViewModelWeatherTable dia = new ViewModelWeatherTable()
                            {
                                city_name = weather.city_name,
                                temp = day.temp.ToString()+""+unidad,
                                min_temp= day.min_temp.ToString() + "" + unidad,
                                max_temp =day.max_temp.ToString() + "" + unidad,
                                datetime = String.Format("{0:d/M/yyyy}", day.datetime),
                                intemp = day.temp,
                                unidades=unidades

                            };

                            WeatherInCity.Add(dia);


                    }

                    ViewBag.Ciudad = weather.city_name;


                    return Json(WeatherInCity);

                }
                else //web api sent error response 
                {
                    //log response status here..

                    return Json(false);
                }
            }
            //var product = products.Where(p => p.Id == idprueba || p.Name.Contains(search));
            return Json(true);
        }
    }


}
