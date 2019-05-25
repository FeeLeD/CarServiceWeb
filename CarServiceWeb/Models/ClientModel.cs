using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CarServiceWeb.Models
{
    public class ClientModel
    {
        [Display(Name = "ФИО")]
        public string Name { get; set; }
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Статус заказа")]
        public bool OrderDone { get; set; }
    }
}