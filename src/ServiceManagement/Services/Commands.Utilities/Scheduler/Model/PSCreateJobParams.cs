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
using System.Collections;

namespace Microsoft.WindowsAzure.Commands.Utilities.Scheduler.Model
{
    public class PSCreateJobParams
    {
        public string Region { get; set; }

        public string JobCollectionName { get; set; }

        public string JobName { get; set; }

        public string Method { get; set; }

        public Uri Uri { get; set; }

        public string StorageAccount { get; set; }

        public string QueueName { get; set; }

        public string SasToken { get; set; }

        public string StorageQueueMessage { get; set; }

        public string Body { get; set; }

        public DateTime? StartTime { get; set; }

        public int? Interval { get; set; }

        public string Frequency { get; set; }

        public DateTime? EndTime { get; set; }

        public int? ExecutionCount { get; set; }

        public string JobState { get; set; }

        public Hashtable Headers { get; set; }

        public string ErrorActionMethod { get; set; }

        public Uri ErrorActionUri { get; set; }

        public string ErrorActionBody { get; set; }

        public Hashtable ErrorActionHeaders { get; set; }

        public string ErrorActionStorageAccount { get; set; }

        public string ErrorActionQueueName { get; set; }

        public string ErrorActionSasToken { get; set; }

        public string ErrorActionQueueBody { get; set; }

        public string HttpAuthType { get; set; }

        public string ClientCertPfx { get; set; }

        public string ClientCertPassword { get; set; }

        public string Secret { get; set; }

        public string Tenant { get; set; }

        public string Audience { get; set; }

        public string ClientId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
