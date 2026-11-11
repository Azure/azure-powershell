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

using Azure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace Microsoft.Azure.Commands.Batch.Track2
{
    /// <summary>
    /// Reads values from the service's answer as it was sent, for values Azure.Compute.Batch 1.0.0 can't keep: it reads
    /// 16 statistics as float, which keeps about 7 digits (2.123456789 becomes 2.1234567), where Track 1 read double.
    /// The values: the 9 pool resource statistics, the read and write GiB of job, job schedule and task statistics, and
    /// the total core hours of pool usage metrics.
    /// </summary>
    internal static class Track2RawJson
    {
        /// <summary>The JSON of an answer, or null when it has none.</summary>
        internal static JsonElement? Of(Response response)
        {
            if (response == null)
            {
                return null;
            }

            try
            {
                using (JsonDocument document = JsonDocument.Parse(response.Content.ToMemory()))
                {
                    return document.RootElement.Clone();
                }
            }
            catch (Exception e) when (e is JsonException || e is InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Each item of a list with its JSON, page by page as the pages arrive, so -MaxCount still stops the paging early.
        /// </summary>
        internal static IEnumerable<KeyValuePair<T, JsonElement?>> WithJson<T>(Pageable<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            return Iterate(items);
        }

        /// <summary>The number at the path of property names, as the service sent it; null when it isn't there.</summary>
        internal static double? GetDouble(JsonElement? json, params string[] path)
        {
            if (json == null)
            {
                return null;
            }

            JsonElement current = json.Value;
            foreach (string name in path)
            {
                if (current.ValueKind != JsonValueKind.Object || !current.TryGetProperty(name, out current))
                {
                    return null;
                }
            }

            switch (current.ValueKind)
            {
                case JsonValueKind.Number:
                    return current.GetDouble();
                case JsonValueKind.String:
                    return double.TryParse(current.GetString(), NumberStyles.Float, CultureInfo.InvariantCulture, out double value) ? value : (double?)null;
                default:
                    return null;
            }
        }

        private static IEnumerable<KeyValuePair<T, JsonElement?>> Iterate<T>(Pageable<T> items)
        {
            foreach (Page<T> page in items.AsPages())
            {
                JsonElement? answer = Of(page.GetRawResponse());
                JsonElement values = default(JsonElement);
                bool hasValues = answer.HasValue && answer.Value.ValueKind == JsonValueKind.Object
                    && answer.Value.TryGetProperty("value", out values) && values.ValueKind == JsonValueKind.Array
                    && values.GetArrayLength() == page.Values.Count;
                for (int i = 0; i < page.Values.Count; i++)
                {
                    yield return new KeyValuePair<T, JsonElement?>(page.Values[i], hasValues ? values[i] : (JsonElement?)null);
                }
            }
        }
    }
}
