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
using System.Data.Services.Client;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.ServiceModel;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Properties;
using Microsoft.Azure.Common;
using Hyak.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common
{
    /// <summary>
    /// The handler for all Sql Database exceptions.
    /// </summary>
    public static class SqlDatabaseExceptionHandler
    {
        /// <summary>
        /// Process the exception that was thrown and write the error details.
        /// </summary>
        /// <param name="cmdlet">The cmdlet for which to write the error output.</param>
        /// <param name="clientRequestId">The unique id for this request.</param>
        /// <param name="exception">The exception that was thrown.</param>
        public static void WriteErrorDetails(
            Cmdlet cmdlet,
            string clientRequestId,
            Exception exception)
        {
            string requestId;
            ErrorRecord errorRecord = RetrieveExceptionDetails(exception, out requestId);

            // Write the request Id as a warning
            if (requestId != null)
            {
                // requestId was availiable from the server response, write that as warning to the
                // console.
                cmdlet.WriteWarning(string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.ExceptionRequestId,
                    requestId));
            }
            else
            {
                // requestId was not availiable from the server response, write the client Ids that
                // was sent.
                cmdlet.WriteWarning(string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.ExceptionClientSessionId,
                    SqlDatabaseCmdletBase.clientSessionId));
                cmdlet.WriteWarning(string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.ExceptionClientRequestId,
                    clientRequestId));
            }

            // Write the actual errorRecord containing the exception details
            cmdlet.WriteError(errorRecord);
        }

        /// <summary>
        /// Retrieves the exception details contained in the exception and wrap it in a PowerShell <see cref="ErrorRecord"/>.
        /// </summary>
        /// <param name="exception">The exception containing the error details.</param>
        /// <param name="errorRecord">An output parameter for the error record containing the error details.</param>
        /// <param name="requestId">An output parameter for the request Id present in the reponse headers.</param>
        internal static ErrorRecord RetrieveExceptionDetails(
            Exception exception,
            out string requestId)
        {
            ErrorRecord errorRecord = null;
            requestId = null;

            // Look for known exceptions through the exceptions and inner exceptions
            Exception innerException = exception;
            while (innerException != null)
            {
                CloudException cloudException = innerException as CloudException;
                if (cloudException != null)
                {
                    errorRecord = cloudException.AsErrorRecord(out requestId);
                    break;
                }
                
                DataServiceRequestException dataServiceRequestException = innerException as DataServiceRequestException;
                if (dataServiceRequestException != null)
                {
                    errorRecord = dataServiceRequestException.AsErrorRecord();
                    break;
                }

                DataServiceClientException dataServiceClientException = innerException as DataServiceClientException;
                if (dataServiceClientException != null)
                {
                    errorRecord = dataServiceClientException.AsErrorRecord();
                    break;
                }

                WebException webException = innerException as WebException;
                if (webException != null)
                {
                    errorRecord = webException.AsErrorRecord(out requestId);
                    break;
                }

                innerException = innerException.InnerException;
            }

            // If it's here, it was an unknown exception, wrap the original exception as is.
            if (errorRecord == null)
            {
                errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.NotSpecified, null);
            }

            return errorRecord;
        }

        /// <summary>
        /// Process a <see cref="DataServiceRequestException"/> and converts it to a PowerShell
        /// <see cref="ErrorRecord"/>, or <c>null</c> if that is not availaible.
        /// </summary>
        /// <param name="ex">The <see cref="DataServiceRequestException"/> that was thrown.</param>
        private static ErrorRecord AsErrorRecord(this DataServiceRequestException ex)
        {
            ErrorRecord errorRecord = null;
            Exception exceptionToThrow = ex;

            // Look for Sql exception message in response, return that message if found.
            foreach (ChangeOperationResponse change in ex.Response)
            {
                // Try to parse the extended properties in the Exception
                ManagementServiceExceptionInfo info;
                if (ManagementServiceExceptionInfo.TryParse(change, out info))
                {
                    if (info.PropertyBag.Contains(DataServiceConstants.SqlMessageTextKey))
                    {
                        // Set the exception to throw as a new exception with the server message
                        string errorDetails =
                            info.PropertyBag[DataServiceConstants.SqlMessageTextKey].ToString();

                        errorRecord = new ErrorRecord(
                            new CommunicationException(errorDetails, ex),
                            string.Empty,
                            ErrorCategory.InvalidOperation,
                            null);
                        break;
                    }
                }
            }

            // Fall back to use the message in the message element if availiable
            if (errorRecord == null)
            {
                foreach (ChangeOperationResponse change in ex.Response)
                {
                    try
                    {
                        XElement errorRoot = XElement.Parse(change.Error.Message);
                        XElement messageElement = errorRoot.Descendants().Single(x => string.Equals(x.Name.LocalName, "message", StringComparison.OrdinalIgnoreCase));

                        errorRecord = new ErrorRecord(
                            new CommunicationException(messageElement.Value, ex),
                            string.Empty,
                            ErrorCategory.InvalidOperation,
                            null);
                        break;
                    }
                    catch (Exception)
                    {
                        // we hide any parsing error that might have happened because there is no need to expose 
                        // additional errors
                    }
                }
            }

            // Return the resulting error record
            return errorRecord;
        }

        /// <summary>
        /// Process a <see cref="DataServiceClientException"/> and converts it to a PowerShell
        /// <see cref="ErrorRecord"/>, or <c>null</c> if that is not availaible.
        /// </summary>
        /// <param name="ex">The <see cref="DataServiceClientException"/> that was thrown.</param>
        private static ErrorRecord AsErrorRecord(this DataServiceClientException ex)
        {
            ErrorRecord errorRecord = null;

            // Attempt to parse OData message or custom web services message
            try
            {
                XElement errorRoot = XElement.Parse(ex.Message);
                XElement messageElement = errorRoot.Descendants().Where(x => string.Equals(x.Name.LocalName, "Message", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                errorRecord = new ErrorRecord(
                    new CommunicationException(messageElement.Value, ex),
                    string.Empty,
                    ErrorCategory.InvalidOperation,
                    null);
            }
            catch (Exception)
            {
                // we hide any parsing error that might have happened because there is no need to expose 
                // additional errors
            }

            // Return the resulting error record
            return errorRecord;
        }

        /// <summary>
        /// Process a <see cref="WebException"/> and converts it to a PowerShell
        /// <see cref="ErrorRecord"/>, or <c>null</c> if that is not availaible.
        /// </summary>
        /// <param name="ex">The <see cref="WebException"/> that was thrown.</param>
        /// <param name="requestId">The request Id from the response, if it's availiable.</param>
        /// <returns>An <see cref="ErrorRecord"/> containing the exception details,
        /// or <c>null</c> if the exception cannot be parsed.</returns>
        private static ErrorRecord AsErrorRecord(
            this WebException ex,
            out string requestId)
        {
            ErrorRecord errorRecord = null;
            requestId = null;

            if (ex.Response != null)
            {
                HttpWebResponse response = ex.Response as HttpWebResponse;

                // Extract the request Ids
                if (response.Headers != null)
                {
                    requestId = response.Headers[Constants.RequestIdHeaderName];
                }

                // Retrieve the full exception response
                Stream responseStream = response.GetResponseStream();
                string exceptionResponse;
                using (StreamReader responseReader = new StreamReader(responseStream))
                {
                    exceptionResponse = responseReader.ReadToEnd();
                }

                // Check if it's a service resource error message
                ServiceResourceError serviceResourceError;
                if (errorRecord == null &&
                    ServiceResourceError.TryParse(exceptionResponse, out serviceResourceError))
                {
                    errorRecord = new ErrorRecord(
                        new CommunicationException(serviceResourceError.Message, ex),
                        string.Empty,
                        ErrorCategory.InvalidOperation,
                        null);
                }

                // Check if it's a management service error message
                ManagementServiceExceptionInfo info;
                if (errorRecord == null &&
                    ManagementServiceExceptionInfo.TryParse(exceptionResponse, out info))
                {
                    if (info.PropertyBag.Contains(DataServiceConstants.SqlMessageTextKey))
                    {
                        // Set the exception to throw as a new exception with the server message
                        string errorDetails =
                            info.PropertyBag[DataServiceConstants.SqlMessageTextKey].ToString();

                        errorRecord = new ErrorRecord(
                            new CommunicationException(errorDetails, ex),
                            string.Empty,
                            ErrorCategory.InvalidOperation,
                            null);
                    }
                }

                // Check if it's a database management error message
                SqlDatabaseManagementError databaseManagementError;
                if (errorRecord == null &&
                    SqlDatabaseManagementError.TryParse(exceptionResponse, out databaseManagementError))
                {
                    string errorDetails = string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.DatabaseManagementErrorFormat,
                        databaseManagementError.Code,
                        databaseManagementError.Message);

                    errorRecord = new ErrorRecord(
                        new CommunicationException(errorDetails, ex),
                        string.Empty,
                        ErrorCategory.InvalidOperation,
                        null);
                }

                // Check if it's a not found message
                if (errorRecord == null &&
                    response.StatusCode == HttpStatusCode.NotFound)
                {
                    string message = string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.UriDoesNotExist,
                        response.ResponseUri.AbsoluteUri);
                    string errorDetails = string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.DatabaseManagementErrorFormat,
                        response.StatusCode.ToString(),
                        message);

                    errorRecord = new ErrorRecord(
                        new CommunicationException(errorDetails, ex),
                        string.Empty,
                        ErrorCategory.InvalidOperation,
                        null);
                }
            }

            // Return the resulting error record
            return errorRecord;
        }

        /// <summary>
        /// Process a <see cref="CloudException"/> and converts it to a PowerShell
        /// <see cref="ErrorRecord"/>, or <c>null</c> if that is not availaible.
        /// </summary>
        /// <param name="ex">The <see cref="WebException"/> that was thrown.</param>
        /// <param name="requestId">The request Id from the response, if it's availiable.</param>
        /// <returns>An <see cref="ErrorRecord"/> containing the exception details,
        /// or <c>null</c> if the exception cannot be parsed.</returns>
        private static ErrorRecord AsErrorRecord(
            this CloudException ex,
            out string requestId)
        {
            ErrorRecord errorRecord = null;
            requestId = null;

            if (ex.Response != null)
            {
                CloudHttpResponseErrorInfo response = ex.Response;

                // Extract the request Ids
                if (response.Headers != null && 
                    response.Headers.ContainsKey(Constants.RequestIdHeaderName))
                {
                    requestId = response.Headers[Constants.RequestIdHeaderName].First();
                }

                // Check if it's a service resource error message
                ServiceResourceError serviceResourceError;
                if (errorRecord == null &&
                    ServiceResourceError.TryParse(response.Content, out serviceResourceError))
                {
                    errorRecord = new ErrorRecord(
                        new CommunicationException(serviceResourceError.Message, ex),
                        string.Empty,
                        ErrorCategory.InvalidOperation,
                        null);
                }

                // Check if it's a management service error message
                ManagementServiceExceptionInfo info;
                if (errorRecord == null &&
                    ManagementServiceExceptionInfo.TryParse(response.Content, out info))
                {
                    if (info.PropertyBag.Contains(DataServiceConstants.SqlMessageTextKey))
                    {
                        // Set the exception to throw as a new exception with the server message
                        string errorDetails =
                            info.PropertyBag[DataServiceConstants.SqlMessageTextKey].ToString();

                        errorRecord = new ErrorRecord(
                            new CommunicationException(errorDetails, ex),
                            string.Empty,
                            ErrorCategory.InvalidOperation,
                            null);
                    }
                }

                // Check if it's a database management error message
                SqlDatabaseManagementError databaseManagementError;
                if (errorRecord == null &&
                    SqlDatabaseManagementError.TryParse(response.Content, out databaseManagementError))
                {
                    string errorDetails = string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.DatabaseManagementErrorFormat,
                        databaseManagementError.Code,
                        databaseManagementError.Message);

                    errorRecord = new ErrorRecord(
                        new CommunicationException(errorDetails, ex),
                        string.Empty,
                        ErrorCategory.InvalidOperation,
                        null);
                }

                // Check if it's a not found message
                if (errorRecord == null &&
                    response.StatusCode == HttpStatusCode.NotFound)
                {
                    string message = string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.UriDoesNotExist,
                        ex.Request.RequestUri.AbsoluteUri);
                    string errorDetails = string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.DatabaseManagementErrorFormat,
                        response.StatusCode.ToString(),
                        message);

                    errorRecord = new ErrorRecord(
                        new CommunicationException(errorDetails, ex),
                        string.Empty,
                        ErrorCategory.InvalidOperation,
                        null);
                }
            }

            // Return the resulting error record
            return errorRecord;
        }
    }
}
