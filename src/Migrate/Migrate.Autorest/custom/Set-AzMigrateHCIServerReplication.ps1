
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
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.IWorkflowModel])]
    [CmdletBinding(DefaultParameterSetName = 'ById', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the replicating server for which the properties need to be updated. The ID should be retrieved using the Get-AzMigrateHCIServerReplication cmdlet.
        ${TargetObjectID},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the target VM name.
        ${TargetVMName},

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
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemDynamicMemoryConfig]
        # Specifies the dynamic memory configration of RAM.
        ${DynamicMemoryConfig},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Int64]
        # Specifies the target RAM size in MB. 
        ${TargetVMRam},
		
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.AzStackHCINicInput[]]
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
        
        $HasTargetVMName = $PSBoundParameters.ContainsKey('TargetVMName')
        $HasTargetVMCPUCore = $PSBoundParameters.ContainsKey('TargetVMCPUCore')
        $HasIsDynamicMemoryEnabled = $PSBoundParameters.ContainsKey('IsDynamicMemoryEnabled')
        if ($HasIsDynamicMemoryEnabled) {
            $isDynamicRamEnabled = [System.Convert]::ToBoolean($IsDynamicMemoryEnabled)
        }
        $HasDynamicMemoryConfig = $PSBoundParameters.ContainsKey('DynamicMemoryConfig')
        $HasTargetVMRam = $PSBoundParameters.ContainsKey('TargetVMRam')
        $HasNicToInclude = $PSBoundParameters.ContainsKey('NicToInclude')

        $null = $PSBoundParameters.Remove('TargetVMName')
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
       
        # No "DisableProtection" means IR has not been initiated
        # "CommitFailover" means migration has been completed
        if (!$protectedItemProperties.AllowedJob.Contains('DisableProtection') -or
            $protectedItemProperties.AllowedJob.Contains('CommitFailover')) {
            throw "Set server replication is not allowed for this item '$TargetObjectID' at the moment. Please check its status and try again later."
        }

        if ($HasTargetVMName) {
            if ($TargetVMName.length -gt 64 -or $TargetVMName.length -eq 0) {
                throw "The target virtual machine name must be between 1 and 64 characters long."
            }

            Import-Module Az.Resources
            $vmId = $customProperties.TargetResourceGroupId + "/providers/Microsoft.Compute/virtualMachines/" + $TargetVMName
            $VMNamePresentInRg = Get-AzResource -ResourceId $vmId -ErrorVariable notPresent -ErrorAction SilentlyContinue
            if ($VMNamePresentInRg) {
                throw "The target virtual machine name must be unique in the target resource group."
            }
    
            if ($TargetVMName -notmatch "^[^_\W][a-zA-Z0-9\-]{0,63}(?<![-._])$") {
                throw "The target virtual machine name must begin with a letter or number, and can contain only letters, numbers, or hyphens(-). The names cannot contain special characters \/""[]:|<>+=;,?*@&, whitespace, or begin with '_' or end with '.' or '-'."
            }

            if (IsReservedOrTrademarked($TargetVMName)) {
                throw "The target virtual machine name '$TargetVMName' or part of the name is a trademarked or reserved word."
            }

            $customProperties.TargetVMName = $TargetVMName
        }

        if ($HasTargetVMCPUCore) {
            if ($TargetVMCPUCore -le 0) {
                throw "Specify target CPU core greater than 0"    
            }

            $customProperties.TargetCpuCore = $TargetVMCPUCore
        }

        # Validate TargetVMRam
        if ($HasTargetVMRam) {
            if ($TargetVMRam -le 0) {
                throw "Specify target RAM greater than 0"    
            }

            $customProperties.TargetMemoryInMegaByte = $TargetVMRam
        }
        
        if ($HasIsDynamicMemoryEnabled) {
            $customProperties.IsDynamicRam = $isDynamicRamEnabled
        }

        # Dynamic memory enabled & DynamicMemoryConfig supplied
        if ($customProperties.IsDynamicRam -and $HasDynamicMemoryConfig) {
            if ($customProperties.TargetMemoryInMegaByte -lt $DynamicMemoryConfig.MinimumMemoryInMegaByte) {
                throw "DynamicMemoryConfig - Specify minimum memory less than $($customProperties.TargetMemoryInMegaByte)"
            }
          
            if ($customProperties.TargetMemoryInMegaByte -gt $DynamicMemoryConfig.MaximumMemoryInMegaByte) {
                throw "DynamicMemoryConfig - Specify maximum memory greater than $($customProperties.TargetMemoryInMegaByte)"
            }

            if ($DynamicMemoryConfig.TargetMemoryBufferPercentage -NotIn $RAMConfig.MinTargetMemoryBufferPercentage..$RAMConfig.MaxTargetMemoryBufferPercentage)
            {
                throw "DynamicMemoryConfig - Specify target memory buffer percentage between $($RAMConfig.MinTargetMemoryBufferPercentage) % and $($RAMConfig.MaxTargetMemoryBufferPercentage) %."
            }

            $customProperties.DynamicMemoryConfig = $DynamicMemoryConfig
        }

        # Dynamic memory is newly enabled and needs a default
        if ($customProperties.IsDynamicRam -and $null -eq $customProperties.DynamicMemoryConfig) {
            $memoryConfig = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemDynamicMemoryConfig]::new()
            $memoryConfig.MinimumMemoryInMegaByte = [System.Math]::Min($customProperties.TargetMemoryInMegaByte, $RAMConfig.DefaultMinDynamicMemoryInMB)
            $memoryConfig.MaximumMemoryInMegaByte = [System.Math]::Max($customProperties.TargetMemoryInMegaByte, $RAMConfig.DefaultMaxDynamicMemoryInMB)
            $memoryConfig.TargetMemoryBufferPercentage = $RAMConfig.DefaultTargetMemoryBufferPercentage
    
            $customProperties.DynamicMemoryConfig = $memoryConfig
        }

        # Nics
        [PSCustomObject[]]$nics = @()
        foreach ($nic in $customProperties.ProtectedNic) {
            $NicObject = [PSCustomObject]@{
                NicId                    = $nic.NicId
                TargetNetworkId          = $nic.TargetNetworkId
                TestNetworkId            = $nic.TestNetworkId
                SelectionTypeForFailover = $nic.SelectionTypeForFailover
            }
          
            $nics += $NicObject
        }

        if ($HasNicToInclude -and $NicToInclude.length -gt 0) {
            foreach ($nic in $NicToInclude)
            {
                $updatedNic = $nics | Where-Object { $_.NicId -eq $nic.NicId }
                if ($null -eq $updatedNic){
                    throw "The Nic id '$($nic.NicId)' is not found."
                }

                if ($nic.SelectionTypeForFailover -eq $VMNicSelection.SelectedByUser -and
                    [string]::IsNullOrEmpty($nic.TargetNetworkId)) {
                    throw "TargetVirtualSwitchId is required when the NIC '$($nic.NicId)' is to be CreateAtTarget. Please utilize the New-AzMigrateHCINicMappingObject command to properly create a Nic mapping object."
                }
                
                $updatedNic.TargetNetworkId            = $nic.TargetNetworkId
                $updatedNic.TestNetworkId              = $nic.TestNetworkId 
                $updatedNic.SelectionTypeForFailover   = $nic.SelectionTypeForFailover
            }
        }

        # Disks
        [PSCustomObject[]]$disks = @()
        foreach ($disk in $customProperties.ProtectedDisk) {
            $DiskObject = [PSCustomObject]@{
                DiskId          = $disk.SourceDiskId
                DiskSizeGb      = [long] [Math]::Ceiling($disk.CapacityInByte/1GB)
                DiskFileFormat  = $disk.DiskType
                IsDynamic       = $disk.IsDynamic
                IsOSDisk        = $disk.IsOSDisk
            }
            
            $disks += $DiskObject
        }

        if ($SiteType -eq $SiteTypes.HyperVSites) {
            $customProperties.DisksToInclude = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.HyperVToAzStackHCIDiskInput[]]$disks
            $customProperties.NicsToInclude = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.HyperVToAzStackHCINicInput[]]$nics
        }
        elseif ($SiteType -eq $SiteTypes.VMwareSites) {
            $customProperties.DisksToInclude = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.VMwareToAzStackHCIDiskInput[]]$disks
            $customProperties.NicsToInclude = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.VMwareToAzStackHCINicInput[]]$nics     
        }

        $protectedItemProperties.CustomProperty = $customProperties

        $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
        $null = $PSBoundParameters.Add('VaultName', $vaultName)
        $null = $PSBoundParameters.Add('Name', $MachineName)
        $null = $PSBoundParameters.Add('Property', $protectedItemProperties)
        $null = $PSBoundParameters.Add('NoWait', $true)
        
        if ($PSCmdlet.ShouldProcess($TargetObjectID, "Updates VM replication.")) {
            $operation = Az.Migrate.Internal\New-AzMigrateProtectedItem @PSBoundParameters
            $jobName = $operation.Target.Split("/")[-1].Split("?")[0]
            
            $null = $PSBoundParameters.Remove('Name')  
            $null = $PSBoundParameters.Remove('Property')
            $null = $PSBoundParameters.Remove('NoWait')

            $null = $PSBoundParameters.Add('JobName', $jobName)
            return Az.Migrate.Internal\Get-AzMigrateWorkflow @PSBoundParameters
        }
    }
}   