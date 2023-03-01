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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class FrequencyService
    {
        private Dictionary<string, FrequencyInfo> _frequencies;
        private static FrequencyService _instance;
        private readonly string _filePath = "xxxx.json";
        private Dictionary<string, bool> _sessionLogic;
        private FrequencyService()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string json = File.ReadAllText(_filePath);
                    _frequencies = JsonConvert.DeserializeObject<Dictionary<string, FrequencyInfo>>(json);
                }
                else
                {
                    _frequencies = new Dictionary<string, FrequencyInfo>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading frequency file", ex);
            }
        }

        public static FrequencyService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FrequencyService();
            }

            return _instance;
        }

        public void Check(string featureName, Func<bool> businessCheck, Action business)
        {
            if (_sessionLogic.ContainsKey(featureName))
            {
                if (_sessionLogic[featureName] == false && businessCheck())
                {
                    _sessionLogic[featureName] = true;
                    business();
                }
            }
            else if (_frequencies.ContainsKey(featureName))
            {
                if ((DateTime.Now - _frequencies[featureName].LastCheckTime) >= _frequencies[featureName].Frequency && businessCheck())
                {
                    _frequencies[featureName].LastCheckTime = DateTime.Now;
                    Save();
                    business();
                }
            }
            else
            {
                throw new ArgumentException($"Feature name '{featureName}' not found in FrequencyService");
            }

        }

        public void Add(string featureName, TimeSpan frequency)
        {
            if (!_frequencies.ContainsKey(featureName))
            {
                _frequencies.Add(featureName, new FrequencyInfo(frequency, DateTime.MinValue));
                Save();
            }
        }

        public void AddSession(string featureName)
        {
            if (!_sessionLogic.ContainsKey(featureName))
            {
                _sessionLogic.Add(featureName, false);
            }
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(_frequencies);
            File.WriteAllText(_filePath, json);
        }
    }

    public class FrequencyInfo
    {
        public TimeSpan Frequency { get; set; }
        public DateTime LastCheckTime { get; set; }
        public FrequencyInfo(TimeSpan frequency, DateTime lastCheckTime)
        {
            Frequency = frequency;
            LastCheckTime = lastCheckTime;
        }
    }

}
