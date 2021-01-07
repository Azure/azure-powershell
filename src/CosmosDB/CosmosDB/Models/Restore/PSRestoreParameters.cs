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
using System.Collections.Generic;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSRestoreParameters
    {
        public PSRestoreParameters()
        {

        }

        public PSRestoreParameters(RestoreParameters restoreParameters)
        {
            if (restoreParameters == null)
            {
                return;
            }

            RestoreSource = restoreParameters.RestoreSource;
            RestoreTimestampInUtc = restoreParameters.RestoreTimestampInUtc ?? default(DateTime);
            if (restoreParameters.DatabasesToRestore?.Count > 0)
            {
                DatabasesToRestore = new PSDatabaseToRestore[restoreParameters.DatabasesToRestore.Count];
                for (int i = 0; i < restoreParameters.DatabasesToRestore.Count; i++)
                {
                    DatabasesToRestore[i] = new PSDatabaseToRestore(restoreParameters.DatabasesToRestore[i]);
                }
            }
        }

        /// <summary>
        /// Gets or sets path of the source account from which the restore has
        /// to be initiated
        /// </summary>
        public string RestoreSource { get; set; }

        /// <summary>
        /// Gets or sets time to which the account has to be restored (ISO-8601
        /// format).
        /// </summary>
        public DateTime RestoreTimestampInUtc { get; set; }

        /// <summary>
        /// Gets or sets array of specific databases to restore.
        /// </summary>
        public PSDatabaseToRestore[] DatabasesToRestore { get; set; }

        public RestoreParameters ToSDKModel()
        {
            RestoreParameters restoreParameters = new RestoreParameters()
            {
                RestoreMode = "PointInTime",
                RestoreSource = RestoreSource,
                RestoreTimestampInUtc = RestoreTimestampInUtc
            };

            if (DatabasesToRestore != null)
            {
                List<DatabaseRestoreResource> databasesToRestore = new List<DatabaseRestoreResource>();
                foreach (PSDatabaseToRestore database in DatabasesToRestore)
                {
                    databasesToRestore.Add(database.ToSDKModel());
                }

                restoreParameters.DatabasesToRestore = databasesToRestore;
            }

            return restoreParameters;
        }
    }
}
