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
using System.Globalization;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    internal static class ExceptionExtensions
    {
        public static ErrorResponseException CreateFormattedException(this ErrorResponseException errorResponseException)
        {
            return new ErrorResponseException(
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.FormattedCloudExceptionMessageTemplate,
                    errorResponseException.Response.StatusCode,
                    errorResponseException.Body != null && errorResponseException.Body.Code != null ? errorResponseException.Body.Code : errorResponseException.Response.StatusCode.ToString(),
                    errorResponseException.Body != null && errorResponseException.Body.Message != null ? errorResponseException.Body.Message : errorResponseException.Message,
                    errorResponseException.GetRequestId(),
                    DateTime.UtcNow));
        }

        public static CloudException CreateFormattedException(this CloudException cloudException)
        {
            return new CloudException(
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.FormattedCloudExceptionMessageTemplate,
                    cloudException.Response.StatusCode,
                    cloudException.Body != null && cloudException.Body.Code != null ? cloudException.Body.Code : cloudException.Response.StatusCode.ToString(),
                    cloudException.Body != null && cloudException.Body.Message != null ? cloudException.Body.Message : cloudException.Message,
                    cloudException.GetRequestId(),
                    DateTime.UtcNow));
        }

        public static string GetRequestId(this ErrorResponseException exception)
        {
            IEnumerable<string> strings;

            if (exception.Response != null
                && exception.Response.Headers != null
                && exception.Response.Headers.TryGetValue("x-ms-request-id", out strings))
            {
                return string.Join(";", strings);
            }

            return string.Empty;
        }

        public static string GetRequestId(this CloudException exception)
        {
            IEnumerable<string> strings;

            if (exception.Response != null
                && exception.Response.Headers != null
                && exception.Response.Headers.TryGetValue("x-ms-request-id", out strings))
            {
                return string.Join(";", strings);
            }

            return string.Empty;
        }

        public static ArgumentOutOfRangeException CreateFormattedException(this ArgumentOutOfRangeException exception)
        {
            return new ArgumentOutOfRangeException(
                exception.ParamName,
                exception.ActualValue,
                string.Format(CultureInfo.InvariantCulture,
                    Resources.FormattedArgumentOutOfRangeExceptionMessageTemplate,
                    exception.Message));
        }
    }
}