using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class CovidConfig
{
    private Dictionary<string, string> configMap = new Dictionary<string, string>();

    public CovidConfig()
    {
        LoadConfig();
    }

    private void LoadConfig()
    {
        try
        {
            string jsonText = File.ReadAllText("covid_config.json");
            var rawConfig = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonText);

            configMap["CONFIG1"] = rawConfig.ContainsKey("satuan_suhu") ? rawConfig["satuan_suhu"] : "celcius";
            configMap["CONFIG2"] = rawConfig.ContainsKey("batas_hari_demam") ? rawConfig["batas_hari_demam"] : "14";
            configMap["CONFIG3"] = rawConfig.ContainsKey("pesan_ditolak") ? rawConfig["pesan_ditolak"] : "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            configMap["CONFIG4"] = rawConfig.ContainsKey("pesan_diterima") ? rawConfig["pesan_diterima"] : "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }
        catch
        {
            configMap["CONFIG1"] = "celcius";
            configMap["CONFIG2"] = "14";
            configMap["CONFIG3"] = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            configMap["CONFIG4"] = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }
    }

    public string Get(string configKey)
    {
        return configMap.ContainsKey(configKey) ? configMap[configKey] : "";
    }

    public void UbahSatuan()
    {
        configMap["CONFIG1"] = configMap["CONFIG1"] == "celcius" ? "fahrenheit" : "celcius";
    }
}
