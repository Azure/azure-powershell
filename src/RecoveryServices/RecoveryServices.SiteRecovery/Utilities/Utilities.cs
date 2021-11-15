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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Class to define Utility methods
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        ///     Deserialize the xml as T
        /// </summary>
        /// <typeparam name="T">the type name</typeparam>
        /// <param name="xml">the xml as string</param>
        /// <returns>the equivalent T</returns>
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed.")]
        public static T Deserialize<T>(
            string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default(T);
            }

            using (Stream stream = new MemoryStream())
            {
                var data = Encoding.UTF8.GetBytes(xml);
                stream.Write(
                    data,
                    0,
                    data.Length);
                stream.Position = 0;
                var deserializer = new DataContractSerializer(typeof(T));
                return (T)deserializer.ReadObject(stream);
            }
        }

        /// <summary>
        ///     Generate cryptographically random key of given bit size.
        /// </summary>
        /// <param name="size">size of the key to be generated</param>
        /// <returns>the key</returns>
        public static string GenerateRandomKey(
            int size)
        {
            var key = new byte[size / 8];
            var crypto = new RNGCryptoServiceProvider();
            crypto.GetBytes(key);
            return Convert.ToBase64String(key);
        }

        public static List<IPage<T>> GetAllFurtherPages<T>(
            Func<string, Dictionary<string, List<string>>, CancellationToken,
            Task<AzureOperationResponse<IPage<T>>>> getNextPage,
            string NextPageLink,
            Dictionary<string, List<string>> customHeaders = null)
        {
            var result = new List<IPage<T>>();

            while ((NextPageLink != null) &&
                   (getNextPage != null))
            {
                var page = getNextPage(
                        NextPageLink,
                        customHeaders,
                        default(CancellationToken))
                    .GetAwaiter()
                    .GetResult()
                    .Body;
                result.Add(page);
                NextPageLink = page.NextPageLink;
            }

            return result;
        }

        public static List<IPage<T>> GetNextPages<T>(
            Func<string, CancellationToken,
            Task<AzureOperationResponse<IPage<T>>>> getNextPage,
            string NextPageLink)
        {
            var result = new List<IPage<T>>();

            while ((NextPageLink != null) &&
                   (getNextPage != null))
            {
                var page = getNextPage(
                        NextPageLink,
                        default(CancellationToken))
                    .GetAwaiter()
                    .GetResult()
                    .Body;
                result.Add(page);
                NextPageLink = page.NextPageLink;
            }

            return result;
        }

        /// <summary>
        ///     method to return the Downloads path for the current user.
        /// </summary>
        /// <returns>path as  string.</returns>
        public static string GetDefaultPath()
        {
            var path = Path.GetTempPath();
            return path;
        }

        /// <summary>
        ///     Get the name of the member for memberExpression.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="memberExpression">Member Expression.</param>
        /// <returns>Name of the member.</returns>
        public static string GetMemberName<T>(
            Expression<Func<T>> memberExpression)
        {
            var expressionBody = (MemberExpression)memberExpression.Body;
            return expressionBody.Member.Name;
        }

        /// <summary>
        ///     Returns provider namespace from ARM id.
        /// </summary>
        /// <param name="data">ARM Id of the resource.</param>
        /// <returns>Provider namespace.</returns>
        public static string GetProviderNameSpaceFromArmId(
            this string data)
        {
            return data.UnFormatArmId(ARMResourceIdPaths.SRSArmUrlPattern)[2];
        }

        /// <summary>
        ///     Get Value from ARM ID
        /// </summary>
        /// <param name="size">size of the key to be generated</param>
        /// <returns>the key</returns>
        public static string GetValueFromArmId(
            string armId,
            string key)
        {
            var armFields = armId.Split('/');
            var dictionary = new Dictionary<string, string>();

            if (armFields.Length % 2 == 0)
            {
                throw new Exception("Invalid ARM ID");
            }

            for (var i = 1; i < armFields.Length; i = i + 2)
            {
                dictionary.Add(
                    armFields[i],
                    armFields[i + 1]);
            }

            return dictionary[key];
        }

        /// <summary>
        ///     Returns ARM Id of the vault from ARM ID of the contained resource.
        /// </summary>
        /// <param name="data">ARM Id of the resource.</param>
        /// <returns>ARM Id of the vault.</returns>
        public static string GetVaultArmId(
            this string data)
        {
            return string.Format(
                ARMResourceIdPaths.SRSArmUrlPattern,
                data.UnFormatArmId(ARMResourceIdPaths.SRSArmUrlPattern));
        }

        /// <summary>
        /// Checks whether the ARM Id is valid per the given format.
        /// </summary>
        /// <param name="armId">ARM Id.</param>
        /// <param name="armIdFormat">ARM id format.</param>
        /// <returns>True if the ARM Id is valid, false otherwise.</returns>
        public static bool IsValidArmId(this string armId, string armIdFormat)
        {
            try
            {
                var tokens = armId.UnFormatArmId(armIdFormat);

                return tokens.All(x => !string.IsNullOrEmpty(x));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<T> IpageToList<T>(
            List<IPage<T>> pages)
        {
            var result = new List<T>();

            foreach (var page in pages)
            {
                foreach (var item in page)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        /// <summary>
        ///     Serialize the T as xml using DataContract Serializer
        /// </summary>
        /// <typeparam name="T">the type name</typeparam>
        /// <param name="value">the T object.</param>
        /// <returns>the serialized object.</returns>
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed.")]
        public static string Serialize<T>(
            T value)
        {
            if (value == null)
            {
                return null;
            }

            string serializedValue;

            using (var memoryStream = new MemoryStream())
            using (var reader = new StreamReader(memoryStream))
            {
                var serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(
                    memoryStream,
                    value);
                memoryStream.Position = 0;
                serializedValue = reader.ReadToEnd();
            }

            return serializedValue;
        }

        /// <summary>
        ///     Converts Query object to query string to pass on.
        /// </summary>
        /// <param name="queryObject">Query object</param>
        /// <returns>Qeury string</returns>
        public static string ToQueryString(
            this object queryObject)
        {
            if (queryObject == null)
            {
                return string.Empty;
            }

            var objType = queryObject.GetType();
            var properties = objType.GetProperties();

            var queryString = new StringBuilder();
            var propQuery = new List<string>();
            foreach (var property in properties)
            {
                var propValue = property.GetValue(
                    queryObject,
                    null);
                if (propValue != null)
                {
                    // IList is the only one we are handling
                    var elems = propValue as IList;
                    if ((elems != null) &&
                        (elems.Count != 0))
                    {
                        var itemCount = 0;
                        var multiPropQuery = new string[elems.Count];
                        foreach (var item in elems)
                        {
                            multiPropQuery[itemCount] = new StringBuilder().Append(property.Name)
                                .Append(" eq '")
                                .Append(item)
                                .Append("'")
                                .ToString();

                            itemCount++;
                        }

                        propQuery.Add(
                            "( " +
                            string.Join(
                                " or ",
                                multiPropQuery) +
                            " )");
                    }
                    /*Add DateTime, others if required*/
                    else
                    {
                        if (propValue.ToString()
                            .Contains("Hyak.Common.LazyList"))
                        {
                            // Just skip the property.
                        }
                        else
                        {
                            propQuery.Add(
                                new StringBuilder().Append(property.Name)
                                    .Append(" eq '")
                                    .Append(propValue)
                                    .Append("'")
                                    .ToString());
                        }
                    }
                }
            }

            queryString.Append(
                string.Join(
                    " and ",
                    propQuery));
            return queryString.ToString();
        }

        /// <summary>
        ///     Returns tokens based on format provided. This works on ARM IDs only.
        /// </summary>
        /// <param name="data">String to unformat.</param>
        /// <param name="format">Format reference.</param>
        /// <returns>Array of string tokens.</returns>
        public static string[] UnFormatArmId(
            this string data,
            string format)
        {
            // Creates a new copy of the strings.
            var dataCopy = string.Copy(data);
            var processFormat = string.Copy(format);

            try
            {
                var tokens = new List<string>();
                var processData = string.Empty;

                if (string.IsNullOrEmpty(dataCopy))
                {
                    throw new Exception(
                        "Null and empty strings are not valid resource Ids - " + data);
                }

                // First truncate data string to point from where format string starts.
                // We start from 1 index so that if url starts with / we avoid picking the first /.
                var firstTokenEnd = format.IndexOf(
                    "/",
                    1);
                var matchIndex = dataCopy.ToLower()
                    .IndexOf(
                        format.Substring(
                                0,
                                firstTokenEnd)
                            .ToLower());

                if (matchIndex == -1)
                {
                    throw new Exception("Invalid resource Id - " + data);
                }

                processData = dataCopy.Substring(matchIndex);

                var counter = 0;
                while (true)
                {
                    var markerStartIndex = processFormat.IndexOf("{" + counter + "}");

                    if (markerStartIndex == -1)
                    {
                        break;
                    }

                    var markerEndIndex = processData.IndexOf(
                        "/",
                        markerStartIndex);

                    if (markerEndIndex == -1)
                    {
                        tokens.Add(processData.Substring(markerStartIndex));
                    }
                    else
                    {
                        tokens.Add(
                            processData.Substring(
                                markerStartIndex,
                                markerEndIndex - markerStartIndex));
                        processData = processData.Substring(markerEndIndex);
                        processFormat = processFormat.Substring(markerStartIndex + 3);
                    }

                    counter++;
                }

                // Similar formats like /a/{0}/b/{1} and /c/{0}/d/{1} can return incorrect tokens
                // therefore, adding another check to ensure that the data is unformatted correctly.
                if (data.ToLower()
                    .Contains(
                        string.Format(
                                format,
                                tokens.ToArray())
                            .ToLower()))
                {
                    return tokens.ToArray();
                }

                throw new Exception("Invalid resource Id - " + data);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    string.Format(
                        "Invalid resource Id - {0}. Exception - {1} ",
                        data,
                        ex));
            }
        }

        /// <summary>
        ///     Updates current Vault context.
        /// </summary>
        /// <param name="asrVaultCreds">ASR Vault credentials</param>
        public static void UpdateCurrentVaultContext(
            ASRVaultCreds asrVaultCreds)
        {
            var updateVaultContextOneAtATime = new object();
            lock (updateVaultContextOneAtATime)
            {
                PSRecoveryServicesClient.asrVaultCreds.ResourceName = asrVaultCreds.ResourceName;
                PSRecoveryServicesClient.asrVaultCreds.ResourceGroupName =
                    asrVaultCreds.ResourceGroupName;
                PSRecoveryServicesClient.asrVaultCreds.ChannelIntegrityKey =
                    asrVaultCreds.ChannelIntegrityKey;
                PSRecoveryServicesClient.asrVaultCreds.ResourceNamespace =
                    asrVaultCreds.ResourceNamespace;
                PSRecoveryServicesClient.asrVaultCreds.ARMResourceType =
                    asrVaultCreds.ARMResourceType;
                PSRecoveryServicesClient.asrVaultCreds.PrivateEndpointStateForSiteRecovery =
                    asrVaultCreds.PrivateEndpointStateForSiteRecovery;
            }
        }

        /// <summary>
        ///     Validate the email addresses.
        /// </summary>
        /// <param name="emails">list of email addresses.</param>
        public static void ValidateCustomEmails(string[] emails)
        {
            var emailPattern = "^[a-zA-Z0-9\\\".!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9]" +
                "(?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9]" +
                "(?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
            var rgx = new Regex(emailPattern);

            if (emails.Length > 20)
            {
                throw new InvalidOperationException(
                    string.Format(Resources.EmailsCountExceeded));
            }

            foreach (var email in emails)
            {
                if (email.Length > 254)
                {
                    throw new InvalidOperationException(
                        string.Format(Resources.EmailLengthExceeded));
                }

                if (!rgx.IsMatch(email))
                {
                    throw new InvalidOperationException(
                        string.Format(Resources.EmailFormatInvalid));
                }
            }
        }

        /// <summary>
        ///     Validate the ipaddress or host name.
        /// </summary>
        /// <param name="server">ip or hostname.</param>
        public static void ValidateIpOrHostName(string server)
        {
            var ipRegEx = "^([0-9]+).(([0-9]+)|.)*$";
            var ipReg = new Regex(ipRegEx);

            // Checking for ipv4
            if (ipReg.IsMatch(server))
            {
                var ipAddressRegEX = "^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]).){3}" +
                    "([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";

                var ipAddressReg = new Regex(ipAddressRegEX);

                if (!ipAddressReg.IsMatch(server))
                {
                    throw new InvalidOperationException(
                        string.Format(Resources.InvalidIpAddress));
                }
            }
        }

        /// <summary>
        ///     Method to write content to a file.
        /// </summary>
        /// <typeparam name="T">Class to be serialized</typeparam>
        /// <param name="fileContent">content to be written to the file</param>
        /// <param name="filePath">the path where the file is to be created</param>
        /// <param name="fileName">name of the file to be created</param>
        /// <returns>file path with file name as string</returns>
        public static string WriteToFile<T>(
            T fileContent,
            string filePath,
            string fileName)
        {
            var fullFileName = Path.Combine(
                filePath,
                fileName);
            using (var file = new StreamWriter(
                fullFileName,
                false))
            {
                var contentToWrite = Serialize(fileContent);
                file.WriteLine(contentToWrite);
            }

            return fullFileName;
        }

        /// <summary>
        /// Creating DiskEncryptionInfo for A2A encrypted Vm.
        /// </summary>
        /// <param name="diskEncryptionSecretUrl">Secret identifier.</param>
        /// <param name="diskEncryptionVaultId">Secret KeyVault.</param>
        /// <param name="keyEncryptionKeyUrl">Key identifier.</param>
        /// <param name="keyEncryptionVaultId">Key KeyVault.</param>
        /// <returns>DiskEncryptionInfo object.</returns>
        public static DiskEncryptionInfo A2AEncryptionDetails(
                    string diskEncryptionSecretUrl,
                    string diskEncryptionVaultId,
                    string keyEncryptionKeyUrl,
                    string keyEncryptionVaultId)
        {
            DiskEncryptionInfo diskEncryptionInfo = null;
            if (!string.IsNullOrEmpty(diskEncryptionSecretUrl) &&
                !string.IsNullOrEmpty(diskEncryptionVaultId))
            {
                diskEncryptionInfo = new DiskEncryptionInfo
                {
                    DiskEncryptionKeyInfo =
                        new DiskEncryptionKeyInfo(diskEncryptionSecretUrl, diskEncryptionVaultId)
                };

                if (!string.IsNullOrEmpty(keyEncryptionKeyUrl) &&
                    !string.IsNullOrEmpty(keyEncryptionVaultId))
                {
                    diskEncryptionInfo.KeyEncryptionKeyInfo =
                        new KeyEncryptionKeyInfo(keyEncryptionKeyUrl, keyEncryptionVaultId);
                }
                else if (!string.IsNullOrEmpty(keyEncryptionKeyUrl) ||
                    !string.IsNullOrEmpty(keyEncryptionVaultId))
                {
                    throw new Exception("Provide both keyEncryptionKeyUrl and keyEncryptionVaultId.");
                }
            }
            else if (!string.IsNullOrEmpty(diskEncryptionSecretUrl) ||
                !string.IsNullOrEmpty(diskEncryptionVaultId))
            {
                throw new Exception("Provide both diskEncryptionSecretUrl and diskEncryptionVaultId.");
            }

            return diskEncryptionInfo;
        }
    }

    /// <summary>
    ///     Custom Convertor for deserializing JSON
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        /// <summary>
        ///     Gets a value indicating whether this Newtonsoft.Json.JsonConverter can write JSON
        /// </summary>
        public override bool CanWrite => false;

        /// <summary>
        ///     Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>true if this instance can convert the specified object type; otherwise, false.</returns>
        public override bool CanConvert(
            Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        /// <summary>
        ///     Reads the JSON representation of the object.
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
            var jObject = JObject.Load(reader);

            // Create target object based on JObject 
            var target = this.Create(
                objectType,
                jObject);

            // Populate the object properties 
            serializer.Populate(
                jObject.CreateReader(),
                target);

            return target;
        }

        /// <summary>
        ///     Writes the JSON representation of the object.
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
        ///     Create an instance of objectType, based on properties in the JSON object
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="jObject">Contents of JSON object that will be deserialized.</param>
        /// <returns>Returns object of type.</returns>
        protected abstract T Create(
            Type objectType,
            JObject jObject);
    }

    /// <summary>
    ///     Custom Convertor for deserializing RecoveryPlanActionDetails(RecoveryPlan) object
    /// </summary>
    [JsonConverter(typeof(RecoveryPlanActionDetails))]
    public class RecoveryPlanActionDetailsConverter :
        JsonCreationConverter<RecoveryPlanActionDetails>
    {
        /// <summary>
        ///     Gets a value indicating whether this Newtonsoft.Json.JsonConverter can write JSON
        /// </summary>
        public override bool CanWrite => true;

        /// <summary>
        ///     Creates recovery plan action custom details.
        /// </summary>
        /// <param name="objectType">Object type.</param>
        /// <param name="jObject">JSON object that will be deserialized.</param>
        /// <returns>Returns recovery plan action custom details.</returns>
        protected override RecoveryPlanActionDetails Create(
            Type objectType,
            JObject jObject)
        {
            RecoveryPlanActionDetails outputType = null;
            var actionType = (RecoveryPlanActionDetailsType)Enum.Parse(
                typeof(RecoveryPlanActionDetailsType),
                jObject.Value<string>(Constants.InstanceType));

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

        /// <summary>
        ///     Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The Newtonsoft.Json.JsonWriter to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);
            string instanceType = null;
            if (value != null)
            {
                if (string.Compare(value.GetType().ToString(), typeof(RecoveryPlanAutomationRunbookActionDetails).ToString()) == 0)
                {
                    instanceType = RecoveryPlanActionDetailsType.AutomationRunbookActionDetails.ToString();
                }
                else if (string.Compare(value.GetType().ToString(), typeof(RecoveryPlanManualActionDetails).ToString()) == 0)
                {
                    instanceType = RecoveryPlanActionDetailsType.ManualActionDetails.ToString();
                }
                else if (string.Compare(value.GetType().ToString(), typeof(RecoveryPlanScriptActionDetails).ToString()) == 0)
                {
                    instanceType = RecoveryPlanActionDetailsType.ScriptActionDetails.ToString();
                }
            }
            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                JObject o = (JObject)t;
                IList<string> propertyNames = o.Properties().Select(p => p.Name).ToList();

                o.AddFirst(new JProperty(Constants.InstanceType, instanceType));

                o.WriteTo(writer);
            }
        }

    }

    /// <summary> 
    ///     Custom Convertor for deserializing RecoveryPlanProviderSpecificDetails(RecoveryPlan) object 
    /// </summary> 
    [JsonConverter(typeof(RecoveryPlanProviderSpecificDetails))]
    public class RecoveryPlanProviderSpecificDetailsConverter :
        JsonCreationConverter<RecoveryPlanProviderSpecificDetails>
    {
        /// <summary> 
        ///     Gets a value indicating whether this Newtonsoft.Json.JsonConverter can write JSON 
        /// </summary> 
        public override bool CanWrite => true;

        /// <summary> 
        ///     Creates RecoveryPlanProviderSpecific details. 
        /// </summary> 
        /// <param name="objectType">Object type.</param> 
        /// <param name="jObject">JSON object that will be deserialized.</param> 
        /// <returns>Returns recovery plan action custom details.</returns> 
        protected override RecoveryPlanProviderSpecificDetails Create(
            Type objectType,
            JObject jObject)
        {
            RecoveryPlanProviderSpecificDetails outputType = null;
            var actionType = (RecoveryPlanProviderType)Enum.Parse(
                typeof(RecoveryPlanProviderType),
                jObject.Value<string>(Constants.InstanceType));

            switch (actionType)
            {
                case RecoveryPlanProviderType.A2A:
                    outputType = new RecoveryPlanA2ADetails();
                    break;
            }

            return outputType;
        }

        /// <summary> 
        ///     Writes the JSON representation of the object. 
        /// </summary> 
        /// <param name="writer">The Newtonsoft.Json.JsonWriter to write to.</param> 
        /// <param name="value">The value.</param> 
        /// <param name="serializer">The calling serializer.</param> 
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);
            string instanceType = null;
            if (value != null)
            {
                if (string.Compare(value.GetType().ToString(), typeof(RecoveryPlanA2ADetails).ToString()) == 0)
                {
                    instanceType = RecoveryPlanProviderType.A2A.ToString();
                }
            }

            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                JObject o = (JObject)t;
                IList<string> propertyNames = o.Properties().Select(p => p.Name).ToList();
                o.AddFirst(new JProperty(Constants.InstanceType, instanceType));
                o.WriteTo(writer);
            }
        }
    }
    /// <summary>
    ///     Recovery Plan Action Types
    /// </summary>
    public enum RecoveryPlanActionDetailsType
    {
        AutomationRunbookActionDetails,
        ManualActionDetails,
        ScriptActionDetails
    }

    /// <summary> 
    ///     Recovery Plan Provider Types 
    /// </summary> 
    public enum RecoveryPlanProviderType
    {
        A2A
    }
}
