using Azure.Security.KeyVault.Administration;
using System;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultEkmPrivateEndpointOperation
    {
        public string HsmName { get; set; }
        public string JobId { get; set; }
        public string PrivateEndpointName { get; set; }
        public string OperationType { get; set; }
        public string Status { get; set; }
        public string StatusDetails { get; set; }
        public DateTimeOffset? StartsOn { get; set; }
        public DateTimeOffset? EndsOn { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public PSKeyVaultEkmPrivateEndpointOperation() { }

        internal PSKeyVaultEkmPrivateEndpointOperation(KeyVaultEkmPrivateEndpointOperation operation, string hsmName)
        {
            HsmName = hsmName;
            JobId = operation.JobId;
            PrivateEndpointName = operation.PrivateEndpointName;
            OperationType = operation.OperationType?.ToString();
            Status = operation.Status?.ToString();
            StatusDetails = operation.StatusDetails;
            StartsOn = operation.StartsOn;
            EndsOn = operation.EndsOn;
            ErrorCode = operation.ErrorCode;
            ErrorMessage = operation.ErrorMessage;
        }
    }
}