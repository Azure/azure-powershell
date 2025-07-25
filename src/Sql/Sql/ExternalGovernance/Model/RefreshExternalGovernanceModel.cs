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
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ExternalGovernance.Model
{
    public class RefreshExternalGovernanceModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the request id.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets or sets the queued time for the request.
        /// </summary>
        public string QueuedTime { get; set; }

        /// <summary>
        /// Gets or sets the request status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
