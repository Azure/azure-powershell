
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
Starts replication for the specified server.
.Description
The New-AzMigrateHCIServerReplication cmdlet starts the replication for a particular discovered server in the Azure Migrate project.
.Link
https://learn.microsoft.com/powershell/module/az.migrate/new-azmigratehciserverreplication
#>
function New-AzMigrateHCIServerReplication {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.IWorkflowModel])]
    [CmdletBinding(DefaultParameterSetName = 'ByIdDefaultUser', PositionalBinding = $false)]
    param(
        [Parameter(ParameterSetName = 'ByIdDefaultUser', Mandatory)]
        [Parameter(ParameterSetName = 'ByIdPowerUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the machine ID of the discovered server to be migrated.
        ${MachineId}, 

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the storage path used when setting up ARC.
        ${TargetStoragePathId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Int32]
        # Specifies the number of CPU cores.
        ${TargetVMCPUCores},

        [Parameter(ParameterSetName = 'ByIdDefaultUser', Mandatory)]
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
        [System.Int64]
        # Specifies the target RAM size in MB. 
        ${TargetVMRam},

        [Parameter(ParameterSetName = 'ByIdPowerUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.AzStackHCIDiskInput[]]
        # Specifies the disks on the source server to be included for replication.
        ${DiskToInclude},

        [Parameter(ParameterSetName = 'ByIdPowerUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.AzStackHCINicInput[]]
        # Specifies the NICs on the source server to be included for replication.
        ${NicToInclude},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Resource Group Id within the destination Azure subscription to which the server needs to be migrated.
        ${TargetResourceGroupId},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the name of the Azure VM to be created.
        ${TargetVMName},

        [Parameter(ParameterSetName = 'ByIdDefaultUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Operating System disk for the source server to be migrated.
        ${OSDiskID},
    
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
        Import-Module Az.ResourceGraph

        $HasTargetVMCPUCores = $PSBoundParameters.ContainsKey('TargetVMCPUCores')
        $HasIsDynamicMemoryEnabled = $PSBoundParameters.ContainsKey('IsDynamicMemoryEnabled')
        $HasTargetVMRam = $PSBoundParameters.ContainsKey('TargetVMRam')
        $parameterSet = $PSCmdlet.ParameterSetName

        $null = $PSBoundParameters.Remove('TargetVMCPUCores')
        $null = $PSBoundParameters.Remove('IsDynamicMemoryEnabled')
        $null = $PSBoundParameters.Remove('TargetVMRam')
        $null = $PSBoundParameters.Remove('DiskToInclude')
        $null = $PSBoundParameters.Remove('NicToInclude')
        $null = $PSBoundParameters.Remove('TargetResourceGroupId')
        $null = $PSBoundParameters.Remove('TargetVMName')
        $null = $PSBoundParameters.Remove('TargetVirtualSwitch')
        $null = $PSBoundParameters.Remove('TargetStoragePathId')
        $null = $PSBoundParameters.Remove('OSDiskID')
        $null = $PSBoundParameters.Remove('MachineId')
        
        $MachineIdArray = $MachineId.Split("/")
        $SiteType = $MachineIdArray[7]
        $SiteName = $MachineIdArray[8]
        $ResourceGroupName = $MachineIdArray[4]
        $MachineName = $MachineIdArray[10]

        if (($SiteType -ne $SiteTypes.HyperVSites)-and ($SiteType -ne $SiteTypes.VMwareSites)) {
            throw "Site type is not supported. Site type '$SiteType'"
        }

        # Get the discovered site and the discovered machine
        $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
        $null = $PSBoundParameters.Add("SiteName", $SiteName)
        $null = $PSBoundParameters.Add("MachineName", $MachineName)
        
        if ($SiteType -eq $SiteTypes.HyperVSites) {
            $instanceType = $AzStackHCIInstanceTypes.HyperVToAzStackHCI
            $InputObject = Az.Migrate.Internal\Get-AzMigrateHyperVMachine @PSBoundParameters
            
            $null = $PSBoundParameters.Remove('MachineName')
            $siteObject = Az.Migrate\Get-AzMigrateHyperVSite @PSBoundParameters
        }
        elseif ($SiteType -eq $SiteTypes.VMwareSites) {
            $instanceType = $AzStackHCIInstanceTypes.VMwareToAzStackHCI
            $InputObject = Az.Migrate.Internal\Get-AzMigrateMachine @PSBoundParameters

            $null = $PSBoundParameters.Remove('MachineName')
            $siteObject = Az.Migrate\Get-AzMigrateSite @PSBoundParameters
        }

        $null = $PSBoundParameters.Remove('ResourceGroupName')
        $null = $PSBoundParameters.Remove('SiteName')

        if ($null -eq $InputObject) {
           throw "Provided MachineId is not found."
        }

        if ($siteObject -and ($siteObject.Count -ge 1)) {
            $ProjectName = $siteObject.DiscoverySolutionId.Split("/")[8]
        }
        else {
            throw "Site not found"
        }

        # Get the migrate solution to get vault name.
        $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
        $null = $PSBoundParameters.Add("Name", "Servers-Migration-ServerMigration_DataReplication")
        $null = $PSBoundParameters.Add("MigrateProjectName", $ProjectName)
        
        $solution = Az.Migrate\Get-AzMigrateSolution @PSBoundParameters
        $vaultName = $solution.DetailExtendedDetail.AdditionalProperties.vaultId.Split("/")[8]

        $null = $PSBoundParameters.Remove('ResourceGroupName')
        $null = $PSBoundParameters.Remove("Name")
        $null = $PSBoundParameters.Remove("MigrateProjectName")

        if ($null -eq $solution) {
            throw "Migrate solution is not found."
        }

        if ([string]::IsNullOrEmpty($vaultName)) {
            throw "Vault is not found."
        }

        # Validate Policy
        $policyName = $vaultName + $instanceType + "policy"
        $policyObj = Az.Migrate.Internal\Get-AzMigratePolicy `
            -ResourceGroupName $ResourceGroupName `
            -Name $policyName `
            -VaultName $vaultName `
            -SubscriptionId $SubscriptionId `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        if ($policyObj -and ($policyObj.Count -ge 1)) {
            $policyId = $policyObj.Id
        }
        else {
            throw "The replication infrastructure is not initialized. Run the initialize-azmigratereplicationinfrastructure script again."
        }
        
        # Get Source and Target Fabrics
        $allFabrics = Az.Migrate.Internal\Get-AzMigrateFabric -ResourceGroupName $ResourceGroupName
        foreach ($fabric in $allFabrics) {
            if ($fabric.Property.CustomProperty.MigrationSolutionId -ne $solution.Id) {
                continue;
            }

            if ($fabric.Property.CustomProperty.InstanceType -ceq $FabricInstanceTypes.HyperVInstance) {
                $sourceFabric = $fabric
            }
            elseif ($fabric.Property.CustomProperty.InstanceType -ceq $FabricInstanceTypes.VmwareInstance) {
                $sourceFabric = $fabric
            }
            elseif ($fabric.Property.CustomProperty.InstanceType -ceq $FabricInstanceTypes.AzStackHCIInstance) {
                $targetFabric = $fabric
            }
        }

        if (($null -eq $sourceFabric) -or ($null -eq $targetFabric)) {
            throw "The replication infrastructure is not initialized. Run the initialize-azmigratereplicationinfrastructure script again."
        }

        # Get Source and Target Dras
        $sourceDras = Az.Migrate.Internal\Get-AzMigrateDra `
            -FabricName $sourceFabric.Name `
            -ResourceGroupName $ResourceGroupName `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        if ($null -eq $sourceDras) {
            throw "Source Dra not found. Please verify your appliance setup."
        }

        $sourceDra = $sourceDras[0]
        # IsResponsive is always return null
        # if (!$sourceDra.IsResponsive) {
        #     throw "The Azure Migrate unified appliance '$($sourceDra.Name)' is in a disconnected state. Ensure that the appliance is running and has connectivity before proceeding."
        # }

        $targetDras = Az.Migrate.Internal\Get-AzMigrateDra `
            -FabricName $targetFabric.Name `
            -ResourceGroupName $ResourceGroupName `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue
        if ($null -eq $targetDras) {
            throw "Target Dra not found. Please verify your appliance setup."
        }

        $targetDra = $targetDras[0]
        # if (!$targetDra.IsResponsive) {
        #     throw "The Azure Migrate unified appliance '$($targetDra.Name)' is in a disconnected state. Ensure that the appliance is running and has connectivity before proceeding."
        # }

        # Get Replication Extension
        $replicationExtensionName = ($sourceFabric.Id -split '/')[-1] + "-" + ($targetFabric.Id -split '/')[-1] + "-MigReplicationExtn"
        $replicationExtension = Az.Migrate.Internal\Get-AzMigrateReplicationExtension `
            -ResourceGroupName $ResourceGroupName `
            -Name $replicationExtensionName `
            -VaultName $vaultName `
            -SubscriptionId $SubscriptionId `
            -ErrorVariable notPresent `
            -ErrorAction SilentlyContinue

        if ($null -eq $replicationExtension) {
            throw "The replication infrastructure is not initialized. Run the initialize-azmigratereplicationinfrastructure script again."
        }

        $targetClusterId = $targetFabric.Property.CustomProperty.Cluster.ResourceName
        # Get Storage Container
        $storageContainers = Search-AzGraph -Query ($StorageContainerQuery -f $targetClusterId)
        $storageContainer = $storageContainers | Where-Object {$_.Id -eq $TargetStoragePathId}
        if($null -eq $storageContainer) {
            throw "Provided target storage path is not found."
        }

        if("Succeeded" -ne $storageContainer.Properties.ProvisioningState) {
            throw "Provided target storage path is not successfully provisioned. Provisioning State: $($storageContainer.Properties.ProvisioningState)"
        }

        # Get Virtual Switch
        $virtualSwitchIds = if ($parameterSet -match 'DefaultUser') { $TargetVirtualSwitchId } else { $NicToInclude | Select-Object -Property TargetNetworkId }
        $virtualSwitches = Search-AzGraph -Query ($VirtualSwitchQuery -f $targetClusterId)
        foreach ($virtualSwitchId in $virtualSwitchIds) {
            $virtualSwitch = $virtualSwitches | Where-Object {$_.Id -eq $virtualSwitchId}
            if ($null -eq $virtualSwitch) {
                throw "Provided virtual switch '$virtualSwitchId' is not found."
            }

            if ("Succeeded" -ne $virtualSwitch.Properties.ProvisioningState) {
                throw "Provided virtual switch '$virtualSwitchId' is not successfully provisioned. Provisioning State: $($virtualSwitch.Properties.ProvisioningState)"
            }
        }
            
        # Get source appliance RunAsAccount
        if ($SiteType -eq $SiteTypes.HyperVSites) {
            $runAsAccounts = Az.Migrate\Get-AzMigrateHyperVRunAsAccount `
                -ResourceGroupName $ResourceGroupName `
                -SiteName $SiteName `
                -SubscriptionId $SubscriptionId
            $runAsAccount = $runAsAccounts | Where-Object { $_.CredentialType -eq $RunAsAccountCredentialTypes.HyperVFabric}
        }
        elseif ($SiteType -eq $SiteTypes.VMwareSites) {  
            $runAsAccounts = Az.Migrate\Get-AzMigrateRunAsAccount `
                -ResourceGroupName $ResourceGroupName `
                -SiteName $SiteName `
                -SubscriptionId $SubscriptionId
            $runAsAccount = $runAsAccounts | Where-Object { $_.CredentialType -eq $RunAsAccountCredentialTypes.VMwareFabric}
        }
            
        if ($null -eq $runAsAccount) {
            throw "Source site run as account is not found."
        }

        # Validate TargetVMName
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

        # Validate TargetVMRam
        if ($HasTargetVMRam) {
            if (!($TargetVMRam -In $RAMConfig.MinMemoryInMB..$RAMConfig.MaxMemoryInMB)) {
                throw "Specify RAM between $($RAMConfig.MinMemoryInMB) and $($RAMConfig.MaxMemoryInMB)"
            }

            if ($TargetVMRam % $RAMConfig.MinMemoryInMB -ne 0) {
                throw "Specify target RAM in multiples of $($RAMConfig.MinMemoryInMB) MB"    
            }
        }

        $protectedItemProperties = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelProperties]::new()
        $protectedItemProperties.PolicyName = $policyName
        $protectedItemProperties.ReplicationExtensionName = $replicationExtensionName

        if ($SiteType -eq $SiteTypes.HyperVSites) {     
            $customProperties = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.HyperVToAzStackHCIProtectedItemModelCustomProperties]::new()
        }
        elseif ($SiteType -eq $SiteTypes.VMwareSites) {  
            $customProperties = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.VMwareToAzStackHCIProtectedItemModelCustomProperties]::new()
        }

        $customProperties.InstanceType                        = $instanceType
        $customProperties.CustomLocationRegion                = $storageContainer.Location
        $customProperties.FabricDiscoveryMachineId            = $InputObject.Id
        $customProperties.RunAsAccountId                      = $runAsAccount.Id
        $customProperties.SourceDraName                       = $sourceDra.Name
        $customProperties.StorageContainerId                  = $storageContainer.Id
        $customProperties.TargetArcClusterCustomLocationId    = $storageContainer.ExtendedLocation.Name
        $customProperties.TargetDraName                       = $targetDra.Name
        $customProperties.TargetHciClusterId                  = $targetClusterId
        $customProperties.TargetResourceGroupId               = $TargetResourceGroupId
        $customProperties.TargetVMName                        = $TargetVMName
        $customProperties.HyperVGeneration                    = if ($SiteType -eq $SiteTypes.HyperVSites) { $InputObject.Generation } else { "1" }
        $customProperties.TargetCpuCore                       = if ($HasTargetVMCPUCores) { $TargetVMCPUCores } else { $InputObject.NumberOfProcessorCore }
        $customProperties.TargetMemoryInMegaByte              = if ($HasTargetVMRam) { $TargetVMRam } else { $InputObject.AllocatedMemoryInMB }
        $customProperties.IsDynamicRam                        = if ($HasIsDynamicMemoryEnabled) { $IsDynamicMemoryEnabled } else { $InputObject.IsDynamicMemoryEnabled }

        $memoryConfig = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemDynamicMemoryConfig]::new()
        $memoryConfig.MinimumMemoryInMegaByte = [System.Math]::Min($customProperties.TargetMemoryInMegaByte, $RAMConfig.MinMemoryInMB)
        $memoryConfig.MaximumMemoryInMegaByte = [System.Math]::Max($customProperties.TargetMemoryInMegaByte, $RAMConfig.MaxMemoryInMB)
        $memoryConfig.TargetMemoryBufferPercentage = $RAMConfig.TargetMemoryBufferPercentage

        $customProperties.DynamicMemoryConfig = $memoryConfig
        
        # Disks and Nics
        [PSCustomObject[]]$disks = @()
        [PSCustomObject[]]$nics = @()
        
        if ($parameterSet -match 'DefaultUser') {
            if ($SiteType -eq $SiteTypes.HyperVSites) {
                $osDisk = $InputObject.Disk | Where-Object { $_.InstanceId -eq $OSDiskID }
            }
            elseif ($SiteType -eq $SiteTypes.VMwareSites) {  
                $osDisk = $InputObject.Disk | Where-Object { $_.Uuid -eq $OSDiskID }
            }
            
            if ($null -eq $osDisk) {
                throw "The OSDiskID provided is not found."
            }

            foreach ($sourceDisk in $InputObject.Disk) {
                $diskId   = if ($SiteType -eq $SiteTypes.HyperVSites) { $sourceDisk.InstanceId } else { $sourceDisk.Uuid }
                $diskSize = if ($SiteType -eq $SiteTypes.HyperVSites) { $sourceDisk.MaxSizeInByte } else { $sourceDisk.MaxSizeInBytes }

                $DiskObject = [PSCustomObject]@{
                    DiskId          = $diskId
                    DiskSizeGb      = [long] [Math]::Ceiling($diskSize/1GB)
                    DiskFileFormat  = "VHDX"
                    IsDynamic       = $true
                    IsOSDisk        = $diskId -eq $OSDiskID
                }
                
                $disks += $DiskObject
            }
            
            foreach ($sourceNic in $InputObject.NetworkAdapter) {
                $NicObject = [PSCustomObject]@{
                    NicId                    = $sourceNic.NicId
                    TargetNetworkId          = $TargetVirtualSwitch
                    TestNetworkId            = $TargetVirtualSwitch
                    SelectionTypeForFailover = "SelectedByUser"
                }
                $nics += $NicObject
            }
        }
        else {
            if ($null -eq $DiskToInclude -or $DiskToInclude.length -lt 1) {
                throw "Invalid DiskToInclude. Atleast one disk is required."
            }

            if ($null -eq $NicToInclude -or $NicToInclude.length -lt 1) {
                throw "Invalid NicToInclude. Atleast one NIC is required."
            }

            # Validate OSDisk is set.
            $osDisk = $DiskToInclude | Where-Object { $_.IsOSDisk -eq $True }
            if (($null -eq $osDisk) -or ($osDisk.length -ne 1)) {
                throw "One disk must be set as OS Disk."
            }
            
            # Validate disks
            foreach ($disk in $DiskToInclude)
            {
                if ($SiteType -eq $SiteTypes.HyperVSites) {
                    $discoveredDisk = $InputObject.Disk | Where-Object { $_.InstanceId -eq $disk.DiskId }
                }
                elseif ($SiteType -eq $SiteTypes.VMwareSites) {  
                    $discoveredDisk = $InputObject.Disk | Where-Object { $_.Uuid -eq $disk.DiskId }
                }

                if ($null -eq $discoveredDisk){
                    throw "The disk id '$($disk.DiskId)' is not found."
                }

                if (($null -ne $uniqueDisks) -and ($uniqueDisks.Contains($disk.DiskId))) {
                    throw "The disk id '$($disk.DiskId)' is already taken."
                }
                $uniqueDisks += $disk.DiskId

                $htDisk = @{}
                $disk.PSObject.Properties | ForEach-Object { $htDisk[$_.Name] = $_.Value }
                $disks += [PSCustomObject]$htDisk
            }

            # Validate nics
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
                $nic.PSObject.Properties | ForEach-Object { $htNic[$_.Name] = $_.Value }
                $nics += [PSCustomObject]$htNic
            }
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
            -VaultName $vaultName `
            -Property $protectedItemProperties
                    
        $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
        $null = $PSBoundParameters.Add('VaultName', $vaultName)
        $null = $PSBoundParameters.Add('Name', $output.Name)

        return Az.Migrate.Internal\Get-AzMigrateWorkflow @PSBoundParameters;
    }
}