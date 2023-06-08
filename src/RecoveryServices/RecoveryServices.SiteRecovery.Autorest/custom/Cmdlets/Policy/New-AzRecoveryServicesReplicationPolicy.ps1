
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
The operation to create a replication policy.
.Description
The operation to create a replication policy.
.Example
{{ Add code here }}
.Example
{{ Add code here }}
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IPolicy
.Notes
COMPLEX PARAMETER PROPERTIES
#>

function New-AzRecoveryServicesReplicationPolicy {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IPolicy])]
    [CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory, HelpMessage='Specific replication policy name.')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Path')]
        [System.String]
        # Replication policy name.
        ${PolicyName},
    
        [Parameter(Mandatory, HelpMessage='The name of the resource group where the recovery services vault is present.')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Path')]
        [System.String]
        # The name of the resource group where the recovery services vault is present.
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='The name of the recovery services vault.')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Path')]
        [System.String]
        # The name of the recovery services vault.
        ${ResourceName},

        [Parameter(Mandatory=$false, HelpMessage="Subscription Id")]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The subscription Id.
        ${SubscriptionId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IPolicyProviderSpecificInput]
        # The ReplicationProviderSettings.
        # To construct, see NOTES section for PROVIDERSPECIFICINPUT properties and create a hash table.
        ${ProviderSpecificInput},

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
            $replicationscenario = $ProviderSpecificInput.ReplicationScenario
            if($replicationscenario -eq "ReplicateAzureToAzure") {
                $ProviderSpecificInput.ReplicationScenario = "A2A"
            }
            elseif ($replicationscenario -eq "ReplicateHyperVToAzure") {
                $ProviderSpecificInput.ReplicationScenario = "HyperVReplicaAzure"
            }
            else {
                throw "Provided replication scenario is not supported. Only ReplicateAzureToAzure and ReplicateHyperVToAzure are supported."
            }
            return Az.RecoveryServices.internal\New-AzRecoveryServicesReplicationPolicy @PSBoundParameters
        } catch {
            throw
        }
    }
}