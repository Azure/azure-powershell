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
    public class PSApiProperties
    {
        public PSApiProperties(ApiProperties apiProperties)
        {
            if (apiProperties == null)
            {
                return;
            }

            ServerVersion = apiProperties.ServerVersion;
        }
        //
        // Summary:
        //     Gets or sets describes the ServerVersion of an a MongoDB account. Possible values
        //     include: '3.2', '3.6', '4.0'
        public string ServerVersion { get; set; }
    }
}