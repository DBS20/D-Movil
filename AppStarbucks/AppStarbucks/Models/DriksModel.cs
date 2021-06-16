using System;
using System.Collections.Generic;
using System.Text;

namespace AppStarbucks.Models
{
    public  class DriksModel
    {
        public int ID { get; set; }

        public string Name { get; set; }//Nombre

        public double Price { get; set; }//Precio

        public string Size { get; set; }//Tamaño: Chico-Mediano-Alto

        public string CustomerName { get; set; }//NombreCliente

        public string Type { get; set; }//Tipo:Frío o Caliente

        public string Image { get; set; }//Imagen
    }
}
