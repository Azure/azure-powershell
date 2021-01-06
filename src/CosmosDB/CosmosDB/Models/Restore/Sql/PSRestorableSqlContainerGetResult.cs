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

namespace Microsoft.Azure.Management.CosmosDB.Models
{
    public class PSRestorableSqlContainerGetResult
    {
        public PSRestorableSqlContainerGetResult()
        {
        }

        public PSRestorableSqlContainerGetResult(RestorableSqlContainerGetResult restorableSqlContainerGetResult)
        {
            if (restorableSqlContainerGetResult == null)
            {
                return;
            }

            Id = restorableSqlContainerGetResult.Id;
            Name = restorableSqlContainerGetResult.Name;
            Type = restorableSqlContainerGetResult.Type;
            Resource = new PSRestorableSqlContainerPropertiesResource(restorableSqlContainerGetResult.Resource);
        }

        //
        // Summary:
        //     Gets the unique resource identifier of the RestorableSqlContainer resource.
        public string Id { get; }

        //
        // Summary:
        //     Gets the name of the RestorableSqlContainer resource.
        public string Name { get; }

        //
        // Summary:
        //     Gets the type of Azure resource.
        public string Type { get; }

        /// <summary>
        /// </summary>
        public PSRestorableSqlContainerPropertiesResource Resource { get; set; }
    }
}
