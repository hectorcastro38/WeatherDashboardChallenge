using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeatherDashboard.Models
{
        public class ViewModelCiudadCoordenadas
        {
           public string Ciudad { get; set; }
           public string Coordenadas { get; set; }
        }
        public class ViewModelTempScale
        {
            public string Metric { get; set; }
            public string Simbol { get; set; }

        }



}