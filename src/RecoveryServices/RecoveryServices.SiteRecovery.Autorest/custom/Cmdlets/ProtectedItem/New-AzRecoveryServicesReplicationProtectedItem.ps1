
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
The operation to create an ASR replication protected item (Enable replication).
.Description
The operation to create an ASR replication protected item (Enable replication).

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IJob
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

PROVIDERSPECIFICDETAIL <IEnableProtectionProviderSpecificInput>: The ReplicationProviderInput. For HyperVReplicaAzure provider, it will be AzureEnableProtectionInput object. For San provider, it will be SanEnableProtectionInput object. For HyperVReplicaAzure provider, it can be null.
  InstanceType <String>: The class type.
.Link
https://docs.microsoft.com/powershell/module/az.recoveryservices/new-azrecoveryservicesreplicationprotecteditem
#>
function New-AzRecoveryServicesReplicationProtectedItem {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IJob])]
    [CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerMapping]
        # Protection container mapping object.
        ${ProtectionContainerMapping},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Path')]
        [System.String]
        # A name for the replication protected item.
        ${ReplicatedProtectedItemName},

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
        [ValidateNotNullOrEmpty()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        # The protectable item Id.
        ${ProtectableItemId},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        # Primary Staging Azure Storage Account Id.
        ${LogStorageAccountId},

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        # Primary Staging Azure Storage Account Id.
        ${RecoveryAzureStorageAccountId},

        [Parameter(Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IEnableProtectionProviderSpecificInput]
        # The ReplicationProviderInput.
        # For HyperVReplicaAzure provider, it will be AzureEnableProtectionInput object.
        # For San provider, it will be SanEnableProtectionInput object.
        # For HyperVReplicaAzure provider, it can be null.
        # To construct, see NOTES section for PROVIDERSPECIFICDETAIL properties and create a hash table.
        ${ProviderSpecificDetail},

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
            CheckComputeModuleDependency

            $replicationscenario = $ProviderSpecificDetail.ReplicationScenario
            if($replicationscenario -eq "ReplicateAzureToAzure") {
                $ProviderSpecificDetail.ReplicationScenario = "A2A"
            }
            else {
                throw "Provided replication scenario is not supported. Only ReplicateAzureToAzure is supported."
            }

            if($ProviderSpecificDetail.ReplicationScenario -ne $ProtectionContainerMapping.ProviderSpecificDetailInstanceType) {
                throw "Input replication scenario and mapping replication scenario cannot be different"
            }

            if(-not [string]::IsNullOrEmpty($ProviderSpecificDetail.FabricObjectId)) {
                $Vmdetails = $ProviderSpecificDetail.FabricObjectId.Split("/")
            }
            else {
                throw 'Please provide fabric object id in provider specific detail input'
            }

            $VmResouceGroup = $Vmdetails[-5]
            $VmName = $Vmdetails[-1]
            $Vm = Get-AzVM -ResourceGroupName $VmResouceGroup -Name $VmName

            if($ProviderSpecificDetail.ReplicationScenario -eq "A2A") {
                if($ProviderSpecificDetail.VMManagedDisk -eq $null) {
                    if ($Vm.StorageProfile.OsDisk.ManagedDisk -ne $null) {
                        $diskInput = @()

                        $osDiskInput = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AVmManagedDiskInputDetails]::new()
                        $osDiskInput.DiskId = $Vm.StorageProfile.OsDisk.ManagedDisk.Id
                        $osDiskInput.PrimaryStagingAzureStorageAccountId = $LogStorageAccountId
                        $osDiskInput.RecoveryResourceGroupId = $ProviderSpecificDetail.RecoveryResourceGroupId
                        $osDiskInput.RecoveryReplicaDiskAccountType = $Vm.StorageProfile.OsDisk.ManagedDisk.StorageAccountType
                        $osDiskInput.RecoveryTargetDiskAccountType = $Vm.StorageProfile.OsDisk.ManagedDisk.StorageAccountType

                        $diskInput += $osDiskInput

                        if($Vm.StorageProfile.DataDisks.ManagedDisk -ne $null) {
                            $Vm.StorageProfile.DataDisks.ManagedDisk | ForEach-Object {
                                $dataDiskInput = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AVmManagedDiskInputDetails]::new()
                                $dataDiskInput.DiskId = $_.Id
                                $dataDiskInput.PrimaryStagingAzureStorageAccountId = $LogStorageAccountId
                                $dataDiskInput.RecoveryResourceGroupId = $ProviderSpecificDetail.RecoveryResourceGroupId
                                $dataDiskInput.RecoveryReplicaDiskAccountType = $_.StorageAccountType
                                $dataDiskInput.RecoveryTargetDiskAccountType = $_.StorageAccountType

                                $diskInput += $dataDiskInput
                            }
                        }

                        $ProviderSpecificDetail.VMManagedDisk = $diskInput
                    }
                    else {
                        if($RecoveryAzureStorageAccountId -ne $null) {
                            $vmdiskInput = @()

                            $osDiskInput = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AVmDiskInputDetails]::new()
                            $osDiskInput.DiskUri = $vm.StorageProfile.OsDisk.Vhd.Uri
                            $osDiskInput.PrimaryStagingAzureStorageAccountId = $LogStorageAccountId
                            $osDiskInput.RecoveryAzureStorageAccountId = $RecoveryAzureStorageAccountId

                            $vmdiskInput += $osDiskInput

                            if($Vm.StorageProfile.DataDisks -ne $null) {
                                $Vm.StorageProfile.DataDisks | ForEach-Object {
                                    $dataDiskInput = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AVmDiskInputDetails]::new()
                                    $dataDiskInput.DiskUri = $_.Vhd.Uri
                                    $dataDiskInput.PrimaryStagingAzureStorageAccountId = $LogStorageAccountId
                                    $dataDiskInput.RecoveryAzureStorageAccountId = $RecoveryAzureStorageAccountId

                                    $vmdiskInput += $dataDiskInput
                                }
                            }

                            $ProviderSpecificDetail.VMDisk = $vmdiskInput
                        }
                        else {
                            throw "Recovery Storage account is required for non-managed disk vm to protect"
                        }
                    }
                }
                else {
                    if ($Vm.StorageProfile.OsDisk.ManagedDisk -ne $null) {
                        $osDiskExist = $false

                        $ProviderSpecificDetail.VMManagedDisk | ForEach-Object {
                            if($_.DiskId -eq $Vm.StorageProfile.OsDisk.ManagedDisk.Id) {
                                $osDiskExist = $true
                            }
                        }

                        if($osDiskExist -eq $false) {
                            $osDiskInput = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AVmManagedDiskInputDetails]::new()
                            $osDiskInput.DiskId = $vm.StorageProfile.OsDisk.ManagedDisk.Id
                            $osDiskInput.PrimaryStagingAzureStorageAccountId = $LogStorageAccountId
                            $osDiskInput.RecoveryResourceGroupId = $ProviderSpecificDetail.RecoveryResourceGroupId
                            $osDiskInput.RecoveryReplicaDiskAccountType = $Vm.StorageProfile.OsDisk.ManagedDisk.StorageAccountType
                            $osDiskInput.RecoveryTargetDiskAccountType = $Vm.StorageProfile.OsDisk.ManagedDisk.StorageAccountType

                            $Vm.StorageProfile.OsDisk.ManagedDisk += $osDiskInput
                        }
                    }
                }
            }

            $policyId = $ProtectionContainerMapping.PolicyId
            if(-not [string]::IsNullOrEmpty($ProtectionContainerMapping.id)) {
                $protectionContainermapString = $ProtectionContainerMapping.id.Split("/")
            }
            else {
                throw 'Protection container mapping does not contain an ARM Id. Please check the protection container mapping details'
            }
            $protectionContainerName = $protectionContainermapString[-3]
            $fabricName = $protectionContainermapString[-5]

            if($ProviderSpecificDetail.RecoveryContainerId -eq $null) {
                $ProviderSpecificDetail.RecoveryContainerId = $ProtectionContainerMapping.TargetProtectionContainerId
            }

            $null = $PSBoundParameters.Remove("ProtectionContainerMapping")
            $null = $PSBoundParameters.Remove("LogStorageAccountId")
            $null = $PSBoundParameters.Remove("RecoveryAzureStorageAccountId")
            $null = $PSBoundParameters.Add("PolicyId", $policyId)
            $null = $PSBoundParameters.Add("FabricName", $fabricName)
            $null = $PSBoundParameters.Add("ProtectionContainerName", $protectionContainerName)
            $null = $PSBoundParameters.Add("NoWait", $true)

            $output = Az.RecoveryServices.internal\New-AzRecoveryServicesReplicationProtectedItem @PSBoundParameters
            
            if(-not [string]::IsNullOrEmpty($output.Target)) {
                $JobName = $output.Target.Split("/")[-1].Split("?")[0]
            }
            else {
                throw 'The process has not returned any job id.'
            }

            $null = $PSBoundParameters.Remove("PolicyId")
            $null = $PSBoundParameters.Remove("FabricName")
            $null = $PSBoundParameters.Remove("ProtectionContainerName")
            $null = $PSBoundParameters.Remove("NoWait")
            $null = $PSBoundParameters.Remove("ProtectableItemId")
            $null = $PSBoundParameters.Remove("ProviderSpecificDetail")
            $null = $PSBoundParameters.Remove("ReplicatedProtectedItemName")
            $null = $PSBoundParameters.Add("JobName", $JobName)

            return Get-AzRecoveryServicesReplicationJob @PSBoundParameters
        } catch {
            throw
        }
    }
}
