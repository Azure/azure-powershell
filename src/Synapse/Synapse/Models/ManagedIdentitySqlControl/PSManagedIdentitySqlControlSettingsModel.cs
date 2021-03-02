using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSManagedIdentitySqlControlSettingsModel : PSSynapseResource
    {
        public PSManagedIdentitySqlControlSettingsModel(ManagedIdentitySqlControlSettingsModel model)
            :base(model?.Id, model?.Name, model?.Type)
        {
            this.DesiredState = model?.GrantSqlControlToManagedIdentity?.DesiredState;
            this.ActualState = model?.GrantSqlControlToManagedIdentity?.ActualState;
        }

        public string DesiredState { get; set; }

        public string ActualState { get; }
    }
}
