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

namespace Microsoft.Azure.Commands.Support.Models
{
    public class PSQuotaTicketDetail
    {
        /// <summary>
        /// Gets or sets this is the quota sub type for which the quota request
        /// is being made and is optional for some quota types.
        /// </summary>
        public string QuotaChangeRequestSubType { get; set; }

        /// <summary>
        /// Gets or sets quota change request version
        /// </summary>
        public string QuotaChangeRequestVersion { get; set; }

        /// <summary>
        /// Gets or sets quota change requests.
        /// </summary>
        public PSQuotaChangeRequest[] QuotaChangeRequests { get; set; }
    }
}
