
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
    [CmdletBinding(DefaultParameterSetName = 'ById', PositionalBinding = $false)]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the replicating server for which the properties need to be updated. The ID should be retrieved using the Get-AzMigrateServerReplication cmdlet.
        ${TargetObjectID},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the replcating server for which the properties need to be updated. The ID should be retrieved using the Get-AzMigrateServerReplication cmdlet.
        ${TargetVMName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Int32]
        # Specifies the number of CPU cores.
        ${TargetVMCPUCores},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the virtual switch to use. 
        ${TargetVirtualSwitch},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Boolean]
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
        Import-Module $PSScriptRoot\AzStackHCICommonSettings.ps1
        
        $HasTargetVMName = $PSBoundParameters.ContainsKey('TargetVMName')
        $HasTargetVMCPUCores = $PSBoundParameters.ContainsKey('TargetVMCPUCores')
        $HasTargetVirtualSwitch = $PSBoundParameters.ContainsKey('TargetVirtualSwitch')
        $HasIsDynamicMemoryEnabled = $PSBoundParameters.ContainsKey('IsDynamicMemoryEnabled')
        $HasDynamicMemoryConfig = $PSBoundParameters.ContainsKey('DynamicMemoryConfig')
        $HasTargetVMRam = $PSBoundParameters.ContainsKey('TargetVMRam')
        $HasNicToInclude = $PSBoundParameters.ContainsKey('NicToInclude')

        $null = $PSBoundParameters.Remove('TargetVMName')
        $null = $PSBoundParameters.Remove('TargetVMCPUCores')
        $null = $PSBoundParameters.Remove('TargetVirtualSwitch')
        $null = $PSBoundParameters.Remove('IsDynamicMemoryEnabled')
        $null = $PSBoundParameters.Remove('DynamicMemoryConfig')
        $null = $PSBoundParameters.Remove('TargetVMRam')
        $null = $PSBoundParameters.Remove('NicToInclude')
        $null = $PSBoundParameters.Remove('TargetObjectID')
        
        $ProtectedItemIdArray = $TargetObjectID.Split("/")
        $ResourceGroupName = $ProtectedItemIdArray[4]
        $VaultName = $ProtectedItemIdArray[8]
        $MachineName = $ProtectedItemIdArray[10]
        
        $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
        $null = $PSBoundParameters.Add("VaultName", $VaultName)
        $null = $PSBoundParameters.Add("Name", $MachineName)

        $ProtectedItem = Az.Migrate.Internal\Get-AzMigrateProtectedItem @PSBoundParameters
      
        $null = $PSBoundParameters.Remove("ResourceGroupName")
        $null = $PSBoundParameters.Remove("VaultName")
        $null = $PSBoundParameters.Remove("Name")
        
        $protectedItemProperties = $ProtectedItem.Property
        $customProperties = $protectedItemProperties.CustomProperty
        $MachineIdArray = $customProperties.FabricDiscoveryMachineId.Split("/")
        $SiteType = $MachineIdArray[7]
        $SiteName = $MachineIdArray[8]
       
        if ($HasTargetVMName) {
            Import-Module Az.Resources
            $vmId = $customProperties.TargetResourceGroupId + "/providers/Microsoft.Compute/virtualMachines/" + $TargetVMName
            $VMNamePresentInRg = Get-AzResource -ResourceId $vmId -ErrorVariable notPresent -ErrorAction SilentlyContinue
            if ($VMNamePresentInRg) {
                throw "The target virtual machine name must be unique in the target resource group."
            }
    
            if ($TargetVMName -notmatch "^[^_\W][a-zA-Z0-9\-]{0,63}(?<![-._])$") {
                throw "The target virtual machine name must begin with a letter or number, and can contain only letters, numbers, or hyphens(-). The names cannot contain special characters \/""[]:|<>+=;,?*@&, whitespace, or begin with '_' or end with '.' or '-'."
            }

            $customProperties.TargetVMName = $TargetVMName
        }

        if ($HasTargetVMCPUCores) {
            $customProperties.TargetCpuCore = $TargetVMCPUCores
        }

        if ($HasTargetVirtualSwitch) {
            $customProperties.TargetVirtualSwitch = $TargetVirtualSwitch
        }

        # Memory
        if ($HasIsDynamicMemoryEnabled) {
            $customProperties.IsDynamicRam = $IsDynamicMemoryEnabled
        }

        if (!$customProperties.IsDynamicRam -and $HasTargetVMRam) {
            if (!($TargetVMRam -In $RAMConfig.MinMemoryInMB..$RAMConfig.MaxMemoryInMB)) {
                throw "Specify RAM between $($RAMConfig.MinMemoryInMB) and $($RAMConfig.MaxMemoryInMB)"
            }

            if ($TargetVMRam % $RAMConfig.MinMemoryInMB -ne 0) {
                throw "Specify target RAM in multiples of $($RAMConfig.MinMemoryInMB) MB"    
            }

            $customProperties.TargetMemoryInMegaByte = $TargetVMRam
        }

        if ($customProperties.IsDynamicRam -and $HasDynamicMemoryConfig) {
    
            if ($customProperties.TargetMemoryInMegaBytes -lt $DynamicMemoryConfig.MinimumMemoryInMegaByte) {
                throw "DynamicMemoryConfig - Specify minimum memory between $($RAMConfig.MinMemoryInMB) and $($customProperties.TargetMemoryInMegaBytes)"
            }

            if ($DynamicMemoryConfig.MinimumMemoryInMegaByte % $RAMConfig.MinMemoryInMB -ne 0) {
                throw "DynamicMemoryConfig - Specify minimum memory in multiples of $($RAMConfig.MinMemoryInMB) MB"    
            }

            if ($customProperties.TargetMemoryInMegaBytes -gt $DynamicMemoryConfig.MaximumMemoryInMegaByte) {
                throw "DynamicMemoryConfig - Specify maximum memory between $($customProperties.TargetMemoryInMegaBytes) and $($RAMConfig.MaxMemoryInMB)"
            }

            if ($DynamicMemoryConfig.MaximumMemoryInMegaByte % $RAMConfig.MinMemoryInMB -ne 0) {
                throw "DynamicMemoryConfig - Specify maximum memory in multiples of $($RAMConfig.MinMemoryInMB) MB"    
            }

            $customProperties.DynamicMemoryConfig = $DynamicMemoryConfig
        }

        # Get the discovered object.
        $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
        $null = $PSBoundParameters.Add("SiteName", $SiteName)
        $null = $PSBoundParameters.Add("MachineName", $MachineName)

        if ($SiteType -eq $SiteTypes.HyperVSites) {
            $InputObject = Az.Migrate.Internal\Get-AzMigrateHyperVMachine @PSBoundParameters
        }
        elseif ($SiteType -eq $SiteTypes.VMwareSites) {
            $InputObject = Az.Migrate.Internal\Get-AzMigrateMachine @PSBoundParameters
        }

        $null = $PSBoundParameters.Remove('ResourceGroupName')
        $null = $PSBoundParameters.Remove('SiteName')
        $null = $PSBoundParameters.Remove('MachineName')

        # Nics
        [PSCustomObject[]]$nics = @()
        if ($HasNicToInclude -and $NicToInclude.length -gt 0) {
            foreach ($nic in $NicToInclude)
            {
                $discoveredNic = $InputObject.NetworkAdapter | Where-Object { $_.NicId -eq $nic.NicId }
                if ($null -eq $discoveredNic){
                    throw "The Nic id '$($nic.NicId)' is not found."
                }

                if (($null -ne $uniqueNics) -and ($uniqueNics.Contains($nic.NicId))) {
                    throw "The Nic id '$($nic.NicId)' is already taken."
                }
                
                $uniqueNics += $nic.NicId
                
                $htNic = @{}
                $nics += [PSCustomeObject]($nic.PSObject.Properties | ForEach-Object { $htNic[$_.Name] = $_.Value })
            }
        }  
        else {
            foreach ($nic in $customProperties.ProtectedNic) {
                $NicObject = [PSCustomObject]@{
                    NicId                    = $nic.NicId
                    TargetNetworkId          = $nic.TargetNetworkId
                    TestNetworkId            = $nic.TestNetworkId
                    SelectionTypeForFailover = "SelectedByUser"
                }
              
                $nics += $NicObject
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

        $output = Az.Migrate.Internal\New-AzMigrateProtectedItem `
            -Name $MachineName `
            -ResourceGroupName $ResourceGroupName `
            -VaultName $VaultName `
            -Property $protectedItemProperties
                
        $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
        $null = $PSBoundParameters.Add('VaultName', $VaultName)
        $null = $PSBoundParameters.Add('Name', $output.Name)

        return Az.Migrate.Internal\Get-AzMigrateWorkflow @PSBoundParameters;
    }
}   