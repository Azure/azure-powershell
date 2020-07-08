
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
.Example
PS C:\> New-AzKubernetesConfiguration -Name conf-test01 -ClusterName connaks-d983yc -ResourceGroupName connaks-rg-w9vlnp -RepositoryUrl http://github.com/xxxx

Name        Type
----        ----
conf-test01 Microsoft.KubernetesConfiguration/sourceControlConfigurations

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfiguration
.Link
https://docs.microsoft.com/en-us/powershell/module/az.kubernetesconfiguration/new-azsourcecontrolconfiguration
#>
function New-AzKubernetesConfiguration {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfiguration])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Path')]
    [System.String]
    # The name of the kubernetes cluster.
    ${ClusterName},

    [Parameter(Mandatory)]
    [Alias('SourceControlConfigurationName')]
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Path')]
    [System.String]
    # Name of the Source Control Configuration.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Path')]
    [System.String]
    # The name of the resource group.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Path')]
    [System.String]
    # The Kubernetes cluster resource name - either managedClusters (for AKS clusters) or connectedClusters (for OnPrem K8S clusters).
    ${ClusterType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription ID.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Body')]
    [System.String]
    # Url of the SourceControl Repository.
    ${RepositoryUrl},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Option to enable Helm Operator for this git configuration.
    ${EnableHelmOperator},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Body')]
    [System.String]
    # Values override for the operator Helm chart.
    ${HelmOperatorChartValues},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Body')]
    [System.String]
    # Version of the operator Helm chart.
    ${HelmOperatorChartVersion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Body')]
    [System.String]
    # Instance name of the operator - identifying the specific configuration.
    ${OperatorInstanceName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Body')]
    [System.String]
    # The namespace to which this operator is installed to.
    # Maximum of 253 lower case alphanumeric characters, hyphen and period only.
    ${OperatorNamespace},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Body')]
    [System.String]
    # Any Parameters for the Operator instance in string format.
    ${OperatorParameters},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # If passed set the scope of the Configuration to Cluster (default is nameSpace).
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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            CreateExpanded = 'Az.KubernetesConfiguration.custom\New-AzKubernetesConfiguration';
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
