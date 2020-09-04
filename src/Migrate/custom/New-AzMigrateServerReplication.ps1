
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
The New-AzMigrateServerReplication cmdlet starts the replication for a particular discovered server in the Azure Migrate project.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.migrate/new-azmigrateserverreplication
#>
function New-AzMigrateServerReplication {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItem])]
    [CmdletBinding(DefaultParameterSetName='ByNameDefaultUser', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='ByIdDefaultUser', Mandatory)]
        [Parameter(ParameterSetName='ByIdPowerUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the machine ID of the discovered server to be migrated.
        ${VMwareMachineId},

        [Parameter(ParameterSetName='ByNameDefaultUser', Mandatory)]
        [Parameter(ParameterSetName='ByNamePowerUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the resource group of the discovered server to be migrated.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='ByNameDefaultUser', Mandatory)]
        [Parameter(ParameterSetName='ByNamePowerUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the migrate project name of the discovered server to be migrated.
        ${ProjectName},

        [Parameter(ParameterSetName='ByNameDefaultUser', Mandatory)]
        [Parameter(ParameterSetName='ByNamePowerUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the discovered machine name of the discovered server to be migrated.
        ${MachineName},

        [Parameter(ParameterSetName='ByIdPowerUser', Mandatory)]
        [Parameter(ParameterSetName='ByNamePowerUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtDiskInput[]]
        # Specifies the disks on the source server to be included for replication.
        ${DisksToInclude},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.LicenseType]
        # Specifies if Azure Hybrid benefit is applicable for the source server to be migrated.
        ${LicenseType},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the destination Azure subscription id to which the server needs to be migrated.
        ${TargetSubscriptionId},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Resource Group id within the destination Azure subscription to which the server needs to be migrated.
        ${TargetResourceGroupId},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Virtual Network id within the destination Azure subscription to which the server needs to be migrated.
        ${TargetNetworkId},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Subnet name within the destination Virtual Netowk to which the server needs to be migrated.
        ${TargetSubnetName},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Mapping.
        ${ReplicationContainerMapping},

        [Parameter(ParameterSetName='ByNamePowerUser')]
        [Parameter(ParameterSetName='ByNameDefaultUser')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Account id.
        ${VMWarerunasaccountID},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the name of the Azure VM to be created.
        ${TargetVMName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the SKU of the Azure VM to be created.
        ${TargetVMSize},

        [Parameter(ParameterSetName='ByIdDefaultUser')]
        [Parameter(ParameterSetName='ByNameDefaultUser')]
        [Parameter(ParameterSetName='ByIdPowerUser', Mandatory)]
        [Parameter(ParameterSetName='ByNamePowerUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies if replication be auto-repaired in case change tracking is lost for the source server under replication.
        ${PerformAutoResync},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Availability Set to be used for VM creationSpecifies the Availability Set to be used for VM creation.
        ${TargetAvailabilitySet},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Availability Zone to be used for VM creation.
        ${TargetAvailabilityZone},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the storage account to be used for boot diagnostics.
        ${TargetBootDiagnosticsStorageAccount},

        [Parameter(ParameterSetName='ByNameDefaultUser', Mandatory)]
        [Parameter(ParameterSetName='ByIdDefaultUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DiskAccountType]
        # Specifies the type of disks to be used for the Azure VM.
        ${DiskType},
        
        [Parameter(ParameterSetName='ByNameDefaultUser', Mandatory)]
        [Parameter(ParameterSetName='ByIdDefaultUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Operating System disk for the source server to be migrated.
        ${OSDiskID},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
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
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
    
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
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
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
        try {
          
            Set-PSDebug -Step; foreach ($i in 1..3) {$i}
            $test = $PSBoundParameters

            $ParameterSetName = $PSCmdlet.ParameterSetName
            $MachineIdArray = $VmWareMachineId.Split("/")
            $SiteType = $MachineIdArray[7]
            $HasRunAsAccountId = $PSBoundParameters.ContainsKey('VMWarerunasaccountID')
            $HasTargetAVSet = $PSBoundParameters.ContainsKey('TargetAvailabilitySet')
            $HasTargetAVZone = $PSBoundParameters.ContainsKey('TargetAvailabilityZone')
            $HasTargetBDStorage = $PSBoundParameters.ContainsKey('TargetBootDiagnosticsStorageAccount')
            $HasResync = $PSBoundParameters.ContainsKey('PerformAutoResync')

            if(!$HasRunAsAccountId){
                # TODO 
                $VMWarerunasaccountObject = Mock-AzMigrateGetRunAsAccountId -ResourceGroupName $SourceResourceGroup -SiteName $SiteName
                $VMWarerunasaccountID = $VMWarerunasaccountObject.value[0].id
            }
            #TODO
            $PolicyId = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.RecoveryServices/vaults/AzMigrateTestProjectPWSH02aarsvault/replicationPolicies/migrateAzMigratePWSHTc8d1sitepolicy"
            $LogStorageAccountID = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.Storage/storageAccounts/migratelsa846827101"
            $LogStorageAccountSas = $LogStorageAccountID.Split("/")[8] + '-cacheSas'
            if(!$HasTargetBDStorage){
                # TODO
                $TargetBootDiagnosticsStorageAccount = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.Storage/storageAccounts/migratelsa846827101"
            }
            if(!$HasResync){
                $PerformAutoResync = "true"
            }

            $null = $PSBoundParameters.Remove('ReplicationContainerMapping')
            $null = $PSBoundParameters.Remove('VMWarerunasaccountID')
            $null = $PSBoundParameters.Remove('TargetAvailabilitySet')
            $null = $PSBoundParameters.Remove('TargetAvailabilityZone')
            $null = $PSBoundParameters.Remove('TargetBootDiagnosticsStorageAccount')
            $null = $PSBoundParameters.Remove('VMwareMachineId')
            $null = $PSBoundParameters.Remove('DisksToInclude')
            $null = $PSBoundParameters.Remove('TargetSubscriptionId')
            $null = $PSBoundParameters.Remove('TargetResourceGroupId')
            $null = $PSBoundParameters.Remove('TargetNetworkId')
            $null = $PSBoundParameters.Remove('TargetSubnetName')
            $null = $PSBoundParameters.Remove('TargetVMName')
            $null = $PSBoundParameters.Remove('TargetVMSize')
            $null = $PSBoundParameters.Remove('PerformAutoResync')
            $null = $PSBoundParameters.Remove('DiskType')
            $null = $PSBoundParameters.Remove('OSDiskID')
            $null = $PSBoundParameters.Remove('VMWarerunasaccountID')

            if($SiteType -eq 'VMwareSites'){
                
                $MachineName = $MachineIdArray[10]
                $SourceResourceGroup = $MachineIdArray[4]
                $SiteName = $MachineIdArray[8]
                
                # TODO make them PSBoundPArameter
                $SiteObject = Mock-AzMigrateGetSite -ResourceGroupName $SourceResourceGroup -SiteName $SiteName
                $ProjectName = $SiteObject.properties.discoverySolutionId.Split("/")[8]

                $Solutions = Mock-AzMigrateGetSolution -ResourceGroupName $SourceResourceGroup -ProjectName $ProjectName
                $VaultName = $Solutions.value[0].properties.details.extendeddetails.vaultId.Split("/")[8]

                $null = $PSBoundParameters.Add('ResourceGroupName', $SourceResourceGroup)
                $null = $PSBoundParameters.Add('ResourceName', $VaultName)
                $allFabrics = Az.Migrate.internal\Get-AzMigrateReplicationFabric @PSBoundParameters
                if($allFabrics -and ($allFabrics.length -gt 0)){
                    $FabricName = $allFabrics[0].Name
                }
                
                $null = $PSBoundParameters.Add('FabricName', $FabricName)
                $peContainers = Az.Migrate.internal\Get-AzMigrateReplicationProtectionContainer @PSBoundParameters
                if($peContainers -and ($peContainers.length -gt 0)){
                    $ProtectionContainerName = $peContainers[0].Name
                }
                $null = $PSBoundParameters.Add("MigrationItemName", $MachineName)
                $null = $PSBoundParameters.Add("ProtectionContainerName", $ProtectionContainerName)
                $null = $PSBoundParameters.Add("PolicyId", $PolicyId)

                $ProviderSpecificDetails = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtEnableMigrationInput]::new()
                $ProviderSpecificDetails.DataMoverRunAsAccountId = $VMWarerunasaccountID
                $ProviderSpecificDetails.SnapshotRunAsAccountId = $VMWarerunasaccountID
                $ProviderSpecificDetails.InstanceType = 'VMwareCbt'
                $ProviderSpecificDetails.LicenseType = $LicenseType
                $ProviderSpecificDetails.PerformAutoResync = $PerformAutoResync
                if($HasTargetAVSet){
                    $ProviderSpecificDetails.TargetAvailabilitySetId = $TargetAvailabilitySet
                }
                if($HasTargetAVZone){
                    $ProviderSpecificDetails.TargetAvailabilityZone = $TargetAvailabilityZone
                }
                $ProviderSpecificDetails.TargetBootDiagnosticsStorageAccountId  = $TargetBootDiagnosticsStorageAccount
                $ProviderSpecificDetails.TargetNetworkId = $TargetNetworkId
                $ProviderSpecificDetails.TargetResourceGroupId = $TargetResourceGroupId
                $ProviderSpecificDetails.TargetSubnetName = $TargetSubnetName
                $ProviderSpecificDetails.TargetVMName = $TargetVMName
                $ProviderSpecificDetails.TargetVMSize = $TargetVMSize
                $ProviderSpecificDetails.VmwareMachineId = $VMwareMachineId


                if ($ParameterSetName -eq 'DefaultUser'){
                    $DiskObject = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtDiskInput]::new()
                    $DiskObject.DiskId = $DiskID
                    $DiskObject.DiskType = $DiskType
                    $DiskObject.IsOSDisk = $IsOSDisk
                    $DiskObject.LogStorageAccountSasSecretName = $LogStorageAccountSas
                    $DiskObject.LogStorageAccountId = $LogStorageAccountID
                    
                    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtDiskInput[]]$DisksToInclude = @()
                    $DisksToInclude+=$DiskObject
                    $ProviderSpecificDetails.DisksToInclude = $DisksToInclude
                }else{
                    foreach ($DiskObject in $DisksToInclude) {
                        $DiskObject.LogStorageAccountSasSecretName = $LogStorageAccountSas
                        $DiskObject.LogStorageAccountId = $LogStorageAccountID
                    }
                    $ProviderSpecificDetails.DisksToInclude = $DisksToInclude
                }
                $null = $PSBoundParameters.add('ProviderSpecificDetail', $ProviderSpecificDetails)
                return Az.Migrate.internal\New-AzMigrateReplicationMigrationItem @PSBoundParameters

            }else{
                Write-Host 'Not a Vmware machine'
            }
            
        } catch {
           throw
        }
    }

}   