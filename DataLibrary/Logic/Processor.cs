using DataLibrary.DataAccess;
using DataLibrary.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace DataLibrary.Logic
{
    public static class Processor
    {
        public static void CreateClient(string name, string phoneNumber, bool orderDone, List<Cars> cars)
        {
            Client data = new Client
            {
                Name = name,
                PhoneNumber = phoneNumber,
                OrderDone = orderDone,
                Cars = cars
            };

            string sql = @"insert into dbo.Client (Name, PhoneNumber, OrderDone) 
                           values (@Name, @PhoneNumber, @OrderDone);";

            SqlDataAccess.SaveData(sql, data);

            var carName = ConvertToEnglish(name) + "Cars";
            string sqlcreate = @"create table [dbo].[" + carName + @"] 
                                ([Id] INT NOT NULL PRIMARY KEY IDENTITY,
                                [CarName] NVARCHAR(50) NOT NULL,
                                [VIN] NVARCHAR(50) NOT NULL,
                                [EngineVolume] FLOAT NOT NULL, 
                                [ManufactureYear] DATETIME NOT NULL, 
                                [Defects] NVARCHAR(50) NOT NULL,
                                [ClientId] NVARCHAR(50) NOT NULL);";

            using (IDbConnection cnn = new SqlConnection(SqlDataAccess.GetConnectionString()))
            {
                cnn.Execute(sqlcreate);
            }

            foreach (var c in cars)
            {
                Car car = new Car
                {
                    CarName = ConvertFromEnum(c.Name),
                    VIN = c.VIN,
                    EngineVolume = (float)c.EngineVolume,
                    ManufactureYear = c.ManufactureYear,
                    Defects = GetFromList(c.DefectsDescription),
                    ClientId = data.Name
                };

                string sqldata = @"insert into dbo." + carName + @" (CarName, VIN, EngineVolume, ManufactureYear, Defects, ClientId) 
                                values (@CarName, @VIN, @EngineVolume, @ManufactureYear, @Defects, @ClientId);";

                SqlDataAccess.SaveData(sqldata, car);
            }

        }

        public static List<Client> LoadClients()
        {
            string sql = @"select Name, PhoneNumber, OrderDone
                           from dbo.Client;";

            return SqlDataAccess.LoadData<Client>(sql);
        }

        public static List<Car> LoadCars()
        {
            var clientList = LoadClients();
            List<Car> totalList = new List<Car>();
            foreach (var c in clientList)
            {
                var tableName = ConvertToEnglish(c.Name) + "Cars";
                string sql = @"SELECT ClientId, CarName, VIN, EngineVolume, ManufactureYear, Defects
                            FROM dbo." + tableName;
                var data = SqlDataAccess.LoadData<Car>(sql);
                foreach(var row in data)
                {
                    totalList.Add(row);
                }
            }
            return totalList;
        }

        private static string ConvertFromEnum(CarNames name)
        {
            switch (name)
            {
                case CarNames.Audi: return "Audi";
                case CarNames.BMW: return "BMW";
                case CarNames.Chevrolet: return "Chevrolet";
                case CarNames.Citroen: return "Citroen";
                case CarNames.Ford: return "Ford";
                case CarNames.Honda: return "Honda";
                case CarNames.Hyinday: return "Hyinday";
                case CarNames.Kia: return "Kia";
                case CarNames.LADA: return "LADA";
                case CarNames.Lexus: return "Lexus";
                case CarNames.Mazda: return "Mazda";
                case CarNames.Mercedes: return "Mercedes";
                case CarNames.Mitsubishi: return "Mitsubishi";
                case CarNames.Nissan: return "Nissan";
                case CarNames.Opel: return "Opel";
                case CarNames.Renault: return "Renault";
                case CarNames.Skoda: return "Skoda";
                case CarNames.Subaru: return "Subaru";
                case CarNames.Toyota: return "Toyota";
                case CarNames.Volkswagen: return "Volkswagen";
                case CarNames.Volvo: return "Volvo";
                default: throw new Exception("vot tak");
            }
        }

        private static string GetFromList(List<string> list)
        {
            StringBuilder result = new StringBuilder();
            foreach (var note in list)
            {
                result.Append(note);
                result.Append("; ");
            }
            return result.ToString();
        }

        private static string ConvertToEnglish(string name)
        {
            if (IsStringLatin(name))
            {
                var arr = name.Split(' ');
                string fullName = "";
                foreach (var e in arr)
                    fullName += e;
                fullName = fullName.ToLower();
                return fullName;
            }
            else
            {
                var arr = name.Split(' ');
                string fullName = "";
                foreach (var e in arr)
                    fullName += e;
                fullName = fullName.ToLower();
                var map = new Dictionary<char, string>
                {
                    { 'а', "a" },
                    { 'б', "b" },
                    { 'в', "v" },
                    { 'г', "g" },
                    { 'д', "d" },
                    { 'е', "e" },
                    { 'ё', "e" },
                    { 'ж', "zh" },
                    { 'з', "z" },
                    { 'и', "i" },
                    { 'й', "y" },
                    { 'к', "k" },
                    { 'л', "l" },
                    { 'м', "m" },
                    { 'н', "n" },
                    { 'о', "o" },
                    { 'п', "p" },
                    { 'р', "r" },
                    { 'с', "s" },
                    { 'т', "t" },
                    { 'у', "u" },
                    { 'ф', "f" },
                    { 'х', "h" },
                    { 'ц', "c" },
                    { 'ч', "ch" },
                    { 'ш', "sh" },
                    { 'щ', "sh" },
                    { 'ъ', "" },
                    { 'ы', "i" },
                    { 'ь', "" },
                    { 'э', "e" },
                    { 'ю', "yi" },
                    { 'я', "ya" }
                };

                var result = string.Concat(fullName.Select(c => map[c]));
                return result;
            }
        }

        private static bool IsStringLatin(string content)
        {
            bool result = true;

            char[] letters = content.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                int charValue = System.Convert.ToInt32(letters[i]);

                if (charValue > 128)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}
