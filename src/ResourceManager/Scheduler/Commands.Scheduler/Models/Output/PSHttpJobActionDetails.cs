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

namespace Microsoft.Azure.Commands.Scheduler.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using SchedulerModels = Microsoft.Azure.Management.Scheduler.Models;

    public class PSHttpJobActionDetails : PSJobActionDetails
    {
        /// <summary>
        /// Gets or sets request http method. (GET, PUT, POST, DELETE).
        /// </summary>
        public string RequestMethod { get; set; }

        /// <summary>
        /// Gets or sets Uri.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets request body.
        /// </summary>
        public string RequestBody { get; set; }

        /// <summary>
        /// Gets or sets request headers.
        /// </summary>
        public IDictionary<string, string> RequestHeaders { get; set; }

        /// <summary>
        /// Gets or sets http authentication type. (None, Basic, ClientCertificate, ActiveDirectoryOAuth)
        /// </summary>
        public PSHttpJobAuthenticationDetails HttpJobAuthentication { get; set; }

        public PSHttpJobActionDetails(SchedulerModels.JobActionType jobActionType)
        {
            if (jobActionType != SchedulerModels.JobActionType.Http &&
                jobActionType != SchedulerModels.JobActionType.Https)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.JobActionType = jobActionType;
        }
    }
}
