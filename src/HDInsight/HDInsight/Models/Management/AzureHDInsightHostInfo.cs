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

using Microsoft.Azure.Management.HDInsight.Models;

namespace Microsoft.Azure.Commands.HDInsight.Models.Management
{
    public class AzureHDInsightHostInfo
    {
        public AzureHDInsightHostInfo(HostInfo hostInfo)
        {
            name = hostInfo?.Name;
            Fqdn = hostInfo?.Fqdn;
            EffectiveDiskEncryptionKeyUrl = hostInfo?.EffectiveDiskEncryptionKeyUrl;
        }

        /// <summary>
        /// The name of hosts.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The full qualified dns name.
        /// </summary>
        public string Fqdn { get; set; }

        /// <summary>
        /// The effective disk encryption key url.
        /// </summary>
        public string EffectiveDiskEncryptionKeyUrl { get; set; }
    }
}
