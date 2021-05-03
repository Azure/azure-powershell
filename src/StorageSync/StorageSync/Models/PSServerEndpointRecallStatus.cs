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

namespace Microsoft.Azure.Commands.StorageSync.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class PSServerEndpointRecallStatus.
    /// </summary>
    public class PSServerEndpointRecallStatus
    {
        /// <summary>
        /// Gets or sets the last updated timestamp.
        /// </summary>
        /// <value>The last updated timestamp.</value>
        public DateTime? LastUpdatedTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the total count of recall errors.
        /// </summary>
        /// <value>The total count of recall errors.</value>
        public long? TotalRecallErrorsCount { get; set; }

        /// <summary>
        /// Gets or sets the list of recall errors.
        /// </summary>
        /// <value>The list of recall errors.</value>
        public IList<PSServerEndpointRecallError> RecallErrors { get; set; }
    }
}
