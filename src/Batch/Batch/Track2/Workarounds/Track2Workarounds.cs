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
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using JObject = Newtonsoft.Json.Linq.JObject;
using JsonConvert = Newtonsoft.Json.JsonConvert;
using JsonDocument = System.Text.Json.JsonDocument;
using JsonValueKind = System.Text.Json.JsonValueKind;
using JTokenType = Newtonsoft.Json.Linq.JTokenType;
using NewtonsoftFormatting = Newtonsoft.Json.Formatting;
using NewtonsoftSettings = Newtonsoft.Json.JsonSerializerSettings;
using STJsonException = System.Text.Json.JsonException;

namespace Microsoft.Azure.Commands.Batch.Track2.Workarounds
{
    /// <summary>
    /// Works around three issues in Azure.Compute.Batch 1.0.0, until a newer version fixes them (then this folder goes):
    /// 1. it reads 15 int64 values only as JSON text, but the service sends numbers;
    /// 2. it writes URLs with Uri.AbsoluteUri, which fails for a registry server such as "myregistry.azurecr.io" and
    ///    adds a "/" to "https://myregistry.azurecr.io";
    /// 3. it types VM extension settings as text, but they can be any JSON (bug 40599114).
    /// </summary>
    internal static class Track2Workarounds
    {
        /// <summary>
        /// The int64 values Azure.Compute.Batch 1.0.0 reads only as text: file contentLength, the disk IOps of pool
        /// resource statistics, and the IOps and task counts of job, job schedule and task statistics. No other model
        /// has properties with these names.
        /// </summary>
        internal static readonly ISet<string> Int64ReadAsText = new HashSet<string>(StringComparer.Ordinal)
        {
            "contentLength", "diskReadIOps", "diskWriteIOps", "readIOps", "writeIOps",
            "numSucceededTasks", "numFailedTasks", "numTaskRetries",
        };

        /// <summary>The VM extension properties Azure.Compute.Batch 1.0.0 types as a dictionary of text.</summary>
        internal static readonly ISet<string> ExtensionSettings = new HashSet<string>(StringComparer.Ordinal)
        {
            "settings", "protectedSettings",
        };

        /// <summary>
        /// A stand-in URL for text the service must get exactly as typed (<see cref="ToExactUrl"/>); the request step
        /// sends the text instead, but only in the properties in <see cref="ExactUrlProperties"/>. ".invalid" never
        /// resolves.
        /// </summary>
        internal const string ExactUrlPrefix = "https://exact-text.azure-powershell.invalid/";

        /// <summary>
        /// The request properties that can carry a stand-in URL (<see cref="ToExactUrl"/>). Add a property here before
        /// using ToExactUrl for it.
        /// </summary>
        internal static readonly ISet<string> ExactUrlProperties = new HashSet<string>(StringComparer.Ordinal)
        {
            "registryServer", "httpUrl", "storageContainerUrl",
        };

        /// <summary>
        /// Marks a VM extension setting value given as JSON: a number, true/false, a list, an object, or text that
        /// itself starts with this marker (as a JSON string), so any text can be told apart from a marked value.
        /// </summary>
        internal const string JsonSettingPrefix = "azure-powershell-json:";

        // How Track 1 (Microsoft.Azure.Batch 16.3.1) reads JSON, so settings come back as the same objects.
        private static readonly NewtonsoftSettings Track1Reading = new NewtonsoftSettings
        {
            DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
            DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
        };

        private static readonly byte[][] AnswerHints = Int64ReadAsText.Concat(ExtensionSettings)
            .Select(name => Encoding.UTF8.GetBytes("\"" + name + "\"")).ToArray();

        private static readonly byte[][] RequestHints =
        {
            Encoding.UTF8.GetBytes(ExactUrlPrefix), Encoding.UTF8.GetBytes(JsonSettingPrefix),
        };

