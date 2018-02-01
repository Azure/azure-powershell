using System;
using Microsoft.Azure.Management.ManagementPartner.Models;

namespace Microsoft.Azure.Commands.Resources
{
    class PSManagementPartner
    {
        public string PartnerId { get; set; }
        public string TenantId { get; set; }
        public string ObjectId { get; set; }
        public string State { get; set; }

        public PSManagementPartner(PartnerResponse partnerResponse)
        {
            PartnerId = partnerResponse.PartnerId;
            TenantId = partnerResponse.TenantId;
            ObjectId = partnerResponse.ObjectId;
            State = partnerResponse.State;
        }
    }
}
