using Microsoft.Azure.Commands.Common.Authentication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Exceptions;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    // This service is to ensure the business actions will be called after their due dates. It does not work like a scheduler.
    // It relies on its record file AzPSFrequencyService.json. If this file is not readable or failed to be parsed, ignore it. 
    internal class FrequencyService : IFrequencyService
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
        public void TryRun(string featureName, Func<bool> businessCheck, Action business)
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
                    business();
                    Save();
                }
            }
            else
            {
                throw new AzPSArgumentException ($"Feature name '{featureName}' not found in FrequencyService", nameof(featureName));
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
                    business();
                    Save();
                }
            }
            else
            {
                throw new AzPSArgumentException ($"Feature name '{featureName}' not found in FrequencyService", nameof(featureName));
            }

        }

        public void Register(string featureName, TimeSpan frequency)
        {
            if (!_frequencies.ContainsKey(featureName))
            {
                _frequencies.Add(featureName, new FrequencyInfo(frequency, DateTime.MinValue));
                Save();
            }
            if (_frequencies.ContainsKey(featureName) && _frequencies[featureName].Frequency != frequency)
            {
                throw new AzPSArgumentException ($"Feature name '{featureName}' already exists in FrequencyService with a different frequency!", nameof(featureName));
            }
        }

        public void RegisterInSession(string featureName)
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

    internal interface IClock
    {
        bool IsDue(DateTime lastCheckTime, TimeSpan frequency);
    }

    internal class Clock : IClock
    {
        public bool IsDue(DateTime lastCheckTime, TimeSpan freq)
        {
            return DateTime.Now - lastCheckTime >= freq;
        }
    }


}