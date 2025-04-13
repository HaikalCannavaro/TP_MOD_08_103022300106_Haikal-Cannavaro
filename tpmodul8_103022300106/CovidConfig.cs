using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_103022300106
{
    public class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public void UbahSatuan()
        {
            if (satuan_suhu.ToLower() == "celcius")
            {
                satuan_suhu = "fahrenheit";
            }
            else
            {
                satuan_suhu = "celcius";
            }
        }

        public static CovidConfig LoadFromFile()
        {
            string path = "covid_config.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<CovidConfig>(json);
                Console.WriteLine("Config file loaded successfully.");
            }
            else
            {
                Console.WriteLine("Config file not found. Using default values.");
                return new CovidConfig
                {
                    satuan_suhu = "celcius",
                    batas_hari_demam = 14,
                    pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                    pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
                };
            }
        }
    }
}
