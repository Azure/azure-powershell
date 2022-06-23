using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CrrModel = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using AzureRestNS = Microsoft.Rest.Azure;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    public abstract class RSBackupVaultCmdletBase : RecoveryServicesBackupCmdletBase
    {
        /// <summary>
        /// ARM ID of the Recovery Services Vault.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "ARM ID of the Recovery Services Vault.",
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string VaultId { get; set; }

        /// <summary>
        /// Get the job PS model after fetching the job object from the service given the job ID.
        /// </summary>
        /// <param name="jobId">ID of the job to be fetched</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        public CmdletModel.JobBase GetJobObject(string jobId, string vaultName = null, string resourceGroupName = null)
        {
            return JobConversions.GetPSJob(ServiceClientAdapter.GetJob(
                jobId,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName));
        }

        /// <summary>
        /// Gets list of job PS models after fetching the job objects from the service given the list of job IDs.
        /// </summary>
        /// <param name="jobIds">List of IDs of jobs to be fetched</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        public List<CmdletModel.JobBase> GetJobObject(IList<string> jobIds, string vaultName = null, string resourceGroupName = null)
        {
            List<CmdletModel.JobBase> result = new List<CmdletModel.JobBase>();
            foreach (string jobId in jobIds)
            {
                result.Add(GetJobObject(
                    jobId,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName));
            }
            return result;
        }

        /// <summary>
        /// Get the job PS model after fetching the job object from the service given the job ID.
        /// </summary>
        /// <param name="secondaryRegion"></param>
        /// <param name="vaultId"></param>
        /// <param name="jobId">ID of the job to be fetched</param>
        /// <returns></returns>
        public CmdletModel.JobBase GetCrrJobObject(string secondaryRegion, string vaultId, string jobId)
        {
            CrrModel.CrrJobRequest jobRequest = new CrrModel.CrrJobRequest();
            jobRequest.JobName = jobId;
            jobRequest.ResourceId = vaultId;
                        
            JobBase job = JobConversions.GetPSJobCrr(ServiceClientAdapter.GetCRRJobDetails(
                secondaryRegion,
                jobRequest));

            return job;
        }

        /// <summary>
        /// Based on the response from the service, handles the job created in the service appropriately.
        /// </summary>
        /// <param name="response">Response from service</param>
        /// <param name="operationName">Name of the operation</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        protected void HandleCreatedJob(
            AzureRestNS.AzureOperationResponse response,
            string operationName,
            string vaultName = null,
            string resourceGroupName = null)
        {
            WriteDebug(Resources.TrackingOperationStatusURLForCompletion +
                            response.Response.Headers.GetAzureAsyncOperationHeader());

            var operationStatus = TrackingHelpers.GetOperationStatus(
                response,
                operationId => ServiceClientAdapter.GetProtectedItemOperationStatus(
                    operationId,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName));

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
                        WriteObject(GetJobObject(
                            jobStatusResponse.JobId,
                            vaultName: vaultName,
                            resourceGroupName: resourceGroupName));
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

        protected void HandleCreatedJob(
            AzureRestNS.AzureOperationResponse<ProtectedItemResource> response,
            string operationName,
            string vaultName = null,
            string resourceGroupName = null)
        {
            WriteDebug(Resources.TrackingOperationStatusURLForCompletion +
                            response.Response.Headers.GetAzureAsyncOperationHeader());

            var operationStatus = TrackingHelpers.GetOperationStatus(
                response,
                operationId => ServiceClientAdapter.GetProtectedItemOperationStatus(
                    operationId,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName));

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
                        WriteObject(GetJobObject(
                            jobStatusResponse.JobId,
                            vaultName: vaultName,
                            resourceGroupName: resourceGroupName));
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
