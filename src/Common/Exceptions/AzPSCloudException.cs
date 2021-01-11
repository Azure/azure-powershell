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
using System.Runtime.CompilerServices;

using Microsoft.Rest;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Common.Exceptions
{
    public class AzPSCloudException : Exception, IContainsAzPSErrorData
    {
        private HttpResponseMessageWrapper httpResponseMessageWrapper;

        public HttpRequestMessageWrapper Request { get; set; }

        /// <summary>
        /// Gets information about the associated HTTP response.
        /// </summary>
        public HttpResponseMessageWrapper Response
        {
            get { return httpResponseMessageWrapper; }
            set
            {
                httpResponseMessageWrapper = value;
                HttpStatusCode = (int?)httpResponseMessageWrapper?.StatusCode;
            }
        }

        /// <summary>
        /// Gets or sets the response object.
        /// </summary>
        public CloudError Body { get; set; }

        /// <summary>
        /// Gets or sets the value that uniquely identifies a request 
        /// made against the service.
        /// </summary>
        public string RequestId { get; set; }

        public ErrorKind ErrorKind
        {
            get => Data.GetValue<ErrorKind>(AzurePSErrorDataKeys.ErrorKindKey);
            private set => Data.SetValue(AzurePSErrorDataKeys.ErrorKindKey, value);
        }

        public string DesensitizedErrorMessage
        {
            get => Data.GetValue<string>(AzurePSErrorDataKeys.DesensitizedErrorMessageKey);
            private set => Data.SetValue(AzurePSErrorDataKeys.DesensitizedErrorMessageKey, value);
        }

        public int? ErrorLineNumber
        {
            get => Data.GetNullableValue<int>(AzurePSErrorDataKeys.ErrorLineNumberKey);
            private set => Data.SetValue(AzurePSErrorDataKeys.ErrorLineNumberKey, value);
        }

        public string ErrorFileName
        {
            get => Data.GetValue<string>(AzurePSErrorDataKeys.ErrorFileNameKey);
            private set => Data.SetValue(AzurePSErrorDataKeys.ErrorFileNameKey, value);
        }

        public int? HttpStatusCode
        {
            get => Data.GetNullableValue<int>(AzurePSErrorDataKeys.HttpStatusCode);
            private set => Data.SetValue(AzurePSErrorDataKeys.HttpStatusCode, value);
        }

        public AzPSCloudException(
            string message,
            string desensitizedMessage = null,
            Exception innerException = null,
            [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = null)
            :this(message, ErrorKind.ServiceError, desensitizedMessage, innerException, lineNumber, filePath)
        {
        }

        public AzPSCloudException(
            string message,
            ErrorKind errorKind,
            string desensitizedMessage = null,
            Exception innerException = null,
            [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = null)
            : base(message, innerException)
        {
            ErrorKind = errorKind;
            DesensitizedErrorMessage = desensitizedMessage;
            ErrorLineNumber = lineNumber;
            if (!string.IsNullOrEmpty(filePath))
            {
                ErrorFileName = Path.GetFileNameWithoutExtension(filePath);
            }
        }
    }
}
