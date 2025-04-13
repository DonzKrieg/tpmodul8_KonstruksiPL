using System;
using System.IO;
using System.Text.Json;
using tpmodul8_103022330150;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();

        Console.WriteLine("Konfigurasi awal:");
        Console.WriteLine($"Satuan suhu: {config.config.satuan_suhu}");
        Console.WriteLine($"Batas hari demam: {config.config.batas_hari_deman}");
        Console.WriteLine($"Pesan ditolak: {config.config.pesan_ditolak}");
        Console.WriteLine($"Pesan diterima: {config.config.pesan_diterima}");
        Console.WriteLine();

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.config.satuan_suhu}:");
        double suhu = double.Parse(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        int hariDeman = int.Parse(Console.ReadLine());

        bool terima = config.CekKondisi(suhu, hariDeman);

        if (terima)
        {
            Console.WriteLine(config.config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.config.pesan_ditolak);
        }

        Console.WriteLine("\nMengubah satuan...");
        config.UbahSatuan();

        Console.WriteLine("\nKonfigurasi setelah diubah:");
        Console.WriteLine($"Satuan suhu: {config.config.satuan_suhu}");
        Console.WriteLine($"Batas hari demam: {config.config.batas_hari_deman}");
        Console.WriteLine($"Pesan ditolak: {config.config.pesan_ditolak}");
        Console.WriteLine($"Pesan diterima: {config.config.pesan_diterima}");
    }
}