        /// <summary>
        /// The URL to give Azure.Compute.Batch for text the service must get exactly as typed, such as a registry
        /// server: the request step puts the text back. To read such a URL, use Uri.OriginalString, which is the text
        /// the service sent.
        /// </summary>
        internal static Uri ToExactUrl(string text)
        {
            if (text == null)
            {
                return null;
            }

            string base64Url = Convert.ToBase64String(Encoding.UTF8.GetBytes(text)).TrimEnd('=').Replace('+', '-').Replace('/', '_');
            return new Uri(ExactUrlPrefix + base64Url);
        }

        /// <summary>
        /// VM extension settings for Azure.Compute.Batch: text stays text; other JSON values, and text that starts with
        /// <see cref="JsonSettingPrefix"/>, are marked.
        /// </summary>
        internal static IDictionary<string, string> ToSettings(JObject settings)
        {
            if (settings == null)
            {
                return null;
            }

            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (Newtonsoft.Json.Linq.JProperty setting in settings.Properties())
            {
                JTokenType type = setting.Value.Type;
                result[setting.Name] = type == JTokenType.Null ? null
                    : type == JTokenType.String && !IsMarked((string)setting.Value) ? (string)setting.Value
                    : JsonSettingPrefix + setting.Value.ToString(NewtonsoftFormatting.None);
            }

            return result;
        }

        /// <summary>
        /// VM extension settings read by Azure.Compute.Batch, as the object Track 1 gives for the same answer.
        /// </summary>
        internal static JObject FromSettings(IDictionary<string, string> settings)
        {
            if (settings == null)
            {
                return null;
            }

            StringBuilder json = new StringBuilder("{");
            foreach (KeyValuePair<string, string> setting in settings)
            {
                if (json.Length > 1)
                {
                    json.Append(',');
                }

                json.Append(JsonConvert.ToString(setting.Key)).Append(':');
                string marked = setting.Value != null && IsMarked(setting.Value) ? setting.Value.Substring(JsonSettingPrefix.Length) : null;
                if (setting.Value == null)
                {
                    json.Append("null");
                }
                else if (marked != null && IsJson(marked))
                {
                    json.Append(marked);
                }
                else
                {
                    json.Append(JsonConvert.ToString(setting.Value));
                }
            }

            return JsonConvert.DeserializeObject<JObject>(json.Append('}').ToString(), Track1Reading);
        }

        /// <summary>
        /// Fixes an answer from the service so that Azure.Compute.Batch 1.0.0 can read it: the int64 values become
        /// text, and extension settings that aren't text become marked text. Null when there's nothing to fix.
        /// </summary>
        internal static byte[] FixAnswer(byte[] json)
        {
            JsonNode root = ParseIfAny(json, AnswerHints);
            return root != null && FixAnswer(root) ? Encoding.UTF8.GetBytes(root.ToJsonString()) : null;
        }

        /// <summary>
        /// Fixes a request before it's sent: stand-in URLs become the text as typed, and marked extension settings
        /// become JSON again. Null when there's nothing to fix.
        /// </summary>
        internal static byte[] FixRequest(byte[] json)
        {
            JsonNode root = ParseIfAny(json, RequestHints);
            return root != null && FixRequest(root) ? Encoding.UTF8.GetBytes(root.ToJsonString()) : null;
        }

