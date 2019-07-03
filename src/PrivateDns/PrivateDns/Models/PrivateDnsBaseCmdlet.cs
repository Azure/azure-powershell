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

namespace Microsoft.Azure.Commands.PrivateDns.Models
{
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using ProjectResources = Microsoft.Azure.Commands.PrivateDns.Properties.Resources;

    public abstract class PrivateDnsBaseCmdlet : AzureRMCmdlet
    {
        private PrivateDnsClient _client;

        public PrivateDnsClient PrivateDnsClient
        {
            get => _client ?? (_client = new PrivateDnsClient(DefaultContext));

            set => _client = value;
        }

        public string TrimTrailingDotInZoneName(string zoneName)
        {
            if (!zoneName.EndsWith(".")) return zoneName;

            this.WriteWarning(string.Format(ProjectResources.Progress_ModifyingZoneNameTrimDot, zoneName));
            return zoneName.TrimEnd('.');
        }
    }
}
