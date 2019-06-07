using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarServiceWeb.Models
{
    public class CarsModel
    {
        [Display (Name = "ФИО клиента")]
        public string ClientId { get; set; }
        [Display (Name = "Название автомобиля")]
        public string CarName { get; set; }
        [Display(Name = "Модель автомобиля")]
        public string Model { get; set; }
        [Display (Name = "VIN")]
        public string VIN { get; set; }
        [Display (Name = "Объём двигателя")]
        public float EngingeVolume { get; set; }
        [Display (Name = "Год выпуска")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy}")]
        public DateTime ManufactureYear { get; set; }
        [Display (Name = "Описание работ")]
        public string Defects { get; set; }
    }
}