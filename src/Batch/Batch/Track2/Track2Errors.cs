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

using Microsoft.Azure.Batch.Common;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using BatchErrorException = Microsoft.Azure.Batch.Protocol.Models.BatchErrorException;
using HttpHeader = Azure.Core.HttpHeader;
using ProtocolBatchError = Microsoft.Azure.Batch.Protocol.Models.BatchError;
using RequestFailedException = Azure.RequestFailedException;
using Response = Azure.Response;

namespace Microsoft.Azure.Commands.Batch.Track2
{
    /// <summary>
    /// Turns a Track 2 (Azure.Compute.Batch) error into the BatchException that Track 1 (Microsoft.Azure.Batch 16.3.1)
    /// throws for the same answer from the service, so cmdlets show the same errors after they move to Track 2.
    /// </summary>
    internal static class Track2Errors
    {
        // Track 1 fills BatchException.RequestInformation only in this internal constructor, from its protocol-layer
        // error. Calling it gives the same values as Track 1 by construction.
        private static readonly ConstructorInfo BatchExceptionFromProtocolError = typeof(BatchException).GetConstructor(
            BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(BatchErrorException) }, null);

        // The settings Track 1's protocol layer reads error bodies with (BatchServiceClient.DeserializationSettings).
        private static readonly JsonSerializerSettings ErrorBodySettings = new JsonSerializerSettings
        {
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            ContractResolver = new ReadOnlyJsonContractResolver(),
            Converters = new List<JsonConverter> { new Iso8601TimeSpanConverter() }
        };

        /// <summary>
        /// Returns the BatchException Track 1 throws for the same answer, or null when there is no answer from the
        /// service (for example a network error) or it can't be converted; the caller then keeps the original error.
        /// </summary>
        internal static BatchException ToBatchException(RequestFailedException exception)
        {
            Response response = exception?.GetRawResponse();
            if (response == null || BatchExceptionFromProtocolError == null)
            {
                return null;
            }

            try
            {
                return FromResponse(response, exception);
            }
            catch (Exception e) when (e is TargetInvocationException || e is InvalidOperationException || e is FormatException)
            {
                // For example a body that wasn't read, or a client-request-id that isn't a GUID: keep the original
                // error rather than hide it.
                return null;
            }
        }

        private static BatchException FromResponse(Response response, RequestFailedException exception)
        {
            string content = response.Content.ToString();
            using (HttpResponseMessage httpResponse = new HttpResponseMessage((HttpStatusCode)response.Status))
            {
                httpResponse.ReasonPhrase = response.ReasonPhrase;
                foreach (HttpHeader header in response.Headers)
                {
                    httpResponse.Headers.TryAddWithoutValidation(header.Name, header.Value);
                }

                // The same steps as Track 1's protocol layer when the service returns an error.
                BatchErrorException protocolError = new BatchErrorException(
                    string.Format("Operation returned an invalid status code '{0}'", httpResponse.StatusCode), exception);
                ProtocolBatchError body = ReadErrorBody(content);
                if (body != null)
                {
                    protocolError.Body = body;
                }
                protocolError.Response = new HttpResponseMessageWrapper(httpResponse, content);

                return (BatchException)BatchExceptionFromProtocolError.Invoke(new object[] { protocolError });
            }
        }

        private static ProtocolBatchError ReadErrorBody(string content)
        {
            try
            {
                return SafeJsonConvert.DeserializeObject<ProtocolBatchError>(content, ErrorBodySettings);
            }
            catch (JsonException)
            {
                return null;
            }
        }
    }
}
