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
        private const string ParameterSetAdhocServiceFileSas = "AdhocServiceFileSas";

        /// <summary>
        /// container pipeline paremeter set name with policy
        /// </summary>
        private const string ParameterSetStoredPolicyServiceFileSas = "StoredPolicyServiceFileSas";

        private const string PathHelpMessage = "Path to the cloud file to generate sas token against.";

        [Parameter( Mandatory = true, HelpMessage = PathHelpMessage, ParameterSetName = ParameterSetAdhocServiceFileSas )]
        [Parameter( Mandatory = true, HelpMessage = PathHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceFileSas )]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        private KeyValuePair<string, string>? PathParameter
        {
            get
            {
                if ( string.IsNullOrWhiteSpace( Path ) ) return null;

                return new KeyValuePair<string, string>( SasDefinitionParameterConstants.PathName, Path );
            }
        }
    }
}
