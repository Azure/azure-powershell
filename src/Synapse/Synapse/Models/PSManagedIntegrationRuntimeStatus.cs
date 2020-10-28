using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSManagedIntegrationRuntimeStatus : PSManagedIntegrationRuntime
    {
        private readonly ManagedIntegrationRuntimeStatus _status;

        public PSManagedIntegrationRuntimeStatus(
            IntegrationRuntimeResource integrationRuntime,
            ManagedIntegrationRuntimeStatus status,
            string resourceGroupName,
            string workspaceName)
            : base(integrationRuntime, resourceGroupName, workspaceName)
        {
            _status = status;
        }

        public DateTime? CreateTime => _status.CreateTime;

        public IList<ManagedIntegrationRuntimeNode> Nodes => _status.Nodes;

        public IList<ManagedIntegrationRuntimeError> OtherErrors => _status.OtherErrors;

        public ManagedIntegrationRuntimeOperationResult LastOperation => _status.LastOperation;

        public new string State => _status.State;
    }
}
