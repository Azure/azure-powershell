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
using System.IO;
using System.Linq;
using System.Net.Http;
using Microsoft.Azure.Commands.TestFx.Recorder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    /// <summary>
    /// Matches a recorded request by method and URL, like the default matcher, and also by the JSON body of POST,
    /// PUT and PATCH requests. In playback, a cmdlet that sends a different body than the recorded one then fails
    /// with "Unable to find a matching HTTP request" instead of passing.
    /// </summary>
    public class BatchRecordMatcher : PermissiveRecordMatcherWithApiExclusion
    {
        private static readonly HashSet<string> MethodsWithBody = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "POST", "PUT", "PATCH" };

        public BatchRecordMatcher(bool ignoreResourcesClient, Dictionary<string, string> providers, Dictionary<string, string> userAgents)
            : base(ignoreResourcesClient, providers, userAgents)
        {
        }

        public override string GetMatchingKey(HttpRequestMessage request)
        {
            // Same formatting and secret masking the recorder applies before it saves a request body.
            string body = request.Content == null ? null : RecorderUtilities.FormatHttpContent(request.Content);
            return WithBody(base.GetMatchingKey(request), request.Method.Method, body);
        }

        public override string GetMatchingKey(RecordEntry recordEntry)
        {
            return WithBody(base.GetMatchingKey(recordEntry), recordEntry.RequestMethod, recordEntry.RequestBody);
        }

        internal static string WithBody(string key, string method, string body)
        {
            if (!MethodsWithBody.Contains(method))
            {
                return key;
            }

            string normalized = NormalizeJson(body);
            return normalized == null ? key : key + " body:" + normalized;
        }

        /// <summary>
        /// The body as one-line JSON with object properties in name order, lists of named items in name order and
        /// dates in UTC, or null if the body isn't a JSON object or array. Empty lists, nulls and missing properties
        /// stay different.
        /// </summary>
        internal static string NormalizeJson(string body)
        {
            if (string.IsNullOrWhiteSpace(body))
            {
                return null;
            }

            string trimmed = body.TrimStart();
            if (!trimmed.StartsWith("{") && !trimmed.StartsWith("["))
            {
                return null;
            }

            try
            {
                using (var reader = new JsonTextReader(new StringReader(body)) { DateParseHandling = DateParseHandling.DateTimeOffset })
                {
                    return Normalize(JToken.ReadFrom(reader)).ToString(Formatting.None);
                }
            }
            catch (JsonReaderException)
            {
                return null;
            }
        }

        private static JToken Normalize(JToken token)
        {
            switch (token)
            {
                case JObject obj:
                    return new JObject(obj.Properties()
                        .OrderBy(p => p.Name, StringComparer.Ordinal)
                        .Select(p => new JProperty(p.Name, Normalize(p.Value))));
                case JArray array:
                    var items = array.Select(Normalize).ToList();
                    // Lists made from PowerShell hashtables (environment settings, metadata) have no fixed order.
                    if (items.Count > 1 && items.All(i => i is JObject o && o["name"]?.Type == JTokenType.String))
                    {
                        items = items
                            .OrderBy(i => (string)i["name"], StringComparer.Ordinal)
                            .ThenBy(i => i.ToString(Formatting.None), StringComparer.Ordinal)
                            .ToList();
                    }

                    return new JArray(items);
                case JValue value when value.Value is DateTimeOffset date:
                    return new JValue(date.UtcDateTime.ToString("o", CultureInfo.InvariantCulture));
                default:
                    return token.DeepClone();
            }
        }
    }
}