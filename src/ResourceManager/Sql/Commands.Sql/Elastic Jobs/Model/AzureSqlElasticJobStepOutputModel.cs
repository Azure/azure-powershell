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

namespace Microsoft.Azure.Commands.Sql.Elastic_Jobs.Model
{
    public class AzureSqlElasticJobStepOutputModel
    {
        /// <summary>
        /// The output credential name
        /// </summary>
        public string Credential { get; set; }

        /// <summary>
        /// The output database name
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// The output resource group name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The output schema name
        /// </summary>
        public string SchemaName { get; set; }

        /// <summary>
        /// The output server name
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// The output subscription id
        /// </summary>
        public Guid? SubscriptionId { get; set; }

        /// <summary>
        /// The output table name
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// The output type
        /// </summary>
        public string Type { get; set; }
    }
}