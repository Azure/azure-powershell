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
    [DataContract(Name = "Permission", Namespace = UriElements.ServiceNamespace)]
    public enum Permission
    {
        [EnumMember]
        Create = 0, // Can create an entity. Usually used in conjunction with All/InheritOnly scope to create children.
        
        [EnumMember]
        Read = 1, // Can read an entity

        [EnumMember]
        Update = 2, // Can update an entity

        [EnumMember]
        Delete = 3, // Can delete an entity

        [EnumMember]
        Publish = 4, // Can publish content an entity. Applicable to websites only

        [EnumMember]
        Admin = 5 // Create, Read, Update, Delete and Publish
    }
}
