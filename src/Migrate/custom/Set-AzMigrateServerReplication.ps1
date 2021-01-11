
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
The Set-AzMigrateServerReplication cmdlet updates the target properties for the replicating server.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.migrate/set-azmigrateserverreplication
#>
function Set-AzMigrateServerReplication {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJob])]
    [CmdletBinding(DefaultParameterSetName='ByIDVMwareCbt', PositionalBinding=$false)]
    param(
        [Parameter(ParameterSetName='ByIDVMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the replcating server for which the properties need to be updated. The ID should be retrieved using the Get-AzMigrateServerReplication cmdlet.
        ${TargetObjectID},

        [Parameter(ParameterSetName='ByInputObjectVMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItem]
        # Specifies the replicating server for which the properties need to be updated. The server object can be retrieved using the Get-AzMigrateServerReplication cmdlet.
        ${InputObject},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the replcating server for which the properties need to be updated. The ID should be retrieved using the Get-AzMigrateServerReplication cmdlet.
        ${TargetVMName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Updates the SKU of the Azure VM to be created.
        ${TargetVMSize},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Updates the Virtual Network id within the destination Azure subscription to which the server needs to be migrated.
        ${TargetNetworkId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Updates the Resource Group id within the destination Azure subscription to which the server needs to be migrated.
        ${TargetResourceGroupID},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtNicInput[]]
        # Updates the NIC for the Azure VM to be created.
        ${NicToUpdate},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Availability Set to be used for VM creation.
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

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
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

            $HasTargetVMName = $PSBoundParameters.ContainsKey('TargetVMName')
            $HasTargetVmSize = $PSBoundParameters.ContainsKey('TargetVMSize')
            $HasTargetNetworkId = $PSBoundParameters.ContainsKey('TargetNetworkId')
            $HasTargetResourceGroupID = $PSBoundParameters.ContainsKey('TargetResourceGroupID')
            $HasNicToUpdate = $PSBoundParameters.ContainsKey('NicToUpdate')
            $HasTargetAvailabilitySet = $PSBoundParameters.ContainsKey('TargetAvailabilitySet')
            $HasTargetAvailabilityZone = $PSBoundParameters.ContainsKey('TargetAvailabilityZone')
            $HasTargetBootDignosticStorageAccount = $PSBoundParameters.ContainsKey('TargetBootDiagnosticsStorageAccount')
            

            $null = $PSBoundParameters.Remove('TargetObjectID')
            $null = $PSBoundParameters.Remove('TargetVMName')
            $null = $PSBoundParameters.Remove('TargetVMSize')
            $null = $PSBoundParameters.Remove('TargetNetworkId')
            $null = $PSBoundParameters.Remove('TargetResourceGroupID')
            $null = $PSBoundParameters.Remove('NicToUpdate')
            $null = $PSBoundParameters.Remove('TargetAvailabilitySet')
            $null = $PSBoundParameters.Remove('TargetAvailabilityZone')
            $null = $PSBoundParameters.Remove('InputObject')
            $null = $PSBoundParameters.Remove('TargetBootDiagnosticsStorageAccount')
            $parameterSet = $PSCmdlet.ParameterSetName

            if($parameterSet -eq 'ByInputObjectVMwareCbt'){
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
            if($ReplicationMigrationItem -and ($ReplicationMigrationItem.ProviderSpecificDetail.InstanceType -eq 'VMwarecbt')){
                $ProviderSpecificDetails = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtUpdateMigrationItemInput]::new()
                
                # Auto fill unchanged parameters
                $ProviderSpecificDetails.InstanceType = 'VMwareCbt'
                $ProviderSpecificDetails.LicenseType = $ReplicationMigrationItem.ProviderSpecificDetail.LicenseType
                $ProviderSpecificDetails.PerformAutoResync = $ReplicationMigrationItem.ProviderSpecificDetail.PerformAutoResync
                
                if($HasTargetAvailabilitySet){ 
                    $ProviderSpecificDetails.TargetAvailabilitySetId = $TargetAvailabilitySet
                }else{
                    $ProviderSpecificDetails.TargetAvailabilitySetId = $ReplicationMigrationItem.ProviderSpecificDetail.TargetAvailabilitySetId
                }

                if($HasTargetAvailabilityZone){ 
                    $ProviderSpecificDetails.TargetAvailabilityZone = $TargetAvailabilityZone
                }else{
                    $ProviderSpecificDetails.TargetAvailabilityZone = $ReplicationMigrationItem.ProviderSpecificDetail.TargetAvailabilityZone
                }

                if($HasTargetNetworkId){ 
                    $ProviderSpecificDetails.TargetNetworkId = $TargetNetworkId
                }else{
                    $ProviderSpecificDetails.TargetNetworkId = $ReplicationMigrationItem.ProviderSpecificDetail.TargetNetworkId
                }

                if($HasTargetVMName){ 
                    $ProviderSpecificDetails.TargetVMName = $TargetVMName
                }else{
                    $ProviderSpecificDetails.TargetVMName = $ReplicationMigrationItem.ProviderSpecificDetail.TargetVMName
                }

                if($HasTargetResourceGroupID){ 
                    $ProviderSpecificDetails.TargetResourceGroupId = $TargetResourceGroupID
                }else{
                    $ProviderSpecificDetails.TargetResourceGroupId = $ReplicationMigrationItem.ProviderSpecificDetail.TargetResourceGroupId
                }

                if($HasTargetVmSize){ 
                    $ProviderSpecificDetails.TargetVMSize = $TargetVmSize 
                }else{
                    $ProviderSpecificDetails.TargetVMSize = $ReplicationMigrationItem.ProviderSpecificDetail.TargetVmSize
                }

                if($HasTargetBootDignosticStorageAccount){
                    $ProviderSpecificDetails.TargetBootDiagnosticsStorageAccountId = $TargetBootDiagnosticsStorageAccount
                }else{
                    $ProviderSpecificDetails.TargetBootDiagnosticsStorageAccountId = $ReplicationMigrationItem.ProviderSpecificDetail.TargetBootDiagnosticsStorageAccountId
                }
                 
                # Storage accounts need to be in the same subscription as that of the VM.
                if (($null -ne $ProviderSpecificDetails.TargetBootDiagnosticsStorageAccountId) -and ($ProviderSpecificDetails.TargetBootDiagnosticsStorageAccountId.length -gt 1)){
                    $TargetBDSASubscriptionId = $ProviderSpecificDetails.TargetBootDiagnosticsStorageAccountId.Split('/')[2]
                    $TargetSubscriptionId = $ProviderSpecificDetails.TargetResourceGroupId.Split('/')[2]
                    if($TargetBDSASubscriptionId -ne $TargetSubscriptionId){
                        $ProviderSpecificDetails.TargetBootDiagnosticsStorageAccountId = $null
                    }
                }

                $originalNics = $ReplicationMigrationItem.ProviderSpecificDetail.VMNic
                [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtNicInput[]]$updateNicsArray = @()

                foreach ($storedNic in $originalNics) {
                    $updateNic = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtNicInput]::new()
                    $updateNic.IsPrimaryNic = $storedNic.IsPrimaryNic
                    $updateNic.IsSelectedForMigration = $storedNic.IsSelectedForMigration
                    $updateNic.NicId = $storedNic.NicId
                    $updateNic.TargetStaticIPAddress = $storedNic.TargetIPAddress
                    $updateNic.TargetSubnetName = $storedNic.TargetSubnetName
                    
                    $matchingUserInputNic = $null
                    if($HasNicToUpdate){
                        foreach ($userInputNic in $NicToUpdate) {
                            if($userInputNic.NicId -eq $storedNic.NicId){
                                $matchingUserInputNic = $userInputNic
                                break
                            }
                        }
                    }
                    if($matchingUserInputNic -ne $null){
                        if($matchingUserInputNic.IsPrimaryNic -ne $null){
                            $updateNic.IsPrimaryNic = $matchingUserInputNic.IsPrimaryNic
                            $updateNic.IsSelectedForMigration = $matchingUserInputNic.IsSelectedForMigration
                            if($updateNic.IsSelectedForMigration -eq "false"){
                                $updateNic.TargetSubnetName = ""
                                $updateNic.TargetStaticIPAddress = ""
                            }
                        }
                        if($matchingUserInputNic.TargetSubnetName -ne $null){
                            $updateNic.TargetSubnetName = $matchingUserInputNic.TargetSubnetName
                        }
                        if($matchingUserInputNic.TargetStaticIPAddress -ne $null){
                            if($matchingUserInputNic.TargetStaticIPAddress -eq "auto"){
                                $updateNic.TargetStaticIPAddress = $null
                            }else{
                                $updateNic.TargetStaticIPAddress = $matchingUserInputNic.TargetStaticIPAddress
                            }
                        }
                    }
                    $updateNicsArray += $updateNic
                }

                # validate there is exactly one primary nic
                $primaryNicCountInUpdate = 0
                foreach($nic in $updateNicsArray){
                    if($nic.IsPrimaryNic -eq "true"){
                        $primaryNicCountInUpdate += 1
                    }
                }
                if($primaryNicCountInUpdate -ne 1){
                    throw "One NIC has to be Primary."
                }
                
                $ProviderSpecificDetails.VMNic = $updateNicsArray
                $null = $PSBoundParameters.Add('ProviderSpecificDetail', $ProviderSpecificDetails)
                $null = $PSBoundParameters.Add('NoWait', $true)
                $output =  Az.Migrate.internal\Update-AzMigrateReplicationMigrationItem @PSBoundParameters
                $JobName =  $output.Target.Split("/")[12].Split("?")[0]

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
            }else{
                throw "Either machine doesn't exist or provider/action isn't supported for this machine"
            } 

    }

}   