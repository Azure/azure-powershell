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
        private const string ParameterSetAdhocServiceTableSas = "AdhocServiceTableSas";

        /// <summary>
        /// container pipeline paremeter set name with policy
        /// </summary>
        private const string ParameterSetStoredPolicyServiceTableSas = "StoredPolicyServiceTableSas";

        private const string TableHelpMessage = "Table Name";
        [Parameter( Mandatory = true, HelpMessage = TableHelpMessage, ParameterSetName = ParameterSetAdhocServiceTableSas )]
        [Parameter( Mandatory = true, HelpMessage = TableHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceTableSas )]
        [ValidateNotNullOrEmpty]
        public string Table { get; set; }

        private const string SpkHelpMessage = "Start Partition Key";

        [Alias( "startpk" )]
        [Parameter( HelpMessage = SpkHelpMessage, ParameterSetName = ParameterSetAdhocServiceTableSas )]
        [Parameter( HelpMessage = SpkHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceTableSas )]
        [ValidateNotNullOrEmpty]
        public string StartPartitionKey { get; set; }

        private const string SrkHelpMessage = "Start Row Key";
        [Alias( "startrk" )]
        [Parameter( HelpMessage = SrkHelpMessage, ParameterSetName = ParameterSetAdhocServiceTableSas )]
        [Parameter( HelpMessage = SrkHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceTableSas )]
        [ValidateNotNullOrEmpty]
        public string StartRowKey { get; set; }

        private const string EpkHelpMessage = "End Partition Key";
        [Alias( "endpk" )]
        [Parameter( HelpMessage = EpkHelpMessage, ParameterSetName = ParameterSetAdhocServiceTableSas )]
        [Parameter( HelpMessage = EpkHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceTableSas )]
        [ValidateNotNullOrEmpty]
        public string EndPartitionKey { get; set; }

        private const string ErkHelpMessage = "End Row Key";
        [Alias( "endrk" )]
        [Parameter( HelpMessage = ErkHelpMessage, ParameterSetName = ParameterSetAdhocServiceTableSas )]
        [Parameter( HelpMessage = ErkHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceTableSas )]
        [ValidateNotNullOrEmpty]
        public string EndRowKey { get; set; }

        private KeyValuePair<string, string>? TableParameter
        {
            get
            {
                if ( string.IsNullOrWhiteSpace( Table ) ) return null;
                return new KeyValuePair<string, string>( SasDefinitionParameterConstants.TableName, Table );
            }
        }

        private KeyValuePair<string, string>? StartPartitionKeyParameter
        {
            get
            {
                if ( string.IsNullOrWhiteSpace( StartPartitionKey ) ) return null;
                return new KeyValuePair<string, string>( SasDefinitionParameterConstants.StartPartitionKey, StartPartitionKey );
            }
        }

        private KeyValuePair<string, string>? EndPartitionKeyParameter
        {
            get
            {
                if ( string.IsNullOrWhiteSpace( EndPartitionKey ) ) return null;
                return new KeyValuePair<string, string>( SasDefinitionParameterConstants.EndPartitionKey, EndPartitionKey );
            }
        }

        private KeyValuePair<string, string>? StartRowKeyParameter
        {
            get
            {
                if ( string.IsNullOrWhiteSpace( StartRowKey ) ) return null;
                return new KeyValuePair<string, string>( SasDefinitionParameterConstants.StartRowKey, StartRowKey );
            }
        }

        private KeyValuePair<string, string>? EndRowKeyParameter
        {
            get
            {
                if ( string.IsNullOrWhiteSpace( EndRowKey ) ) return null;
                return new KeyValuePair<string, string>( SasDefinitionParameterConstants.EndRowKey, EndRowKey );
            }
        }
    }
}
