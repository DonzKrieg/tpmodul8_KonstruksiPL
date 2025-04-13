using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_103022330150
{
    public class CovidConfig
    {
        public Config config;
        private const string filePath = "covid_config.json";

        public CovidConfig()
        {
            try
            {
                string configJson = File.ReadAllText(filePath);
                config = JsonSerializer.Deserialize<Config>(configJson);
            }
            catch (FileNotFoundException)
            {
                config = new Config
                {
                    satuan_suhu = "celcius",
                    batas_hari_deman = 14,
                    pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                    pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
                };

                SimpanConfig();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Environment.Exit(1);
            }
        }

        private void SimpanConfig()
        {
            try
            {
                string configJson = JsonSerializer.Serialize(config);
                File.WriteAllText(filePath, configJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error menyimpan config: {ex.Message}");
            }
        }

        public bool CekKondisi(double suhu, int hariDeman)
        {
            bool suhuValid = false;

            if (config.satuan_suhu.ToLower() == "celcius")
            {
                suhuValid = (suhu >= 36.5 && suhu <= 37.5);
            }
            else if (config.satuan_suhu.ToLower() == "fahrenheit")
            {
                suhuValid = (suhu >= 97.7 && suhu <= 99.5);
            }

            bool hariValid = (hariDeman < config.batas_hari_deman);

            return suhuValid && hariValid;
        }

        public void UbahSatuan()
        {
            if (config.satuan_suhu.ToLower() == "celcius")
            {
                config.satuan_suhu = "fahrenheit";
            }
            else
            {
                config.satuan_suhu = "celcius";
            }

            SimpanConfig();
        }
    }

    public class Config
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }
    }
}
