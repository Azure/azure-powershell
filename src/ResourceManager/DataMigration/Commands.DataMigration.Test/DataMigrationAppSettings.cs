// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataMigrationAppSettings.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Microsoft.Azure.Commands.DataMigration.Test
{
    public class DataMigrationAppSettings
    {
        private static volatile DataMigrationAppSettings instance;
        private string configFileName = "appsettings.json";
        private static object lockObj = new Object();
        private JObject config;

        private DataMigrationAppSettings() { }

        public static DataMigrationAppSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new DataMigrationAppSettings();
                            instance.LoadConfigFile();
                        }
                    }
                }

                return instance;
            }
        }

        private void LoadConfigFile()
        {
            string fullFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configFileName);
            if (!File.Exists(fullFilePath))
            {
                instance = null;
                throw new FileNotFoundException("appsettings.json File Not Found");
            }

            config = (JObject)JsonConvert.DeserializeObject(File.ReadAllText(fullFilePath));
        }

        public string GetValue(string configName)
        {
            string value = (string) config[configName];

            if (string.IsNullOrEmpty(value))
            {
                string message = "Cannot not find config : " + configName;
                throw new ArgumentException(message);
            }

            return value;
        }

    }
}
