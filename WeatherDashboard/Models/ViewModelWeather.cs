using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeatherDashboard.Models
{
        public class ViewModelWeather
        {

                    public List<ViewModelWeatherDay> data { get; set; }
                    public string  city_name { get; set; }
                    public double? lon { get; set; }
                    public string timezone { get; set; }
                    public double? lat { get; set; }
                    public string country_code { get; set; }
                    public double? state_code { get; set; }
        }


        public class ViewModelWeatherDayWeather
        {
                    public string  icon { get; set; }
                    public double? code { get; set; }
                    public string description { get; set; }
        }


        public class ViewModelWeatherDay
            {
                    public double? moonrise_ts { get; set; }
                    public string   wind_cdir { get; set; }
                    public double?   rh { get; set; }
                    public double?    pres { get; set; }
                    public double?   sunset_ts { get; set; }
                    public double?    ozone { get; set; }
                    public double?  moon_phase { get; set; }
                    public double?    wind_gust_spd { get; set; }
                    public double?   snow_depth { get; set; }
                    public double?   clouds { get; set; }
                    public double?  ts { get; set; }
                    public double?  sunrise_ts { get; set; }
                    public double?  app_min_temp { get; set; }
                    public double? wind_spd { get; set; }
                    public double?  pop { get; set; }
                    public string wind_cdir_full { get; set; }
                    public double? slp { get; set; }
                    public double? app_max_temp { get; set; }
                    public double? vis { get; set; }
                    public double? dewpt { get; set; }
                    public double?  snow { get; set; }
                    public double? uv { get; set; }
                    public DateTime valid_date { get; set; }
                    public double?  wind_dir { get; set; }
                    public double? max_dhi { get; set; }
                    public double?  clouds_hi { get; set; }
                    public double?  precip { get; set; }
                    public ViewModelWeatherDayWeather weather { get; set; }
                    public double? max_temp { get; set; }
                    public double? moonset_ts { get; set; }
                    public DateTime datetime { get; set; }
                    public double? temp { get; set; }
                    public double? min_temp { get; set; }
                    public double? clouds_mid { get; set; }
                    public double? clouds_low { get; set; }

             }

}