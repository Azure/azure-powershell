using System.IO;
using System;
using System.Collections.Generic;
using Microsoft.CLU.Common.Properties;

namespace Microsoft.CLU
{
    /// <summary>
    /// Represents collection of command configurations.
    /// Each configuration will be a key-value pair, where key a unique string and
    /// value is also string [the value can be plain string or a json string]
    /// </summary>
    public class ConfigurationDictionary : Dictionary<string, string>
    {
        /// <summary>
        /// Creates an instance of ConfigurationDictionary.
        /// </summary>
        public ConfigurationDictionary() : base(StringComparer.OrdinalIgnoreCase) { }

        /// <summary>
        /// Creates a ConfigurationDictionary instance from the given configuration entries.
        /// </summary>
        /// <param name="configLines">string array of configuration entries</param>
        /// <returns></returns>
        public static ConfigurationDictionary Create(string [] configLines)
        {
            if (configLines == null)
            {
                throw new ArgumentNullException("configLines");
            }

            var configDict = new ConfigurationDictionary();
            foreach (var line in configLines)
            {
                if (string.IsNullOrEmpty(line)) continue;
                var firstColon = line.IndexOf(':');
                if (firstColon > -1)
                {
                    var key = line.Substring(0, firstColon).Trim();
                    var value = line.Substring(firstColon + 1).Trim();
                    configDict.Add(key, value);
                }
                else
                {
                    configDict.Add(line, "");
                }
            }
            return configDict;
        }

        /// <summary>
        /// This is a temporary hack, the ConfigurationDictionary class needs to be reworked.
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static ConfigurationDictionary Create(IDictionary<string, string> dict)
        {
            if (dict == null)
            {
                throw new ArgumentNullException("dict");
            }

            var configDict = new ConfigurationDictionary();
            foreach (var kv in dict)
            {
                configDict[kv.Key] = kv.Value;
            }

            return configDict;
        }

        /// <summary>
        /// This is a temporary hack, the ConfigurationDictionary class needs to be reworked.
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static ConfigurationDictionary Create(IEnumerable<Tuple<string,string>> entries)
        {
            if (entries == null)
            {
                throw new ArgumentNullException("entries");
            }

            var configDict = new ConfigurationDictionary();
            foreach (var kv in entries)
            {
                configDict[kv.Item1] = kv.Item2;
            }

            return configDict;
        }

        /// <summary>
        /// Creates a ConfigurationDictionary instance from the contents of the given file.
        /// </summary>
        /// <param name="path">A file path to load from</param>
        /// <returns></returns>
        public static ConfigurationDictionary Load(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }

            if (File.Exists(path))
            {
                return ConfigurationDictionary.Create(File.ReadAllLines(path));
            }

            return null;
        }

        /// <summary>
        /// Store a ConfigurationDictionary instance in the given file, overwriting if necessary.
        /// </summary>
        /// <param name="path">A file path to store to</param>
        /// <returns></returns>
        public void Store(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }

            using (var writer = File.CreateText(path))
            {
                foreach (var entry in this)
                {
                    writer.WriteLine(entry.Key + ":" + entry.Value);
                }
            }
        }

        /// <summary>
        /// Gets configuration value for the configuration idenfied by configurationName. If the
        /// caller identifies this as a required configuration (via required argument) and if the
        ///  configuration does not exists, then this method will throw error.
        /// </summary>
        /// <param name="configurationName">The configuration name</param>
        /// <param name="required">Indicates this configuration is a required one or optional</param>
        /// <returns></returns>
        public string Get(string configurationName, bool required)
        {
            if (!this.ContainsKey(configurationName))
            {
                if (required)
                {
                    throw new KeyNotFoundException(string.Format(Strings.ConfigurationDictionary_Get_KeyNotFound, configurationName));
                }

                return null;
            }

            return this[configurationName];
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
            string value;
            if (this.TryGetValue(key, out value))
            {
                return value.Split(',');
            }

            return new List<string>();
        }

        /// <summary>
        /// Set a list value.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="list">The values</param>
        public void SetListValue(string key, string [] list)
        {
            if (list.Length == 0)
            {
                return;
            }

            string value = string.Join(",", list);
            this[key] = value;
        }
    }
}
