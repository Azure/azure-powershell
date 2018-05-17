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

using Microsoft.Rest.TransientFaultHandling;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication.Factories
{
    public class AzureHttpRetryStrategy : ITransientErrorDetectionStrategy
    {
        public bool IsTransient(Exception ex)
        {
            if (ex != null)
            {
                HttpRequestWithStatusException httpException = ex as HttpRequestWithStatusException;
                if (httpException != null)
                {
                    if (httpException.StatusCode == HttpStatusCode.RequestTimeout ||
                        (httpException.StatusCode >= HttpStatusCode.InternalServerError &&
                         httpException.StatusCode != HttpStatusCode.NotImplemented &&
                         httpException.StatusCode != HttpStatusCode.HttpVersionNotSupported) || 
                         httpException.StatusCode == (HttpStatusCode)429)
                    {
                        return true;
                    }
                }

                if (ex is TaskCanceledException)
                {
                    Console.WriteLine("[Retrying]: !!! Retrying a TaskCanceled Exception !!!");
                    return true;
                }
            }

            return false;
        }
    }
}
