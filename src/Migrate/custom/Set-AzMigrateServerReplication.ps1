
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
        [System.String]
        # Updates the NIC for the Azure VM to be created.
        ${UpdateNic},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies whether the NIC to be updated will be the primary, secondary or not migrated.
        ${TargetNicSelectionType},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Subnet name for the NIC in the destination Virtual Network to which the server needs to be migrated.
        ${TargetNicSubnet},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the IP within the destination subnet to be used for the NIC.
        ${TargetNicIP},

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
            $HasUpdateNic = $PSBoundParameters.ContainsKey('$UpdateNic')
            $HasTargetNicSelectionType = $PSBoundParameters.ContainsKey('TargetNicSelectionType')
            $HasTargetNicSubnet = $PSBoundParameters.ContainsKey('TargetNicSubnet')
            $HasTargetNicIP = $PSBoundParameters.ContainsKey('TargetNicIP')
            $HasTargetAvailabilitySet = $PSBoundParameters.ContainsKey('TargetAvailabilitySet')
            $HasTargetAvailabilityZone = $PSBoundParameters.ContainsKey('TargetAvailabilityZone')

            $null = $PSBoundParameters.Remove('TargetObjectID')
            $null = $PSBoundParameters.Remove('TargetVMName')
            $null = $PSBoundParameters.Remove('TargetVMSize')
            $null = $PSBoundParameters.Remove('TargetNetworkId')
            $null = $PSBoundParameters.Remove('TargetResourceGroupID')
            $null = $PSBoundParameters.Remove('UpdateNic')
            $null = $PSBoundParameters.Remove('TargetNicSelectionType')
            $null = $PSBoundParameters.Remove('TargetNicSubnet')
            $null = $PSBoundParameters.Remove('TargetNicIP')
            $null = $PSBoundParameters.Remove('TargetAvailabilitySet')
            $null = $PSBoundParameters.Remove('TargetAvailabilityZone')
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('ProjectName')
            $null = $PSBoundParameters.Remove('MachineName')
            $null = $PSBoundParameters.Remove('InputObject')
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
                $ProviderSpecificDetails.InstanceType = 'VMwareCbt'
                if($HasTargetAvailabilitySet){
                    $ProviderSpecificDetails.TargetAvailabilitySetId = $TargetAvailabilitySet
                }
                if($HasTargetAvailabilityZone){
                    $ProviderSpecificDetails.TargetAvailabilityZone = $TargetAvailabilityZone
                }
                if($HasTargetNetworkId){
                    $ProviderSpecificDetails.TargetNetworkId = $TargetNetworkId
                }
                if($HasTargetVMName){
                    $ProviderSpecificDetails.TargetVMName = $TargetVMName
                }
                if($HasTargetResourceGroupID){
                    $ProviderSpecificDetails.TargetResourceGroupId = $TargetResourceGroupID
                }
                if($HasTargetVmSize){
                    $ProviderSpecificDetails.TargetVMSize = $TargetVmSize
                }
                if($HasUpdateNic){
                    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtNicInput[]]$Nics = @()
                    $VmNic = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtNicInput]::new()
                    $VmNic.TargetSubnetName = $TargetNicSubnet
                    $VmNic.TargetStaticIPAddress = $TargetNicIP
                    $VmNic.NicId = $UpdateNic
                    if($HasTargetNicSelectionType){
                        if($TargetNicSelectionType -eq 'primary'){
                            $VmNic.IsPrimaryNic = "true"
                            $VmNic.IsSelectedForMigration = "true"
                        }elseif($TargetNicSelectionType -eq 'secondary'){
                            $VmNic.IsPrimaryNic = "false"
                            $VmNic.IsSelectedForMigration = "true"
                        }elseif($TargetNicSelectionType -eq 'donotcreate'){
                            $VmNic.IsPrimaryNic = "false"
                            $VmNic.IsSelectedForMigration = "false"
                        }
                    }
                    $Nics += $VmNic
                    $ProviderSpecificDetails.VMNic = $Nics
                }
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