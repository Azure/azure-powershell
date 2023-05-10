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

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Microsoft.Azure.Commands.TestFx.Recorder
{
    public class RecordEntry
    {
        public string RequestUri { get; set; }

        public string EncodedRequestUri { get; set; }

        public string RequestMethod { get; set; }

        [JsonIgnore]
        public RecordEntryContentType RequestContentType { get; set; }

        public Dictionary<string, List<string>> RequestHeaders { get; set; }

        public string RequestBody { get; set; }

        [JsonIgnore]
        public RecordEntryContentType ResponseContentType { get; set; }

        public Dictionary<string, List<string>> ResponseHeaders { get; set; }

        public string ResponseBody { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public RecordEntry()
        {

        }

        public RecordEntry(RecordEntry record) : this(record.GetResponse())
        {

        }

        public RecordEntry(HttpResponseMessage response)
        {
            HttpRequestMessage request = response.RequestMessage;
            RequestUri = request.RequestUri.ToString();
            EncodedRequestUri = RecorderUtilities.EncodeUriAsBase64(request.RequestUri);
            RequestMethod = request.Method.Method;

            RequestHeaders = new Dictionary<string, List<string>>();
            ResponseHeaders = new Dictionary<string, List<string>>();

            RequestBody = string.Empty;
            ResponseBody = string.Empty;

            RequestContentType = DetectContentType(request.Content);
            ResponseContentType = DetectContentType(response.Content);

            request.Headers.ForEach(h => RequestHeaders.Add(h.Key, h.Value.ToList()));
            response.Headers.ForEach(h => ResponseHeaders.Add(h.Key, h.Value.ToList()));

            StatusCode = response.StatusCode;

            if (RequestContentType != RecordEntryContentType.Null)
            {
                RequestBody = RecorderUtilities.FormatHttpContent(request.Content);
                request.Content.Headers.ForEach(h => RequestHeaders.Add(h.Key, h.Value.ToList()));
            }

            if (ResponseContentType != RecordEntryContentType.Null)
            {
                ResponseBody = RecorderUtilities.FormatHttpContent(response.Content);
                response.Content.Headers.ForEach(h => ResponseHeaders.Add(h.Key, h.Value.ToList()));
            }
        }

        public HttpResponseMessage GetResponse()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = StatusCode;
            ResponseHeaders.ForEach(h => response.Headers.TryAddWithoutValidation(h.Key, h.Value));
            ResponseContentType = RecorderUtilities.GetContetTypeFromHeaders(ResponseHeaders);
            response.Content = RecorderUtilities.CreateHttpContent(ResponseBody, ResponseContentType);
            ResponseHeaders.ForEach(h => response.Content.Headers.TryAddWithoutValidation(h.Key, h.Value));
            return response;
        }

        private RecordEntryContentType DetectContentType(HttpContent content)
        {
            RecordEntryContentType contentType = RecordEntryContentType.Null;

            if (content != null)
            {
                if (RecorderUtilities.IsHttpContentBinary(content))
                {
                    contentType = RecordEntryContentType.Binary;
                }
                else
                {
                    contentType = RecordEntryContentType.Ascii;
                }
            }

            return contentType;
        }
    }

    /// <summary>
    /// Request/Response content type enum
    /// </summary>
    public enum RecordEntryContentType
    {
        Binary,
        Ascii,
        Null
    }
}
