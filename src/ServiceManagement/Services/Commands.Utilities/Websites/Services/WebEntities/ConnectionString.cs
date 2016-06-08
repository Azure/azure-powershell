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
    /// Class that represents a connection string.
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class ConnectionString
    {
        /// <summary>
        /// Name for the database
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Connection string
        /// </summary>
        [DataMember]
        [PIIValue]
        public string Value { get; set; }

    }

    /// <summary>
    /// Collection of connection strings
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class ConnectionStrings : List<ConnectionString>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public ConnectionStrings() { }

        /// <summary>
        /// Initialize from list
        /// </summary>
        /// <param name="plans"></param>
        public ConnectionStrings(List<ConnectionString> list) : base(list) { }
    }
}
