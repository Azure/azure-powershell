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
using System.Linq;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSTablesToRestore
    {
        public PSTablesToRestore()
        {
        }

        public PSTablesToRestore(IEnumerable<string> tableNames)
        {
            TableNames = tableNames.ToArray();
        }

        public PSTablesToRestore(string[] tableNames)
        {
            TableNames = tableNames;
        }

        //
        // Summary:
        //     Gets or sets the names of the tables available for restore.
        public string[] TableNames;

        public List<string> ToSDKModel()
        {
            List<string> tableNames = new List<string>();
            if (TableNames != null)
            {
                tableNames.AddRange(TableNames);
            }

            return tableNames;
        }
    }
}
