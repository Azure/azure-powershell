
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
        $AadProfileClientAppId = ''
        $PSBoundParameters.Add('AadProfileClientAppId', $AadProfileClientAppId)
        $AadProfileServerAppId = ''
        $PSBoundParameters.Add('AadProfileServerAppId', $AadProfileServerAppId)
        $AadProfileTenantId = ''
        $PSBoundParameters.Add('AadProfileTenantId', $AadProfileTenantId)
        $IdentityType = [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ResourceIdentityType]::SystemAssigned
        $PSBoundParameters.Add('IdentityType', $IdentityType)

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
        #EndRegion

        #Region get release namespace
        $ReleaseNamespace = $null
        try {
            $ReleaseNamespace = (helm status azure-arc -o json --kubeconfig $KubeConfig --kube-context $KubeContext | ConvertFrom-Json).namespace
        } catch {
            Write-Error "Fail to find the namespace for azure-arc."
        }
        #Endregion

        if ($null -ne $ReleaseNamespace) {
            # $Configmap = kubectl get configmap --namespace azure-arc azure-clusterconfig -o json --kubeconfig $KubeConfig | ConvertFrom-Json
            # $ConfigmapRgName = $Configmap.data.AZURE_RESOURCE_GROUP
            # $ConfigmapClusterName = $Configmap.data.AZURE_RESOURCE_NAME
            try {
                $ExistConnectedKubernetes = Get-AzConnectedKubernetes -ResourceGroupName $ResourceGroupName -ClusterName $ClusterName @CommonPSBoundParameters
        
                $PSBoundParameters.Add('AgentPublicKeyCertificate', $ExistConnectedKubernetes.AgentPublicKeyCertificate)
                Az.ConnectedKubernetes.internal\New-AzConnectedKubernetes @PSBoundParameters
                # if (($ResourceGroupName -eq $ConfigmapRgName) -and ($ClusterName -eq $ConfigmapClusterName)) {
                #     $PSBoundParameters.Add('AgentPublicKeyCertificate', $ExistConnectedKubernetes.AgentPublicKeyCertificate)
                #     Az.ConnectedKubernetes.internal\New-AzConnectedKubernetes @PSBoundParameters
                # } else {
                #     Write-Error "The kubernetes cluster you are trying to onboard is already onboarded to the resource group '${ConfigmapRgName}' with resource name '${ConfigmapClusterName}'."
                # }
                # return
            } catch {
                helm delete azure-arc --namespace $ReleaseNamespace --kubeconfig $KubeConfig --kube-context $KubeContext
            }
        }

        if ((Test-Path Env:HELMREPONAME) -and (Test-Path Env:HELMREPOURL)) {
            $HelmRepoName = Get-ChildItem -Path Env:HELMREPONAME
            $HelmRepoUrl = Get-ChildItem -Path Env:HELMREPOURL
            helm repo add $HelmRepoName $HelmRepoUrl --kubeconfig $KubeConfig --kube-context $KubeContext
        }

        if (Test-Path Env:HELMREGISTRY) {
            $RegisteryPath = Get-ChildItem -Path Env:HELMREGISTRY
        } else {
            $ReleaseTrain = ''
            if ((Test-Path Env:RELEASETRAIN) -and (Test-Path Env:RELEASETRAIN)) {
                $ReleaseTrain = Get-ChildItem -Path Env:RELEASETRAIN
            } else {
                $ReleaseTrain = 'stable'
            }
            $ChartLocationUrl = "https://${Location}.dp.kubernetesconfiguration.azure.com/azure-arc-k8sagents/GetLatestHelmPackagePath?api-version=2019-11-01-preview&releaseTrain=${ReleaseTrain}"
        
            $Uri = [System.Uri]::New($ChartLocationUrl)
            $Account = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Account
            $Env = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment]::PublicEnvironments[[Microsoft.Azure.Commands.Common.Authentication.Abstractions.EnvironmentName]::AzureCloud]
            $TenantId = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Tenant.Id
            $PromptBehavior = [Microsoft.Azure.Commands.Common.Authentication.ShowDialog]::Never
            $Token = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.AuthenticationFactory.Authenticate($account, $env, $tenantId, $null, $promptBehavior, $null)
            $AccessToken = $Token.AccessToken
        
            $HeaderParameter = @{
                "Authorization" = "Bearer $AccessToken"
            }
            $Response = Invoke-WebRequest -Uri $Uri -Headers $HeaderParameter -Method Post
            if ($Response.StatusCode -eq 200) {
                $RegisteryPath = ($Response.Content | ConvertFrom-Json).repositoryPath
            } else {
                Write-Error "Error while fetching helm chart registry path: ${$Response.RawContent}"
                throw
            }
        }
        Set-Item -Path Env:HELM_EXPERIMENTAL_OCI -Value 1
        #Region pull helm chart
        try {
            helm chart pull $RegisteryPath --kubeconfig $KubeConfig --kube-context $KubeContext
        } catch {
            Write-Error "Unable to pull helm chart from the registery $RegisteryPath"
            throw
        }
        #Endregion

        #Region export helm chart
        $ChartExportPath = Join-Path -Path (Get-Item Env:HOME).Value -ChildPath '.azure' | Join-Path -ChildPath 'AzureArcCharts'
        try {
            helm chart export $RegisteryPath --kubeconfig $KubeConfig --kube-context $KubeContext --destination $ChartExportPath
        } catch {
            Write-Error "Unable to export helm chart from the registery $RegisteryPath"
            throw
        }
        #Endregion

        $RSA = [System.Security.Cryptography.RSA]::Create(4096)
        $AgentPublicKey = [System.Convert]::ToBase64String($RSA.ExportRSAPublicKey())
        $AgentPrivateKey = [System.Convert]::ToBase64String($RSA.ExportRSAPrivateKey())

        $HelmChartPath = Join-Path -Path $ChartExportPath -ChildPath 'azure-arc-k8sagents'
        if (Test-Path Env:HELMCHART) {
            $ChartPath = Get-ChildItem -Path Env:HELMCHART
        } else {
            $ChartPath = $HelmChartPath
        }

        $TenantId = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Tenant.Id
        helm upgrade --install azure-arc $ChartPath --set global.subscriptionId=$SubscriptionId --set global.resourceGroupName=$ResourceGroupName --set global.resourceName=$ClusterName --set global.tenantId=$TenantId --set global.location=$Location --set global.onboardingPrivateKey=$AgentPrivateKey --set systemDefaultValues.spnOnboarding=false --kubeconfig $KubeConfig --kube-context $KubeContext
        
        $PSBoundParameters.Add('AgentPublicKeyCertificate', $AgentPublicKey)
        Az.ConnectedKubernetes.internal\New-AzConnectedKubernetes @PSBoundParameters
    }
}
