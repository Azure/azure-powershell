
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
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJob])]
    [CmdletBinding(DefaultParameterSetName='ByIdDefaultUser', PositionalBinding=$false)]
    param(
        [Parameter(ParameterSetName='ByIdDefaultUser', Mandatory)]
        [Parameter(ParameterSetName='ByIdPowerUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the machine ID of the discovered server to be migrated.
        ${MachineId},

        [Parameter(ParameterSetName='ByInputObjectDefaultUser', Mandatory)]
        [Parameter(ParameterSetName='ByInputObjectPowerUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachine]
        # Specifies the discovered server to be migrated. The server object can be retrieved using the Get-AzMigrateServer cmdlet.
        ${InputObject},

        [Parameter(ParameterSetName='ByIdPowerUser', Mandatory)]
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

        [Parameter()]
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
        [Parameter(ParameterSetName='ByInputObjectDefaultUser')]
        [Parameter(ParameterSetName='ByIdPowerUser')]
        [Parameter(ParameterSetName='ByInputObjectPowerUser')]
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

        [Parameter(ParameterSetName='ByIdDefaultUser', Mandatory)]
        [Parameter(ParameterSetName='ByInputObjectDefaultUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DiskAccountType]
        # Specifies the type of disks to be used for the Azure VM.
        ${DiskType},
        
        [Parameter(ParameterSetName='ByIdDefaultUser', Mandatory)]
        [Parameter(ParameterSetName='ByInputObjectDefaultUser', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Operating System disk for the source server to be migrated.
        ${OSDiskID},

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
            $parameterSet = $PSCmdlet.ParameterSetName
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
            $null = $PSBoundParameters.Remove('MachineId')
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

            $null = $PSBoundParameters.Remove('MachineId')
            $null = $PSBoundParameters.Remove('InputObject')
           
            if(($parameterSet -match 'Id') -or ($parameterSet -match 'InputObject')){
                if(($parameterSet -match 'InputObject')){
                    $MachineId = $InputObject.Id
                }
                $MachineIdArray = $MachineId.Split("/")
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
                $VaultName = $solution.DetailExtendedDetail.AdditionalProperties.vaultId.Split("/")[8]
                
                $null = $PSBoundParameters.Remove('ResourceGroupName')
                $null = $PSBoundParameters.Remove("Name")
                $null = $PSBoundParameters.Remove("MigrateProjectName")
            }
            if ($SiteType -ne "VMwareSites"){
                throw "Provider not supported"
            }
           
            # in case if the credential type is null which is in case of older appliances or
            # in case if the credential type is vmwarefabric type which is for newer appliances
            # send that run as account id only.
            # for vCenter there will be always one credential so returning the first one which matches it.
            # when multiple vCenter support comes then this might not work and need to redesign this.
            if(!$HasRunAsAccountId){
                $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
                $null = $PSBoundParameters.Add('SiteName', $SiteName)
                $runAsAccounts = Az.Migrate\Get-AzMigrateRunAsAccount @PSBoundParameters
                $VMWarerunasaccountID = ""
                foreach($account in $runAsAccounts){
                    if(($null -eq $account.CredentialType) -or ($account.CredentialType -eq "VMwareFabric")){
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
            $policyObj = Az.Migrate\Get-AzMigrateReplicationPolicy @PSBoundParameters -ErrorVariable notPresent -ErrorAction SilentlyContinue
            if($policyObj -and ($policyObj.Count -ge 1)){
                $PolicyId = $policyObj.Id
            }else{
                throw "The replication infrastructure is not initialized. Run the initialize-azmigratereplicationinfrastructure script again."
            }
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('ResourceName')
            $null = $PSBoundParameters.Remove('PolicyName')

            $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
            $null = $PSBoundParameters.Add('ResourceName', $VaultName)
            $allFabrics = Az.Migrate\Get-AzMigrateReplicationFabric @PSBoundParameters
            $FabricName = ""
            if($allFabrics -and ($allFabrics.length -gt 0)){
                foreach ($fabric in $allFabrics) {
                    if(($fabric.Property.CustomDetail.InstanceType -ceq "VMwareV2") -and ($fabric.Property.CustomDetail.VmwareSiteId.Split("/")[8] -ceq $SiteName)){
                        $FabricName = $fabric.Name
                        break
                    }
                }
            }
            if($FabricName -eq ""){
                throw "Fabric not found for given resource group."
            }
                
            $null = $PSBoundParameters.Add('FabricName', $FabricName)
            $peContainers = Az.Migrate\Get-AzMigrateReplicationProtectionContainer @PSBoundParameters
            $ProtectionContainerName = ""
            if($peContainers -and ($peContainers.length -gt 0)){
                $ProtectionContainerName = $peContainers[0].Name
            }

            if($ProtectionContainerName -eq ""){
                throw "Container not found for given resource group."
            }

            $mappingName = "containermapping"
            $null = $PSBoundParameters.Add('MappingName', $mappingName)
            $null = $PSBoundParameters.Add("ProtectionContainerName", $ProtectionContainerName)

            $mappingObject = Az.Migrate\Get-AzMigrateReplicationProtectionContainerMapping @PSBoundParameters -ErrorVariable notPresent -ErrorAction SilentlyContinue
            if($mappingObject -and ($mappingObject.Count -ge 1)){
                $TargetRegion = $mappingObject.ProviderSpecificDetail.TargetLocation
            }else{
                throw "The replication infrastructure is not initialized. Run the initialize-azmigratereplicationinfrastructure script again."
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

            # Storage accounts need to be in the same subscription as that of the VM.
            if (($null -ne $TargetBootDiagnosticsStorageAccount) -and ($TargetBootDiagnosticsStorageAccount.length -gt 1)){
                $TargetBDSASubscriptionId = $TargetBootDiagnosticsStorageAccount.Split('/')[2]
                $TargetSubscriptionId = $TargetResourceGroupId.Split('/')[2]
                if($TargetBDSASubscriptionId -ne $TargetSubscriptionId){
                    $TargetBootDiagnosticsStorageAccount = $null
                }
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
            $ProviderSpecificDetails.VmwareMachineId = $MachineId


            if ($parameterSet -match 'DefaultUser'){
                [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtDiskInput[]]$DiskToInclude = @()
                if($parameterSet -eq 'ByInputObjectDefaultUser'){
                    foreach($onPremDisk in $InputObject.Disk){
                        if($onPremDisk.Uuid -ne $OSDiskID){
                            $DiskObject = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtDiskInput]::new()
                            $DiskObject.DiskId = $onPremDisk.Uuid
                            $DiskObject.DiskType = "Standard_LRS"
                            $DiskObject.IsOSDisk = "false"
                            $DiskObject.LogStorageAccountSasSecretName = $LogStorageAccountSas
                            $DiskObject.LogStorageAccountId = $LogStorageAccountID
                            if($HasDiskEncryptionSetID){
                                $DiskObject.DiskEncryptionSetId = $DiskEncryptionSetID
                            }
                            $DiskToInclude+=$DiskObject
                        }
                    }
                }
                $DiskObject = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtDiskInput]::new()
                $DiskObject.DiskId = $OSDiskID
                $DiskObject.DiskType = $DiskType
                $DiskObject.IsOSDisk = "true"
                $DiskObject.LogStorageAccountSasSecretName = $LogStorageAccountSas
                $DiskObject.LogStorageAccountId = $LogStorageAccountID
                if($HasDiskEncryptionSetID){
                    $DiskObject.DiskEncryptionSetId = $DiskEncryptionSetID
                }
                
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
            $null = $PSBoundParameters.Add('NoWait', $true)
            $output = Az.Migrate.internal\New-AzMigrateReplicationMigrationItem @PSBoundParameters
            $JobName = $output.Target.Split("/")[12].Split("?")[0]
            $null = $PSBoundParameters.Remove('NoWait')
            $null = $PSBoundParameters.Remove('ProviderSpecificDetail')
            $null = $PSBoundParameters.Remove("ResourceGroupName")
            $null = $PSBoundParameters.Remove("ResourceName")
            $null = $PSBoundParameters.Remove("FabricName")
            $null = $PSBoundParameters.Remove("MigrationItemName")
            $null = $PSBoundParameters.Remove("ProtectionContainerName")
            $null = $PSBoundParameters.Remove("PolicyId")

            $null = $PSBoundParameters.Add('JobName', $JobName)
            $null = $PSBoundParameters.Add('ResourceName', $VaultName)
            $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
        
            return Az.Migrate.internal\Get-AzMigrateReplicationJob @PSBoundParameters    
        
    }

}   