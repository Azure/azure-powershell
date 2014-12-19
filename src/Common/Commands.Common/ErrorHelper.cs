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

using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.Xml;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public class ErrorHelper
    {
        public static bool TryGetExceptionDetails(CommunicationException exception, out ServiceManagementError errorDetails, out string operationId)
        {
            HttpStatusCode httpStatusCode;
            return TryGetExceptionDetails(exception, out errorDetails, out httpStatusCode, out operationId);
        }

        public static bool TryGetExceptionDetails(CommunicationException exception, out ServiceManagementError errorDetails, out HttpStatusCode httpStatusCode, out string operationId)
        {
            errorDetails = null;
            httpStatusCode = 0;
            operationId = null;

            if (exception == null)
            {
                return false;
            }

            if (exception.Message == "Internal Server Error")
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
                return false;
            }

            WebException wex = exception.InnerException as WebException;

            if (wex == null)
            {
                return false;
            }

            HttpWebResponse response = wex.Response as HttpWebResponse;
            if (response == null)
            {
                return false;
            }

            if (response.Headers != null)
            {
                operationId = response.Headers[ApiConstants.OperationTrackingIdHeader];
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                errorDetails = new ServiceManagementError();
                errorDetails.Message = response.ResponseUri.AbsoluteUri + " does not exist.";
                errorDetails.Code = response.StatusCode.ToString();
                return false;
            }

            using (var s = response.GetResponseStream())
            {
                if (s == null || s.Length == 0)
                {
                    return false;
                }

                try
                {
                    errorDetails = new ServiceManagementError();
                    s.Seek(0, SeekOrigin.Begin);

                    var sr = new StreamReader(s);
                    using (var err = new StringReader(sr.ReadToEnd()))
                    {
                        var reader = XmlReader.Create(err);

                        while (reader.Read())
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element:
                                    {
                                        if (reader.Name == "Code")
                                        {
                                            reader.Read();
                                            errorDetails.Code = reader.Value;
                                        }
                                        else if (reader.Name == "Message")
                                        {
                                            reader.Read();
                                            errorDetails.Message = reader.Value;
                                        }

                                        break;
                                    }
                            }
                        }
                    }
                }
                catch
                {
                    errorDetails = null;
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// is not found communication exception
        /// </summary>
        /// <param name="exception">Communication Exception</param>
        /// <returns>true if exception caused by resource not found, otherwise, false</returns>
        public static bool IsNotFoundCommunicationException(CommunicationException exception)
        {
            ServiceManagementError error;
            string operationId;
            TryGetExceptionDetails(exception, out error, out operationId);
            return error != null && error.Code == HttpStatusCode.NotFound.ToString();
        }
    }
}