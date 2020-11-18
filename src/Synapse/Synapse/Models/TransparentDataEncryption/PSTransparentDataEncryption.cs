using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public enum TransparentDataEncryptionStateType { Enabled, Disabled };

    public class PSTransparentDataEncryption
    {
        public PSTransparentDataEncryption(TransparentDataEncryption encryption,
            string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            this.ResourceGroupName = resourceGroupName;
            this.WorkspaceName = workspaceName;
            this.SqlPoolName = sqlPoolName;
            TransparentDataEncryptionStateType state = TransparentDataEncryptionStateType.Disabled;
            Enum.TryParse<TransparentDataEncryptionStateType>(encryption.Status?.ToString(), true, out state);
            this.State = state;
        }

        public string ResourceGroupName { get; set; }

        public string WorkspaceName { get; set; }

        public string SqlPoolName { get; set; }

        public TransparentDataEncryptionStateType State { get; set; }
    }
}
