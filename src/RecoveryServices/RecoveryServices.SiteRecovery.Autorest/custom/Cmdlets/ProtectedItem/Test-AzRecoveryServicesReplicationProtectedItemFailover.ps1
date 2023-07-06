
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
Operation to perform a test failover of the replication protected item.
.Description
Operation to perform a test failover of the replication protected item.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IJob
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

PROVIDERSPECIFICDETAIL <ITestFailoverProviderSpecificInput>: Provider specific settings.
  InstanceType <String>: The class type.
.Link
https://docs.microsoft.com/powershell/module/az.recoveryservices/test-azrecoveryservicesreplicationprotecteditemfailover
#>
function Test-AzRecoveryServicesReplicationProtectedItemFailover {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IJob])]
    [CmdletBinding(DefaultParameterSetName='TestExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
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

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [ValidateSet('PrimaryToRecovery', 'RecoveryToPrimary')]
        [System.String]
        # Test failover direction.
        ${FailoverDirection},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        # The id of the network to be used for test failover.
        ${NetworkId},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        # Network type to be used for test failover.
        ${NetworkType},

        [Parameter(Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ITestFailoverProviderSpecificInput]
        # Provider specific settings.
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
            $replicationscenario = $ProviderSpecificDetail.ReplicationScenario
            if($replicationscenario -eq "ReplicateAzureToAzure") {
                $ProviderSpecificDetail.ReplicationScenario = "A2A"
            }
            else {
                throw "Provided replication scenario is not supported. Only ReplicateAzureToAzure is supported."
            }

            if($ProviderSpecificDetail.ReplicationScenario -ne $ReplicatedProtectedItem.ProviderSpecificDetail.InstanceType) {
                throw "Input replication scenario and replicated item replication scenario cannot be different"
            }

            if($FailoverDirection -ne "PrimaryToRecovery") {
                throw "Test failover only support primary to recovery flow direction"
            }

            if(-not [string]::IsNullOrEmpty($ReplicatedProtectedItem.id)) {
                $replicatedItem = $ReplicatedProtectedItem.id.Split("/")
            }
            else {
                throw 'Replicated Item does not contain an ARM Id. Please check the replicated item details'
            }

            $replicatedItemName = $replicatedItem[-1]
            $protectionContainerName = $replicatedItem[-3]
            $fabricName = $replicatedItem[-5]

            $null = $PSBoundParameters.Remove("ReplicatedProtectedItem")
            $null = $PSBoundParameters.Add("ReplicatedProtectedItemName", $replicatedItemName)
            $null = $PSBoundParameters.Add("FabricName", $fabricName)
            $null = $PSBoundParameters.Add("ProtectionContainerName", $protectionContainerName)
            $null = $PSBoundParameters.Add("NoWait", $true)

            $output = Az.RecoveryServices.internal\Test-AzRecoveryServicesReplicationProtectedItemFailover @PSBoundParameters
            
            if(-not [string]::IsNullOrEmpty($output.Target)) {
                $JobName = $output.Target.Split("/")[-1].Split("?")[0]
            }
            else {
                throw 'The process has not returned any job id.'
            }

            $null = $PSBoundParameters.Remove("FabricName")
            $null = $PSBoundParameters.Remove("ReplicatedProtectedItemName")
            $null = $PSBoundParameters.Remove("ProtectionContainerName")
            $null = $PSBoundParameters.Remove("NoWait")
            $null = $PSBoundParameters.Remove("ProviderSpecificDetail")
            $null = $PSBoundParameters.Remove("NetworkId")
            $null = $PSBoundParameters.Remove("NetworkType")
            $null = $PSBoundParameters.Remove("FailoverDirection")
            $null = $PSBoundParameters.Add("JobName", $JobName)

            return Get-AzRecoveryServicesReplicationJob @PSBoundParameters
        } catch {
            throw
        }
    }
}
