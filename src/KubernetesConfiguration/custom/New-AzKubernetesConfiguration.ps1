
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
Create a new Kubernetes Source Control Configuration.
.Description
Create a new Kubernetes Source Control Configuration.
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfiguration
.Link
https://docs.microsoft.com/en-us/powershell/module/az.kubernetesconfiguration/new-azsourcecontrolconfiguration
#>
function New-AzKubernetesConfiguration {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfiguration])]
    [CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory, HelpMessage="The name of the kubernetes cluster.")]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Path')]
        [System.String]
        # The name of the kubernetes cluster.
        ${ClusterName},
    
        [Parameter(HelpMessage="The Kubernetes cluster resource name - either managedClusters (for AKS clusters) or connectedClusters (for OnPrem K8S clusters).")]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Path')]
        [System.String]
        # The Kubernetes cluster resource name - either managedClusters (for AKS clusters) or connectedClusters (for OnPrem K8S clusters).
        ${ClusterType},
    
        [Parameter(Mandatory, HelpMessage="Name of the Source Control Configuration.")]
        [Alias('SourceControlConfigurationName')]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Path')]
        [System.String]
        # Name of the Source Control Configuration.
        ${Name},
    
        [Parameter(Mandatory, HelpMessage="The name of the resource group.")]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Path')]
        [System.String]
        # The name of the resource group.
        ${ResourceGroupName},
    
        [Parameter(HelpMessage="The Azure subscription ID.")]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The Azure subscription ID.
        # This is a GUID-formatted string (e.g.
        # 00000000-0000-0000-0000-000000000000)
        ${SubscriptionId},
    
        [Parameter(Mandatory, HelpMessage="Url of the SourceControl Repository.")]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Body')]
        [System.String]
        # Url of the SourceControl Repository.
        ${RepositoryUrl},
    
        [Parameter(HelpMessage="Option to enable Helm Operator for this git configuration.")]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Body')]
        [switch]
        # Option to enable Helm Operator for this git configuration.
        ${EnableHelmOperator},
    
        [Parameter(HelpMessage="Values override for the operator Helm chart.")]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Body')]
        [System.String]
        # Values override for the operator Helm chart.
        ${HelmOperatorChartValues},
    
        [Parameter(HelpMessage="Version of the operator Helm chart.")]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Body')]
        [System.String]
        # Version of the operator Helm chart.
        ${HelmOperatorChartVersion},
    
        [Parameter(HelpMessage="Instance name of the operator - identifying the specific configuration.")]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Body')]
        [System.String]
        # Instance name of the operator - identifying the specific configuration.
        ${OperatorInstanceName},
    
        [Parameter(HelpMessage="The namespace to which this operator is installed to. Maximum of 253 lower case alphanumeric characters, hyphen and period only.")]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Body')]
        [System.String]
        # The namespace to which this operator is installed to.
        # Maximum of 253 lower case alphanumeric characters, hyphen and period only.
        ${OperatorNamespace},
    
        [Parameter(HelpMessage="Any Parameters for the Operator instance in string format.")]
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Body')]
        [System.String]
        # Any Parameters for the Operator instance in string format.
        ${OperatorParameters},

        [Parameter(HelpMessage="If passed set the scope of the Configuration to Cluster (default is nameSpace).")]
        [switch]
        ${ClusterScoped},
    
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

        if ($PSBoundParameters.ContainsKey('EnableHelmOperator')) {
            $PSBoundParameters.EnableHelmOperator = [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.EnableHelmOperator]::True
        } else {
            $PSBoundParameters.EnableHelmOperator = [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.EnableHelmOperator]::False
        }

        if ($PSBoundParameters.ContainsKey('ClusterScoped')) {
            $PSBoundParameters.OperatorScope = [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScope]::Cluster
        } else {
            $PSBoundParameters.OperatorScope = [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScope]::Namespace
        }

        if ($PSBoundParameters.ContainsKey('ClusterType')) {
            if ($ClusterType -eq 'ManagedClusters') {
                $PSBoundParameters.Add('ClusterRp', 'Microsoft.ContainerService')
            } elseif ($ClusterType -eq 'ConnectedClusters') {
                $PSBoundParameters.Add('ClusterRp', 'Microsoft.Kubernetes')
            }
        } else {
            $PSBoundParameters.Add('ClusterType', 'ConnectedClusters')
            $PSBoundParameters.Add('ClusterRp', 'Microsoft.Kubernetes')
        }

        if ($PSBoundParameters.ContainsKey('HelmOperatorChartValues')) {
            $PSBoundParameters.Add('HelmOperatorPropertyChartValue', $HelmOperatorChartValues)
            $null = $PSBoundParameters.Remove('HelmOperatorChartValues')
        }

        if ($PSBoundParameters.ContainsKey('HelmOperatorChartVersion')) {
            $PSBoundParameters.Add('HelmOperatorPropertyChartVersion', $HelmOperatorChartVersion)
            $null = $PSBoundParameters.Remove('HelmOperatorChartVersion')
        }

        if ($PSBoundParameters.ContainsKey('OperatorParam')) {
            $PSBoundParameters.Add('OperatorParameters', $OperatorParam)
            $null = $PSBoundParameters.Remove('OperatorParam')
        }
        $PSBoundParameters.Add('OperatorType', [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType]::Flux)

        
        Az.KubernetesConfiguration.internal\New-AzKubernetesConfiguration @PSBoundParameters
    }
}
