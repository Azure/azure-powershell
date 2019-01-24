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

using Microsoft.Azure.Commands.StreamAnalytics.Properties;
using Microsoft.Rest.Azure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.Azure.Commands.StreamAnalytics
{
    internal static class CloudExceptionExtensions
    {
        public static CloudException CreateFormattedException(this CloudException cloudException)
        {
            JObject errorResponse = JObject.Parse(cloudException.Response.Content);
            return new CloudException(
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.FormattedCloudExceptionMessageTemplate,
                    cloudException.Response.StatusCode,
                    cloudException.Body == null ? errorResponse["code"] : cloudException.Body.Code,
                    cloudException.Body == null ? errorResponse["message"] : cloudException.Body.Message,
                    cloudException.GetRequestId(),
                    DateTime.UtcNow));
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
    }
}