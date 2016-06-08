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
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class ConnStringInfo
    {

        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [DataMember(IsRequired = true)]
        [PIIValue]
        public string ConnectionString { get; set; }

        [DataMember(IsRequired = true)]
        public DatabaseType Type { get; set; }
    }

    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public enum DatabaseType
    {
        [EnumMember]
        MySql,
        [EnumMember]
        SQLServer,
        [EnumMember]
        SQLAzure,
        [EnumMember]
        Custom
    }

    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class ConnStringPropertyBag : List<ConnStringInfo>
    {

        public ConnStringPropertyBag()
        {
        }

        public ConnStringPropertyBag(List<ConnStringInfo> connections)
            : base(connections)
        {
        }
    }
}
