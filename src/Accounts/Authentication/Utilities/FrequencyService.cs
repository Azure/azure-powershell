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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication.Properties;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class FrequencyService : IFrequencyService
    {
        private Dictionary<string, FrequencyInfo> _frequencies;
        private Dictionary<string, bool> _perPSSessionRegistry;
        private readonly string _filePath = Path.Combine(Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    Resources.AzureDirectoryName), "AzPSFrequencyService.json");
        private IDataStore _dataStore;
        internal IClock _clock;

        internal Dictionary<string, bool> SessionLogic { get { return _perPSSessionRegistry; } }
        internal Dictionary<string, FrequencyInfo> Frequencies { get { return _frequencies; } }
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

        public FrequencyService(IDataStore dataStore)
        {
            try
            {
                _dataStore = dataStore;
                _clock = new Clock();
                if (dataStore.FileExists(_filePath))
                {
                    string json = dataStore.ReadFileAsText(_filePath);
                    _frequencies = JsonConvert.DeserializeObject<Dictionary<string, FrequencyInfo>>(json);
                }
                else
                {
                    _frequencies = new Dictionary<string, FrequencyInfo>();
                }
            }
            catch (Exception)
            {
                _dataStore = new MemoryDataStore();

                _frequencies = new Dictionary<string, FrequencyInfo>();

            }
            
        }

        public FrequencyService(IDataStore dataStore, IClock clock)
        {
            try
            {
                _dataStore = dataStore;
                _clock = clock;
                if (dataStore.FileExists(_filePath))
                {
                    string json = dataStore.ReadFileAsText(_filePath);
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
        public void Check(string featureName, Func<bool> businessCheck, Action business)
        {
            if (_perPSSessionRegistry != null && _perPSSessionRegistry.ContainsKey(featureName))
            {
                if (_perPSSessionRegistry[featureName] == false && businessCheck())
                {
                    _perPSSessionRegistry[featureName] = true;
                    business();
                }
            }
            else if (_frequencies.ContainsKey(featureName))
            {
                if (_clock.IsDue(_frequencies[featureName].LastCheckTime, _frequencies[featureName].Frequency) && businessCheck())
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
        /// <summary>
        /// This method is used for testing purposes only. It allows the caller to specify a fakeNow time to use for the check.
        /// </summary>
        internal void Check(string featureName, Func<bool> businessCheck, Action business, DateTime fakeNow)
        {
            if (_perPSSessionRegistry != null && _perPSSessionRegistry.ContainsKey(featureName))
            {
                if (_perPSSessionRegistry[featureName] == false && businessCheck())
                {
                    _perPSSessionRegistry[featureName] = true;
                    business();
                }
            }
            else if (_frequencies.ContainsKey(featureName))
            {
                if (_clock.IsDue(_frequencies[featureName].LastCheckTime, _frequencies[featureName].Frequency) && businessCheck())
                {
                    _frequencies[featureName].LastCheckTime = fakeNow;
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
            if (_frequencies.ContainsKey(featureName) && _frequencies[featureName].Frequency != frequency)
            {
                throw new ArgumentException($"Feature name '{featureName}' already exists in FrequencyService with a different frequency!");
            }
        }

        public void AddSession(string featureName)
        {
            if (_perPSSessionRegistry == null)
            {
                _perPSSessionRegistry = new Dictionary<string, bool>();
            }
            if (!_perPSSessionRegistry.ContainsKey(featureName))
            {
                _perPSSessionRegistry.Add(featureName, false);
            }
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(_frequencies);
            _dataStore.WriteFile(_filePath, json);
        }

        internal List<string> GetAllFeatureNames()
        {
            var allFeatureNames = new List<string>(_frequencies.Keys);
            if (SessionLogic != null)
            {
                allFeatureNames.AddRange(SessionLogic.Keys);
            }
            return allFeatureNames.ToList();
        }
    }

    public interface IClock
    {
        bool IsDue(DateTime lastCheckTime, TimeSpan frequency);
    }

    class Clock : IClock
    {
        public bool IsDue(DateTime lastCheckTime, TimeSpan freq)
        {
            return DateTime.Now - lastCheckTime >= freq;
        }
    }

    class MockClock : IClock
    {
        public DateTime fakeNow { get; set; }
        public bool IsDue(DateTime lastCheckTime, TimeSpan freq)
        {
            return fakeNow - lastCheckTime >= freq;
        }
        public void AddSecond(int sec)
        {
            fakeNow = fakeNow.AddSeconds(sec);
        }
    }
}
