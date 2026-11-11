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

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Batch.Track2
{
    /// <summary>
    /// Gives the requests that Track 1 (Microsoft.Azure.Batch 16.3.1) treated as long running the same longer time-out:
    /// getting a file from a task or a compute node, and adding a task. Every other request keeps the client's network
    /// time-out, which is Track 1's time-out for a single request.
    /// </summary>
    internal sealed class BatchRequestTimeoutPolicy : HttpPipelineSynchronousPolicy
    {
        internal static readonly TimeSpan RequestTimeout = TimeSpan.FromMinutes(1);

        internal static readonly TimeSpan LongRequestTimeout = TimeSpan.FromMinutes(3);

        // GET /jobs/{jobId}/tasks/{taskId}/files/{filePath} and GET /pools/{poolId}/nodes/{nodeId}/files/{filePath}
        private static readonly Regex GetFile = new Regex(
            "^/(jobs/[^/]+/tasks|pools/[^/]+/nodes)/[^/]+/files/.+$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        // POST /jobs/{jobId}/tasks
        private static readonly Regex AddTask = new Regex(
            "^/jobs/[^/]+/tasks/?$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        public override void OnSendingRequest(HttpMessage message)
        {
            if (IsLongRequest(message.Request.Method, message.Request.Uri.Path))
            {
                message.NetworkTimeout = LongRequestTimeout;
            }
        }

        internal static bool IsLongRequest(RequestMethod method, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            if (method == RequestMethod.Get)
            {
                return GetFile.IsMatch(path);
            }

            if (method == RequestMethod.Post)
            {
                return AddTask.IsMatch(path);
            }

            return false;
        }
    }
}
