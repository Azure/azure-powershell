/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime.Json;

    public enum MockMode
    {
        Live,
        Record,
        Playback,

    }

    public class PipelineMock
    {

        private System.Collections.Generic.Stack<string> scenario = new System.Collections.Generic.Stack<string>();
        private System.Collections.Generic.Stack<string> context = new System.Collections.Generic.Stack<string>();
        private System.Collections.Generic.Stack<string> description = new System.Collections.Generic.Stack<string>();

        private readonly string recordingPath;
        private int counter = 0;

        public static implicit operator Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime.SendAsyncStep(PipelineMock instance) => instance.SendAsync;

        public MockMode Mode { get; set; } = MockMode.Live;
        public PipelineMock(string recordingPath)
        {
            this.recordingPath = recordingPath;
        }

        public void PushContext(string text) => context.Push(text);

        public void PushDescription(string text) => description.Push(text);


        public void PushScenario(string it)
        {
            // reset counter too
            counter = 0;

            scenario.Push(it);
        }

        public void PopContext() => context.Pop();

        public void PopDescription() => description.Pop();

        public void PopScenario() => scenario.Pop();

        public void SetRecord() => Mode = MockMode.Record;

        public void SetPlayback() => Mode = MockMode.Playback;

        public void SetLive() => Mode = MockMode.Live;

        public string Scenario => (scenario.Count > 0 ? scenario.Peek() : "[NoScenario]");
        public string Description => (description.Count > 0 ? description.Peek() : "[NoDescription]");
        public string Context => (context.Count > 0 ? context.Peek() : "[NoContext]");

        /// <summary>
        /// Headers that we substitute out blank values for in the recordings
        /// Add additional headers as necessary
        /// </summary>
        public static HashSet<string> Blacklist = new HashSet<string>(System.StringComparer.CurrentCultureIgnoreCase) {
          "Authorization",
        };

        public Dictionary<string, string> ForceResponseHeaders = new Dictionary<string, string>();

        internal static XImmutableArray<string> Removed = new XImmutableArray<string>(new string[] { "[Filtered]" });

        internal static IEnumerable<KeyValuePair<string, JsonNode>> FilterHeaders(IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers) => headers.Select(header => new KeyValuePair<string, JsonNode>(header.Key, Blacklist.Contains(header.Key) ? Removed : new XImmutableArray<string>(header.Value.ToArray())));

        internal static JsonNode SerializeContent(HttpContent content, ref bool isBase64) => content == null ? XNull.Instance : SerializeContent(content.ReadAsByteArrayAsync().Result, ref isBase64);

        internal static JsonNode SerializeContent(byte[] content, ref bool isBase64)
        {
            if (null == content || content.Length == 0)
            {
                return XNull.Instance;
            }
            var first = content[0];
            var last = content[content.Length - 1];

            // plaintext for JSON/SGML/XML/HTML/STRINGS/ARRAYS
            if ((first == '{' && last == '}') || (first == '<' && last == '>') || (first == '[' && last == ']') || (first == '"' && last == '"'))
            {
                return new JsonString(System.Text.Encoding.UTF8.GetString(content));
            }

            // base64 for everyone else
            return new JsonString(System.Convert.ToBase64String(content));
        }

        internal static byte[] DeserializeContent(string content, bool isBase64)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return new byte[0];
            }

            if (isBase64)
            {
                try
                {
                    return System.Convert.FromBase64String(content);
                }
                catch
                {
                    // hmm. didn't work, return it as a string I guess.
                }
            }
            return System.Text.Encoding.UTF8.GetBytes(content);
        }

        public void SaveMessage(string rqKey, HttpRequestMessage request, HttpResponseMessage response)
        {
            var messages = System.IO.File.Exists(this.recordingPath) ? Load() : new JsonObject() ?? new JsonObject();
            bool isBase64Request = false;
            bool isBase64Response = false;
            messages[rqKey] = new JsonObject {
              { "Request",new JsonObject {
                { "Method", request.Method.Method },
                { "RequestUri", request.RequestUri },
                { "Content", SerializeContent( request.Content, ref isBase64Request) },
                { "isContentBase64", isBase64Request },
                { "Headers", new JsonObject(FilterHeaders(request.Headers)) },
                { "ContentHeaders", request.Content == null ? new JsonObject() : new JsonObject(FilterHeaders(request.Content.Headers))}
              } },
              {"Response", new JsonObject {
                { "StatusCode", (int)response.StatusCode},
                { "Headers", new JsonObject(FilterHeaders(response.Headers))},
                { "ContentHeaders", new JsonObject(FilterHeaders(response.Content.Headers))},
                { "Content", SerializeContent(response.Content, ref isBase64Response) },
                { "isContentBase64", isBase64Response },
              }}
            };
            System.IO.File.WriteAllText(this.recordingPath, messages.ToString());
        }

        private JsonObject Load()
        {
            if (System.IO.File.Exists(this.recordingPath))
            {
                try
                {
                    return JsonObject.FromStream(System.IO.File.OpenRead(this.recordingPath));
                }
                catch
                {
                    throw new System.Exception($"Invalid recording file: '{recordingPath}'");
                }
            }

            throw new System.ArgumentException($"Missing recording file: '{recordingPath}'", nameof(recordingPath));
        }

        public HttpResponseMessage LoadMessage(string rqKey)
        {
            var responses = Load();
            var message = responses.Property(rqKey);

            if (null == message)
            {
                throw new System.ArgumentException($"Missing Request '{rqKey}' in recording file", nameof(rqKey));
            }

            var sc = 0;
            var reqMessage = message.Property("Request");
            var respMessage = message.Property("Response");

            // --------------------------- deserialize response ----------------------------------------------------------------
            bool isBase64Response = false;
            respMessage.BooleanProperty("isContentBase64", ref isBase64Response);
            var response = new HttpResponseMessage
            {
                StatusCode = (HttpStatusCode)respMessage.NumberProperty("StatusCode", ref sc),
                Content = new System.Net.Http.ByteArrayContent(DeserializeContent(respMessage.StringProperty("Content"), isBase64Response))
            };

            foreach (var each in respMessage.Property("Headers"))
            {
                response.Headers.TryAddWithoutValidation(each.Key, each.Value.ToArrayOf<string>());
            }

            foreach (var frh in ForceResponseHeaders)
            {
                response.Headers.Remove(frh.Key);
                response.Headers.TryAddWithoutValidation(frh.Key, frh.Value);
            }

            foreach (var each in respMessage.Property("ContentHeaders"))
            {
                response.Content.Headers.TryAddWithoutValidation(each.Key, each.Value.ToArrayOf<string>());
            }

            // --------------------------- deserialize request ----------------------------------------------------------------
            bool isBase64Request = false;
            reqMessage.BooleanProperty("isContentBase64", ref isBase64Request);
            response.RequestMessage = new HttpRequestMessage
            {
                Method = new HttpMethod(reqMessage.StringProperty("Method")),
                RequestUri = new System.Uri(reqMessage.StringProperty("RequestUri")),
                Content = new System.Net.Http.ByteArrayContent(DeserializeContent(reqMessage.StringProperty("Content"), isBase64Request))
            };

            foreach (var each in reqMessage.Property("Headers"))
            {
                response.RequestMessage.Headers.TryAddWithoutValidation(each.Key, each.Value.ToArrayOf<string>());
            }
            foreach (var each in reqMessage.Property("ContentHeaders"))
            {
                response.RequestMessage.Content.Headers.TryAddWithoutValidation(each.Key, each.Value.ToArrayOf<string>());
            }

            return response;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, IEventListener callback, ISendAsync next)
        {
            counter++;
            var rqkey = $"{Description}+{Context}+{Scenario}+${request.Method.Method}+{request.RequestUri}+{counter}";

            switch (Mode)
            {
                case MockMode.Record:
                    //Add following code since the request.Content will be released after sendAsync
                    var requestClone = request;
                    if (requestClone.Content != null)
                    {
                        requestClone = await request.CloneWithContent(request.RequestUri, request.Method);
                    }
                    // make the call
                    var response = await next.SendAsync(request, callback);

                    // save the message to the recording file
                    SaveMessage(rqkey, requestClone, response);

                    // return the response.
                    return response;

                case MockMode.Playback:
                    // load and return the response.
                    return LoadMessage(rqkey);

                default:
                    // pass-thru, do nothing
                    return await next.SendAsync(request, callback);
            }
        }
    }
}
