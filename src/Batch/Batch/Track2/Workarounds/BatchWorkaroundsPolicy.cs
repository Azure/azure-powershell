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
using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Batch.Track2.Workarounds
{
    /// <summary>
    /// Applies <see cref="Track2Workarounds"/> to the Track 2 client's JSON requests and answers. File content is never
    /// changed. Remove it with the SDK version that fixes the issues.
    /// </summary>
    internal sealed class BatchWorkaroundsPolicy : HttpPipelinePolicy
    {
        // The content of a file: /jobs/{jobId}/tasks/{taskId}/files/{filePath} and /pools/{poolId}/nodes/{nodeId}/files/{filePath}.
        private static readonly Regex FileContent = new Regex(
            "^/(jobs/[^/]+/tasks|pools/[^/]+/nodes)/[^/]+/files/.+$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            FixRequest(message);
            ProcessNext(message, pipeline);
            FixAnswer(message);
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            FixRequest(message);
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            FixAnswer(message);
        }

        private static void FixRequest(HttpMessage message)
        {
            RequestContent content = message.Request.Content;
            if (content == null || !message.Request.Headers.TryGetValue("Content-Type", out string contentType) || !IsJson(contentType))
            {
                return;
            }

            using (MemoryStream body = new MemoryStream())
            {
                content.WriteTo(body, message.CancellationToken);
                byte[] fixedBody = Track2Workarounds.FixRequest(body.ToArray());
                if (fixedBody != null)
                {
                    message.Request.Content = RequestContent.Create(fixedBody);
                }
            }
        }

        private static void FixAnswer(HttpMessage message)
        {
            if (!message.HasResponse || !message.BufferResponse || FileContent.IsMatch(message.Request.Uri.Path))
            {
                return;
            }

            Response response = message.Response;
            if (!(response.ContentStream is MemoryStream body) || !IsJson(response.Headers.ContentType))
            {
                return;
            }

            byte[] fixedBody = Track2Workarounds.FixAnswer(body.ToArray());
            if (fixedBody != null)
            {
                response.ContentStream = new MemoryStream(fixedBody);
            }
        }

        private static bool IsJson(string contentType)
        {
            return contentType != null && contentType.IndexOf("json", StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
