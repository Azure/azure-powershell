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
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Get list of backup items from soft deleted vaults using Azure Resource Graph
    /// </summary>    
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesSoftDeletedVaultBackupItem"), OutputType(typeof(PSObject))]
    public class GetAzureRmRecoveryServicesSoftDeletedVaultBackupItem : RSBackupVaultCmdletBase
    {
        /// <summary>
        /// Name of the vault
        /// </summary>
        [Parameter(
            Mandatory = false,
            Position = 0,
            HelpMessage = "Name of the soft deleted recovery services vault")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Resource group name of the vault
        /// </summary>
        [Parameter(
            Mandatory = false,
            Position = 1,
            HelpMessage = "Resource group name of the soft deleted recovery services vault")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// ARM ID of the Recovery Services Vault (inherited from base class but redefined for clarity)
        /// </summary>
        [Parameter(
            Mandatory = false,
            Position = 2,
            HelpMessage = "ARM ID of the Recovery Services Vault")]
        [ValidateNotNullOrEmpty]
        public new string VaultId { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();                

                WriteVerbose($"Parameters provided - VaultName: {VaultName}, ResourceGroupName: {ResourceGroupName}, VaultId: {VaultId}");
                        
                if (string.IsNullOrEmpty(VaultId) && string.IsNullOrEmpty(VaultName))
                {
                    throw new PSArgumentException("At least one of VaultId or VaultName must be provided.", "VaultIdentification");
                }

                try
                {
                    // Get subscription - extract from VaultId if provided, otherwise use default from context
                    var subscriptions = new List<string>();
                    
                    if (!string.IsNullOrEmpty(VaultId))
                    {
                        Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(VaultId);
                        string subscriptionId = HelperUtils.GetSubscriptionIdFromId(keyValueDict, VaultId);
                        subscriptions.Add(subscriptionId);
                    }
                    else
                    {
                        var defaultSub = this.DefaultContext?.Subscription?.Id;
                        WriteVerbose($"DefaultContext Subscription ID: {defaultSub}");
                        
                        if (!string.IsNullOrEmpty(defaultSub))
                        {
                            subscriptions.Add(defaultSub);
                        }
                        else
                        {
                            throw new PSInvalidOperationException("No subscription context available and VaultId not provided. Please set a default subscription context or provide VaultId.");
                        }
                    }

                    // Build the KQL query dynamically based on input parameters
                    var query = @"Recoveryservicesresources
| where type == ""microsoft.recoveryservices/locations/deletedvaults/backupfabrics/protectioncontainers/protecteditems""
| extend dataSourceType = strcat(properties.backupManagementType, '/', properties.workloadType)";

                    // Add filtering based on provided parameters
                    if (!string.IsNullOrEmpty(VaultId))
                    {
                        query += $@"
| where tostring(id) contains ""{VaultId}""";
                    }
                    else if (!string.IsNullOrEmpty(VaultName))
                    {
                        if (!string.IsNullOrEmpty(ResourceGroupName))
                        {
                            query += $@"
| where tostring(id) contains ""{VaultName}"" and tostring(id) contains ""{ResourceGroupName}""";
                        }
                        else
                        {
                            query += $@"
| where tostring(id) contains ""{VaultName}""";
                        }
                    }

                    query += @"
| project id, type, name, location, resourceGroup, subscriptionId, dataSourceType, properties, tags";

                    WriteVerbose($"Generated ARG Query: {query}");

                    // Execute paginated ARG query
                    WriteVerbose("Starting ARG query execution");
                    var paginatedResult = ServiceClientAdapter.ExecuteResourceGraphQuery(
                        query: query,
                        subscriptions: subscriptions,
                        managementGroups: null,
                        pageSize: 1000,
                        maxPages: 50
                    );

                    // Handle warnings and errors from pagination
                    foreach (var warning in paginatedResult.Warnings)
                    {
                        WriteWarning(warning);
                    }

                    foreach (var error in paginatedResult.Errors)
                    {
                        WriteError(new ErrorRecord(error, "ARGPaginationError", ErrorCategory.InvalidOperation, null));
                    }

                    WriteVerbose($"ARG query completed. Pages retrieved: {paginatedResult.PagesRetrieved}, Total items: {paginatedResult.TotalRetrieved}");

                    // Handle results based on what was retrieved
                    if (paginatedResult.TotalRetrieved == 0)
                    {
                        WriteWarning("No backup items found in soft deleted vaults matching the specified criteria.");
                        return;
                    }

                    // Convert and output results
                    WriteVerbose($"Converting {paginatedResult.TotalRetrieved} raw ARG results to backup item models...");

                    try
                    {
                        // Convert ARG response to soft deleted backup item models
                        List<ItemBase> itemModels = ConversionHelpers.GetSoftDeletedItemsModelList(paginatedResult.Data);

                        WriteVerbose($"Successfully converted {itemModels.Count} out of {paginatedResult.TotalRetrieved} items to soft deleted backup item");

                        // Output the converted backup items
                        if (itemModels.Count > 0)
                        {
                            WriteVerbose($"Outputting {itemModels.Count} backup items...");
                            foreach (var backupItem in itemModels)
                            {
                                WriteObject(backupItem);
                            }
                        }
                        else
                        {
                            WriteWarning("Retrieved items from ARG but failed to convert them to backup item models. Check logs for conversion errors.");
                        }
                    }
                    catch (Exception conversionEx)
                    {
                        WriteError(new ErrorRecord(conversionEx, "ResultConversionError", 
                            ErrorCategory.InvalidData, paginatedResult.Data));
                    }
                }
                catch (System.Exception ex)
                {
                    WriteError(new ErrorRecord(ex, "QueryExecutionError",
                        ErrorCategory.InvalidOperation, null));
                }
            });
        }        
    }
}