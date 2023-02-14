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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure.OData;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Gets the list of protection policies associated with this recovery services vault
    /// according to the filters passed via the cmdlet parameters.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupProtectionPolicy", DefaultParameterSetName = NoParamSet), OutputType(typeof(PolicyBase))]
    public class GetAzureRmRecoveryServicesBackupProtectionPolicy : RSBackupVaultCmdletBase
    {
        protected const string PolicyNameParamSet = "PolicyNameParamSet";
        protected const string WorkloadParamSet = "WorkloadParamSet";
        protected const string NoParamSet = "NoParamSet";
        protected const string WorkloadBackupMangementTypeParamSet = "WorkloadBackupManagementTypeParamSet";

        /// <summary>
        /// List of supported BackupManagementTypes for this cmdlet. Used in help text creation.
        /// </summary>
        private const string validBackupManagementTypes = "AzureVM, AzureStorage, AzureWorkload ";

        /// <summary>
        /// List of supported WorkloadTypes for this cmdlet. Used in help text creation.
        /// </summary>
        private const string validWorkloadTypes = "AzureVM, AzureFiles, MSSQL";

        /// <summary>
        /// Name of the policy to be fetched.
        /// </summary>
        [Parameter(ParameterSetName = PolicyNameParamSet, Position = 1,
            Mandatory = true, HelpMessage = ParamHelpMsgs.Policy.Name)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Workload type of the policy to be fetched
        /// </summary>
        [Parameter(ParameterSetName = WorkloadParamSet, Position = 2,
            Mandatory = true, HelpMessage = ParamHelpMsgs.Common.WorkloadType + validWorkloadTypes)]
        [Parameter(ParameterSetName = WorkloadBackupMangementTypeParamSet, Position = 2,
            Mandatory = true, HelpMessage = ParamHelpMsgs.Common.WorkloadType + validWorkloadTypes)]
        [ValidateNotNullOrEmpty]
        public WorkloadType? WorkloadType { get; set; }

        /// <summary>
        /// Backup management type of the policy to be fetched
        /// </summary>
        [Parameter(ParameterSetName = WorkloadBackupMangementTypeParamSet, Position = 3,
            Mandatory = true, HelpMessage = ParamHelpMsgs.Common.BackupManagementType + validBackupManagementTypes)]
        [ValidateNotNullOrEmpty]
        public BackupManagementType? BackupManagementType { get; set; }

        /// <summary>
        /// policy subtype filter. 
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.PolicySubType)]
        public PSPolicyType PolicySubType = 0;

        /// <summary>
        /// Parameter to list policies for which smart tiering is Enabled/Disabled. Allowed values are $true, $false. 
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Policy.IsSmartTieringEnabled)]
        public bool? IsArchiveSmartTieringEnabled { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                WriteDebug(string.Format("Input params - Name:{0}, " +
                                      "WorkloadType: {1}, BackupManagementType:{2}, " +
                                      "ParameterSetName: {3}",
                                      Name == null ? "NULL" : Name,
                                      WorkloadType.HasValue ? WorkloadType.ToString() : "NULL",
                                      BackupManagementType.HasValue ?
                                      BackupManagementType.ToString() : "NULL",
                                      this.ParameterSetName));

                if (ParameterSetName == PolicyNameParamSet)
                {
                    // validate policyName
                    PolicyCmdletHelpers.ValidateProtectionPolicyName(Name);

                    // query service
                    ServiceClientModel.ProtectionPolicyResource policy =
                        PolicyCmdletHelpers.GetProtectionPolicyByName(
                            Name,
                            ServiceClientAdapter,
                            vaultName: vaultName,
                            resourceGroupName: resourceGroupName);

                    if (policy == null)
                    {
                        throw new ArgumentException(string.Format(Resources.PolicyNotFoundException, Name));
                    }
                    WriteObject(ConversionHelpers.GetPolicyModel(policy));
                }
                else
                {
                    List<PolicyBase> policyList = new List<PolicyBase>();
                    string serviceClientProviderType = null;

                    switch (this.ParameterSetName)
                    {
                        case WorkloadParamSet:
                            if (WorkloadType == Models.WorkloadType.AzureVM)
                            {
                                serviceClientProviderType =
                                    ServiceClientHelpers.GetServiceClientProviderType(Models.WorkloadType.AzureVM);
                            }
                            else if (WorkloadType == Models.WorkloadType.AzureSQLDatabase)
                            {
                                serviceClientProviderType = ServiceClientHelpers.GetServiceClientProviderType(Models.WorkloadType.AzureSQLDatabase);
                            }
                            else if (WorkloadType == Models.WorkloadType.AzureFiles)
                            {
                                serviceClientProviderType = ServiceClientHelpers.GetServiceClientProviderType(Models.WorkloadType.AzureFiles);
                            }
                            else if (WorkloadType == Models.WorkloadType.MSSQL)
                            {
                                serviceClientProviderType = ServiceClientHelpers.GetServiceClientProviderType(Models.WorkloadType.MSSQL);
                            }
                            break;

                        case WorkloadBackupMangementTypeParamSet:
                    if( WorkloadType == Models.WorkloadType.AzureVM )
                        {
                        if( BackupManagementType != Models.BackupManagementType.AzureVM )
                            {
                            throw new ArgumentException(
                                Resources.AzureVMUnsupportedBackupManagementTypeException );
                            }
                        serviceClientProviderType = ServiceClientHelpers.
                            GetServiceClientProviderType( Models.WorkloadType.AzureVM );
                        }
                    else if( WorkloadType == Models.WorkloadType.AzureFiles )
                        {
                        if( BackupManagementType != Models.BackupManagementType.AzureStorage )
                            {
                            throw new ArgumentException(
                                Resources.AzureFileUnsupportedBackupManagementTypeException );
                            }
                        serviceClientProviderType =
                            ServiceClientHelpers.GetServiceClientProviderType(
                                Models.WorkloadType.AzureFiles );
                        }
                    else if( WorkloadType == Models.WorkloadType.MSSQL )
                        {
                        if( BackupManagementType != Models.BackupManagementType.AzureWorkload )
                            {
                            throw new ArgumentException(
                                Resources.AzureFileUnsupportedBackupManagementTypeException );
                            }
                        serviceClientProviderType =
                            ServiceClientHelpers.GetServiceClientProviderType(
                                Models.WorkloadType.MSSQL );
                        }
                    else
                        {
                        throw new ArgumentException( string.Format(
                            Resources.UnsupportedWorkloadBackupManagementTypeException,
                            WorkloadType.ToString(),
                            BackupManagementType.ToString() ) );
                        }
                            break;

                        default:
                            break;
                    }

                    var backupManagementTypeFilter = serviceClientProviderType;

                    ODataQuery<ServiceClientModel.ProtectionPolicyQueryObject> queryParams
                    = new ODataQuery<ServiceClientModel.ProtectionPolicyQueryObject>(
                    q => q.BackupManagementType == backupManagementTypeFilter);

                    WriteDebug("going to query service to get list of policies");
                    List<ServiceClientModel.ProtectionPolicyResource> respList =
                        ServiceClientAdapter.ListProtectionPolicy(
                            queryParams,
                            vaultName: vaultName,
                            resourceGroupName: resourceGroupName);
                    WriteDebug("Successfully got response from service");

                    policyList = ConversionHelpers.GetPolicyModelList(respList);
                    policyList = FilterPolicyBasedOnPolicyType(policyList, PolicySubType);
                    policyList = FilterPolicyBasedOnSmartTiering(policyList, IsArchiveSmartTieringEnabled);

                    WriteObject(policyList, enumerateCollection: true);
                }
            });            
        }

        /// <summary>
        /// filter policies based on policySubType
        /// </summary>
        /// <param name="policyList"></param>
        /// <param name="policySubType"></param>
        /// <returns></returns>
        public static List<PolicyBase> FilterPolicyBasedOnPolicyType (List<PolicyBase> policyList, PSPolicyType policySubType)
        {
            if (policySubType != 0)
            {
                policyList = policyList.Where(policy =>
                {
                    if (policy.GetType() == typeof(AzureVmPolicy))
                    {
                        return ((AzureVmPolicy)policy).PolicySubType == policySubType;
                    }
                    else if (policySubType == PSPolicyType.Enhanced)
                    {
                        return false;
                    }

                    return true;
                }).ToList();
            }

            return policyList;
        }

        /// <summary>
        /// filter policies for which smart tiering is Enabled/Disabled
        /// </summary>
        /// <param name="policyList"></param>
        /// <param name="MoveToArchiveTier"></param>
        /// <returns></returns>
        public static List<PolicyBase> FilterPolicyBasedOnSmartTiering(List<PolicyBase> policyList, bool? MoveToArchiveTier)
        {
            if (MoveToArchiveTier == true)
            {
                policyList = policyList.Where(policy =>
                {
                    if (policy.BackupManagementType == Models.BackupManagementType.AzureVM )
                    {
                        if (((AzureVmPolicy)policy).TieringPolicy != null)
                        {
                            return (((AzureVmPolicy)policy).TieringPolicy.TieringMode == TieringMode.TierAllEligible || ((AzureVmPolicy)policy).TieringPolicy.TieringMode == TieringMode.TierRecommended);
                        }
                    }
                    else if (policy.BackupManagementType == Models.BackupManagementType.AzureWorkload)
                    {
                        if (((AzureVmWorkloadPolicy)policy).FullBackupTieringPolicy != null)
                        {
                            return (((AzureVmWorkloadPolicy)policy).FullBackupTieringPolicy.TieringMode == TieringMode.TierAllEligible || ((AzureVmWorkloadPolicy)policy).FullBackupTieringPolicy.TieringMode == TieringMode.TierRecommended);
                        }
                    }
                    
                    return false;
                }).ToList();
            }
            else if (MoveToArchiveTier == false)
            {
                policyList = policyList.Where(policy =>
                {
                    if (policy.BackupManagementType == Models.BackupManagementType.AzureVM)
                    {
                        if (((AzureVmPolicy)policy).TieringPolicy != null)
                        {
                            return (((AzureVmPolicy)policy).TieringPolicy.TieringMode != TieringMode.TierAllEligible && ((AzureVmPolicy)policy).TieringPolicy.TieringMode != TieringMode.TierRecommended);
                        }                        
                    }
                    else if (policy.BackupManagementType == Models.BackupManagementType.AzureWorkload)
                    {
                        if (((AzureVmWorkloadPolicy)policy).FullBackupTieringPolicy != null)
                        {
                            return (((AzureVmWorkloadPolicy)policy).FullBackupTieringPolicy.TieringMode != TieringMode.TierAllEligible && ((AzureVmWorkloadPolicy)policy).FullBackupTieringPolicy.TieringMode != TieringMode.TierRecommended);
                        }
                    }

                    return true;
                }).ToList();
            }

            return policyList;
        }
    }
}
