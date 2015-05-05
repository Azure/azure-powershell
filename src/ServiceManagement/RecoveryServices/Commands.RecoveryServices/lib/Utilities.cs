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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Class to define Utility methods 
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Serialize the T as xml using DataContract Serializer
        /// </summary>
        /// <typeparam name="T">the type name</typeparam>
        /// <param name="value">the T object.</param>
        /// <returns>the serialized object.</returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        public static string Serialize<T>(T value)
        {
            if (value == null)
            {
                return null;
            }

            string serializedValue;

            using (MemoryStream memoryStream = new MemoryStream())
            using (StreamReader reader = new StreamReader(memoryStream))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(memoryStream, value);
                memoryStream.Position = 0;
                serializedValue = reader.ReadToEnd();
            }

            return serializedValue;
        }

        /// <summary>
        /// Deserialize the xml as T
        /// </summary>
        /// <typeparam name="T">the type name</typeparam>
        /// <param name="xml">the xml as string</param>
        /// <returns>the equivalent T</returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        public static T Deserialize<T>(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default(T);
            }

            using (Stream stream = new MemoryStream())
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                DataContractSerializer deserializer = new DataContractSerializer(typeof(T));
                return (T)deserializer.ReadObject(stream);
            }
        }

        /// <summary>
        /// Method to write content to a file.
        /// </summary>
        /// <typeparam name="T">Class to be serialized</typeparam>
        /// <param name="fileContent">content to be written to the file</param>
        /// <param name="filePath">the path where the file is to be created</param>
        /// <param name="fileName">name of the file to be created</param>
        /// <returns>file path with file name as string</returns>
        public static string WriteToFile<T>(T fileContent, string filePath, string fileName)
        {
            string fullFileName = Path.Combine(filePath, fileName);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@fullFileName, false))
            {
                string contentToWrite = Serialize<T>(fileContent);
                file.WriteLine(contentToWrite);
            }

            return fullFileName;
        }

        /// <summary>
        /// Imports Azure Site Recovery Vault settings.
        /// </summary>
        /// <param name="asrVaultCreds">ASR Vault credentials</param>
        public static void UpdateVaultSettings(ASRVaultCreds asrVaultCreds)
        {
            object updateVaultSettingsOneAtATime = new object();
            lock (updateVaultSettingsOneAtATime)
            {
                PSRecoveryServicesClient.asrVaultCreds.ResourceName =
                    asrVaultCreds.ResourceName;
                PSRecoveryServicesClient.asrVaultCreds.CloudServiceName =
                    asrVaultCreds.CloudServiceName;
                PSRecoveryServicesClient.asrVaultCreds.ChannelIntegrityKey =
                    asrVaultCreds.ChannelIntegrityKey;
            }
        }

        /// <summary>
        /// method to return the Downloads path for the current user.
        /// </summary>
        /// <returns>path as  string.</returns>
        public static string GetDefaultPath()
        {
            string path = Path.GetTempPath();
            return path;
        }

        /// <summary>
        /// Generate cryptographically random key of given bit size.
        /// </summary>
        /// <param name="size">size of the key to be generated</param>
        /// <returns>the key</returns>
        public static string GenerateRandomKey(int size)
        {
            byte[] key = new byte[(int)size / 8];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetBytes(key);
            return Convert.ToBase64String(key);
        }

        /// <summary>
        /// Method to generate the cloud service name 
        /// </summary>
        /// <param name="region">region name</param>
        /// <returns>cloud service name as string</returns>
        public static string GenerateCloudServiceName(string region)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}{1}{2}",
                Constants.CloudServiceNameExtensionPrefix,
                region.Replace(' ', '-'),
                Constants.CloudServiceNameExtensionSuffix);       
        }
    }
}
