using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    
    public class Order
{
        public int Id { get; set; }     
        public string Region { get; set; }
        public string Locality { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Price_Service { get; set; } = 0;
        public int Price_Tariff { get; set; }
        public int Price_Surcharge { get; set; }//*Доплата
        public int Price_declared_value { get; set; } = 0;
        public double Price_Cash_delivery { get; set; } = 0;
        public string Order_number { get; set; }
        public string Status { get; set; } = "API";
        //public DateTime Date_of_recording { get; set; }//DateTime.Today
        //public string Cause { get; set; }//Причина
        //public string Processing { get; set; }//"Не обработано"
        //public DateTime Processing_date { get; set; }
        //public string Filial { get; set; }
        public string Partner { get; set; }
        public string List { get; set; } = "0";
        public string Invoice { get; set; } = "0";
        public string Registry { get; set; } = "0";
        public int Ns { get; set; } = 0;
        public int Nn { get; set; } = 0;
        public int Nr { get; set; } = 0;
        //public string Tariffs { get; set; }//Table.Tarifs.Rows[0][0].ToString()
    }

}
