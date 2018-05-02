// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            string value = (string)config[configName];

            if (string.IsNullOrEmpty(value))
            {
                string message = "Cannot not find config : " + configName;
                throw new ArgumentException(message);
            }

            return value;
        }

    }
}
