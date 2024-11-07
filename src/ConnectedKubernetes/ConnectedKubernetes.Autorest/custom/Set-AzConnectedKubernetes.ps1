
# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
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

[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute('PSUseSingularNouns', '',
    Justification = 'Kubernetes is a recognised term', Scope = 'Function', Target = 'Set-AzConnectedKubernetes')]
[CmdletBinding()]
param()

<#
.Synopsis
API to set properties of the connected cluster resource
.Description
API to set properties of the connected cluster resource. Replaces all configuration of an existing connected cluster; any properties not specified will be reset to their default values.
.Example
Set-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus -GatewayResourceId $gatewayResourceId
.Example
Set-AzConnectedKubernetes -ClusterName azps_test_cluster1 -ResourceGroupName azps_test_group -Location eastus -KubeConfig $HOME\.kube\config -KubeContext azps_aks_t01 -DisableGateway

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.IConnectedCluster
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IConnectedCluster>:
  Location <String>: The geo-location where the resource lives
  AgentPublicKeyCertificate <String>: Base64 encoded public certificate used by the agent to do the initial handshake to the backend services in Azure.
  IdentityType <ResourceIdentityType>: The type of identity used for the connected cluster. The type 'SystemAssigned, includes a system created identity. The type 'None' means no identity is assigned to the connected cluster.
  [Tag <ITrackedResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [AadProfileAdminGroupObjectID <String[]>]: The list of AAD group object IDs that will have admin role of the cluster.
  [AadProfileEnableAzureRbac <Boolean?>]: Whether to enable Azure RBAC for Kubernetes authorization.
  [AadProfileTenantId <String>]: The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription.
  [ArcAgentProfileAgentAutoUpgrade <AutoUpgradeOptions?>]: Indicates whether the Arc agents on the be upgraded automatically to the latest version. Defaults to Enabled.
  [ArcAgentProfileAgentError <IAgentError[]>]: List of arc agentry and system components errors on the cluster resource.
  [ArcAgentProfileDesiredAgentVersion <String>]: Version of the Arc agents to be installed on the cluster resource
  [ArcAgentProfileSystemComponent <ISystemComponent[]>]: List of system extensions that are installed on the cluster resource.
    [MajorVersion <Int32?>]: Major Version of the system extension that is currently installed on the cluster resource.
    [Type <String>]: Type of the system extension
    [UserSpecifiedVersion <String>]: Version of the system extension to be installed on the cluster resource.
  [ArcAgentryConfiguration <IArcAgentryConfigurations[]>]: Configuration settings for customizing the behavior of the connected cluster.
    [Feature <String>]: Specifies the name of the feature for the configuration setting.
    [ProtectedSetting <IArcAgentryConfigurationsProtectedSettings>]: The configuration settings for the feature that contain any sensitive or secret information.
      [(Any) <String>]: This indicates any property can be added to this object.
    [Setting <IArcAgentryConfigurationsSettings>]: The configuration settings for the feature that do not contain any sensitive or secret information.
      [(Any) <String>]: This indicates any property can be added to this object.
  [AzureHybridBenefit <AzureHybridBenefit?>]: Indicates whether Azure Hybrid Benefit is opted in
  [Distribution <String>]: The Kubernetes distribution running on this connected cluster.
  [DistributionVersion <String>]: The Kubernetes distribution version on this connected cluster.
  [GatewayEnabled <Boolean?>]: Indicates whether the gateway for arc router connectivity is enabled.
  [GatewayResourceId <String>]: The resource ID of the gateway used for the Arc router feature.
  [Infrastructure <String>]: The infrastructure on which the Kubernetes cluster represented by this connected cluster is running on.
  [Kind <ConnectedClusterKind?>]: The kind of connected cluster.
  [OidcIssuerProfileEnabled <Boolean?>]: Whether to enable oidc issuer for workload identity integration.
  [OidcIssuerProfileSelfHostedIssuerUrl <String>]: The issuer url for public cloud clusters - AKS, EKS, GKE - used for the workload identity feature.
  [PrivateLinkScopeResourceId <String>]: This is populated only if privateLinkState is enabled. The resource id of the private link scope this connected cluster is assigned to, if any.
  [PrivateLinkState <PrivateLinkState?>]: Property which describes the state of private link on a connected cluster resource.
  [ProvisioningState <ProvisioningState?>]: Provisioning state of the connected cluster resource.
  [SystemDataCreatedAt <DateTime?>]: The timestamp of resource creation (UTC).
  [SystemDataCreatedBy <String>]: The identity that created the resource.
  [SystemDataCreatedByType <CreatedByType?>]: The type of identity that created the resource.
  [SystemDataLastModifiedAt <DateTime?>]: The timestamp of resource modification (UTC).
  [SystemDataLastModifiedBy <String>]: The identity that last modified the resource.
  [SystemDataLastModifiedByType <LastModifiedByType?>]: The type of identity that last modified the resource.
  [WorkloadIdentityEnabled <Boolean?>]: Whether to enable or disable the workload identity Webhook
.Link
https://learn.microsoft.com/powershell/module/az.connectedkubernetes/set-azconnectedkubernetes
#>
function Set-AzConnectedKubernetes {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.IConnectedCluster])]
    [CmdletBinding(DefaultParameterSetName = 'SetExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute('PSAvoidUsingConvertToSecureStringWithPlainText', '',
        Justification = 'Code published before this issue was identified')]
    param(
        [Parameter(ParameterSetName = 'SetExpanded', Mandatory)]
        [Parameter(ParameterSetName = 'SetExpandedDisableGateway', Mandatory)]
        [Parameter(ParameterSetName = 'SetExpandedEnableGateway', Mandatory)]
        [Alias('Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Path')]
        [System.String]
        # The name of the Kubernetes cluster on which get is called.
        ${ClusterName},

        [Parameter(ParameterSetName = 'SetExpanded', Mandatory)]
        [Parameter(ParameterSetName = 'SetExpandedDisableGateway', Mandatory)]
        [Parameter(ParameterSetName = 'SetExpandedEnableGateway', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'SetExpanded', Mandatory)]
        [Parameter(ParameterSetName = 'SetExpandedDisableGateway', Mandatory)]
        [Parameter(ParameterSetName = 'SetExpandedEnableGateway', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [System.String]
        # The geo-location where the resource lives
        ${Location},

        [Parameter(ParameterSetName = 'Set', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName = 'SetDisableGateway', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName = 'SetEnableGateway', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.IConnectedCluster]
        ${InputObject},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Path')]
        [System.Uri]
        # The http URI of the proxy server for the kubernetes cluster to use
        ${HttpProxy},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Path')]
        [System.Uri]
        # The https URI of the proxy server for the kubernetes cluster to use
        ${HttpsProxy},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Path')]
        [System.String]
        # The comma-separated list of hostnames that should be excluded from the proxy server for the kubernetes cluster to use
        ${NoProxy},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Path')]
        [System.String]
        # The path to the certificate file for proxy or custom Certificate Authority.
        ${ProxyCert},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        # Flag to disable auto upgrade of arc agents.
        ${DisableAutoUpgrade},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Path')]
        [System.String]
        # Override the default container log path to enable fluent-bit logging.
        ${ContainerLogPath},

        [Parameter(HelpMessage = "Path to the kube config file")]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [System.String]
        # Path to the kube config file
        ${KubeConfig},

        [Parameter(HelpMessage = "Kubconfig context from current machine")]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [System.String]
        # Kubconfig context from current machine
        ${KubeContext},

        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.AzureHybridBenefit])]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.AzureHybridBenefit]
        # Indicates whether Azure Hybrid Benefit is opted in
        ${AzureHybridBenefit},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [System.String]
        # The Kubernetes distribution running on this connected cluster.
        ${Distribution},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [System.String]
        # The Kubernetes distribution version on this connected cluster.
        ${DistributionVersion},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [System.String]
        # The infrastructure on which the Kubernetes cluster represented by this connected cluster is running on.
        ${Infrastructure},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [System.String]
        # The resource id of the private link scope this connected cluster is assigned to, if any.
        ${PrivateLinkScopeResourceId},

        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.PrivateLinkState])]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.PrivateLinkState]
        # Property which describes the state of private link on a connected cluster resource.
        ${PrivateLinkState},

        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState])]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState]
        # Provisioning state of the connected cluster resource.
        ${ProvisioningState},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(PossibleTypes = ([Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceTags]))]
        [System.Collections.Hashtable]
        # Resource tags.
        ${Tag},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [System.String]
        # OID of 'custom-locations' app.
        ${CustomLocationsOid},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Whether to enable oidc issuer for workload identity integration.
        ${OidcIssuerProfileEnabled},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [System.String]
        # The issuer url for public cloud clusters - AKS, EKS, GKE - used for the workload identity feature.
        ${OidcIssuerProfileSelfHostedIssuerUrl},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Enable the workload identity Webhook
        ${WorkloadIdentityEnabled},

        [Parameter()]
        [System.Management.Automation.SwitchParameter]
        # Accept EULA of ConnectedKubernetes, legal term will pop up without this parameter provided
        ${AcceptEULA},

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

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Runtime')]
        [System.Uri]
        # The URI of the proxy server for host os to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # The credential of the proxy server for host os to use
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [System.Collections.Hashtable]
        # Arc Agentry System Configuration
        ${ConfigurationSetting},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [System.Collections.Hashtable]
        # Arc Agentry System Protected Configuration
        ${ConfigurationProtectedSetting},

        [Parameter(ParameterSetName = 'SetDisableGateway', Mandatory)]
        [Parameter(ParameterSetName = 'SetExpandedDisableGateway', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('body')]
        [System.Management.Automation.SwitchParameter]
        ${DisableGateway},

        [Parameter(ParameterSetName = 'SetEnableGateway', Mandatory)]
        [Parameter(ParameterSetName = 'SetExpandedEnableGateway', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('body')]
        [System.String]
        # Arc Gateway resource Id, providing this will enable the gateway
        ${GatewayResourceId}
    )

    process {
        Write-Debug "Checking if Azure Hybrid Benefit is opted in and processing the EULA."
        . "$PSScriptRoot/helpers/HelmHelper.ps1"
        . "$PSScriptRoot/helpers/ConfigDPHelper.ps1"
        . "$PSScriptRoot/helpers/AzCloudMetadataHelper.ps1"
        . "$PSScriptRoot/helpers/UtilsHelper.ps1"

        # Configuration is structured as a hashtable of hashtables where the final
        # values must be strings.  Check this!
        Test-ConfigurationSyntax -name 'ConfigurationSetting'
        Test-ConfigurationSyntax -configuration 'ConfigurationProtectedSetting'

        $ProtectedSettingsPlaceholderValue = "redacted"

        if ($AzureHybridBenefit) {
            if (!$AcceptEULA) {
                $legalTermPath = Join-Path $PSScriptRoot -ChildPath "LegalTerm.txt"
                try {
                    $legalTerm = (Get-Content -Path $legalTermPath) -join "`r`n"
                }
                catch {
                    Write-Error "Get legal term failed."
                    throw
                }
                $confirmation = Read-Host $legalTerm"`n[Y] Yes  [N] No  (default is `"N`")"
                if ($confirmation -ine "Y") {
                    Return
                }
            }
        }
        Write-Debug "Removed the AcceptEULA and InputObject parameters after processing."
        $null = $PSBoundParameters.Remove('AcceptEULA')
        $null = $PSBoundParameters.Remove('InputObject')

        Write-Debug "Determining the kube config file path."
        if ($PSBoundParameters.ContainsKey("KubeConfig")) {
            $Null = $PSBoundParameters.Remove('KubeConfig')
        }
        elseif (Test-Path Env:KUBECONFIG) {
            $KubeConfig = Get-ChildItem -Path $Env:KUBECONFIG
        }
        elseif (Test-Path Env:Home) {
            $KubeConfig = Join-Path -Path $Env:Home -ChildPath '.kube' | Join-Path -ChildPath 'config'
        }
        else {
            $KubeConfig = Join-Path -Path $Home -ChildPath '.kube' | Join-Path -ChildPath 'config'
        }
        Write-Debug "Setting the kube context."
        if (-not (Test-Path $KubeConfig)) {
            Write-Error 'Cannot find the kube-config. Please make sure that you have the kube-config on your machine.'
            return
        }
        if ($PSBoundParameters.ContainsKey('KubeContext')) {
            $Null = $PSBoundParameters.Remove('KubeContext')
        }
        if (($null -eq $KubeContext) -or ($KubeContext -eq '')) {
            $KubeContext = kubectl config current-context
        }

        # The internal Set command does not support inputObject probably due to current implementation of swagger
        # So we do it hard way and parse value from inputObject
        # ArcAgentryConfiguration is handled in a separate block
        if ($null -ne $InputObject) {
            $Location = $InputObject.Location
            $PSBoundParameters.Add('Location', $Location)

            $ClusterName = $InputObject.Name
            $PSBoundParameters.Add('ClusterName', $ClusterName)

            $ResourceGroupName = $InputObject.ResourceGroupName
            $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)

            if (-not $PSBoundParameters.ContainsKey('DisableGateway') -and $InputObject.PSObject.Properties['GatewayEnabled']) {
                $DisableGateway = -not $InputObject.GatewayEnabled
            }
            if ((-not $PSBoundParameters.ContainsKey('GatewayResourceId')) -and (-not [String]::IsNullOrEmpty($InputObject.GatewayResourceId))) {
                $GatewayResourceId = $InputObject.GatewayResourceId
            }

            if (-not $PSBoundParameters.ContainsKey('DisableAutoUpgrade')) {
                $DisableAutoUpgrade = ($InputObject.ArcAgentProfileAgentAutoUpgrade -eq 'Disabled')
            }

            # Merge the fields that use a common merging process.
            Merge-MaybeNullInput -InputObject $InputObject -LclPSBoundParameters $PSBoundParameters
        }

        if ($PSBoundParameters.ContainsKey('GatewayResourceId')) {
            Write-Debug "Gateway enabled"
            $PSBoundParameters.Add('GatewayEnabled', $true)
        }
        elseif ($PSBoundParameters.ContainsKey('DisableGateway')) {
            Write-Debug "Gateway disabled"
            $Null = $PSBoundParameters.Remove('DisableGateway')
            $PSBoundParameters.Add('GatewayEnabled', $false)
        }
        else {
            $PSBoundParameters.Add('GatewayEnabled', -not $DisableGateway)
            if (-not [String]::IsNullOrEmpty($GatewayResourceId)) {
                $PSBoundParameters.Add('GatewayResourceId', $GatewayResourceId)
            }
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
        if ($PSBoundParameters.ContainsKey('PrivateLinkState') -and ($null -ne $CustomLocationsOid) -and ($CustomLocationsOid -ne '')) {
            Write-Warning "The features 'cluster-connect' and 'custom-locations' cannot be enabled for a private link enabled connected cluster."
            $CustomLocationsOid = $null
        }
        if ($PSBoundParameters.ContainsKey('CustomLocationsOid')) {
            $Null = $PSBoundParameters.Remove('CustomLocationsOid')
        }
        $IdentityType = [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ResourceIdentityType]::SystemAssigned
        $PSBoundParameters.Add('IdentityType', $IdentityType)

        #Region check helm install
        Confirm-HelmVersion `
            -KubeConfig $KubeConfig `
            -Verbose:($PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent -eq $true) `
            -Debug:($PSCmdlet.MyInvocation.BoundParameters["Debug"].IsPresent -eq $true)

        #EndRegion
        $helmClientLocation = 'helm'

        #Region get release namespace
        $ReleaseNamespaces = Get-HelmReleaseNamespace -KubeConfig $KubeConfig -KubeContext $KubeContext
        $ReleaseNamespace = $ReleaseNamespaces['ReleaseNamespace']
        $ReleaseInstallNamespace = $ReleaseNamespaces['ReleaseInstallNamespace']

        #Endregion

        #Region validate release namespace
        if (-not ([string]::IsNullOrEmpty($ReleaseNamespace))) {
            $Configmap = kubectl get configmap --namespace azure-arc azure-clusterconfig -o json --kubeconfig $KubeConfig | ConvertFrom-Json
            $ConfigmapRgName = $Configmap.data.AZURE_RESOURCE_GROUP
            $ConfigmapClusterName = $Configmap.data.AZURE_RESOURCE_NAME
            try {
                $ExistConnectedKubernetes = Get-AzConnectedKubernetes `
                    -ResourceGroupName $ConfigmapRgName `
                    -ClusterName $ConfigmapClusterName `
                    @CommonPSBoundParameters `
                    -ErrorAction 'silentlycontinue'
                $PSBoundParameters.Add('AgentPublicKeyCertificate', $ExistConnectedKubernetes.AgentPublicKeyCertificate)

                if (($ResourceGroupName.ToLower() -ne $ConfigmapRgName.ToLower()) -or ($ClusterName.ToLower() -ne $ConfigmapClusterName.ToLower())) {
                    Write-Error "The provided cluster name and rg correspond to different cluster"
                    return
                }
            }
            catch {
                Write-Error "The corresponding connected cluster resource does not exist"
                return
            }
        }
        else {
            Write-Error "The azure-arc release namespace couldn't be retrieved, which implies that the kubernetes cluster has not been onboarded to azure-arc."
            return
        }
        #Endregion

        # Adding Helm repo
        $RegistryPath = Set-HelmModulesAndRepository -KubeConfig $KubeConfig -KubeContext $KubeContext -Location $Location

        Write-Debug "Processing Helm chart installation options."

        $options = ""

        if ($DisableAutoUpgrade) {
            $Null = $PSBoundParameters.Remove('DisableAutoUpgrade')
            $PSBoundParameters.Add('ArcAgentProfileAgentAutoUpgrade', 'Disabled')
        }
        if (-not ([string]::IsNullOrEmpty($ContainerLogPath))) {
            $options += " --set systemDefaultValues.fluent-bit.containerLogPath=$ContainerLogPath"
            $Null = $PSBoundParameters.Remove('ContainerLogPath')
        }
        if (-not ([string]::IsNullOrEmpty($KubeConfig))) {
            $options += " --kubeconfig $KubeConfig"
        }
        if (-not ([string]::IsNullOrEmpty($KubeContext))) {
            $options += " --kube-context $KubeContext"
        }
        if (-not ([string]::IsNullOrEmpty($CustomLocationsOid))) {
            $options += " --set systemDefaultValues.customLocations.oid=$CustomLocationsOid"
            $options += " --set systemDefaultValues.customLocations.enabled=true"
        }

        if ((-not ([string]::IsNullOrEmpty($Proxy))) -and (-not $PSBoundParameters.ContainsKey('ProxyCredential'))) {
            if (-not ([string]::IsNullOrEmpty($Proxy.UserInfo))) {
                try {
                    $userInfo = $Proxy.UserInfo -Split ':'
                    $pass = ConvertTo-SecureString $userInfo[1] -AsPlainText -Force
                    $ProxyCredential = New-Object System.Management.Automation.PSCredential ($userInfo[0] , $pass)
                    $PSBoundParameters.Add('ProxyCredential', $ProxyCredential)
                }
                catch {
                    throw "Please set ProxyCredential or provide username and password in the Proxy parameter"
                }
            }
            else {
                Write-Warning "If the proxy is a private proxy, pass ProxyCredential parameter or provide username and password in the Proxy parameter"
            }
        }

        #Endregion

        #Region Deal with configuration settings and protected settings

        if ($null -eq $ConfigurationSetting) {
            $ConfigurationSetting = @{}
        }
        if ($null -eq $ConfigurationProtectedSetting) {
            $ConfigurationProtectedSetting = @{}
        }

        if ($null -ne $InputObject) {
            foreach ($arcAgentConfig in $InputObject.ArcAgentryConfiguration) {
                $ConfigurationSetting[$arcAgentConfig.feature] = $arcAgentConfig.settings
                $ConfigurationProtectedSetting[$arcAgentConfig.feature] = $arcAgentConfig.protectedSettings
            }
        }

        if (-not $ConfigurationProtectedSetting.ContainsKey("proxy")) {
            $ConfigurationProtectedSetting["proxy"] = @{}
        }

        if (-not ([string]::IsNullOrEmpty($HttpProxy))) {
            $HttpProxyStr = $HttpProxy.ToString()
            $HttpProxyStr = $HttpProxyStr -replace ',', '\,'
            $HttpProxyStr = $HttpProxyStr -replace '/', '\/'
            $ConfigurationProtectedSetting["proxy"]["http_proxy"] = $HttpProxyStr
            # Note how we are removing k8s parameters from the list of parameters
            # to pass to the internal (creates ARM object) command.
            $Null = $PSBoundParameters.Remove('HttpProxy')
        }
        if (-not ([string]::IsNullOrEmpty($HttpsProxy))) {
            $HttpsProxyStr = $HttpsProxy.ToString()
            $HttpsProxyStr = $HttpsProxyStr -replace ',', '\,'
            $HttpsProxyStr = $HttpsProxyStr -replace '/', '\/'
            $ConfigurationProtectedSetting["proxy"]["https_proxy"] = $HttpsProxyStr
            $Null = $PSBoundParameters.Remove('HttpsProxy')
        }
        if (-not ([string]::IsNullOrEmpty($NoProxy))) {
            $NoProxy = $NoProxy -replace ',', '\,'
            $NoProxy = $NoProxy -replace '/', '\/'
            $ConfigurationProtectedSetting["proxy"]["no_proxy"] = $NoProxy
            $Null = $PSBoundParameters.Remove('NoProxy')
        }

        try {
            if ((-not ([string]::IsNullOrEmpty($ProxyCert))) -and (Test-Path $ProxyCert)) {
                $ConfigurationProtectedSetting["proxy"]["proxy_cert"] = $ProxyCert
            }
        }
        catch {
            throw "Unable to find ProxyCert from file path"
        }

        $RedactedProtectedConfiguration = @{}
        # Duplicate the protected settings into the settings.
        foreach ($feature in $ConfigurationProtectedSetting.Keys) {
            if (-not $RedactedProtectedConfiguration.ContainsKey($feature)) {
                $RedactedProtectedConfiguration[$feature] = @{}
            }
            foreach ($setting in $ConfigurationProtectedSetting[$feature].Keys) {
                $RedactedProtectedConfiguration[$feature][$setting] = "${ProtectedSettingsPlaceholderValue}:${feature}:${setting}"
            }
        }
        #Endregion

        # A lot of what follows relies on knowing the cloud we are using and the
        # various endpoints so get that information now.
        $cloudMetadata = Get-AzCloudMetadata `
            -Verbose:($PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent -eq $true) `
            -Debug:($PSCmdlet.MyInvocation.BoundParameters["Debug"].IsPresent -eq $true)

        # Perform DP health check
        $configDpinfo = Get-ConfigDPEndpoint `
            -location $Location `
            -Cloud $cloudMetadata `
            -Verbose:($PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent -eq $true) `
            -Debug:($PSCmdlet.MyInvocation.BoundParameters["Debug"].IsPresent -eq $true)

        $configDPEndpoint = $configDpInfo.configDPEndpoint

        # If the health check fails (not 200 response), an exception is thrown
        # so we can ignore the output.
        $null = Invoke-ConfigDPHealthCheck `
            -configDPEndpoint $configDPEndpoint `
            -Verbose:($PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent -eq $true) `
            -Debug:($PSCmdlet.MyInvocation.BoundParameters["Debug"].IsPresent -eq $true)

        # This call does the "pure ARM" update of the ARM objects.
        Write-Debug "Updating Connected Kubernetes ARM objects."

        # Process the Arc agentry settings and protected settings
        # Create any empty array of IArcAgentryConfigurations.
        # shortened name to avoid class with type name.
        #
        # **NOTE** The Swagger naming does NOT match the names that will be used
        #          in the final helm values file.  Instead there needs to be an
        #          explicit mapping which is done in TWO places:
        #          1. The ConfigDP is able to map the (unprotected) settings but
        #             does not have access to the protected settings so...
        #          2. This Powershell script has to perform the mapping for
        #             protected settings.
        #
        #          This DOES mean that code changes are required both in the
        #          Config DP annd this Powershell script if a new Kubernetes
        #          feature is added.
        # Do not send protected settings to CCRP
        $arcAgentryConfigs = ConvertTo-ArcAgentryConfiguration `
            -ConfigurationSetting $ConfigurationSetting `
            -RedactedProtectedConfiguration @{} `
            -CCRP $true `
            -Verbose:($PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent -eq $true) `
            -Debug:($PSCmdlet.MyInvocation.BoundParameters["Debug"].IsPresent -eq $true)

        # It is possible to set an empty value for these parameters and then
        # the code above gets skipped but we still need to remove the empty
        # values from $PSBoundParameters.
        if ($PSBoundParameters.ContainsKey('ConfigurationSetting')) {
            $PSBoundParameters.Remove('ConfigurationSetting')
        }
        if ($PSBoundParameters.ContainsKey('ConfigurationProtectedSetting')) {
            $PSBoundParameters.Remove('ConfigurationProtectedSetting')
        }

        $PSBoundParameters.Add('ArcAgentryConfiguration', $arcAgentryConfigs)

        Write-Output "Updating the connected cluster resource...."
        $Response = Az.ConnectedKubernetes.internal\Set-AzConnectedKubernetes @PSBoundParameters
        if ((-not $WhatIfPreference) -and (-not $Response)) {
            Write-Error "Failed to update the 'Kubernetes - Azure Arc' resource"
            return
        }
        $arcAgentryConfigs = ConvertTo-ArcAgentryConfiguration `
            -ConfigurationSetting $ConfigurationSetting `
            -RedactedProtectedConfiguration $RedactedProtectedConfiguration `
            -CCRP $false `
            -Verbose:($PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent -eq $true) `
            -Debug:($PSCmdlet.MyInvocation.BoundParameters["Debug"].IsPresent -eq $true)


        # Convert the $Response object into a nested hashtable.
        Write-Debug "PUT response: $Response"
        $Response = ConvertFrom-Json "$Response"
        $Response = ConvertTo-Hashtable $Response

        # Whatif may return empty response
        if (-not $Response) {
            $Response = @{}
        }
        if (-not $Response.ContainsKey('properties')) {
            $Response['properties'] = @{}
        }

        $Response['properties']['arcAgentryConfigurations'] = $arcAgentryConfigs

        # Retrieving Helm chart OCI (Open Container Initiative) Artifact location
        Write-Debug "Retrieving Helm chart OCI (Open Container Initiative) Artifact location."
        $ResponseStr = $Response | ConvertTo-Json -Depth 10
        Write-Debug "PUT response: $ResponseStr"

        Write-Output "Preparing helm ...."

        if ($PSCmdlet.ShouldProcess('configDP', 'get helm values from config DP')) {
            $helmValuesDp = Get-HelmValuesFromConfigDP `
                -configDPEndpoint $configDPEndpoint `
                -releaseTrain $ReleaseTrain `
                -requestBody $ResponseStr `
                -Verbose:($PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent -eq $true) `
                -Debug:($PSCmdlet.MyInvocation.BoundParameters["Debug"].IsPresent -eq $true)

            Write-Debug "helmValuesDp: $helmValuesDp"
            Write-Debug "OCI Artifact location: ${helmValuesDp.repositoryPath}."

            $registryPath = if ($env:HELMREGISTRY) { $env:HELMREGISTRY } else { $helmValuesDp.repositoryPath }
            Write-Debug "RegistryPath: ${registryPath}."

            $helmValuesContent = $helmValuesDp.helmValuesContent
            Write-Debug "Helm values: ${helmValuesContent}."

            $optionsFromDp = ""
            foreach ($field in $helmValuesContent.PSObject.Properties) {
                if ($field.Value.StartsWith($ProtectedSettingsPlaceholderValue)) {
                    $parsedValue = $field.Value.Split(":")
                    # "${ProtectedSettingsPlaceholderValue}:${feature}:${setting}"
                    $field.Value = $ConfigurationProtectedSetting[$parsedValue[1]][$parsedValue[2]]
                }
                if ($field.Name -eq "global.proxyCert") {
                    $optionsFromDp += " --set-file $($field.Name)=$($field.Value)"
                }
                $optionsFromDp += " --set $($field.Name)=$($field.Value)"
            }
            # In helm, priority is given to new values, so we append $options contains user input last
            $options = $optionsFromDp + $options

            # Set agent version in registry path
            if ($ExistConnectedKubernetes.AgentVersion) {
                $repositoryPath = $repositoryPath -replace "(?<=:).*", $ExistConnectedKubernetes.AgentVersion
            }
        }

        if ($PSCmdlet.ShouldProcess('configDP', 'get helm chart path')) {
            # Get helm chart path (within the OCI registry).
            $chartPath = Get-HelmChartPath `
                -registryPath $registryPath `
                -kubeConfig $KubeConfig `
                -kubeContext $KubeContext `
                -helmClientLocation $HelmClientLocation `
                -Verbose:($PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent -eq $true) `
                -Debug:($PSCmdlet.MyInvocation.BoundParameters["Debug"].IsPresent -eq $true)
            if (Test-Path Env:HELMCHART) {
                $ChartPath = Get-ChildItem -Path $Env:HELMCHART
            }
        }

        # Get current helm values
        if ($PSCmdlet.ShouldProcess($ClusterName, "Get current helm values")) {
            $userValuesLocation = Get-HelmValue `
                -HelmClientLocation $HelmClientLocation `
                -Namespace $ReleaseInstallNamespace `
                -KubeConfig $KubeConfig `
                -KubeContext $KubeContext `
                -Verbose:($PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent -eq $true) `
                -Debug:($PSCmdlet.MyInvocation.BoundParameters["Debug"].IsPresent -eq $true)
        }

        Write-Output "Executing helm upgrade, this can take a few minutes ...."
        Write-Debug $options -ErrorAction Continue
        if ($DebugPreference -eq "Continue") {
            $options += " --debug"
        }
        if ($PSCmdlet.ShouldProcess($ClusterName, "Update Kubernetes cluster with Azure Arc")) {
            try {
                helm upgrade `
                    azure-arc `
                    $ChartPath `
                    --namespace $ReleaseInstallNamespace `
                    -f $userValuesLocation `
                    --wait (-split $options)
            }
            catch {
                throw "Unable to install helm release"
            }
            Return $Response
        }

        if ($PSCmdlet.ShouldProcess($ClusterName, "Check agent state of the connected cluster")) {
            if ($PSBoundParameters.ContainsKey('OidcIssuerProfileEnabled') -or $PSBoundParameters.ContainsKey('WorkloadIdentityEnabled') ) {
                $ExistConnectedKubernetes = Get-AzConnectedKubernetes -ResourceGroupName $ResourceGroupName -ClusterName $ClusterName @CommonPSBoundParameters

                Write-Output "Cluster configuration is in progress..."
                $timeout = [datetime]::Now.AddMinutes(60)

                while (($ExistConnectedKubernetes.ArcAgentProfileAgentState -ne "Succeeded") -and ($ExistConnectedKubernetes.ArcAgentProfileAgentState -ne "Failed") -and ([datetime]::Now -lt $timeout)) {
                    Start-Sleep -Seconds 30
                    $ExistConnectedKubernetes = Get-AzConnectedKubernetes -ResourceGroupName $ResourceGroupName -ClusterName $ClusterName @CommonPSBoundParameters
                }

                if ($ExistConnectedKubernetes.ArcAgentProfileAgentState -eq "Succeeded") {
                    Write-Output "Cluster configuration succeeded."
                }
                elseif ($ExistConnectedKubernetes.ArcAgentProfileAgentState -eq "Failed") {
                    Write-Error "Cluster configuration failed."
                }
                else {
                    Write-Error "Cluster configuration timed out after 60 minutes."
                }
            }
        }
    }
}

function Merge-MaybeNullInput {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExportAttribute()]
    param(
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.IConnectedCluster]
        $InputObject,
        [System.Collections.Generic.Dictionary[system.String, System.Object]]
        $LclPSBoundParameters
    )

    $mergeFields = 'WorkloadIdentityEnabled', 'OidcIssuerProfileEnabled', 'OidcIssuerProfileSelfHostedIssuerUrl', 'Distribution', 'DistributionVersion', 'Infrastructure', 'PrivateLinkState'

    foreach ($mergeField in $mergeFields) {
        if ((-not $LclPSBoundParameters.ContainsKey($mergeField)) -and $InputObject.PSObject.Properties[$mergeField] -and $null -ne $InputObject.PSObject.Properties[$mergeField].Value) {
            $parameterValue = $InputObject.PSObject.Properties[$mergeField].Value
            $LclPSBoundParameters.Add($mergeField, $parameterValue)
        }
    }
}
