using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using AzureRestNS = Microsoft.Rest.Azure;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    public abstract class RSBackupVaultCmdletBase : RecoveryServicesBackupCmdletBase
    {
        /// <summary>
        /// The Recovery Services Vault.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The Recovery Services Vault.",
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ARSVault Vault { get; set; }

        /// <summary>
        /// Get the job PS model after fetching the job object from the service given the job ID.
        /// </summary>
        /// <param name="jobId">ID of the job to be fetched</param>
        /// <returns></returns>
        public CmdletModel.JobBase GetJobObject(string jobId, ARSVault vault = null)
        {
            return JobConversions.GetPSJob(ServiceClientAdapter.GetJob(
                jobId,
                vaultName: vault?.Name,
                resourceGroupName: vault?.ResourceGroupName));
        }

        /// <summary>
        /// Gets list of job PS models after fetching the job objects from the service given the list of job IDs.
        /// </summary>
        /// <param name="jobIds">List of IDs of jobs to be fetched</param>
        /// <returns></returns>
        public List<CmdletModel.JobBase> GetJobObject(IList<string> jobIds, ARSVault vault = null)
        {
            List<CmdletModel.JobBase> result = new List<CmdletModel.JobBase>();
            foreach (string jobId in jobIds)
            {
                result.Add(GetJobObject(jobId, vault));
            }
            return result;
        }

        /// <summary>
        /// Based on the response from the service, handles the job created in the service appropriately.
        /// </summary>
        /// <param name="response">Response from service</param>
        /// <param name="operationName">Name of the operation</param>
        protected void HandleCreatedJob(
            AzureRestNS.AzureOperationResponse response,
            string operationName,
            ARSVault vault = null)
        {
            WriteDebug(Resources.TrackingOperationStatusURLForCompletion +
                            response.Response.Headers.GetAzureAsyncOperationHeader());

            var operationStatus = TrackingHelpers.GetOperationStatus(
                response,
                operationId => ServiceClientAdapter.GetProtectedItemOperationStatus(
                    operationId,
                    vaultName: vault?.Name,
                    resourceGroupName: vault?.ResourceGroupName));

            if (response != null && operationStatus != null)
            {
                WriteDebug(Resources.FinalOperationStatus + operationStatus.Status);

                if (operationStatus.Properties != null)
                {
                    var jobExtendedInfo =
                        (OperationStatusJobExtendedInfo)operationStatus.Properties;

                    if (jobExtendedInfo.JobId != null)
                    {
                        var jobStatusResponse =
                            (OperationStatusJobExtendedInfo)operationStatus.Properties;
                        WriteObject(GetJobObject(jobStatusResponse.JobId, vault: vault));
                    }
                }

                if (operationStatus.Status == OperationStatusValues.Failed &&
                    operationStatus.Error != null)
                {
                    var errorMessage = string.Format(
                        Resources.OperationFailed,
                        operationName,
                        operationStatus.Error.Code,
                        operationStatus.Error.Message);
                    throw new Exception(errorMessage);
                }
            }
        }
    }
}
