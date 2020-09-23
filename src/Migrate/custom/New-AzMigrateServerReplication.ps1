
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

        [Parameter(ParameterSetName='ByInputObjectDefaultUser', Mandatory)]
        [Parameter(ParameterSetName='ByInputObjectPowerUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachine]
        # Specifies the discovered server to be migrated. The server object can be retrieved using the Get-AzMigrateServer cmdlet.
        ${InputObject},

        [Parameter(ParameterSetName='ByIdPowerUser', Mandatory)]
        [Parameter(ParameterSetName='ByNamePowerUser', Mandatory)]
        [Parameter(ParameterSetName='ByInputObjectPowerUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtDiskInput[]]
        # Specifies the disks on the source server to be included for replication.
        ${DiskToInclude},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.LicenseType]
        # Specifies if Azure Hybrid benefit is applicable for the source server to be migrated.
        ${LicenseType},

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

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the SKU of the Azure VM to be created.
        ${TargetVMSize},

        [Parameter(ParameterSetName='ByIdDefaultUser')]
        [Parameter(ParameterSetName='ByNameDefaultUser')]
        [Parameter(ParameterSetName='ByInputObjectDefaultUser')]
        [Parameter(ParameterSetName='ByIdPowerUser', Mandatory)]
        [Parameter(ParameterSetName='ByNamePowerUser', Mandatory)]
        [Parameter(ParameterSetName='ByInputObjectPowerUser', Mandatory)]
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
        [Parameter(ParameterSetName='ByInputObjectDefaultUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DiskAccountType]
        # Specifies the type of disks to be used for the Azure VM.
        ${DiskType},
        
        [Parameter(ParameterSetName='ByNameDefaultUser', Mandatory)]
        [Parameter(ParameterSetName='ByIdDefaultUser', Mandatory)]
        [Parameter(ParameterSetName='ByInputObjectDefaultUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Operating System disk for the source server to be migrated.
        ${OSDiskID},

        [Parameter(ParameterSetName='ByNameDefaultUser')]
        [Parameter(ParameterSetName='ByIdDefaultUser')]
        [Parameter(ParameterSetName='ByInputObjectDefaultUser')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the disk encyption set to be used.
        ${DiskEncryptionSetID},
    
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
            $parameterSet = $PSCmdlet.ParameterSetName
            
            # TODO
            # validate the vm name
            $HasRunAsAccountId = $PSBoundParameters.ContainsKey('VMWarerunasaccountID')
            $HasTargetAVSet = $PSBoundParameters.ContainsKey('TargetAvailabilitySet')
            $HasTargetAVZone = $PSBoundParameters.ContainsKey('TargetAvailabilityZone')
            $HasTargetBDStorage = $PSBoundParameters.ContainsKey('TargetBootDiagnosticsStorageAccount')
            $HasResync = $PSBoundParameters.ContainsKey('PerformAutoResync')
            $HasDiskEncryptionSetID = $PSBoundParameters.ContainsKey('DiskEncryptionSetID')
            $HasTargetVMSize = $PSBoundParameters.ContainsKey('TargetVMSize')

            $null = $PSBoundParameters.Remove('ReplicationContainerMapping')
            $null = $PSBoundParameters.Remove('VMWarerunasaccountID')
            $null = $PSBoundParameters.Remove('TargetAvailabilitySet')
            $null = $PSBoundParameters.Remove('TargetAvailabilityZone')
            $null = $PSBoundParameters.Remove('TargetBootDiagnosticsStorageAccount')
            $null = $PSBoundParameters.Remove('VMwareMachineId')
            $null = $PSBoundParameters.Remove('DiskToInclude')
            $null = $PSBoundParameters.Remove('TargetResourceGroupId')
            $null = $PSBoundParameters.Remove('TargetNetworkId')
            $null = $PSBoundParameters.Remove('TargetSubnetName')
            $null = $PSBoundParameters.Remove('TargetVMName')
            $null = $PSBoundParameters.Remove('TargetVMSize')
            $null = $PSBoundParameters.Remove('PerformAutoResync')
            $null = $PSBoundParameters.Remove('DiskType')
            $null = $PSBoundParameters.Remove('OSDiskID')
            $null = $PSBoundParameters.Remove('LicenseType')
            $null = $PSBoundParameters.Remove('DiskEncryptionSetID')

            $null = $PSBoundParameters.Remove('VMwareMachineId')
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('ProjectName')
            $null = $PSBoundParameters.Remove('MachineName')
            $null = $PSBoundParameters.Remove('InputObject')
           
            if(($parameterSet -match 'Id') -or ($parameterSet -match 'InputObject')){
                if(($parameterSet -match 'InputObject')){
                    $VMwareMachineId = $InputObject.Id
                }
                $MachineIdArray = $VMwareMachineId.Split("/")
                $SiteType = $MachineIdArray[7]
                $SiteName = $MachineIdArray[8]
                $ResourceGroupName = $MachineIdArray[4]
                $MachineName = $MachineIdArray[10]

                $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
                $null = $PSBoundParameters.Add('SiteName', $SiteName)
                $siteObject = Az.Migrate\Get-AzMigrateSite @PSBoundParameters
                if($siteObject -and ($siteObject.Count -ge 1)){
                    $ProjectName = $siteObject.DiscoverySolutionId.Split("/")[8]
                }else{
                    throw "Site not found"
                }
                
                $null = $PSBoundParameters.Remove('ResourceGroupName')
                $null = $PSBoundParameters.Remove('SiteName')

                $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
                $null = $PSBoundParameters.Add("Name", "Servers-Migration-ServerMigration")
                $null = $PSBoundParameters.Add("MigrateProjectName", $ProjectName)
                
                $solution = Az.Migrate\Get-AzMigrateSolution @PSBoundParameters
                if($solution -and ($solution.Count -ge 1)){
                    $VaultName = $solution.DetailExtendedDetail.AdditionalProperties.vaultId.Split("/")[8]
                    $applianceObj =  ConvertFrom-Json $solution.DetailExtendedDetail.AdditionalProperties.applianceNameToSiteIdMapV2
                    $applianceName = $applianceObj[0].ApplianceName
                }else{
                    throw "Solution not found."
                }
                
                $null = $PSBoundParameters.Remove('ResourceGroupName')
                $null = $PSBoundParameters.Remove("Name")
                $null = $PSBoundParameters.Remove("MigrateProjectName")
                
            }else{
                $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
                $null = $PSBoundParameters.Add("Name", "Servers-Migration-ServerMigration")
                $null = $PSBoundParameters.Add("MigrateProjectName", $ProjectName)
                
                $solution = Az.Migrate\Get-AzMigrateSolution @PSBoundParameters
                if($solution -and ($solution.Count -ge 1)){
                    $VaultName = $solution.DetailExtendedDetail.AdditionalProperties.vaultId.Split("/")[8]
                    $applianceObj =  ConvertFrom-Json $solution.DetailExtendedDetail.AdditionalProperties.applianceNameToSiteIdMapV2
                    $applianceName = $applianceObj[0].ApplianceName
                    $SiteName = $applianceObj[0].SiteId.Split("/")[8]
                    $SiteType = $applianceObj[0].SiteId.Split("/")[7]
                }else{
                    throw "Solution not found."
                }
                
                $null = $PSBoundParameters.Remove('ResourceGroupName')
                $null = $PSBoundParameters.Remove("Name")
                $null = $PSBoundParameters.Remove("MigrateProjectName")
                $VMwareMachineId = "/subscriptions/" + $SubscriptionId +
                    "/resourceGroups/" + $ResourceGroupName +"/providers/Microsoft.OffAzure/" +
                    $SiteType + "/" + $SiteName + "/machines/" + $MachineName
                
            }
            if ($SiteType -ne "VMwareSites"){
                throw "Provider not supported"
            }
           
            if(!$HasRunAsAccountId){
                $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
                $null = $PSBoundParameters.Add('SiteName', $SiteName)
                $runAsAccounts = Az.Migrate\Get-AzMigrateRunAsAccount @PSBoundParameters
                $VMWarerunasaccountID = ""
                foreach($account in $runAsAccounts){
                    if($account.type -match 'VMwareSites'){
                        $VMWarerunasaccountID = $account.Id
                        break
                    }
                }
                if($VMWarerunasaccountID -eq ""){
                    throw "Run As Account missing"
                }

                $null = $PSBoundParameters.Remove('ResourceGroupName')
                $null = $PSBoundParameters.Remove('SiteName')
            }
            
            $policyName = "migrate" + $SiteName + "policy"
            $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
            $null = $PSBoundParameters.Add('ResourceName', $VaultName)
            $null = $PSBoundParameters.Add('PolicyName', $policyName)
            $policyObj = Az.Migrate\Get-AzMigrateReplicationPolicy @PSBoundParameters
            if($policyObj -and ($policyObj.Count -ge 1)){
                $PolicyId = $policyObj.Id
            }else{
                throw "Please initialise the infrastructure."
            }
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('ResourceName')
            $null = $PSBoundParameters.Remove('PolicyName')

            $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
            $null = $PSBoundParameters.Add('ResourceName', $VaultName)
            $allFabrics = Az.Migrate.internal\Get-AzMigrateReplicationFabric @PSBoundParameters
            $FabricName = ""
            if($allFabrics -and ($allFabrics.length -gt 0)){
                foreach ($fabric in $allFabrics) {
                    if($fabric.Name -match $applianceName){
                        $FabricName = $fabric.Name
                        break
                    }
                }
            }
            if($FabricName -eq ""){
                throw "Fabric not found for given resource group."
            }
                
            $null = $PSBoundParameters.Add('FabricName', $FabricName)
            $peContainers = Az.Migrate.internal\Get-AzMigrateReplicationProtectionContainer @PSBoundParameters
            $ProtectionContainerName = ""
            if($peContainers -and ($peContainers.length -gt 0)){
                foreach ($peContainer in $peContainers) {
                    if($peContainer.Name -match $applianceName){
                        $ProtectionContainerName = $peContainer.Name
                        break
                    }
                }
            }

            if($ProtectionContainerName -eq ""){
                throw "Container not found for given resource group."
            }

            $mappingName = "containermapping"
            $null = $PSBoundParameters.Add('MappingName', $mappingName)
            $null = $PSBoundParameters.Add("ProtectionContainerName", $ProtectionContainerName)

            $mappingObject = Az.Migrate\Get-AzMigrateReplicationProtectionContainerMapping @PSBoundParameters
            if($mappingObject -and ($mappingObject.Count -ge 1)){
                $TargetRegion = $mappingObject.ProviderSpecificDetail.TargetLocation
            }else{
                throw "Please initialise the infrastructure. "
            }
            $null = $PSBoundParameters.Remove('MappingName')

            $HashCodeInput = $SiteName + $TargetRegion
            $Source = @"
using System;
public class HashFunctions
{
public static int hashForArtifact(String artifact)
{
        int hash = 0;
        int al = artifact.Length;
        int tl = 0;
        char[] ac = artifact.ToCharArray();
        while (tl < al)
        {
            hash = ((hash << 5) - hash) + ac[tl++] | 0;
        }
        return Math.Abs(hash);
}
}
"@
            Add-Type -TypeDefinition $Source -Language CSharp 
            $hash = [HashFunctions]::hashForArtifact($HashCodeInput) 

            $LogStorageAccountID = "/subscriptions/" +  $SubscriptionId + "/resourceGroups/" + 
                $ResourceGroupName + "/providers/Microsoft.Storage/storageAccounts/migratelsa" + $hash
            $LogStorageAccountSas = "migratelsa" + $hash + '-cacheSas'
            if(!$HasTargetBDStorage){
                $TargetBootDiagnosticsStorageAccount = $LogStorageAccountID
            }
            if(!$HasResync){
                $PerformAutoResync = "true"
            }
            $null = $PSBoundParameters.Add("MigrationItemName", $MachineName)
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
            if($HasTargetVMSize){$ProviderSpecificDetails.TargetVMSize = $TargetVMSize}
            $ProviderSpecificDetails.VmwareMachineId = $VMwareMachineId


            if ($parameterSet -match 'DefaultUser'){
                $DiskObject = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtDiskInput]::new()
                $DiskObject.DiskId = $OSDiskID
                $DiskObject.DiskType = $DiskType
                $DiskObject.IsOSDisk = "true"
                $DiskObject.LogStorageAccountSasSecretName = $LogStorageAccountSas
                $DiskObject.LogStorageAccountId = $LogStorageAccountID
                if($HasDiskEncryptionSetID){
                    $DiskObject.DiskEncryptionSetId = DiskEncryptionSetID
                }
                
                [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtDiskInput[]]$DiskToInclude = @()
                $DiskToInclude+=$DiskObject
                $ProviderSpecificDetails.DisksToInclude = $DiskToInclude
            }else{
                foreach ($DiskObject in $DiskToInclude) {
                    $DiskObject.LogStorageAccountSasSecretName = $LogStorageAccountSas
                    $DiskObject.LogStorageAccountId = $LogStorageAccountID
                }
                $ProviderSpecificDetails.DisksToInclude = $DiskToInclude
            }
            $null = $PSBoundParameters.add('ProviderSpecificDetail', $ProviderSpecificDetails)
            return Az.Migrate.internal\New-AzMigrateReplicationMigrationItem @PSBoundParameters   
        
    }

}   