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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    public partial class SetAzureKeyVaultManagedStorageSasDefinition
    {
        private const string PolicyHelpMessage = "Policy Identifier";
        [Parameter( Mandatory = true, HelpMessage = PolicyHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceContainerSas )]
        [Parameter( Mandatory = true, HelpMessage = PolicyHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceBlobSas )]
        [Parameter( Mandatory = true, HelpMessage = PolicyHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceFileSas )]
        [Parameter( Mandatory = true, HelpMessage = PolicyHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceShareSas )]
        [Parameter( Mandatory = true, HelpMessage = PolicyHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceQueueSas )]
        [Parameter( Mandatory = true, HelpMessage = PolicyHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceTableSas )]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }


        private static class SasHeaders
        {
            public const string CacheControl = "CacheControl";
            public const string ContentDisposition = "ContentDisposition";
            public const string ContentEncoding = "ContentEncoding";
            public const string ContentLanguage = "ContentLanguage";
            public const string ContentType = "ContentType";
        }

        private const string HeadersHelpMessage = "Specifies the query parameters to override response headers.";
        [Parameter( HelpMessage = HeadersHelpMessage, ParameterSetName = ParameterSetAdhocServiceContainerSas )]
        [Parameter( HelpMessage = HeadersHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceContainerSas )]
        [Parameter( HelpMessage = HeadersHelpMessage, ParameterSetName = ParameterSetAdhocServiceBlobSas )]
        [Parameter( HelpMessage = HeadersHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceBlobSas )]
        [Parameter( HelpMessage = HeadersHelpMessage, ParameterSetName = ParameterSetAdhocServiceShareSas )]
        [Parameter( HelpMessage = HeadersHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceShareSas )]
        [Parameter( HelpMessage = HeadersHelpMessage, ParameterSetName = ParameterSetAdhocServiceFileSas )]
        [Parameter( HelpMessage = HeadersHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceFileSas )]
        [ValidateSet( SasHeaders.CacheControl, SasHeaders.ContentDisposition, SasHeaders.ContentEncoding, SasHeaders.ContentLanguage, SasHeaders.ContentType )]
        [ValidateNotNull]
        public string[] SharedAccessHeader { get; set; }

        protected KeyValuePair<string, string>? PolicyParamater
        {
            get
            {
                if ( string.IsNullOrWhiteSpace( Policy ) ) return null;
                return new KeyValuePair<string, string>( SasDefinitionParameterConstants.SignedIdentifier, Policy );
            }
        }

        protected KeyValuePair<string, string>? SharedAccessBlobHeaderCacheControlParameter
        {
            get
            {
                if ( SharedAccessHeader != null && SharedAccessHeader.Contains( SasHeaders.CacheControl, StringComparer.OrdinalIgnoreCase ) )
                    return new KeyValuePair<string, string>( SasDefinitionParameterConstants.HeaderCacheControl, "" );

                return null;
            }
        }

        protected KeyValuePair<string, string>? SharedAccessBlobHeaderContentDispositionParameter
        {
            get
            {
                if ( SharedAccessHeader != null && SharedAccessHeader.Contains( SasHeaders.ContentDisposition, StringComparer.OrdinalIgnoreCase ) )
                    return new KeyValuePair<string, string>( SasDefinitionParameterConstants.HeaderContentDisposition, "" );

                return null;
            }
        }

        protected KeyValuePair<string, string>? SharedAccessBlobHeaderContentEncodingParameter
        {
            get
            {
                if ( SharedAccessHeader != null && SharedAccessHeader.Contains( SasHeaders.ContentEncoding, StringComparer.OrdinalIgnoreCase ) )
                    return new KeyValuePair<string, string>( SasDefinitionParameterConstants.HeaderContentEncoding, "" );

                return null;
            }
        }

        protected KeyValuePair<string, string>? SharedAccessBlobHeaderContentLanguageParameter
        {
            get
            {
                if ( SharedAccessHeader != null && SharedAccessHeader.Contains( SasHeaders.ContentLanguage, StringComparer.OrdinalIgnoreCase ) )
                    return new KeyValuePair<string, string>( SasDefinitionParameterConstants.HeaderContentLanguage, "" );

                return null;
            }
        }

        protected KeyValuePair<string, string>? SharedAccessBlobHeaderContentTypeParameter
        {
            get
            {
                if ( SharedAccessHeader != null && SharedAccessHeader.Contains( SasHeaders.ContentType, StringComparer.OrdinalIgnoreCase ) )
                    return new KeyValuePair<string, string>( SasDefinitionParameterConstants.HeaderContentType, "" );

                return null;
            }
        }
    }
}
