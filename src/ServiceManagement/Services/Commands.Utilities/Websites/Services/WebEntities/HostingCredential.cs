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
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities
{
    /// <summary>
    /// Class that represents a system credential.
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class HostingCredential
    {
        /// <summary>
        /// Username 
        /// </summary>
        [DataMember]
        public string CredentialName { get; set; }

        /// <summary>
        /// Username 
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// Password for the account
        /// </summary>
        [DataMember]
        [PIIValue]
        public string Password { get; set; }
    }

    /// <summary>
    /// Collection of servers
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class HostingCredentials : List<HostingCredential>
    {
        
    }
}
