using System;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai <{config.Get("CONFIG1")}>: ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hari = Convert.ToInt32(Console.ReadLine());

        bool suhuAman = false;

        if (config.Get("CONFIG1") == "celcius")
        {
            suhuAman = (suhu >= 36.5 && suhu <= 37.5);
        }
        else // fahrenheit
        {
            suhuAman = (suhu >= 97.7 && suhu <= 99.5);
        }

        bool hariAman = hari <= int.Parse(config.Get("CONFIG2"));

        if (suhuAman && hariAman)
        {
            Console.WriteLine(config.Get("CONFIG4"));
        }
        else
        {
            Console.WriteLine(config.Get("CONFIG3"));
        }

        Console.Write("Apakah Anda ingin mengubah satuan suhu? (y/n): ");
        string ubah = Console.ReadLine();
        if (ubah.ToLower() == "y")
        {
            config.UbahSatuan();
            Console.WriteLine("Satuan suhu sekarang: " + config.Get("CONFIG1"));
        }

        Console.WriteLine("Program selesai.");
    }
}
