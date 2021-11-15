using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSSshPublicKeyResourceList : PSSshPublicKeyResource
    {
        public PSSshPublicKeyResource ToPSSshPublicKeyResource()
        {
            return ComputeAutomationAutoMapperProfile.Mapper.Map<PSSshPublicKeyResource>(this);
        }
    }
}
