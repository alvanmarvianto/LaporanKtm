using System;
using System.IO;
using System.Text.Json;

namespace Utama.Transfer
{
    public class BankTransferConfig
    {
        private const string configFile = "config.json";
        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        private ConfigData configData;

        public BankTransferConfig()
        {
            if (File.Exists(configFile))
            {
                string configText = File.ReadAllText(configFile);
                configData = JsonSerializer.Deserialize<ConfigData>(configText);
            }
            else
            {
                configData = new ConfigData
                {
                    Lang = "en",
                    Methods = new string[] { "VA", "QR", "BI FAST" },
                    Confirmation = new ConfirmationConfig
                    {
                        En = "yes",
                        Id = "ya"
                    }
                };
                SimpanPerubahan();
            }
        }

        public BankTransferConfig(string lang)
        {
            Lang = lang;
        }

        public string Lang
        {
            get { return configData.Lang; }
            set { configData.Lang = value; }
        }

        public string[] Methods
        {
            get { return configData.Methods; }
        }

        public ConfirmationConfig Confirmation
        {
            get { return configData.Confirmation; }
        }

        public void SimpanPerubahan()
        {
            string json = JsonSerializer.Serialize(configData, options);
            File.WriteAllText(configFile, json);
        }

        public class ConfigData
        {
            public string Lang { get; set; }
            public string[] Methods { get; set; }
            public ConfirmationConfig Confirmation { get; set; }
        }


        public class ConfirmationConfig
        {
            public string En { get; set; }
            public string Id { get; set; }
        }
        public void Test()
        {
            Console.WriteLine("tes");
        }
    }
}