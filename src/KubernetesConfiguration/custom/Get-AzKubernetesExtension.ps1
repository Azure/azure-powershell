
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
Gets Kubernetes Cluster Extension.
.Description
Gets Kubernetes Cluster Extension.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.IKubernetesConfigurationIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210901.IExtension
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IKubernetesConfigurationIdentity>: Identity Parameter
  [ClusterName <String>]: The name of the kubernetes cluster.
  [ClusterResourceName <String>]: The Kubernetes cluster resource name - either managedClusters (for AKS clusters) or connectedClusters (for OnPrem K8S clusters).
  [ClusterRp <String>]: The Kubernetes cluster RP - either Microsoft.ContainerService (for AKS clusters) or Microsoft.Kubernetes (for OnPrem K8S clusters).
  [ExtensionName <String>]: Name of the Extension.
  [Id <String>]: Resource identity path
  [OperationId <String>]: operation Id
  [ResourceGroupName <String>]: The name of the resource group.
  [SourceControlConfigurationName <String>]: Name of the Source Control Configuration.
  [SubscriptionId <String>]: The Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000)
.Link
https://docs.microsoft.com/powershell/module/az.kubernetesconfiguration/get-azkubernetesextension
#>
function Get-AzKubernetesExtension {
    [Alias('Get-AzK8sExtension')]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210901.IExtension])]
    [CmdletBinding(DefaultParameterSetName = 'List', PositionalBinding = $false)]
    param(
        [Parameter(ParameterSetName = 'Get', Mandatory)]
        [Parameter(ParameterSetName = 'List', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Path')]
        [System.String]
        # The name of the kubernetes cluster.
        ${ClusterName},

        [Parameter(ParameterSetName = 'Get', Mandatory)]
        [Parameter(ParameterSetName = 'List', Mandatory)]
        [ValidateSet('ConnectedClusters', 'ManagedClusters')]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Path')]
        [System.String]
        # The Kubernetes cluster resource name - either managedClusters (for AKS clusters) or connectedClusters (for OnPrem K8S clusters).
        ${ClusterType},

        [Parameter(ParameterSetName = 'Get', Mandatory)]
        [Alias('ExtensionName')]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Path')]
        [System.String]
        # Name of the Extension.
        ${Name},

        [Parameter(ParameterSetName = 'Get', Mandatory)]
        [Parameter(ParameterSetName = 'List', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'Get')]
        [Parameter(ParameterSetName = 'List')]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # The Azure subscription ID.
        # This is a GUID-formatted string (e.g.
        # 00000000-0000-0000-0000-000000000000)
        ${SubscriptionId},

        [Parameter(ParameterSetName = 'GetViaIdentity', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.IKubernetesConfigurationIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        if ($ClusterType -eq 'ManagedClusters') {
            $PSBoundParameters.Add('ClusterRp', 'Microsoft.ContainerService')
        }
        elseif ($ClusterType -eq 'ConnectedClusters') {
            $PSBoundParameters.Add('ClusterRp', 'Microsoft.Kubernetes')
        }

        Az.KubernetesConfiguration.internal\Get-AzKubernetesExtension @PSBoundParameters
    }
}
