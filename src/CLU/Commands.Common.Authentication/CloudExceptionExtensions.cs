//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Rest;
using System.Linq;

namespace Microsoft.Azure.Commands.Common
{
    public static class HttpOperationExceptionExtensions
    {
        public static string GetRequestId(this HttpOperationException exception)
        {
            if(exception == null || 
               exception.Response == null || 
               exception.Response.Headers == null ||
               !exception.Response.Headers.Any(
                    s => s.Key.Equals("x-ms-request-id", System.StringComparison.OrdinalIgnoreCase)))
            {
                
                return null;
            }

            return exception.Response.Headers
                    .First(s => s.Key.Equals("x-ms-request-id", System.StringComparison.OrdinalIgnoreCase))
                    .Value
                    .FirstOrDefault();
        }
        public static string GetRoutingRequestId(this HttpOperationException exception)
        {
            if (exception == null ||
               exception.Response == null ||
               exception.Response.Headers == null ||
                !exception.Response.Headers.Any(
                    s => s.Key.Equals("x-ms-routing-request-id", System.StringComparison.OrdinalIgnoreCase)))
            {
                return null;
            }

            return exception.Response.Headers
                  .First(s => s.Key.Equals("x-ms-routing-request-id", System.StringComparison.OrdinalIgnoreCase))
                  .Value
                  .FirstOrDefault();
        }
    }
}
