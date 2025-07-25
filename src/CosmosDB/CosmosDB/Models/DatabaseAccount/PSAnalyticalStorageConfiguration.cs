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

using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSAnalyticalStorageConfiguration
    {
        public PSAnalyticalStorageConfiguration(AnalyticalStorageConfiguration config)
        {
            if (config == null)
            {
                return;
            }

            SchemaType = config.SchemaType;
        }

        // 
        // Summary:
        //     Gets or sets the schema type for analytical storage for the account.  
        //     Valid values are 'WellDefined' and 'FullFidelity'
        public string SchemaType { get; set; }

        static public AnalyticalStorageConfiguration ToSDKModel(PSAnalyticalStorageConfiguration psConfig)
        {
            if (psConfig == null)
            {
                return null;
            }

            return new AnalyticalStorageConfiguration(psConfig.SchemaType);
        }
    }
}
