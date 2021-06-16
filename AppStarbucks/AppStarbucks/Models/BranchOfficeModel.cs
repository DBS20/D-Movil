using System;
using System.Collections.Generic;
using System.Text;

namespace AppStarbucks.Models
{
    public class BranchOfficeModel
    {
        public int ID { get; set; }

        public string Place { get; set; }//Lugar

        public string Address { get; set; }//Dirección

        public string Image { get; set; }//Imagen

        public double Latitude { get; set; }//Latitud

        public double Longitude { get; set; }//Longitud
    }
}
