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

using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace Microsoft.Azure.Commands.SiteRecovery
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
        /// Updates current Vault context.
        /// </summary>
        /// <param name="asrVaultCreds">ASR Vault credentials</param>
        public static void UpdateCurrentVaultContext(ASRVaultCreds asrVaultCreds)
        {
            object updateVaultContextOneAtATime = new object();
            lock (updateVaultContextOneAtATime)
            {
                PSRecoveryServicesClient.asrVaultCreds.ResourceName =
                    asrVaultCreds.ResourceName;
                PSRecoveryServicesClient.asrVaultCreds.ResourceGroupName =
                    asrVaultCreds.ResourceGroupName;
                PSRecoveryServicesClient.asrVaultCreds.ChannelIntegrityKey =
                    asrVaultCreds.ChannelIntegrityKey;
                PSRecoveryServicesClient.asrVaultCreds.ResourceNamespace =
                    asrVaultCreds.ResourceNamespace;
                PSRecoveryServicesClient.asrVaultCreds.ARMResourceType =
                    asrVaultCreds.ARMResourceType;
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
        /// Get Value from ARM ID
        /// </summary>
        /// <param name="size">size of the key to be generated</param>
        /// <returns>the key</returns>
        public static string GetValueFromArmId(string armId, string key)
        {
            string[] armFields = armId.Split('/');
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            if (armFields.Length % 2 == 0)
            {
                throw new Exception("Invalid ARM ID");
            }

            for (int i = 1; i < armFields.Length; i = i + 2)
            {
                dictionary.Add(armFields[i], armFields[i + 1]);
            }

            return dictionary[key];
        }

        public static void GetResourceProviderNamespaceAndType(
            string resourceId,
            out string resourceProviderNamespace,
            out string resourceType)
        {
            string[] armFields = resourceId.Split('/');
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            if (armFields.Length % 2 == 0)
            {
                throw new Exception("Invalid ARM ID");
            }

            for (int i = 1; i < armFields.Length; i = i + 2)
            {
                dictionary.Add(armFields[i], armFields[i + 1]);
            }
            resourceProviderNamespace = dictionary[ARMResourceTypeConstants.Providers];
            resourceType = dictionary.ContainsKey("SiteRecoveryVault") ? "SiteRecoveryVault" : "RecoveryServicesVault";
        }

        /// <summary>
        /// Returns tokens based on format provided. This works on ARM IDs only.
        /// </summary>
        /// <param name="data">String to unformat.</param>
        /// <param name="format">Format reference.</param>
        /// <returns>Array of string tokens.</returns>
        public static string[] UnFormatArmId(this string data, string format)
        {
            // Creates a new copy of the strings.
            string dataCopy = string.Copy(data);
            string processFormat = string.Copy(format);

            try
            {
                List<string> tokens = new List<string>();
                string processData = string.Empty;

                if (string.IsNullOrEmpty(dataCopy))
                {
                    throw new Exception("Null and empty strings are not valid resource Ids - " + data);
                }

                // First truncate data string to point from where format string starts.
                // We start from 1 index so that if url starts with / we avoid picking the first /.
                int firstTokenEnd = format.IndexOf("/", 1);
                int matchIndex = dataCopy.ToLower().IndexOf(format.Substring(0, firstTokenEnd).ToLower());

                if (matchIndex == -1)
                {
                    throw new Exception("Invalid resource Id - " + data);
                }

                processData = dataCopy.Substring(matchIndex);

                int counter = 0;
                while (true)
                {
                    int markerStartIndex = processFormat.IndexOf("{" + counter + "}");

                    if (markerStartIndex == -1)
                    {
                        break;
                    }

                    int markerEndIndex = processData.IndexOf("/", markerStartIndex);

                    if (markerEndIndex == -1)
                    {
                        tokens.Add(processData.Substring(markerStartIndex));
                    }
                    else
                    {
                        tokens.Add(processData.Substring(markerStartIndex, markerEndIndex - markerStartIndex));
                        processData = processData.Substring(markerEndIndex);
                        processFormat = processFormat.Substring(markerStartIndex + 3);
                    }

                    counter++;
                }

                // Similar formats like /a/{0}/b/{1} and /c/{0}/d/{1} can return incorrect tokens
                // therefore, adding another check to ensure that the data is unformatted correctly.
                if (data.ToLower().Contains(string.Format(format, tokens.ToArray()).ToLower()))
                {
                    return tokens.ToArray();
                }
                else
                {
                    throw new Exception("Invalid resource Id - " + data);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    string.Format("Invalid resource Id - {0}. Exception - {1} ", data, ex));
            }
        }

        /// <summary>
        /// Returns ARM Id of the vault from ARM ID of the contained resource.
        /// </summary>
        /// <param name="data">ARM Id of the resource.</param>
        /// <returns>ARM Id of the vault.</returns>
        public static string GetVaultArmId(this string data)
        {
            return string.Format(
                ARMResourceIdPaths.SRSArmUrlPattern,
                data.UnFormatArmId(ARMResourceIdPaths.SRSArmUrlPattern));
        }
    }

    /// <summary>
    /// Custom Convertor for deserializing JSON
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        /// <summary>
        /// Gets a value indicating whether this Newtonsoft.Json.JsonConverter can write JSON
        /// </summary>
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>true if this instance can convert the specified object type; otherwise, false.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The Newtonsoft.Json.JsonReader to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>the type of object</returns>
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            // Load JObject from stream 
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject 
            T target = this.Create(objectType, jObject);

            // Populate the object properties 
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The Newtonsoft.Json.JsonWriter to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary> 
        /// Create an instance of objectType, based on properties in the JSON object 
        /// </summary> 
        /// <param name="objectType">Type of the object.</param> 
        /// <param name="jObject">Contents of JSON object that will be deserialized.</param> 
        /// <returns>Returns object of type.</returns> 
        protected abstract T Create(Type objectType, JObject jObject);
    }

    /// <summary>
    /// Custom Convertor for deserializing RecoveryPlanActionDetails(RecoveryPlan) object
    /// </summary>
    [JsonConverter(typeof(RecoveryPlanActionDetails))]
    public class RecoveryPlanActionDetailsConverter : JsonCreationConverter<RecoveryPlanActionDetails>
    {
        /// <summary>
        /// Creates recovery plan action custom details.
        /// </summary>
        /// <param name="objectType">Object type.</param> 
        /// <param name="jObject">JSON object that will be deserialized.</param> 
        /// <returns>Returns recovery plan action custom details.</returns>
        protected override RecoveryPlanActionDetails Create(
            Type objectType,
            JObject jObject)
        {
            RecoveryPlanActionDetails outputType = null;
            RecoveryPlanActionDetailsType actionType =
                (RecoveryPlanActionDetailsType)Enum.Parse(typeof(RecoveryPlanActionDetailsType), jObject.Value<string>(Constants.InstanceType));

            switch (actionType)
            {
                case RecoveryPlanActionDetailsType.AutomationRunbookActionDetails:
                    outputType = new RecoveryPlanAutomationRunbookActionDetails();
                    break;

                case RecoveryPlanActionDetailsType.ManualActionDetails:
                    outputType = new RecoveryPlanManualActionDetails();
                    break;

                case RecoveryPlanActionDetailsType.ScriptActionDetails:
                    outputType = new RecoveryPlanScriptActionDetails();
                    break;
            }

            return outputType;
        }
    }

    /// <summary>
    /// Recovery Plan Action Types
    /// </summary>
    public enum RecoveryPlanActionDetailsType
    {
        AutomationRunbookActionDetails,
        ManualActionDetails,
        ScriptActionDetails
    };
}
