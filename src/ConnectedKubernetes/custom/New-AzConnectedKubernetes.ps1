
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
API to register a new K8s cluster and thereby create a tracked resource in ARM
.Description
API to register a new K8s cluster and thereby create a tracked resource in ARM
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedCluster
.Link
https://docs.microsoft.com/en-us/powershell/module/az.connectedkubernetes/new-azconnectedkubernetes
#>
function New-AzConnectedKubernetes {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedCluster])]
    [CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Alias('Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Path')]
        [System.String]
        # The name of the Kubernetes cluster on which get is called.
        ${ClusterName},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Path')]
        [System.String]
        # The name of the resource group to which the kubernetes cluster is registered.
        ${ResourceGroupName},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the subscription to which the kubernetes cluster is registered.
        ${SubscriptionId},
    
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
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [System.String]
        # Location of the cluster
        ${Location},
    
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
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
        } else {
            $KubeConfig = Join-Path -Path $Env:Home -ChildPath '.kube' | Join-Path -ChildPath 'config'
        }
        if (-not (Test-Path $KubeConfig)) {
            Write-Error 'Cannot find the kube-config. Please make sure that you have the kube-config on your machine.'
            return
        }
        if ($PSBoundParameters.ContainsKey('KubeContext')) {
            $Null = $PSBoundParameters.Remove('KubeContext')
        }

        #region helm
        try {
            if ($KubeContext -eq $null) {
                helm --kubeconfig $KubeConfig --debug
            } else {
                helm --kubeconfig $KubeConfig --debug --kube-context $KubeContext
            }
            $HelmVersion = helm version --short --kubeconfig $KubeConfig
            if ($HelmVersion.Contains("v2")) {
                Write-Error "Helm version 3+ is required. Ensure that you have installed the latest version of Helm. Learn more at https://aka.ms/arc/k8s/onboarding-helm-install"
                return
            }
        } catch {
            Write-Error "Helm version 3+ is required. Ensure that you have installed the latest version of Helm. Learn more at https://aka.ms/arc/k8s/onboarding-helm-install"
            throw
        }
        #endregion helm
        
        try {
            $CommonPSBoundParameters = @{}
            if ($PSBoundParameters.ContainsKey('HttpPipelineAppend')) {
                $CommonPSBoundParameters['HttpPipelineAppend'] = $HttpPipelineAppend
            }
            if ($PSBoundParameters.ContainsKey('HttpPipelinePrepend')) {
                $CommonPSBoundParameters['HttpPipelinePrepend'] = $HttpPipelinePrepend
            }
            if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                $CommonPSBoundParameters['SubscriptionId'] = $SubscriptionId
            }
            $ExistConnectedKubernetes = Get-AzConnectedKubernetes -ResourceGroupName $ResourceGroupName -ClusterName $ClusterName @CommonPSBoundParameters
            return $ExistConnectedKubernetes
        } catch {
        }
        $AadProfileClientAppId = ''
        $PSBoundParameters.Add('AadProfileClientAppId', $AadProfileClientAppId)
        $AadProfileServerAppId = ''
        $PSBoundParameters.Add('AadProfileServerAppId', $AadProfileServerAppId)
        $AadProfileTenantId = ''
        $PSBoundParameters.Add('AadProfileTenantId', $AadProfileTenantId)

        $RSA = [System.Security.Cryptography.RSA]::Create(4096)
        $RsaPublicKeyXML = [xml]$RSA.ToXmlString($false)
        $AgentPublicKeyCertificate = $RsaPublicKeyXML.FirstChild.Modulus
        $PSBoundParameters.Add('AgentPublicKeyCertificate', $AgentPublicKeyCertificate)
        $IdentityType = [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ResourceIdentityType]::SystemAssigned
        $PSBoundParameters.Add('IdentityType', $IdentityType)
        Az.ConnectedKubernetes.internal\New-AzConnectedKubernetes @PSBoundParameters
    }
}
    