using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using DataLibrary;
using static DataLibrary.Logic.Processor;
using CarServiceWeb.Models;

namespace CarServiceWeb.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0 && file != null)
            {
                try
                {
                    var stream = file.InputStream;
                    var xs = new XmlSerializer(typeof(ClientBase));
                    var cbase = (ClientBase)xs.Deserialize(stream);

                    foreach (var c in cbase.List)
                    {
                        CreateClient(c.Name, c.Number, c.OrderDone, c.Cars);
                    }

                    ViewBag.Message = "Файл загружен!";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Ошибка: " + ex.ToString();
                }
            }
            else
            {
                ViewBag.Message = "Выберите файл!";
            }

            return View();
        }

        public ActionResult ClientsList()
        {
            ViewBag.Message = "Список клиентов";

            var data = LoadClients();
            List<ClientModel> clients = new List<ClientModel>();

            foreach (var row in data)
            {
                clients.Add(new ClientModel
                {
                    Name = row.Name,
                    PhoneNumber = row.PhoneNumber,
                    OrderDone = row.OrderDone
                });
            }

            return View(clients);
        }

        public ActionResult CarsList()
        {
            var data = LoadCars();
            List<CarsModel> cars = new List<CarsModel>();

            foreach (var row in data)
            {
                cars.Add(new CarsModel
                {
                    ClientId = row.ClientId,
                    CarName = row.CarName,
                    VIN = row.VIN,
                    EngingeVolume = row.EngineVolume,
                    ManufactureYear = row.ManufactureYear,
                    Defects = row.Defects
                });
            }

            return View(cars);

        }
    }
}