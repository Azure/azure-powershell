
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Starts the replication that has been suspended.
.Description
The Resume-AzMigrateServerReplication starts the replication that has been suspended.
.Link
https://learn.microsoft.com/powershell/module/az.migrate/resume-azmigrateserverreplication
#>
function Resume-AzMigrateServerReplication {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.IJob])]
    [CmdletBinding(DefaultParameterSetName = 'ByIDVMwareCbt', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(ParameterSetName = 'ByIDVMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the replicating server for which the resume replication needs to be initiated. The ID should be retrieved using the Get-AzMigrateServerReplication cmdlet.
        ${TargetObjectID},

        [Parameter(ParameterSetName = 'ByInputObjectVMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.IMigrationItem]
        # Specifies the replicating server for which the resume replication needs to be initiated. The server object can be retrieved using the Get-AzMigrateServerReplication cmdlet
        ${InputObject},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        # Specifies whether the migrated resources needs to be deleted.
        ${DeleteMigratedResource},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # Azure Subscription ID.
        ${SubscriptionId},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Specifies whether the migrated resources needs to be deleted by Force.
        ${Force},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    
    process {
        if ($DeleteMigratedResource.IsPresent) {
            $PerformDeleteResource = "true"
        }
        else {
            $PerformDeleteResource = "false"
        }

        $null = $PSBoundParameters.Remove('Force')
        $null = $PSBoundParameters.Remove('DeleteMigratedResource')
        $null = $PSBoundParameters.Remove('TargetObjectID')
        $null = $PSBoundParameters.Remove('ResourceGroupName')
        $null = $PSBoundParameters.Remove('ProjectName')
        $null = $PSBoundParameters.Remove('MachineName')
        $null = $PSBoundParameters.Remove('InputObject')
        $parameterSet = $PSCmdlet.ParameterSetName

        if ($parameterSet -eq 'ByInputObjectVMwareCbt') {
            $TargetObjectID = $InputObject.Id
        }
        $MachineIdArray = $TargetObjectID.Split("/")
        $ResourceGroupName = $MachineIdArray[4]
        $VaultName = $MachineIdArray[8]
        $FabricName = $MachineIdArray[10]
        $ProtectionContainerName = $MachineIdArray[12]
        $MachineName = $MachineIdArray[14]
            

        $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
        $null = $PSBoundParameters.Add("ResourceName", $VaultName)
        $null = $PSBoundParameters.Add("FabricName", $FabricName)
        $null = $PSBoundParameters.Add("MigrationItemName", $MachineName)
        $null = $PSBoundParameters.Add("ProtectionContainerName", $ProtectionContainerName)

        $ReplicationMigrationItem = Az.Migrate.internal\Get-AzMigrateReplicationMigrationItem @PSBoundParameters
        if ($ReplicationMigrationItem -and ($ReplicationMigrationItem.ProviderSpecificDetail.InstanceType -eq 'VMwarecbt') -and ($ReplicationMigrationItem.AllowedOperation -contains 'ResumeReplication')) {
            if ($PerformDeleteResource -eq "true") {
                if (($ReplicationMigrationItem.MigrationState -ne "MigrationSucceeded") -and `
                    ($ReplicationMigrationItem.MigrationState -ne "MigrationCompletedWithInformation") `
                    -and ($ReplicationMigrationItem.MigrationState -ne "MigrationPartiallySucceeded")) {
                        throw "Cannot delete migration resources as the VM has not been migrated."
                }
                elseif (!$Force.IsPresent) {
                    $data = @()
                    $data += [PSCustomObject]@{
                        ResourceName = $ReplicationMigrationItem.ProviderSpecificDetail.TargetVMName
                        ResourceType = "Virtual Machine"
                    }

                    $Disks = $ReplicationMigrationItem.ProviderSpecificDetail.ProtectedDisk
                    foreach ($disk in $Disks) {
                        $data += [PSCustomObject]@{
                            ResourceName = $disk.TargetDiskName
                            ResourceType = "Managed Disk"
                        }
                    }

                    $Nics = $ReplicationMigrationItem.ProviderSpecificDetail.VMNic
                    foreach ($nic in $Nics) {
                        $data += [PSCustomObject]@{
                            ResourceName = $nic.TargetNicName
                            ResourceType = "Network Interface"
                        }
                    }

                    Write-Host "The following resources will be deleted and it cannot be reverted."
                    $data | ft -AutoSize
                    $title = 'Confirm'
                    $question = 'Are you sure you want to perform this action?'
                    $choices  = '&Yes', '&No'

                    $decision = $Host.UI.PromptForChoice($title, $question, $choices, 1)

                    if ($decision -eq 1) {
                        return
                    }
                }
            }
            else
            {
                if ((($ReplicationMigrationItem.MigrationState -eq "MigrationSucceeded") -or `
                    ($ReplicationMigrationItem.MigrationState -eq "MigrationCompletedWithInformation") `
                    -or ($ReplicationMigrationItem.MigrationState -eq "MigrationPartiallySucceeded")) `
                    -and !$Force.IsPresent) {
                     Write-Host "The previously migrated resources (virtual machines, disks, and NICs) will not be deleted."
                     Write-Host "To avoid resource name conflicts, you can update the resource names before retrying migration."
                     $title = 'Confirm'
                     $question = 'Are you sure you want to continue?'
                     $choices  = '&Yes', '&No'

                     $decision = $Host.UI.PromptForChoice($title, $question, $choices, 1)

                     if ($decision -eq 1) {
                            return
                     }
                }

            }

            $ProviderSpecificDetailInput = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.VMwareCbtResumeReplicationInput]::new()
            $ProviderSpecificDetailInput.InstanceType = 'VMwareCbt'
            $ProviderSpecificDetailInput.DeleteMigrationResource = $PerformDeleteResource
            $null = $PSBoundParameters.Add('ProviderSpecificDetail', $ProviderSpecificDetailInput)
            $null = $PSBoundParameters.Add('NoWait', $true)
            $output = Az.Migrate.internal\Resume-AzMigrateReplicationMigrationItemReplication @PSBoundParameters
            $JobName = $output.Target.Split("/")[12].Split("?")[0]
            $null = $PSBoundParameters.Remove('NoWait')
            $null = $PSBoundParameters.Remove('ProviderSpecificDetail')
            $null = $PSBoundParameters.Remove("ResourceGroupName")
            $null = $PSBoundParameters.Remove("ResourceName")
            $null = $PSBoundParameters.Remove("FabricName")
            $null = $PSBoundParameters.Remove("MigrationItemName")
            $null = $PSBoundParameters.Remove("ProtectionContainerName")

            $null = $PSBoundParameters.Add('JobName', $JobName)
            $null = $PSBoundParameters.Add('ResourceName', $VaultName)
            $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)

            return Az.Migrate.internal\Get-AzMigrateReplicationJob @PSBoundParameters
        }
        else {
            throw "Operation Not supported"
        }
    }
}