        private static bool FixAnswer(JsonNode node)
        {
            bool changed = false;
            if (node is JsonObject item)
            {
                foreach (KeyValuePair<string, JsonNode> property in item.ToList())
                {
                    JsonNode value = property.Value;
                    if (value == null)
                    {
                        continue;
                    }

                    if (Int64ReadAsText.Contains(property.Key) && value.GetValueKind() == JsonValueKind.Number)
                    {
                        item[property.Key] = JsonValue.Create(value.ToJsonString());
                        changed = true;
                    }
                    else if (ExtensionSettings.Contains(property.Key) && value is JsonObject settings)
                    {
                        foreach (KeyValuePair<string, JsonNode> setting in settings.ToList())
                        {
                            if (setting.Value != null && (setting.Value.GetValueKind() != JsonValueKind.String || IsMarked(setting.Value.GetValue<string>())))
                            {
                                settings[setting.Key] = JsonValue.Create(JsonSettingPrefix + setting.Value.ToJsonString());
                                changed = true;
                            }
                        }
                    }
                    else
                    {
                        changed |= FixAnswer(value);
                    }
                }
            }
            else if (node is JsonArray items)
            {
                foreach (JsonNode value in items)
                {
                    if (value != null)
                    {
                        changed |= FixAnswer(value);
                    }
                }
            }

            return changed;
        }

        // Only the properties the mappers fill with a stand-in URL, and the values of extension settings, are decoded;
        // other text is sent as it is, even if it happens to look like a marker.
        private static bool FixRequest(JsonNode node)
        {
            bool changed = false;
            if (node is JsonObject item)
            {
                foreach (KeyValuePair<string, JsonNode> property in item.ToList())
                {
                    if (property.Value == null)
                    {
                        continue;
                    }

                    if (ExactUrlProperties.Contains(property.Key) && TryRestoreUrl(property.Value, out JsonNode url))
                    {
                        item[property.Key] = url;
                        changed = true;
                    }
                    else if (ExtensionSettings.Contains(property.Key) && property.Value is JsonObject settings)
                    {
                        changed |= RestoreSettings(settings);
                    }
                    else
                    {
                        changed |= FixRequest(property.Value);
                    }
                }
            }
            else if (node is JsonArray items)
            {
                foreach (JsonNode value in items)
                {
                    if (value != null)
                    {
                        changed |= FixRequest(value);
                    }
                }
            }

            return changed;
        }

        private static bool TryRestoreUrl(JsonNode value, out JsonNode restored)
        {
            restored = null;
            string text = value.GetValueKind() == JsonValueKind.String ? value.GetValue<string>() : null;
            if (text == null || !text.StartsWith(ExactUrlPrefix, StringComparison.Ordinal))
            {
                return false;
            }

            string base64 = text.Substring(ExactUrlPrefix.Length).Replace('-', '+').Replace('_', '/');
            base64 = base64.PadRight(base64.Length + ((4 - (base64.Length % 4)) % 4), '=');
            try
            {
                restored = JsonValue.Create(Encoding.UTF8.GetString(Convert.FromBase64String(base64)));
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private static bool RestoreSettings(JsonObject settings)
        {
            bool changed = false;
            foreach (KeyValuePair<string, JsonNode> setting in settings.ToList())
            {
                string text = setting.Value != null && setting.Value.GetValueKind() == JsonValueKind.String ? setting.Value.GetValue<string>() : null;
                if (text == null || !IsMarked(text))
                {
                    continue;
                }

                try
                {
                    settings[setting.Key] = JsonNode.Parse(text.Substring(JsonSettingPrefix.Length));
                    changed = true;
                }
                catch (STJsonException)
                {
                    // Not one of ours: send the text as it is.
                }
            }

            return changed;
        }

        private static bool IsMarked(string text)
        {
            return text.StartsWith(JsonSettingPrefix, StringComparison.Ordinal);
        }

        private static bool IsJson(string text)
        {
            try
            {
                JsonDocument.Parse(text).Dispose();
                return true;
            }
            catch (STJsonException)
            {
                return false;
            }
        }

        // Parses the JSON only when it has one of the hints, so most bodies are left as they are without parsing them.
        private static JsonNode ParseIfAny(byte[] json, byte[][] hints)
        {
            if (json == null || !hints.Any(hint => json.AsSpan().IndexOf(hint) >= 0))
            {
                return null;
            }

            try
            {
                return JsonNode.Parse(json);
            }
            catch (STJsonException)
            {
                return null;
            }
        }
    }
}
