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

using Microsoft.Azure.Test.HttpRecorder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Microsoft.Azure.Commands.TestFx.Recorder
{
    public static class RecorderUtilities
    {
        private const string SanitizeValue = "Sanitized";

        private static Regex _binaryMimeRegex = new Regex("(image/*|audio/*|video/*|application/octet-stream|multipart/form-data)");

        public static List<string> JsonPathSanitizers { get; } = new List<string>();

        static RecorderUtilities()
        {
            JsonPathSanitizers.Add("$..Password");
            JsonPathSanitizers.Add("$..password");
            JsonPathSanitizers.Add("$..adminPassword");
            JsonPathSanitizers.Add("$..passwords[*].value");
            JsonPathSanitizers.Add("$..secret");
            JsonPathSanitizers.Add("$..secretText");
            JsonPathSanitizers.Add("$..accessSAS");
            JsonPathSanitizers.Add("$..storageAccountKey");
            JsonPathSanitizers.Add("$..primaryKey");
            JsonPathSanitizers.Add("$..primaryMasterKey");
            JsonPathSanitizers.Add("$..primaryReadonlyMasterKey");
            JsonPathSanitizers.Add("$..secondaryKey");
            JsonPathSanitizers.Add("$..secondaryMasterKey");
            JsonPathSanitizers.Add("$..secondaryReadonlyMasterKey");
            JsonPathSanitizers.Add("$..keys[*].value");
            JsonPathSanitizers.Add("$..connectionString");
            JsonPathSanitizers.Add("$..primaryConnectionString");
            JsonPathSanitizers.Add("$..secondaryConnectionString");
            JsonPathSanitizers.Add("$..aliasPrimaryConnectionString");
            JsonPathSanitizers.Add("$..aliasSecondaryConnectionString");
            JsonPathSanitizers.Add("$..administratorLoginPassword");
            JsonPathSanitizers.Add("$..hubDatabasePassword");
            JsonPathSanitizers.Add("$.properties.siteConfig.machineKey.decryptionKey");
            JsonPathSanitizers.Add("$.properties.WEBSITE_AUTH_ENCRYPTION_KEY");
            JsonPathSanitizers.Add("$.properties.DOCKER_REGISTRY_SERVER_PASSWORD");
            JsonPathSanitizers.Add("$.properties.protectedSettings.storageAccountKey");
        }

        public static bool IsHttpContentBinary(HttpContent content)
        {
            var contentType = content?.Headers?.ContentType?.MediaType;
            return IsHttpContentBinary(contentType);
        }

        public static bool IsHttpContentBinary(string contentType)
        {
            if (contentType == null)
                return false;

            return _binaryMimeRegex.IsMatch(contentType);
        }

        public static string SerializeBinary(byte[] content)
        {
            return Convert.ToBase64String(content);
        }

        public static byte[] DeserializeBinary(string content)
        {
            return Convert.FromBase64String(content);
        }

        public static string FormatString(string content)
        {
            if (IsXml(content))
                return TryFormatXml(content);

            if (IsJson(content))
                return TryFormatJson(content);

            return content;
        }

        public static RecordEntryContentType GetContetTypeFromHeaders(Dictionary<string, List<string>> responseHeaders)
        {
            string mimeType = string.Empty;
            RecordEntryContentType contentType = RecordEntryContentType.Null;
            var header = responseHeaders.Where(hkv => hkv.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase));

            if (header.Any())
            {
                mimeType = header.First().Value?.First();
            }

            if (!string.IsNullOrWhiteSpace(mimeType))
            {
                if (IsHttpContentBinary(mimeType))
                {
                    contentType = RecordEntryContentType.Binary;
                }
                else
                {
                    contentType = RecordEntryContentType.Ascii;
                }
            }

            return contentType;
        }

        public static string FormatHttpContent(HttpContent httpContent)
        {
            string formattedContent;
            if (IsHttpContentBinary(httpContent))
            {
                formattedContent = Convert.ToBase64String(httpContent.ReadAsByteArrayAsync().Result);
            }
            else
            {
                formattedContent = FormatString(httpContent.ReadAsStringAsync().Result);
            }

            return formattedContent;
        }

        public static HttpContent CreateHttpContent(string contentData, RecordEntryContentType recordContentType)
        {
            HttpContent createdContent = null;

            switch (recordContentType)
            {
                case RecordEntryContentType.Binary:
                    {
                        try
                        {
                            byte[] hashBytes = Convert.FromBase64String(contentData);
                            if (hashBytes != null)
                            {
                                createdContent = new ByteArrayContent(hashBytes);
                            }
                        }
                        catch
                        {
                            if (contentData != null)
                                createdContent = new StringContent(contentData);
                            else
                                createdContent = new StringContent(string.Empty);
                        }
                        break;
                    }
                case RecordEntryContentType.Ascii:
                    {
                        createdContent = new StringContent(contentData);
                        break;
                    }
                case RecordEntryContentType.Null:
                default:
                    {
                        createdContent = new StringContent(string.Empty);
                        break;
                    }
            }

            return createdContent;
        }

        /// <summary>
        /// Formats the given XML into indented way.
        /// </summary>
        /// <param name="content">The input xml string</param>
        /// <returns>The formatted xml string</returns>
        public static string TryFormatXml(string content)
        {
            try
            {
                XDocument doc = XDocument.Parse(content);
                return doc.ToString();
            }
            catch
            {
                return content;
            }
        }

        /// <summary>
        /// Checks if the content is valid XML or not.
        /// </summary>
        /// <param name="content">The text to check</param>
        /// <returns>True if XML, false otherwise</returns>
        public static bool IsXml(string content)
        {
            try
            {
                XDocument doc = XDocument.Parse(content);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string TryFormatJson(string content)
        {
            try
            {
                JToken parsedJson = JsonConvert.DeserializeObject<JToken>(content);
                foreach (var jsonPath in JsonPathSanitizers)
                {
                    foreach (JToken token in parsedJson.SelectTokens(jsonPath))
                    {
                        if (token.Type == JTokenType.String && token.Value<string>() != string.Empty)
                        {
                            token.Replace(SanitizeValue);
                        }
                    }
                }
                return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            }
            catch
            {
                return content;
            }
        }

        public static bool IsJson(string content)
        {
            content = content.Trim();
            return content.StartsWith("{") && content.EndsWith("}")
                   || content.StartsWith("[") && content.EndsWith("]");
        }

        /// <summary>
        /// Perform an action on each element of a sequence.
        /// </summary>
        /// <typeparam name="T">Type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="action">The action to perform.</param>
        internal static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            Debug.Assert(sequence != null, "sequence cannot be null!");
            Debug.Assert(action != null, "action cannot be null!");

            foreach (T element in sequence)
            {
                action(element);
            }
        }

        public static void SerializeJson<T>(T data, string path)
        {
            // TypeNameAssemblyFormat == Simple = 0, Full = 1 
            // (we have an issue with duplicate namespace between newtonsoft and System.Runtime.Serialization.
            // Once we upgrade to newtonsoft 11.x, we can start using TypeNameAssemblyFormatHandling instead)
            HttpMockServer.FileSystemUtilsObject.WriteFile(
                path, JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
                {
#if net452
                    TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
#elif !net452
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
#endif
                    TypeNameHandling = TypeNameHandling.None
                }));
        }

        public static T DeserializeJson<T>(string path)
        {
            // TypeNameAssemblyFormat == Simple = 0, Full = 1 
            // (we have an issue with duplicate namespace between newtonsoft and System.Runtime.Serialization.
            // Once we upgrade to newtonsoft 11.x, we can start using TypeNameAssemblyFormatHandling instead)
            string json = HttpMockServer.FileSystemUtilsObject.ReadFileAsText(path);
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
#if net452
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
#elif !net452
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
#endif
                TypeNameHandling = TypeNameHandling.None
            });
        }

        public static void EnsureDirectoryExists(string dir)
        {
            if (!HttpMockServer.FileSystemUtilsObject.DirectoryExists(dir))
            {
                HttpMockServer.FileSystemUtilsObject.CreateDirectory(dir);
            }
        }

        public static void CleanDirectory(string dir)
        {
            if (HttpMockServer.FileSystemUtilsObject.DirectoryExists(dir))
            {
                foreach (string file in HttpMockServer.FileSystemUtilsObject.GetFiles(dir, "*.*", true))
                {
                    HttpMockServer.FileSystemUtilsObject.DeleteFile(file);
                }
                foreach (string subDirectory in HttpMockServer.FileSystemUtilsObject.GetDirectories(dir, "*", true))
                {
                    HttpMockServer.FileSystemUtilsObject.DeleteDirectory(subDirectory);
                }
            }
        }

        public static string EncodeUriAsBase64(Uri requestUri)
        {
            return EncodeUriAsBase64(requestUri.PathAndQuery);
        }

        public static string EncodeUriAsBase64(string uriToEncode)
        {
            byte[] encodedUri = Encoding.UTF8.GetBytes(uriToEncode);
            return Convert.ToBase64String(encodedUri);
        }

        public static string DecodeBase64AsUri(string uriToDecode)
        {
            if (string.IsNullOrEmpty(uriToDecode))
                return uriToDecode;

            string[] uriSplit = uriToDecode.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (uriSplit.Length < 2)
                return uriToDecode;

            string headers = string.Empty;
            if (uriSplit.Length > 2)
            {
                headers = " " + string.Join(" ", uriSplit.Skip(2));
            }
            byte[] encodedUri = Convert.FromBase64String(uriSplit[1]);
            return string.Format("{0} {1}{2}", uriSplit[0], Encoding.UTF8.GetString(encodedUri, 0, encodedUri.Length), headers);
        }
    }
}
