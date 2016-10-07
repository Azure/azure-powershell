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
using System.Linq;
using System.Net.Http.Headers;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    public static class HttpHeadersExtensions
    {
        public static Uri GetAzureAsyncOperationHeader(this HttpResponseHeaders headers)
        {
            var asyncHeader = headers.GetValues("Azure-AsyncOperation").FirstOrDefault();
            return new Uri(asyncHeader);
        }

        public static string GetAzureAsyncOperationId(this HttpResponseHeaders headers)
        {
            var asyncHeader = headers.GetAzureAsyncOperationHeader();
            return asyncHeader.Segments.Last();
        }

        public static Uri GetLocationHeader(this HttpResponseHeaders headers)
        {
            var asyncHeader = headers.GetValues("Location").FirstOrDefault();
            return new Uri(asyncHeader);
        }

        public static string GetOperationResultId(this HttpResponseHeaders headers)
        {
            var asyncHeader = headers.GetLocationHeader();
            return asyncHeader.Segments.Last();
        }
    }
}
