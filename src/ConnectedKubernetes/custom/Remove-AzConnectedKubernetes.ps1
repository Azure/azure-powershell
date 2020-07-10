
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
Delete a connected cluster, removing the tracked resource in Azure Resource Manager (ARM).
.Description
Delete a connected cluster, removing the tracked resource in Azure Resource Manager (ARM).

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.IConnectedKubernetesIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IConnectedKubernetesIdentity>: Identity Parameter
  [ClusterName <String>]: The name of the Kubernetes cluster on which get is called.
  [Id <String>]: Resource identity path
  [ResourceGroupName <String>]: The name of the resource group. The name is case insensitive.
  [SubscriptionId <String>]: The ID of the target subscription.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.connectedkubernetes/remove-azconnectedkubernetes
#>
function Remove-AzConnectedKubernetes {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Delete', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Alias('Name')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Path')]
    [System.String]
    # The name of the Kubernetes cluster on which get is called.
    ${ClusterName},

    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},
    
    [Parameter(HelpMessage="Path to the kube config file")]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
    [System.String]
    # Path to the kube config file
    ${KubeConfig},

    [Parameter(HelpMessage="Kubconfig context from current machine")]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
    [System.String]
    # Kubconfig context from current machine
    ${KubeContext},

    [Parameter(ParameterSetName='Delete')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='DeleteViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.IConnectedKubernetesIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

    process {
        if ($PSBoundParameters.ContainsKey('KubeConfig')) {
            $Null = $PSBoundParameters.Remove('KubeConfig')
        } elseif (Test-Path Env:KUBECONFIG) {
            $KubeConfig = Get-ChildItem -Path Env:KUBECONFIG
        } elseif (Test-Path Env:Home) {
            $KubeConfig = Join-Path -Path $Env:Home -ChildPath '.kube' | Join-Path -ChildPath 'config'
        } else {
            $KubeConfig = Join-Path -Path $Home -ChildPath '.kube' | Join-Path -ChildPath 'config'
        }
        if (-not (Test-Path $KubeConfig)) {
            Write-Error 'Cannot find the kube-config. Please make sure that you have the kube-config on your machine.'
            return
        }
        if ($PSBoundParameters.ContainsKey('KubeContext')) {
            $Null = $PSBoundParameters.Remove('KubeContext')
        }
        if (($KubeContext -eq $null) -or ($KubeContext -eq '')) {
            $KubeContext = kubectl config current-context
        }

        #Region check helm install
        try {
            $HelmVersion = helm version --short --kubeconfig $KubeConfig
            if ($HelmVersion.Contains("v2")) {
                Write-Error "Helm version 3+ is required. Ensure that you have installed the latest version of Helm. Learn more at https://aka.ms/arc/k8s/onboarding-helm-install"
                return
            }
        } catch {
            Write-Error "Helm version 3+ is required. Ensure that you have installed the latest version of Helm. Learn more at https://aka.ms/arc/k8s/onboarding-helm-install"
            throw
        }
        #Endregion

        #Region get release namespace
        $ReleaseNamespace = $null
        try {
            $ReleaseNamespace = (helm status azure-arc -o json --kubeconfig $KubeConfig --kube-context $KubeContext | ConvertFrom-Json).namespace
        } catch {
            Write-Error "Fail to find the namespace for azure-arc."
        }
        #Endregion

        if ($null -eq $ReleaseNamespace) {
            Az.ConnectedKubernetes.internal\Remove-AzConnectedKubernetes @PSBoundParameters
            return
        }

        $Configmap = kubectl get configmap --namespace azure-arc azure-clusterconfig -o json --kubeconfig $KubeConfig | ConvertFrom-Json
        $ConfigmapRgName = $Configmap.data.AZURE_RESOURCE_GROUP
        $ConfigmapClusterName = $Configmap.data.AZURE_RESOURCE_NAME
        if ($PSBoundParameters.ContainsKey('InputObject')) {
            $ResourceGroupName = $InputObject.ResourceGroupName
            $ClusterName = $InputObject.ClusterName
            $Null = $PSBoundParameters.Remove('InputObject')
            $PSBoundParameters.Add('ResourceGroupName')
            $PSBoundParameters.Add('ClusterName')
        }
        if (($ResourceGroupName -eq $ConfigmapRgName) -and ($ClusterName -eq $ConfigmapClusterName)) {
            Az.ConnectedKubernetes.internal\Remove-AzConnectedKubernetes @PSBoundParameters
            helm delete azure-arc --namespace $ReleaseNamespace --kubeconfig $KubeConfig --kube-context $KubeContext
        } else {
            Write-Error "The current context in the kubeconfig file does not correspond to the connected cluster resource specified. Agents installed on this cluster correspond to the resource group name '$ConfigmapRgName' and resource name '$ConfigmapClusterName'."
        }
    }
}
