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

using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    public partial class SetAzureKeyVaultManagedStorageSasDefinition
    {
        /// <summary>
        /// container pipeline paremeter set name with permission
        /// </summary>
        private const string ParameterSetAdhocServiceShareSas = "AdhocServiceShareSas";

        /// <summary>
        /// container pipeline paremeter set name with policy
        /// </summary>
        private const string ParameterSetStoredPolicyServiceShareSas = "StoredPolicyServiceShareSas";

        private const string ShareHelpMessage = "Share Name";
        [Parameter( Mandatory = true, HelpMessage = ShareHelpMessage, ParameterSetName = ParameterSetAdhocServiceShareSas )]
        [Parameter( Mandatory = true, HelpMessage = ShareHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceShareSas )]
        [Parameter( Mandatory = true, HelpMessage = ShareHelpMessage, ParameterSetName = ParameterSetAdhocServiceFileSas )]
        [Parameter( Mandatory = true, HelpMessage = ShareHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceFileSas )]
        [ValidateNotNullOrEmpty]
        public string Share { get; set; }

        protected KeyValuePair<string, string>? ShareParameter
        {
            get
            {
                if ( string.IsNullOrWhiteSpace( Share ) ) return null;
                return new KeyValuePair<string, string>( SasDefinitionParameterConstants.ShareName, Share );
            }
        }
    }
}
