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
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault
{
    public partial class SetAzureKeyVaultManagedStorageSasDefinition
    {
        private const string ParameterSetAdhocAccountSas = "AdhocAccountSas";

        private static class SingedServices
        {
            public const string Blob = "Blob";
            public const string File = "File";
            public const string Queue = "Queue";
            public const string Table = "Table";
        }

        private const string ServicesHelpMessage = "Service types that this SAS token applies to. Possible values include 'Blob','File','Queue','Table'";
        [Parameter( Mandatory = true, HelpMessage = ServicesHelpMessage, ParameterSetName = ParameterSetAdhocAccountSas )]
        [ValidateSet( SingedServices.Blob, SingedServices.File, SingedServices.Queue, SingedServices.Table )]
        public string[] Service { get; set; }

        private static class SignedResourceTypes
        {
            public const string Service = "Service";
            public const string Container = "Container";
            public const string Object = "Object";
        }

        private const string ResourceTypesHelpMessage = "Resource types that this SAS token applies to. Possible values include 'Service','Container','Object'";
        [Parameter( Mandatory = true, HelpMessage = ResourceTypesHelpMessage, ParameterSetName = ParameterSetAdhocAccountSas )]
        [ValidateSet( SignedResourceTypes.Service, SignedResourceTypes.Container, SignedResourceTypes.Object )]
        public string[] ResourceType { get; set; }

        private const string ApiVersionHelpMessage = "Specifies the storage service version to use to execute the request made using the account SAS URI.";
        [Parameter( HelpMessage = ApiVersionHelpMessage, ParameterSetName = ParameterSetAdhocAccountSas )]
        [ValidateNotNullOrEmpty]
        public string ApiVersion { get; set; }

        private KeyValuePair<string, string>? ServicesParameter
        {
            get
            {
                if ( Service == null ) return null;

                var builder = new StringBuilder();

                var services = new HashSet<string>( Service, StringComparer.OrdinalIgnoreCase );

                if ( services.Contains( SingedServices.Blob ) ) builder.Append( "b" );
                if ( services.Contains( SingedServices.Queue ) ) builder.Append( "q" );
                if ( services.Contains( SingedServices.File ) ) builder.Append( "f" );
                if ( services.Contains( SingedServices.Table ) ) builder.Append( "t" );

                return new KeyValuePair<string, string>( SasDefinitionParameterConstants.SignedServices, builder.ToString() );
            }
        }

        private KeyValuePair<string, string>? ResourceTypeParameter
        {
            get
            {
                if ( ResourceType == null ) return null;

                var builder = new StringBuilder();

                var resourceTypes = new HashSet<string>( ResourceType, StringComparer.OrdinalIgnoreCase );

                if ( resourceTypes.Contains( SignedResourceTypes.Service ) ) builder.Append( "s" );
                if ( resourceTypes.Contains( SignedResourceTypes.Container ) ) builder.Append( "c" );
                if ( resourceTypes.Contains( SignedResourceTypes.Object ) ) builder.Append( "o" );

                return new KeyValuePair<string, string>( SasDefinitionParameterConstants.SignedResourceTypes, builder.ToString() );
            }
        }

        private KeyValuePair<string, string>? ApiVersionParameter
        {
            get
            {
                if ( string.IsNullOrWhiteSpace( ApiVersion ) ) return null;
                return new KeyValuePair<string, string>( SasDefinitionParameterConstants.ApiVersion, ApiVersion );
            }
        }
    }
}
