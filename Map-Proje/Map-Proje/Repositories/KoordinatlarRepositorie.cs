using Map_Proje.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map_Proje.Repositories
{
    public class KoordinatlarRepositorie
    {
        public string directoryadress { get; set; }
        public string jsonDatabase { get; set; }

        public KoordinatlarRepositorie()
        {
            directoryadress = "c:\\koordinatlarItems";
            jsonDatabase = directoryadress + "c:\\koordinat.json";
            bool checkDirectory = Directory.Exists(directoryadress);
            if (checkDirectory == false)
            {
                Directory.CreateDirectory(directoryadress);
                bool checkDatabase = File.Exists(jsonDatabase);
                if (checkDatabase == false)
                {
                    List<koordinatlarItem> databaseList = new List<koordinatlarItem>();
                    databaseList.Add(new koordinatlarItem()

                    {
                        id = Guid.NewGuid(),
                        koordinatlar = "koordinat",
                        lat = "46,5425842",
                        Long = "32,5425254",
                        datetime = "19.08.2022 13:54",

                    });
                    string JsonDatabaseContent = Newtonsoft.Json.JsonConvert.SerializeObject(databaseList);
                    File.WriteAllText(jsonDatabase, JsonDatabaseContent);

                }
            }
        }
    }
}