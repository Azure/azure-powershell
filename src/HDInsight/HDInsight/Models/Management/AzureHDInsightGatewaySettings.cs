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
    public class AzureHDInsightGatewaySettings
    {
        public AzureHDInsightGatewaySettings(GatewaySettings gatewaySettings)
        {
            this.IsCredentialEnabled = gatewaySettings.IsCredentialEnabled;
            this.UserName = gatewaySettings.UserName;
            this.Password = gatewaySettings.Password;
        }

        /// <summary>
        /// indicates whether or not the gateway settings based authorization is enabled.
        /// </summary>
        public string IsCredentialEnabled { get; set; }

        /// <summary>
        /// the gateway settings user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// the gateway settings user password.
        /// </summary>
        public string Password { get; set; }
    }
}
