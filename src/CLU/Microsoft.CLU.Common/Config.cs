using Microsoft.CLU.Common.Properties;
using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.CLU
{
    /// <summary>
    /// Exception represents absence of a configuration entry.
    /// </summary>
    public class ConfigEntryNotFoundException : Exception
    {
        /// <summary>
        /// Creates an instance of ConfigEntryNotFoundException.
        /// </summary>
        /// <param name="entryKey">The configuration entry key</param>
        public ConfigEntryNotFoundException(string entryKey) :
            base(string.Format(Strings.ConfigEntryNotFoundException_Ctor_Message, entryKey))
        {}
    }

    /// <summary>
    /// Type representing configuration.
    /// </summary>
    public class Config
    {
        protected Config()
        {
        }

        /// <summary>
        /// Absolute path to configuration file.
        /// </summary>
        protected string ConfigFilePath;

        /// <summary>
        /// configuration as key-value collection.
        /// Note: configuration entry key is case sensitive.
        /// </summary>
        public Dictionary<string, string> Items { get; private set; }

        /// <summary>
        /// Creates an instance of Config
        /// </summary>
        /// <param name="configFilePath">The absolute path to the configuration</param>
        public Config(string configFilePath)
        {
            if (string.IsNullOrEmpty(configFilePath))
            {
                throw new ArgumentNullException("configFilePath");
            }

            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException(string.Format(Strings.Config_Ctor_FileNotFound, configFilePath));
            }

            ConfigFilePath = configFilePath;
            Items = ReadConfigurationFile();
        }

        /// <summary>
        /// Gets value of the configuration entry identified by entry key. If the
        /// caller indicate this as a required entry (via required argument) and
        /// if the entry does not exists or it's value is empty, then this method
        /// will throw ConfigEntryNotFoundException.
        /// </summary>
        /// <param name="entryKey">The entry key</param>
        /// <param name="required">Indicates this entry is a required one or optional</param>
        /// <returns></returns>
        public string GetConfigEntry(string entryKey, bool required)
        {
            if (string.IsNullOrEmpty(entryKey))
            {
                throw new ArgumentNullException("entryKey");
            }

            string value;
            if (!Items.TryGetValue(entryKey, out value) || string.IsNullOrEmpty(value))
            {
                if (required)
                {
                    throw new ConfigEntryNotFoundException(entryKey);
                }

                return null;
            }

            return value;
        }

        /// <summary>
        /// Given configuration entry key for a comma-seperated list value, return
        /// value as instance of List.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>
        /// List instance deserialized from comma-seperated list value, an empty list
        /// will be retuned if entry with the given key not exists.
        /// </returns>
        public IEnumerable<string> GetListValue(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            string value;
            if (Items.TryGetValue(key, out value))
            {
                return value.Split(',');
            }

            return new List<string>();
        }

        /// <summary>
        /// Create configuration dictionary from the configuration file.
        /// </summary>
        private Dictionary<string, string> ReadConfigurationFile()
        {
            var lines = File.ReadAllLines(ConfigFilePath);
            var dict = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var firstColon = line.IndexOf(':');
                if (firstColon > -1)
                {
                    var key = line.Substring(0, firstColon).Trim();
                    var value = line.Substring(firstColon + 1).Trim();
                    dict.Add(key, value);
                }
                else
                {
                    dict.Add(line, "");
                }
            }

            return dict;
        }
    }
}
