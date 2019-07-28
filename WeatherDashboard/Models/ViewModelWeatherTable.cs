using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeatherDashboard.Models
{
        public class ViewModelWeatherTable
    {
                    public string  city_name { get; set; }
                    public string temp { get; set; }
                    public string datetime { get; set; }
                    public string max_temp { get; set; }
                    public string min_temp { get; set; }
                    public double? intemp { get; set; }
                    public string unidades { get; set; }
    }


    
}