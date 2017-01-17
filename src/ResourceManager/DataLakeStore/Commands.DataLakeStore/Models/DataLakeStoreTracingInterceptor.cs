// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    public class DataLakeStoreTracingInterceptor : IServiceClientTracingInterceptor
    {
        public DataLakeStoreTraceLogger Logger;

        public DataLakeStoreTracingInterceptor(DataLakeStoreTraceLogger logger)
        {
            Logger = logger;
        }

        public void Information(string message)
        {
            Logger.LogInformation(message);
        }

        public void Configuration(string source, string name, string value)
        {
            Logger.LogDebug("Configure source={0} name={1} value={2}", source, name, value);
        }

        public void EnterMethod(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            Logger.LogDebug("Enter {0}.{1} parameters:{2}, invocationId={3}", instance, method, string.Join(";", parameters.Select(p => string.Format("{0}={1}", p.Key, p.Value))), invocationId);
        }

        public void SendRequest(string invocationId, HttpRequestMessage request)
        {
            Logger.LogDebug("{0}, invocationId={1}", request.ToLogMessage(), invocationId);
        }

        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            var message = "{0}, invocationId={1}";
            if (response.IsSuccessStatusCode)
            {
                Logger.LogDebug(string.Format(message, response.ToLogMessage(), invocationId));
            }
            else
            {
                Logger.LogError(string.Format(message, response.ToLogMessage(true), invocationId));
            }
        }

        public void TraceError(string invocationId, Exception exception)
        {
            var adlException = exception as AdlsErrorException;
            if (adlException == null)
            {
                Logger.LogError("exception ocurred: {0}, invocationId={1}", exception, invocationId);
            }
            else
            {
                Logger.LogError(string.Format("ADLS exception occured: {0}, with message: {1}, invocationId={1}"), adlException.Body.RemoteException, adlException.Body.RemoteException.Message, invocationId);
            }
        }

        public void ExitMethod(string invocationId, object returnValue)
        {
            Logger.LogDebug("Exit {0}, invocationId={1}", returnValue, invocationId);
        }
    }

    public static class Extension
    {
        public static string ToLogMessage(this HttpRequestMessage request)
        {
            return string.Format(
                "Send {0} request to {1}, headers:{2}",
                request.Method,
                request.RequestUri,
                string.Join(
                    ";",
                    request.Headers.Where(kv => kv.Key.StartsWith("x-ms-"))
                        .Select(h => string.Format("{0}:{1}", h.Key, string.Join(";", h.Value)))));
        }

        public static string ToLogMessage(this HttpResponseMessage response, bool getError = false)
        {
            return string.Format(
                "Received response for {0} {1} statusCode:{2}, headers:{3}{4}",
                response.RequestMessage.Method,
                response.RequestMessage.RequestUri,
                response.StatusCode,
                string.Join(
                    ";",
                    response.Headers.Where(kv => kv.Key.StartsWith("x-ms-"))
                        .Select(h => string.Format("{0}:{1}", h.Key, string.Join(";", h.Value)))),
                getError ? string.Format(", Error:{0}", response.Content.ReadAsStringAsync().Result) : string.Empty);
        }
    }
}
