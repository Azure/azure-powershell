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
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services;
using Microsoft.WindowsAzure.Management.MediaServices;
using Microsoft.WindowsAzure.Management.MediaServices.Models;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Newtonsoft.Json;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.Utilities.MediaServices
{
    /// <summary>
    ///     Implements IMediaServicesClient to use HttpClient for communication
    /// </summary>
    public class MediaServicesClient : IMediaServicesClient
    {
        public const string MediaServiceVersion = "2013-03-01";
        private readonly IStorageManagementClient _storageClient;
        public IMediaServicesManagementClient _mediaServicesManagementClient;

        /// <summary>
        ///     Creates new MediaServicesClient.
        /// </summary>
        /// <param name="logger">The logger action</param>
        /// <param name="mediaServicesManagementClient"></param>
        /// <param name="storageClient"></param>
        public MediaServicesClient(Action<string> logger, IMediaServicesManagementClient mediaServicesManagementClient, IStorageManagementClient storageClient)
        {
            
            Logger = logger;
            _storageClient = storageClient;
            _mediaServicesManagementClient = mediaServicesManagementClient;

        }

        /// <summary>
        ///     Creates new MediaServicesClient.
        /// </summary>
        /// <param name="subscription">The Microsoft Azure subscription data object</param>
        /// <param name="logger">The logger action</param>
        public MediaServicesClient(AzureSMProfile profile, AzureSubscription subscription, Action<string> logger)
            : this(
            logger,
            AzureSession.ClientFactory.CreateClient<MediaServicesManagementClient>(profile, subscription, AzureEnvironment.Endpoint.ServiceManagement),
            AzureSession.ClientFactory.CreateClient<StorageManagementClient>(profile, subscription, AzureEnvironment.Endpoint.ServiceManagement))
        {
        }

        


        /// <summary>
        ///     Gets or sets the subscription.
        /// </summary>
        /// <value>
        ///     The subscription.
        /// </value>
        public AzureSubscription Subscription { get; set; }

        /// <summary>
        ///     Gets or sets the logger
        /// </summary>
        /// <value>
        ///     The logger.
        /// </value>
        public Action<string> Logger { get; set; }


        /// <summary>
        ///     Gets the media service accounts async.
        /// </summary>
        /// <returns></returns>
        public Task<MediaServicesAccountListResponse> GetMediaServiceAccountsAsync()
        {
            return _mediaServicesManagementClient.Accounts.ListAsync();
        }


        /// <summary>
        ///     Gets the storage service key.
        /// </summary>
        /// <param name="storageAccountName">Name of the storage account.</param>
        /// <returns></returns>
        public Task<StorageAccountGetKeysResponse> GetStorageServiceKeysAsync(string storageAccountName)
        {
            return _storageClient.StorageAccounts.GetKeysAsync(storageAccountName);
        }

        /// <summary>
        ///     Gets the storage service properties.
        /// </summary>
        /// <param name="storageAccountName">Name of the storage account.</param>
        /// <returns></returns>
        public Task<StorageAccountGetResponse> GetStorageServicePropertiesAsync(string storageAccountName)
        {
            return _storageClient.StorageAccounts.GetAsync(storageAccountName);
        }

        /// <summary>
        ///     Gets the media service account details async.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Task<MediaServicesAccountGetResponse> GetMediaServiceAsync(string name)
        {
            
            return _mediaServicesManagementClient.Accounts.GetAsync(name);
        }

        /// <summary>
        ///     Create new azure media service async.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public Task<MediaServicesAccountCreateResponse> CreateNewAzureMediaServiceAsync(MediaServicesAccountCreateParameters request)
        {
            return _mediaServicesManagementClient.Accounts.CreateAsync(request);
        }

        /// <summary>
        ///     Deletes azure media service account async.
        /// </summary>
        /// <returns></returns>
        public Task<AzureOperationResponse> DeleteAzureMediaServiceAccountAsync(string name)
        {
            return _mediaServicesManagementClient.Accounts.DeleteAsync(name);
        }

        /// <summary>
        ///     Deletes azure media service account async.
        /// </summary>
        public Task<AzureOperationResponse> RegenerateMediaServicesAccountAsync(string name, MediaServicesKeyType keyType)
        {
            return _mediaServicesManagementClient.Accounts.RegenerateKeyAsync(name, keyType);
        }

        /// <summary>
        ///     Processes the response and handle error cases.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="responseMessage">The response message.</param>
        /// <returns></returns>
        private static T ProcessJsonResponse<T>(Task<HttpResponseMessage> responseMessage)
        {
            HttpResponseMessage message = responseMessage.Result;
            if (typeof (T) == typeof (bool) && message.IsSuccessStatusCode)
            {
                return (T) (object) true;
            }

            string content = message.Content.ReadAsStringAsync().Result;

            if (message.IsSuccessStatusCode)
            {
                return (T) JsonConvert.DeserializeObject(content, typeof (T));
            }

            throw CreateExceptionFromJson(message.StatusCode, content);
        }

        private static T ProcessXmlResponse<T>(Task<HttpResponseMessage> responseMessage)
        {
            HttpResponseMessage message = responseMessage.Result;
            string content = message.Content.ReadAsStringAsync().Result;
            Encoding encoding = GetEncodingFromResponseMessage(message);

            if (message.IsSuccessStatusCode)
            {
                var ser = new DataContractSerializer(typeof (T));
                using (var stream = new MemoryStream(encoding.GetBytes(content)))
                {
                    stream.Position = 0;
                    XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());
                    return (T) ser.ReadObject(reader, true);
                }
            }

            throw CreateExceptionFromXml(content, message);
        }

        private static Encoding GetEncodingFromResponseMessage(HttpResponseMessage message)
        {
            string encodingString = message.Content.Headers.ContentType.CharSet;
            Encoding encoding = Encoding.GetEncoding(encodingString);
            return encoding;
        }

        private static ServiceManagementClientException CreateExceptionFromXml(string content, HttpResponseMessage message)
        {
            Encoding encoding = GetEncodingFromResponseMessage(message);

            using (var stream = new MemoryStream(encoding.GetBytes(content)))
            {
                stream.Position = 0;
                var serializer = new XmlSerializer(typeof (ServiceError));
                var serviceError = (ServiceError) serializer.Deserialize(stream);
                return new ServiceManagementClientException(message.StatusCode,
                    new ServiceManagementError
                    {
                        Code = message.StatusCode.ToString(),
                        Message = serviceError.Message
                    },
                    string.Empty);
            }
        }

        /// <summary>
        ///     Unwraps error message and creates ServiceManagementClientException.
        /// </summary>
        private static ServiceManagementClientException CreateExceptionFromJson(HttpStatusCode statusCode, string content)
        {
            var doc = new XmlDocument();
            doc.LoadXml(content);
            content = doc.InnerText;
            var serviceError = JsonConvert.DeserializeObject(content, typeof (ServiceError)) as ServiceError;
            var exception = new ServiceManagementClientException(statusCode,
                new ServiceManagementError
                {
                    Code = statusCode.ToString(),
                    Message = serviceError.Message
                },
                string.Empty);
            return exception;
        }

     
    }
}