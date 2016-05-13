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

using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class GeneralUtilities
    {
        private static Assembly assembly = Assembly.GetExecutingAssembly();

        private static List<string> AuthorizationHeaderNames = new List<string>() { "Authorization" };

        private static bool TryFindCertificatesInStore(string thumbprint,
            System.Security.Cryptography.X509Certificates.StoreLocation location, out X509Certificate2Collection certificates)
        {
            X509Store store = new X509Store(StoreName.My, location);
            store.Open(OpenFlags.ReadOnly);
            certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
            store.Close();

            return certificates != null && certificates.Count > 0;
        }

        public static X509Certificate2 GetCertificateFromStore(string thumbprint)
        {
            if (string.IsNullOrWhiteSpace(thumbprint))
            {
                throw new ArgumentNullException("certificate thumbprint");
            }

            X509Certificate2Collection certificates;
            if (TryFindCertificatesInStore(thumbprint, StoreLocation.CurrentUser, out certificates) ||
                TryFindCertificatesInStore(thumbprint, StoreLocation.LocalMachine, out certificates))
            {
                return certificates[0];
            }
            else
            {
                throw new ArgumentException(string.Format(
                    "Certificate {0} was not found in the certificate store.  Please ensure the referenced " +
                    "certificate exists in the the LocalMachine\\My or CurrentUser\\My store",
                    thumbprint));
            }
        }

        /// <summary>
        /// Compares two strings with handling special case that base string can be empty.
        /// </summary>
        /// <param name="leftHandSide">The base string.</param>
        /// <param name="rightHandSide">The comparer string.</param>
        /// <returns>True if equals or leftHandSide is null/empty, false otherwise.</returns>
        public static bool TryEquals(string leftHandSide, string rightHandSide)
        {
            if (string.IsNullOrEmpty(leftHandSide) ||
                leftHandSide.Equals(rightHandSide, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }


        public static string GetConfiguration(string configurationPath)
        {
            var configuration = string.Join(string.Empty, File.ReadAllLines(configurationPath));
            return configuration;
        }

        /// <summary>
        /// Get the value for a given key in a dictionary or return a default
        /// value if the key isn't present in the dictionary.
        /// </summary>
        /// <typeparam name="K">The type of the key.</typeparam>
        /// <typeparam name="V">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">A default value</param>
        /// <returns>The corresponding value or default value.</returns>
        public static V GetValueOrDefault<K, V>(this IDictionary<K, V> dictionary, K key, V defaultValue)
        {
            Debug.Assert(dictionary != null, "dictionary cannot be null!");

            V value;
            if (!dictionary.TryGetValue(key, out value))
            {
                value = defaultValue;
            }
            return value;
        }

        /// <summary>
        /// Returns a non-null sequence by either passing back the original
        /// sequence or creating a new empty sequence if the original was null.
        /// </summary>
        /// <typeparam name="T">Type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <returns>A non-null sequence.</returns>
        public static IEnumerable<T> NonNull<T>(this IEnumerable<T> sequence)
        {
            return (sequence != null) ?
                sequence :
                Enumerable.Empty<T>();
        }

        /// <summary>
        /// Perform an action on each element of a sequence.
        /// </summary>
        /// <typeparam name="T">Type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="action">The action to perform.</param>
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            Debug.Assert(sequence != null, "sequence cannot be null!");
            Debug.Assert(action != null, "action cannot be null!");

            foreach (T element in sequence)
            {
                action(element);
            }
        }

        /// <summary>
        /// Append an element to the end of an array.
        /// </summary>
        /// <typeparam name="T">Type of the arrays.</typeparam>
        /// <param name="left">The left array.</param>
        /// <param name="right">The right array.</param>
        /// <returns>The concatenated arrays.</returns>
        public static T[] Append<T>(T[] left, T right)
        {
            if (left == null)
            {
                return right != null ?
                    new T[] { right } :
                    new T[] { };
            }
            else if (right == null)
            {
                return left;
            }
            else
            {
                return Enumerable.Concat(left, new T[] { right }).ToArray();
            }
        }

        public static TResult MaxOrDefault<T, TResult>(this IEnumerable<T> sequence, Func<T, TResult> selector, TResult defaultValue)
        {
            return (sequence != null) ? sequence.Max(selector) : defaultValue;
        }

        /// <summary>
        /// Extends the array with one element.
        /// </summary>
        /// <typeparam name="T">The array type</typeparam>
        /// <param name="collection">The array holding elements</param>
        /// <param name="item">The item to add</param>
        /// <returns>New array with added item</returns>
        public static T[] ExtendArray<T>(IEnumerable<T> collection, T item)
        {
            if (collection == null)
            {
                collection = new T[0];
            }

            List<T> list = new List<T>(collection);
            list.Add(item);
            return list.ToArray<T>();
        }

        /// <summary>
        /// Extends the array with another array
        /// </summary>
        /// <typeparam name="T">The array type</typeparam>
        /// <param name="collection">The array holding elements</param>
        /// <param name="items">The items to add</param>
        /// <returns>New array with added items</returns>
        public static T[] ExtendArray<T>(IEnumerable<T> collection, IEnumerable<T> items)
        {
            if (collection == null)
            {
                collection = new T[0];
            }

            if (items == null)
            {
                items = new T[0];
            }

            return collection.Concat<T>(items).ToArray<T>();
        }

        /// <summary>
        /// Initializes given object if its set to null.
        /// </summary>
        /// <typeparam name="T">The object type</typeparam>
        /// <param name="obj">The object to initialize</param>
        /// <returns>Initialized object</returns>
        public static T InitializeIfNull<T>(T obj)
            where T : new()
        {
            if (obj == null)
            {
                return new T();
            }

            return obj;
        }

        public static string EnsureTrailingSlash(string url)
        {
            UriBuilder address = new UriBuilder(url);
            if (!address.Path.EndsWith("/", StringComparison.Ordinal))
            {
                address.Path += "/";
            }
            return address.Uri.AbsoluteUri;
        }

        public static string GetHttpResponseLog(string statusCode, WebHeaderCollection headers, string body)
        {
            StringBuilder httpResponseLog = new StringBuilder();
            httpResponseLog.AppendLine(string.Format("============================ HTTP RESPONSE ============================{0}", Environment.NewLine));
            httpResponseLog.AppendLine(string.Format("Status Code:{0}{1}{0}", Environment.NewLine, statusCode));
            httpResponseLog.AppendLine(string.Format("Headers:{0}{1}", Environment.NewLine, MessageHeadersToString(headers)));
            httpResponseLog.AppendLine(string.Format("Body:{0}{1}{0}", Environment.NewLine, body));

            return httpResponseLog.ToString();
        }

        public static string GetHttpResponseLog(string statusCode, HttpHeaders headers, string body)
        {
            return GetHttpResponseLog(statusCode, ConvertHttpHeadersToWebHeaderCollection(headers), body);
        }

        public static string GetHttpRequestLog(
            string method,
            string requestUri,
            WebHeaderCollection headers,
            string body)
        {
            StringBuilder httpRequestLog = new StringBuilder();
            httpRequestLog.AppendLine(string.Format("============================ HTTP REQUEST ============================{0}", Environment.NewLine));
            httpRequestLog.AppendLine(string.Format("HTTP Method:{0}{1}{0}", Environment.NewLine, method));
            httpRequestLog.AppendLine(string.Format("Absolute Uri:{0}{1}{0}", Environment.NewLine, requestUri));
            httpRequestLog.AppendLine(string.Format("Headers:{0}{1}", Environment.NewLine, MessageHeadersToString(headers)));
            httpRequestLog.AppendLine(string.Format("Body:{0}{1}{0}", Environment.NewLine, body));

            return httpRequestLog.ToString();
        }

        public static string GetHttpRequestLog(string method, string requestUri, HttpHeaders headers, string body)
        {
            return GetHttpRequestLog(method, requestUri, ConvertHttpHeadersToWebHeaderCollection(headers), body);
        }

        public static string GetLog(HttpResponseMessage response)
        {
            string body = response.Content == null ? string.Empty
                : FormatString(response.Content.ReadAsStringAsync().Result);

            return GetHttpResponseLog(
                response.StatusCode.ToString(),
                response.Headers,
                body);
        }

        public static string GetLog(HttpRequestMessage request)
        {
            string body = request.Content == null ? string.Empty
                : FormatString(request.Content.ReadAsStringAsync().Result);

            return GetHttpRequestLog(
                request.Method.ToString(),
                request.RequestUri.ToString(),
                (HttpHeaders)request.Headers,
                body);
        }

        public static string FormatString(string content)
        {
            if (CloudException.IsXml(content))
            {
                return TryFormatXml(content);
            }
            else if (CloudException.IsJson(content))
            {
                return TryFormatJson(content);
            }
            else
            {
                return content;
            }
        }

        private static string TryFormatJson(string str)
        {
            try
            {
                object parsedJson = JsonConvert.DeserializeObject(str);
                return JsonConvert.SerializeObject(parsedJson,
                    Newtonsoft.Json.Formatting.Indented);
            }
            catch
            {
                // can't parse JSON, return the original string
                return str;
            }
        }

        private static string TryFormatXml(string content)
        {
            try
            {
                XDocument doc = XDocument.Parse(content);
                return doc.ToString();
            }
            catch (Exception)
            {
                return content;
            }
        }

        private static WebHeaderCollection ConvertHttpHeadersToWebHeaderCollection(HttpHeaders headers)
        {
            WebHeaderCollection webHeaders = new WebHeaderCollection();
            foreach (KeyValuePair<string, IEnumerable<string>> pair in headers)
            {
                if (AuthorizationHeaderNames.Any(h => h.Equals(pair.Key, StringComparison.OrdinalIgnoreCase)))
                {
                    // Skip adding the authorization header
                    continue;
                }

                pair.Value.ForEach<string>(v => webHeaders.Add(pair.Key, v));
            }

            return webHeaders;
        }

        private static string MessageHeadersToString(WebHeaderCollection headers)
        {
            string[] keys = headers.AllKeys;
            StringBuilder result = new StringBuilder();

            foreach (string key in keys)
            {
                result.AppendLine(string.Format(
                    "{0,-30}: {1}",
                    key,
                    ConversionUtilities.ArrayToString(headers.GetValues(key), ",")));
            }

            return result.ToString();
        }

        /// <summary>
        /// Creates https endpoint from the given endpoint.
        /// </summary>
        /// <param name="endpointUri">The endpoint uri.</param>
        /// <returns>The https endpoint uri.</returns>
        public static Uri CreateHttpsEndpoint(string endpointUri)
        {
            UriBuilder builder = new UriBuilder(endpointUri) { Scheme = "https" };
            string endpoint = builder.Uri.GetComponents(
                UriComponents.AbsoluteUri & ~UriComponents.Port,
                UriFormat.UriEscaped);

            return new Uri(endpoint);
        }

        public static string DownloadFile(string uri)
        {
            string contents = null;

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    contents = webClient.DownloadString(new Uri(uri));
                }
                catch
                {
                    // Ignore the exception and return empty contents
                }
            }

            return contents;
        }

        /// <summary>
        /// Pad a string using the given separator string
        /// </summary>
        /// <param name="amount">The number of repetitions of the separator</param>
        /// <param name="separator">The separator string to use</param>
        /// <returns>A string containing the given number of repetitions of the separator string</returns>
        public static string GenerateSeparator(int amount, string separator)
        {
            StringBuilder result = new StringBuilder();
            while (amount-- != 0) result.Append(separator);
            return result.ToString();
        }

        /// <summary>
        /// Ensure the default profile directory exists
        /// </summary>
        public static void EnsureDefaultProfileDirectoryExists()
        {
            if (!AzureSession.DataStore.DirectoryExists(AzureSession.ProfileDirectory))
            {
                AzureSession.DataStore.CreateDirectory(AzureSession.ProfileDirectory);
            }
        }

        /// <summary>
        /// Clear the current storage account from the context - guarantees that only one storage account will be active 
        /// at a time.
        /// </summary>
        /// <param name="clearSMContext">Whether to clear the service management context.</param>
        public static void ClearCurrentStorageAccount(bool clearSMContext = false)
        {
            var RMProfile = AzureRmProfileProvider.Instance.Profile;
            if (RMProfile != null && RMProfile.Context != null &&
                RMProfile.Context.Subscription != null && RMProfile.Context.Subscription.IsPropertySet(AzureSubscription.Property.StorageAccount))
            {
                RMProfile.Context.Subscription.SetProperty(AzureSubscription.Property.StorageAccount, null);
            }

            if (clearSMContext)
            {
                var SMProfile = AzureSMProfileProvider.Instance.Profile;
                if (SMProfile != null && SMProfile.Context != null && SMProfile.Context.Subscription != null &&
                    SMProfile.Context.Subscription.IsPropertySet(AzureSubscription.Property.StorageAccount))
                {
                    SMProfile.Context.Subscription.SetProperty(AzureSubscription.Property.StorageAccount, null);
                }
            }
        }
    }
}