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
    /// Database resource
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class Database
    {
        /// <summary>
        /// The name of the database
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Database password
        /// </summary>
        [DataMember]
        [PIIValue]
        public string Password { get; set; }

        /// <summary>
        /// Database connection string
        /// </summary>
        [DataMember]
        [PIIValue]
        public string ConnectionString { get; set; }
    }

    /// <summary>
    /// Collection of MySqlDatabases
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class Databases : List<Database>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public Databases() { }

        /// <summary>
        /// Initialize collection
        /// </summary>
        /// <param name="databases"></param>
        public Databases(List<Database> databases) : base(databases) { }
    }
}
