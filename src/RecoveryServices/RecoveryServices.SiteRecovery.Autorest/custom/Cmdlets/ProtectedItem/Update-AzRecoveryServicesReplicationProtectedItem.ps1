
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
The operation to update the recovery settings of an ASR replication protected item.
.Description
The operation to update the recovery settings of an ASR replication protected item.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IJob
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

PROVIDERSPECIFICDETAIL <IUpdateReplicationProtectedItemProviderInput>: The provider specific input to update replication protected item.
  InstanceType <String>: The class type.
.Link
https://docs.microsoft.com/powershell/module/az.recoveryservices/update-azrecoveryservicesreplicationprotecteditem
#>
function Update-AzRecoveryServicesReplicationProtectedItem {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IJob])]
    [CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IReplicationProtectedItem]
        # Replication protected item Object.
        ${ReplicatedProtectedItem},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Path')]
        [System.String]
        # The name of the resource group where the recovery services vault is present.
        ${ResourceGroupName},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Path')]
        [System.String]
        # The name of the recovery services vault.
        ${ResourceName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The subscription Id.
        ${SubscriptionId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        # The selected option to enable RDP\SSH on target vm after failover.
        # String value of SrsDataContract.EnableRDPOnTargetOption enum.
        ${EnableRdpOnTargetOption},

        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.LicenseType])]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.LicenseType]
        # License type.
        ${LicenseType},

        [Parameter(Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IUpdateReplicationProtectedItemProviderInput]
        # The provider specific input to update replication protected item.
        # To construct, see NOTES section for PROVIDERSPECIFICDETAIL properties and create a hash table.
        ${ProviderSpecificDetail},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        # The target availability set Id.
        ${RecoveryAvailabilitySetId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        # Target Azure VM name given by the user.
        ${RecoveryAzureVMName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        # Target Azure VM size.
        ${RecoveryAzureVMSize},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        # Target Azure Network Id.
        ${SelectedRecoveryAzureNetworkId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        # The selected source nic Id which will be used as the primary nic during failover.
        ${SelectedSourceNicId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        # The Azure Network Id for test failover.
        ${SelectedTfoAzureNetworkId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.VMNicConfig]
        # The list of VM nic details.
        # To construct, see NOTES section for VMNIC properties and create a hash table.
        ${VMNic},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        try {
            $ProviderSpecificDetails = $ReplicatedProtectedItem.ProviderSpecificDetail

            $replicationscenario = $ProviderSpecificDetail.ReplicationScenario

            if($replicationscenario -eq "ReplicateAzureToAzure" -and $ProviderSpecificDetails.InstanceType -eq "A2A") {
                $ProviderSpecificDetail.ReplicationScenario = "A2A"
            }
            else {
                throw "Provided replication scenario is not supported. Only ReplicateAzureToAzure is supported."
            }

            if(-not [string]::IsNullOrEmpty($ReplicatedProtectedItem.id)) {
                $replicatedItem = $ReplicatedProtectedItem.id.Split("/")
            }
            else {
                throw 'Replicated Item does not contain an ARM Id. Please check the replicated item details'
            }

            $replictaedItemName = $replicatedItem[-1]
            $protectionContainerName = $replicatedItem[-3]
            $fabricName = $replicatedItem[-5]

            if($ProviderSpecificDetails.InstanceType -ne "A2A" -and $VMNic -ne $null) {
                throw "Unsupported Replication Scenario for Asr VM Nic Config"
            }

            if($ProviderSpecificDetails.InstanceType -eq "A2A") {

                if ([string]::IsNullOrEmpty($ProviderSpecificDetail.RecoveryResourceGroupId)) {
                    $ProviderSpecificDetail.RecoveryResourceGroupId = $ProviderSpecificDetails.RecoveryAzureResourceGroupId
                }

                $availabilitySetId = if($PSBoundParameters.ContainsKey('RecoveryAvailabilitySetId')) {
                    $RecoveryAvailabilitySetId
                }
                elseif(-not [string]::IsNullOrEmpty($ProviderSpecificDetails.RecoveryAvailabilitySet)) {
                    $ProviderSpecificDetails.RecoveryAvailabilitySet
                }

                if(-not $PSBoundParameters.ContainsKey('SelectedRecoveryAzureNetworkId')) {
                    $SelectedRecoveryAzureNetworkId = $ProviderSpecificDetails.SelectedRecoveryAzureNetworkId
                }

                $proximityPlacementGroupId = if(-not [string]::IsNullOrEmpty($ProviderSpecificDetail.RecoveryProximityPlacementGroupId)) {
                    $ProviderSpecificDetail.RecoveryProximityPlacementGroupId
                }
                elseif(-not [string]::IsNullOrEmpty($ProviderSpecificDetails.RecoveryProximityPlacementGroupId)) {
                    $ProviderSpecificDetails.RecoveryProximityPlacementGroupId
                }

                $virtualMachineScaleSetId = if(-not [string]::IsNullOrEmpty($ProviderSpecificDetail.RecoveryVirtualMachineScaleSetId)) {
                    $ProviderSpecificDetail.RecoveryVirtualMachineScaleSetId
                }
                elseif(-not [string]::IsNullOrEmpty($ProviderSpecificDetails.RecoveryVirtualMachineScaleSetId)) {
                    $ProviderSpecificDetails.RecoveryVirtualMachineScaleSetId
                }

                $capacityReservationGroupId = if(-not [string]::IsNullOrEmpty($ProviderSpecificDetail.RecoveryCapacityReservationGroupId)) {
                    $ProviderSpecificDetail.RecoveryCapacityReservationGroupId
                }
                elseif(-not [string]::IsNullOrEmpty($ProviderSpecificDetails.RecoveryCapacityReservationGroupId)) {
                    $ProviderSpecificDetails.RecoveryCapacityReservationGroupId
                }

                if([string]::IsNullOrEmpty($ProviderSpecificDetail.RecoveryCloudService) -and -not [string]::IsNullOrEmpty($ProviderSpecificDetails.RecoveryCloudService)) {
                    $ProviderSpecificDetail.RecoveryCloudServiceId = $ProviderSpecificDetails.RecoveryCloudService
                }

                if([string]::IsNullOrEmpty($ProviderSpecificDetail.RecoveryBootDiagStorageAccountId) -and -not [string]::IsNullOrEmpty($ProviderSpecificDetails.RecoveryBootDiagStorageAccountId)) {
                    $ProviderSpecificDetail.RecoveryBootDiagStorageAccountId = $ProviderSpecificDetails.RecoveryBootDiagStorageAccountId
                }

                if([string]::IsNullOrEmpty($ProviderSpecificDetail.TfoAzureVMName) -and -not [string]::IsNullOrEmpty($ProviderSpecificDetails.TfoAzureVMName)) {
                    $ProviderSpecificDetail.TfoAzureVMName = $ProviderSpecificDetails.TfoAzureVMName
                }

                if(-not $PSBoundParameters.ContainsKey('RecoveryAzureVMName')) {
                    $RecoveryAzureVMName = $ProviderSpecificDetails.RecoveryAzureVMName
                }

                if($PSBoundParameters.ContainsKey('VMNic')) {
                    if(-not $PSBoundParameters.ContainsKey('SelectedTfoAzureNetworkId') -and -not [string]::IsNullOrEmpty($VMNic.TfoVMNetworkId)) {
                        $SelectedTfoAzureNetworkId = $VMNic.TfoVMNetworkId
                    }

                    if(-not $PSBoundParameters.ContainsKey('SelectedRecoveryAzureNetworkId') -and -not [string]::IsNullOrEmpty($VMNic.RecoveryVMNetworkId)) {
                        $SelectedRecoveryAzureNetworkId = $VMNic.RecoveryVMNetworkId
                    }
                }
                else {
                    if(-not $PSBoundParameters.ContainsKey('SelectedTfoAzureNetworkId') -and -not [string]::IsNullOrEmpty($ProviderSpecificDetails.SelectedTfoAzureNetworkId)) {
                        $SelectedTfoAzureNetworkId = $ProviderSpecificDetails.SelectedTfoAzureNetworkId
                    }

                    if(-not $PSBoundParameters.ContainsKey('SelectedRecoveryAzureNetworkId') -and -not [string]::IsNullOrEmpty($ProviderSpecificDetails.SelectedRecoveryAzureNetworkId)) {
                        $SelectedRecoveryAzureNetworkId = $ProviderSpecificDetails.SelectedRecoveryAzureNetworkId
                    }
                }

                if($PSBoundParameters.ContainsKey('VMNic')) {
                    $vmNicConfig = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.VMNicInputDetails]::new()
                    $vmNicConfig.EnableAcceleratedNetworkingOnRecovery = $VMNic.EnableAcceleratedNetworkingOnRecovery
                    $vmNicConfig.EnableAcceleratedNetworkingOnTfo = $VMNic.EnableAcceleratedNetworkingOnTfo
                    $vmNicConfig.IPConfig = $VMNic.ipConfigList
                    $vmNicConfig.NicId = $VMNic.NicId
                    $vmNicConfig.RecoveryNetworkSecurityGroupId = $VMNic.RecoveryNetworkSecurityGroupId
                    $vmNicConfig.RecoveryNicName = $VMNic.RecoveryNicName
                    $vmNicConfig.RecoveryNicResourceGroupName = $VMNic.RecoveryNicResourceGroupName
                    $vmNicConfig.ReuseExistingNic = $VMNic.ReuseExistingNic
                    $vmNicConfig.SelectionType = $VMNic.SelectionType
                    $vmNicConfig.TargetNicName = $VMNic.TargetNicName
                    $vmNicConfig.TfoNetworkSecurityGroupId = $VMNic.TfoNetworkSecurityGroupId
                    $vmNicConfig.TfoNicName = $VMNic.TfoNicName
                    $vmNicConfig.TfoNicResourceGroupName = $VMNic.TfoNicResourceGroupName
                    $vmNicConfig.TfoReuseExistingNic = $VMNic.TfoReuseExistingNic

                    $null = $PSBoundParameters.Remove("VMNic")
                    $null = $PSBoundParameters.Add("VMNic", $vmNicConfig)
                }

                write-Output $PSBoundParameters.VMNic
            }

            $null = $PSBoundParameters.Remove("ReplicatedProtectedItem")
            $null = $PSBoundParameters.Add("ReplicatedProtectedItemName", $replictaedItemName)
            $null = $PSBoundParameters.Add("FabricName", $fabricName)
            $null = $PSBoundParameters.Add("ProtectionContainerName", $protectionContainerName)
            $null = $PSBoundParameters.Add("NoWait", $true)

            $output = Az.RecoveryServices.internal\Update-AzRecoveryServicesReplicationProtectedItem @PSBoundParameters

            if(-not [string]::IsNullOrEmpty($output.Target)) {
                $JobName = $output.Target.Split("/")[-1].Split("?")[0]
            }
            else {
                throw 'The process has not returned any job id.'
            }

            $null = $PSBoundParameters.Remove("ReplicatedProtectedItemName")
            $null = $PSBoundParameters.Remove("FabricName")
            $null = $PSBoundParameters.Remove("ProtectionContainerName")
            $null = $PSBoundParameters.Remove("NoWait")
            $null = $PSBoundParameters.Remove("VMNic")
            $null = $PSBoundParameters.Remove("SelectedTfoAzureNetworkId")
            $null = $PSBoundParameters.Remove("SelectedSourceNicId")
            $null = $PSBoundParameters.Remove("SelectedRecoveryAzureNetworkId")
            $null = $PSBoundParameters.Remove("RecoveryAzureVMSize")
            $null = $PSBoundParameters.Remove("RecoveryAzureVMName")
            $null = $PSBoundParameters.Remove("RecoveryAvailabilitySetId")
            $null = $PSBoundParameters.Remove("ProviderSpecificDetail")
            $null = $PSBoundParameters.Remove("LicenseType")
            $null = $PSBoundParameters.Remove("EnableRdpOnTargetOption")
            $null = $PSBoundParameters.Add("JobName", $JobName)

            return Get-AzRecoveryServicesReplicationJob @PSBoundParameters
        } catch {
            throw
        }
    }
}
