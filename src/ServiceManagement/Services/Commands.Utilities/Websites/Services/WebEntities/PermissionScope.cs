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

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities
{
    [DataContract(Name = "PermissionScope", Namespace = UriElements.ServiceNamespace)]
    public enum PermissionScope
    {
        [EnumMember]
        Current = 0, // Permission applies to Current entity only and not to the sub-trees.

        [EnumMember]
        InheritOnly = 1, // Permission applies to sub-trees only and Not to the current entity.

        [EnumMember]
        All = 3 // Current and Inherit Only
    }
}
