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
    [DataContract(Name = "AccessControlEntry", Namespace = UriElements.ServiceNamespace)]
    public class AccessControlEntry
    {
        [DataMember(IsRequired = true)]
        public string EntityName { get; set; }

        [DataMember(IsRequired = true)]
        public string UserName { get; set; }

        [DataMember(IsRequired = true)]
        public string RoleName { get; set; }

        [DataMember(IsRequired = false)]
        public string Description { get; set; }
    }

    /// <summary>
    /// Collection of AccessControlEntries
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class AccessControlList : List<AccessControlEntry>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public AccessControlList() { }

        /// <summary>
        /// Initialize collection
        /// </summary>
        /// <param name="entries"></param>
        public AccessControlList(List<AccessControlEntry> entries) : base(entries) { }
    }
}
