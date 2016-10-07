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

namespace Microsoft.Azure.Commands.Management.IotHub.Models
{
    using System.Collections.Generic;

    public class PSIotHubProperties
    {
        public IList<PSSharedAccessSignatureAuthorizationRule> AuthorizationPolicies { get; set; }

        public string HostName { get; set; }

        public IDictionary<string, PSEventHubProperties> EventHubEndpoints { get; set; }

        public IDictionary<string, PSStorageEndpointProperties> StorageEndpoints { get; set; }

        public IDictionary<string, PSMessagingEndpointProperties> MessagingEndpoints { get; set; }

        public bool? EnableFileUploadNotifications { get; set; }

        public PSCloudToDeviceProperties CloudToDevice { get; set; }

        public string Comments { get; set; }

        public PSOperationsMonitoringProperties OperationsMonitoringProperties { get; set; }

        public PSCapabilities Features { get; set; }
    }
}
