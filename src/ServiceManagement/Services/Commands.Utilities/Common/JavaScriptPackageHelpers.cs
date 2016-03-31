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
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService
{
    internal static class JavaScriptPackageHelpers
    {
        /// <summary>
        /// Ensure that a package.json file is available in the given directory, if not create it.
        /// </summary>
        /// <param name="directoryPath">fully qualified path to the directory to search</param>
        /// <param name="applicationName"></param>
        /// <returns>True if package.json exists and is readable, false otherwise</returns>
        internal static bool EnsurePackageJsonExists(string directoryPath, string applicationName = "")
        {
            string fileName = Path.Combine(directoryPath, Resources.PackageJsonFileName);
            if (!File.Exists(fileName))
            {
                FileUtilities.DataStore.WriteFile(fileName, string.Format(Resources.PackageJsonDefaultFile, applicationName));
            }

            return FileUtilities.DataStore.FileExists(fileName);
        }

        /// <summary>
        /// Get the version specifiction for the given engine, if any
        /// </summary>
        /// <param name="directoryPath">fully qualified path to the directory to search</param>
        /// <param name="engineName">The name of the engine to specify</param>
        /// <param name="version">The version specified in package.json, if any, or null otherwise</param>
        /// <returns>True if we retrieved a valid engine version, false otherwise</returns>
        internal static bool TryGetEngineVersion(string directoryPath, string engineName, out string version)
        {
            version = null;
            Dictionary<string, object> contents;
            if (TryGetContents(directoryPath, out contents))
            {
                return TryGetEngineVersionFromJson(contents, engineName, out version);
            }

            return false;
        }

        /// <summary>
        /// Get the version specifiction for the given engine, if any
        /// </summary>
        /// <param name="directoryPath">fully qualified path to the directory to search</param>
        /// <param name="engineName">The name of the engine to specify</param>
        /// <param name="version">The version to set in package.json.</param>
        /// <returns>True if we successfully set the engine version, false otherwise</returns>
        internal static bool TrySetEngineVersion(string directoryPath, string engineName, string version)
        {
            Dictionary<string, object> contents;
            if (TryGetContents(directoryPath, out contents))
            {
                SetEngineVersionInJson(contents, engineName, version);
                SetContents(directoryPath, contents);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deserialize the contents of package.json in the given directory
        /// </summary>
        /// <param name="directoryPath">fully qualified path to the directory to search</param>
        /// <param name="contents">The contents of the file, represented as a dictionary</param>
        /// <returns>True if we successfully read the file, false otherwise</returns>
        private static bool TryGetContents(string directoryPath, out Dictionary<string, object> contents)
        {
            contents = null;
            string fileName = Path.Combine(directoryPath, Resources.PackageJsonFileName);
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string jsonString = reader.ReadToEnd();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    contents = js.Deserialize<Dictionary<string, object>>(jsonString);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Write the given JavaScript object in dictionaroy representation out to package.json
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="contents">The JavaScript object in dictionary representation</param>
        static void SetContents(string directoryPath, Dictionary<string, object> contents)
        {
            string fileName = Path.Combine(directoryPath, Resources.PackageJsonFileName);
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                writer.Write(serializer.Serialize(contents));
                writer.Flush();
            }
        }

        /// <summary>
        /// Try to get the value of a property from a JavaScript object represented as a dictionary
        /// use case-insensitive matching and coerce the return type as appropriate
        /// </summary>
        /// <param name="store">The JavaScript object in dictionary representation</param>
        /// <param name="searchKey">The property name to find</param>
        /// <param name="value">The out variable to return the value stored in the object</param>
        /// <returns>True if the property is successfully found, false otherwise</returns>
        static bool TryGetValue<T>(Dictionary<string, object> store, string searchKey, out T value) where T : class
        {
            value = null;
            foreach (string key in store.Keys)
            {
                if (string.Equals(key, searchKey, StringComparison.OrdinalIgnoreCase))
                {
                    value = store[key] as T;
                    return value != null;
                }
            }

            return false;
        }

        /// <summary>
        /// Try to set the value of a property in a JavaScript object represented as a dictionary
        /// use case-insensitive matching
        /// </summary>
        /// <param name="store">The JavaScript object in dictionary representation</param>
        /// <param name="searchKey">The property name to find</param>
        /// <param name="value">The out variable to return the value stored in the object</param>
        /// <returns>True if the property is successfully found, false otherwise</returns>
        static void SetValue<T>(Dictionary<string, object> store, string searchKey, T value) where T : class
        {
            foreach (string key in store.Keys)
            {
                if (string.Equals(key, searchKey, StringComparison.OrdinalIgnoreCase))
                {
                    store[key] = value;
                    return;
                }
            }

            store[searchKey] = value;
        }

        /// <summary>
        /// Try to get the engines section from a package.json object
        /// use case-insensitive matching and coerce the return type as appropriate
        /// </summary>
        /// <param name="store">The JavaScript object in dictionary representation</param>
        /// <param name="engines">The out variable to return the engines section as a dictionary</param>
        /// <returns>True if the property is successfully found, false otherwise</returns>
        private static bool TryGetEnginesSection(Dictionary<string, object> store, out Dictionary<string, object> engines)
        {
            return TryGetValue<Dictionary<string, object>>(store, Resources.JsonEnginesSectionName, out engines);
        }

        /// <summary>
        /// Try to get the engine version specification from the given package.json object (represented 
        /// as a dictionary)
        /// </summary>
        /// <param name="store">The JavaScript object in dictionary representation</param>
        /// <param name="engineKey">The property name of the engine version to find</param>
        /// <param name="engineVersion">The out variable to return the value stored in the object</param>
        /// <returns>True if the property is successfully found, false otherwise</returns>
        static bool TryGetEngineVersionFromJson(Dictionary<string, object> store, string engineKey, out string engineVersion)
        {
            engineVersion = null;
            Dictionary<string, object> engines;
            if (TryGetEnginesSection(store, out engines))
            {
                return TryGetValue<string>(engines, engineKey, out engineVersion) && ISValidVersion(engineVersion);
            }

            return false;
        }

        /// <summary>
        /// Determine if the version contained in a package.json is a real version value
        /// </summary>
        /// <param name="version">The version to check</param>
        /// <returns>true if a valid 3-part version, otherwise false</returns>
        static bool ISValidVersion(string version)
        {
            if (!string.IsNullOrEmpty(version))
            {
                string[] versions = version.Split('.');
                return versions != null && versions.Length == 3;
            }

            return false;
        }
        /// <summary>
        /// Try to get the engine version specification from the given package.json object (represented 
        /// as a dictionary)
        /// </summary>
        /// <param name="store">The JavaScript object in dictionary representation</param>
        /// <param name="engineKey">The property name of the engine version to find</param>
        /// <param name="engineVersion">The version value to store in the object for the engine given</param>
        /// <returns>True if the property is successfully set, false otherwise</returns>
        static void SetEngineVersionInJson(Dictionary<string, object> store, string engineKey, string engineVersion)
        {
            Dictionary<string, object> engines;
            if (!TryGetEnginesSection(store, out engines))
            {
                engines = new Dictionary<string, object>();
                store[Resources.JsonEnginesSectionName] = engines;
            }

            SetValue<string>(engines, engineKey, engineVersion);
        }
    }
}
