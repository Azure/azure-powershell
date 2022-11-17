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

using Microsoft.Azure.Management.EventGrid.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.EventGrid.Models
{
    public class PSVerifiedPartner
    {
        public PSVerifiedPartner(VerifiedPartner verifiedPartner)
        {
            this.PartnerRegistrationImmutableId = verifiedPartner.PartnerRegistrationImmutableId;
            this.OrganizationName = verifiedPartner.OrganizationName;
            this.PartnerDisplayName = verifiedPartner.PartnerDisplayName;
            this.PartnerTopicDetails = verifiedPartner.PartnerTopicDetails;
            this.ProvisioningState = verifiedPartner.ProvisioningState;
            this.SystemData = verifiedPartner.SystemData;
        }

        public Guid? PartnerRegistrationImmutableId { get; set; }

        public string OrganizationName { get; set; }

        public string PartnerDisplayName { get; set; }

        public PartnerDetails PartnerTopicDetails { get; set; }

        public string ProvisioningState { get; set; }

        public SystemData SystemData { get; private set; }

        /// <summary>
        /// Return a string representation of this verified partner
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            return null;
        }
    }
}
