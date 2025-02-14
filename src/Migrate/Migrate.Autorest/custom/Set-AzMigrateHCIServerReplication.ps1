
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
Updates the target properties for the replicating server.
.Description
The Set-AzMigrateHCIServerReplication cmdlet updates the target properties for the replicating server.
.Link
https://learn.microsoft.com/powershell/module/az.migrate/set-azmigratehciserverreplication
#>
function Set-AzMigrateHCIServerReplication {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PreviewMessageAttribute("This cmdlet is using a preview API version and is subject to breaking change in a future release.")]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.IJobModel])]
    [CmdletBinding(DefaultParameterSetName = 'ById', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the replicating server for which the properties need to be updated. The ID should be retrieved using the Get-AzMigrateHCIServerReplication cmdlet.
        ${TargetObjectID},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Int32]
        # Specifies the number of CPU cores.
        ${TargetVMCPUCore},

        [Parameter()]
        [ValidateSet("true" , "false")]
        [ArgumentCompleter( { "true" , "false" })]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies if RAM is dynamic or not. 
        ${IsDynamicMemoryEnabled},
        
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.ProtectedItemDynamicMemoryConfig]
        # Specifies the dynamic memory configration of RAM.
        ${DynamicMemoryConfig},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Int64]
        # Specifies the target RAM size in MB. 
        ${TargetVMRam},
		
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.AzStackHCINicInput[]]
        # Specifies the nics on the source server to be included for replication.
        ${NicToInclude},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # The subscription Id.
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
        Import-Module $PSScriptRoot\Helper\AzStackHCICommonSettings.ps1
        Import-Module $PSScriptRoot\Helper\CommonHelper.ps1

        CheckResourcesModuleDependency
        
        $HasTargetVMCPUCore = $PSBoundParameters.ContainsKey('TargetVMCPUCore')
        $HasTargetVMRam = $PSBoundParameters.ContainsKey('TargetVMRam')
        $HasDynamicMemoryConfig = $PSBoundParameters.ContainsKey('DynamicMemoryConfig')
        $HasNicToInclude = $PSBoundParameters.ContainsKey('NicToInclude')
        $HasIsDynamicMemoryEnabled = $PSBoundParameters.ContainsKey('IsDynamicMemoryEnabled')
        if ($HasIsDynamicMemoryEnabled) {
            $isDynamicRamEnabled = [System.Convert]::ToBoolean($IsDynamicMemoryEnabled)
        }

        $null = $PSBoundParameters.Remove('TargetVMCPUCore')
        $null = $PSBoundParameters.Remove('IsDynamicMemoryEnabled')
        $null = $PSBoundParameters.Remove('DynamicMemoryConfig')
        $null = $PSBoundParameters.Remove('TargetVMRam')
        $null = $PSBoundParameters.Remove('NicToInclude')
        $null = $PSBoundParameters.Remove('TargetObjectID')
        $null = $PSBoundParameters.Remove('WhatIf')
        $null = $PSBoundParameters.Remove('Confirm')
        
        $ProtectedItemIdArray = $TargetObjectID.Split("/")
        $ResourceGroupName = $ProtectedItemIdArray[4]
        $VaultName = $ProtectedItemIdArray[8]
        $MachineName = $ProtectedItemIdArray[10]
      
        # Get existing Protected Item
        $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
        $null = $PSBoundParameters.Add("VaultName", $VaultName)
        $null = $PSBoundParameters.Add("Name", $MachineName)
      
        $ProtectedItem = InvokeAzMigrateGetCommandWithRetries `
            -CommandName 'Az.Migrate.Internal\Get-AzMigrateProtectedItem' `
            -Parameters $PSBoundParameters `
            -ErrorMessage "Replication item is not found with Id '$TargetObjectID'."
      
        $null = $PSBoundParameters.Remove("ResourceGroupName")
        $null = $PSBoundParameters.Remove("VaultName")
        $null = $PSBoundParameters.Remove("Name")
        
        $protectedItemProperties = $ProtectedItem.Property
        $customProperties = $protectedItemProperties.CustomProperty
        $MachineIdArray = $customProperties.FabricDiscoveryMachineId.Split("/")
        $SiteType = $MachineIdArray[7]
        $SiteName = $MachineIdArray[8]
       
        # No "DisableProtection" means IR has not been initiated
        # "CommitFailover" means migration has been completed
        if (!$protectedItemProperties.AllowedJob.Contains('DisableProtection') -or
            $protectedItemProperties.AllowedJob.Contains('CommitFailover')) {
            throw "Set server replication is not allowed for this item '$TargetObjectID' at the moment. Please check its status and try again later."
        }

        if ($SiteType -eq $SiteTypes.HyperVSites) {     
            $customPropertiesUpdate = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.HyperVToAzStackHCIProtectedItemModelCustomPropertiesUpdate]::new()
            $customPropertiesUpdate.InstanceType = $AzStackHCIInstanceTypes.HyperVToAzStackHCI
        }
        elseif ($SiteType -eq $SiteTypes.VMwareSites) {  
            $customPropertiesUpdate = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.VMwareToAzStackHCIProtectedItemModelCustomPropertiesUpdate]::new()
            $customPropertiesUpdate.InstanceType = $AzStackHCIInstanceTypes.VMwareToAzStackHCI
        }

        # Update target CPU core
        if ($HasTargetVMCPUCore) {
            if ($TargetVMCPUCore -le 0) {
                throw "Specify target CPU core greater than 0"    
            }

            $customPropertiesUpdate.TargetCpuCore = $TargetVMCPUCore
        }

        # Update VM Ram
        if ($HasTargetVMRam) {
            if ($TargetVMRam -le 0) {
                throw "Specify target RAM greater than 0"    
            }

            $customPropertiesUpdate.TargetMemoryInMegaByte = $TargetVMRam
        }
        $targetMemory = $customPropertiesUpdate.TargetMemoryInMegaByte -or $customProperties.TargetMemoryInMegaByte

        # Update IsDynamicRam 
        if ($HasIsDynamicMemoryEnabled) {
            $customPropertiesUpdate.IsDynamicRam = $isDynamicRamEnabled
        }
        elseif ($HasDynamicMemoryConfig) {
            $customPropertiesUpdate.IsDynamicRam = $customProperties.IsDynamicRam
        }

        # Dynamic memory is enabled - set provided configuration
        if ($customPropertiesUpdate.IsDynamicRam -and $HasDynamicMemoryConfig) {
            if ($targetMemory -lt $DynamicMemoryConfig.MinimumMemoryInMegaByte) {
                throw "DynamicMemoryConfig - Specify minimum memory less than $($targetMemory)"
            }
          
            if ($targetMemory -gt $DynamicMemoryConfig.MaximumMemoryInMegaByte) {
                throw "DynamicMemoryConfig - Specify maximum memory greater than $($targetMemory)"
            }

            if ($DynamicMemoryConfig.TargetMemoryBufferPercentage -NotIn $RAMConfig.MinTargetMemoryBufferPercentage..$RAMConfig.MaxTargetMemoryBufferPercentage)
            {
                throw "DynamicMemoryConfig - Specify target memory buffer percentage between $($RAMConfig.MinTargetMemoryBufferPercentage) % and $($RAMConfig.MaxTargetMemoryBufferPercentage) %."
            }

            $customPropertiesUpdate.DynamicMemoryConfig = $DynamicMemoryConfig
        }

        # Dynamic memory is enabled - set default configuration
        if ($customPropertiesUpdate.IsDynamicRam -and !$HasDynamicMemoryConfig) {
            if ($null -eq $customProperties.DynamicMemoryConfig) {
                $memoryConfig = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.ProtectedItemDynamicMemoryConfig]::new()
                $memoryConfig.MinimumMemoryInMegaByte = [System.Math]::Min($targetMemory, $RAMConfig.DefaultMinDynamicMemoryInMB)
                $memoryConfig.MaximumMemoryInMegaByte = [System.Math]::Max($targetMemory, $RAMConfig.DefaultMaxDynamicMemoryInMB)
                $memoryConfig.TargetMemoryBufferPercentage = $RAMConfig.DefaultTargetMemoryBufferPercentage
                $customPropertiesUpdate.DynamicMemoryConfig = $memoryConfig
            }
            else {
                $customPropertiesUpdate.DynamicMemoryConfig = $customProperties.DynamicMemoryConfig
            }
        }
        
        # Update Nics
        if ($HasNicToInclude -and $NicToInclude.length -gt 0) {
            # Get discovered machine
            $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
            $null = $PSBoundParameters.Add("SiteName", $SiteName)
            $null = $PSBoundParameters.Add("MachineName", $MachineName)
            
            if ($SiteType -eq $SiteTypes.HyperVSites) {
                $machine = InvokeAzMigrateGetCommandWithRetries `
                    -CommandName 'Az.Migrate.Internal\Get-AzMigrateHyperVMachine' `
                    -Parameters $PSBoundParameters `
                    -ErrorMessage "Machine '$MachineName' not found in resource group '$ResourceGroupName' and site '$SiteName'."
            }
            elseif ($SiteType -eq $SiteTypes.VMwareSites) {
                $machine = InvokeAzMigrateGetCommandWithRetries `
                    -CommandName 'Az.Migrate.Internal\Get-AzMigrateMachine' `
                    -Parameters $PSBoundParameters `
                    -ErrorMessage "Machine '$MachineName' not found in resource group '$ResourceGroupName' and site '$SiteName'."
            }

            $null = $PSBoundParameters.Remove("ResourceGroupName")
            $null = $PSBoundParameters.Remove("SiteName")
            $null = $PSBoundParameters.Remove("MachineName")
            
            # Nics
            [PSCustomObject[]]$nics = @()
            [PSCustomObject[]]$uniqueNics = @()
            foreach ($nic in $NicToInclude) {
                $discoveredNic = $machine.NetworkAdapter | Where-Object { $_.NicId -eq $nic.NicId }
                if ($null -eq $discoveredNic) {
                    throw "The Nic id '$($nic.NicId)' is not found."
                }

                if ($uniqueNics.Contains($nic.NicId)) {
                    throw "The Nic id '$($nic.NicId)' is already included. Please remove the duplicate entry and try again."
                }

                $uniqueNics += $nic.NicId
                
                $htNic = @{}
                $nic.PSObject.Properties | ForEach-Object { $htNic[$_.Name] = $_.Value }

                if ($htNic.SelectionTypeForFailover -eq $VMNicSelection.SelectedByUser -and
                    [string]::IsNullOrEmpty($htNic.TargetNetworkId)) {
                    throw "The TargetVirtualSwitchId parameter is required when the CreateAtTarget flag is set to 'true'. NIC '$($htNic.NicId)'. Please utilize the New-AzMigrateHCINicMappingObject command to properly create a Nic mapping object."
                }

                $nics += [PSCustomObject]$htNic
            }

            if ($SiteType -eq $SiteTypes.HyperVSites) {     
                $customPropertiesUpdate.NicsToInclude = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.HyperVToAzStackHCINicInput[]]$nics
            }
            elseif ($SiteType -eq $SiteTypes.VMwareSites) {     
                $customPropertiesUpdate.NicsToInclude = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.VMwareToAzStackHCINicInput[]]$nics
            }
        }

        $protectedItemPropertiesUpdate = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.ProtectedItemModelPropertiesUpdate]::new()
        $protectedItemPropertiesUpdate.CustomProperty = $customPropertiesUpdate

        $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
        $null = $PSBoundParameters.Add('VaultName', $vaultName)
        $null = $PSBoundParameters.Add('Name', $MachineName)
        $null = $PSBoundParameters.Add('Property', $protectedItemPropertiesUpdate)
        $null = $PSBoundParameters.Add('NoWait', $true)
        
        if ($PSCmdlet.ShouldProcess($TargetObjectID, "Updates VM replication.")) {
            $operation = Az.Migrate.Internal\Update-AzMigrateProtectedItem @PSBoundParameters
            $jobName = $operation.Target.Split("/")[-1].Split("?")[0].Split("_")[0]
            
            $null = $PSBoundParameters.Remove('Name')  
            $null = $PSBoundParameters.Remove('Property')
            $null = $PSBoundParameters.Remove('NoWait')

            $null = $PSBoundParameters.Add('JobName', $jobName)
            return Az.Migrate.Internal\Get-AzMigrateHCIReplicationJob @PSBoundParameters
        }
    }
}   