
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
    Justification = 'Kubernetes is a recognised term', Scope = 'Function', Target = 'New-AzConnectedKubernetes')]
[CmdletBinding()]
param()

<#
.Synopsis
API to register a new Kubernetes cluster and create a tracked resource in Azure Resource Manager (ARM).
.Description
API to register a new Kubernetes cluster and create a tracked resource in Azure Resource Manager (ARM).
.Example
New-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus
.Example
New-AzConnectedKubernetes -ClusterName azps_test_cluster1 -ResourceGroupName azps_test_group -Location eastus -KubeConfig $HOME\.kube\config -KubeContext azps_aks_t01

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.IConnectedCluster
.Link
https://learn.microsoft.com/powershell/module/az.connectedkubernetes/new-azconnectedkubernetes
#>
function New-AzConnectedKubernetes {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.IConnectedCluster])]
    [CmdletBinding(DefaultParameterSetName = 'CreateExpanded', SupportsShouldProcess, PositionalBinding = $false, ConfirmImpact = 'Medium')]
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute('PSAvoidUsingConvertToSecureStringWithPlainText', '',
        Justification = 'Code published before this issue was identified')]
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
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

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
        [ValidateRange(0, 3600)]
        [Int]
        # The time required (in seconds) for the arc-agent pods to be installed on the kubernetes cluster.
        ${OnboardingTimeout} = 600,

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

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Body')]
        [System.String]
        # The geo-location where the resource lives
        ${Location},

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
        # Whether to enable or disable the workload identity Webhook
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
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Runtime')]
        [System.Collections.Hashtable]
        # Arc Agentry System Configuration (hash table of hash tables).
        ${ConfigurationSetting},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Runtime')]
        [System.Collections.Hashtable]
        # Arc Agentry System Protected Configuration (hash table of hash tables).
        ${ConfigurationProtectedSetting},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Category('Runtime')]
        [System.String]
        # Arc Gateway resource Id
        ${GatewayResourceId}
    )

    process {
        $ProtectedSettingsPlaceholderValue = "redacted"

        Write-Debug "Checking if Azure Hybrid Benefit is opted in and processing the EULA."
        . "$PSScriptRoot/helpers/HelmHelper.ps1"
        . "$PSScriptRoot/helpers/ConfigDPHelper.ps1"
        . "$PSScriptRoot/helpers/AzCloudMetadataHelper.ps1"
        . "$PSScriptRoot/helpers/UtilsHelper.ps1"

        # Configuration is structured as a hashtable of hashtables where the final
        # values must be strings.  Check this!
        Test-ConfigurationSyntax -name 'ConfigurationSetting'
        Test-ConfigurationSyntax -configuration 'ConfigurationProtectedSetting'

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
        Write-Debug "Removed the AcceptEULA parameter after processing."
        $null = $PSBoundParameters.Remove('AcceptEULA')
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
        if (-not (Test-Path $KubeConfig)) {
            Write-Error 'Cannot find the kube-config. Please make sure that you have the kube-config on your machine.'
            return
        }
        Write-Debug "Setting the kube context."
        if ($PSBoundParameters.ContainsKey("KubeContext")) {
            $Null = $PSBoundParameters.Remove('KubeContext')
        }
        if (($null -eq $KubeContext) -or ($KubeContext -eq '')) {
            $KubeContext = kubectl config current-context
        }
        Write-Debug "Checking whether Gateway is enabled"

        # If GatewayResourceId is provided then set the gateway as enabled.
        $PSBoundParameters.Add('GatewayEnabled', -not [String]::IsNullOrEmpty($GatewayResourceId))

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

                if (($ResourceGroupName -eq $ConfigmapRgName) -and ($ClusterName -eq $ConfigmapClusterName)) {
                    # This performs a re-PUT of an existing connected cluster which should really be done using
                    # a Set-AzConnectedKubernetes cmdlet!

                    if ($PSCmdlet.ShouldProcess($ClusterName, "Updating existing ConnectedKubernetes cluster")) {
                        $PSBoundParameters.Add('AgentPublicKeyCertificate', $ExistConnectedKubernetes.AgentPublicKeyCertificate)
                        return Az.ConnectedKubernetes.internal\New-AzConnectedKubernetes @PSBoundParameters
                    }
                    else {
                        # We are done here if doing a What-if.
                        return
                    }
                }
                else {
                    # We have a cluster with the same Kubernetes settings but already associated via a different RG - error!
                    Write-Error "The kubernetes cluster you are trying to onboard is already onboarded to the resource group '${ConfigmapRgName}' with resource name '${ConfigmapClusterName}'."
                }
                return
            }
            catch {
                # This is attempting to delete Azure Arc resources that are orphaned.
                # We are catching and ignoring any messages here.
                $null = helm delete azure-arc --ignore-not-found --namespace $ReleaseNamespace --kubeconfig $KubeConfig --kube-context $KubeContext | Out-Null
            }
        }

        $RegistryPath = Set-HelmModulesAndRepository -KubeConfig $KubeConfig -KubeContext $KubeContext -Location $Location

        # Region create RSA keys
        Write-Debug "Generating RSA keys for secure communication."
        $RSA = [System.Security.Cryptography.RSA]::Create(4096)
        if ($PSVersionTable.PSVersion.Major -eq 5) {
            try {
                . "$PSScriptRoot/helpers/RSAHelper.ps1"
                $AgentPublicKey = ExportRSAPublicKeyBase64($RSA) `
                    -Verbose:($PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent -eq $true) `
                    -Debug:($PSCmdlet.MyInvocation.BoundParameters["Debug"].IsPresent -eq $true)
                $AgentPrivateKey = ExportRSAPrivateKeyBase64($RSA) `
                    -Verbose:($PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent -eq $true) `
                    -Debug:($PSCmdlet.MyInvocation.BoundParameters["Debug"].IsPresent -eq $true)

                $AgentPrivateKey = "-----BEGIN RSA PRIVATE KEY-----`n" + $AgentPrivateKey + "`n-----END RSA PRIVATE KEY-----"
            }
            catch {
                throw "Unable to generate RSA keys"
            }
        }
        else {
            $AgentPublicKey = [System.Convert]::ToBase64String($RSA.ExportRSAPublicKey())
            $AgentPrivateKey = "-----BEGIN RSA PRIVATE KEY-----`n" + [System.Convert]::ToBase64String($RSA.ExportRSAPrivateKey()) + "`n-----END RSA PRIVATE KEY-----"
        }
        #Endregion
        Write-Debug "Processing Helm chart installation options."

        $options = ""

        if ($DisableAutoUpgrade) {
            # $options += " --set systemDefaultValues.azureArcAgents.autoUpdate=false"
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

        if (!$NoWait) {
            $options += " --wait --timeout $OnboardingTimeout"
            $options += "s"
        }

        if ($PSBoundParameters.ContainsKey('OnboardingTimeout')) {
            $PSBoundParameters.Remove('OnboardingTimeout')
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

        #Region Deal with configuration settings and protected settings

        if (-not $ConfigurationSetting) {
            $ConfigurationSetting = @{}
        }
        if (-not $ConfigurationProtectedSetting) {
            $ConfigurationProtectedSetting = @{}
        }
        if (-not $ConfigurationProtectedSetting.ContainsKey('proxy')) {
            $ConfigurationProtectedSetting['proxy'] = @{}
        }

        if (-not ([string]::IsNullOrEmpty($HttpProxy))) {
            $HttpProxyStr = $HttpProxy.ToString()
            $HttpProxyStr = $HttpProxyStr -replace ',', '\,'
            $HttpProxyStr = $HttpProxyStr -replace '/', '\/'
            $ConfigurationProtectedSetting["proxy"]["http_proxy"] = $HttpProxyStr
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
        Write-Debug "Writing Connected Kubernetes ARM objects."

        # We sometimes see the AgentPublicKeyCertificate present with value $null.
        # If this is the case, update rather than adding.
        if ($PSBoundParameters.ContainsKey('AgentPublicKeyCertificate')) {
            $PSBoundParameters['AgentPublicKeyCertificate'] = $AgentPublicKey
        }
        else {
            $PSBoundParameters.Add('AgentPublicKeyCertificate', $AgentPublicKey)
        }

        # Process the Arc agentry settings and protected settings
        # Create any empty array of IArcAgentryConfigurations.
        # Shortened name to avoid class with type name.
        #
        # Arc Configuration "Name" Mapping
        # ================================
        # The Swagger naming of Arc configuration does NOT match the names that
        # will be used in the final helm values file.  Instead there needs to be
        # an explicit mapping which is done by the ConfigDP.
        #
        # We do not trust the ConfigDP's security though so we do not pass
        # protected configuration values to the ConfigDP.  Instead we hold them
        # in a local hashtable and pass the hash-tabe indexing to the ConfigDP
        # as the Arc configuration protected setting value.
        #
        # One return, the ConfigDP gives us the correct "helm" name for the
        # setting, with the indexing value, and we then replace this index value
        # with the real value.
        #
        # This ensures that when a new feature is implemented, only the ConfigDP
        # needs to change and not the Powershell script (or az CLI).
        #
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

        Write-Verbose "Creating 'Kubernetes - Azure Arc' object in Azure"
        Write-Debug "PSBoundParameters: $PSBoundParameters"
        $CCResponse = Az.ConnectedKubernetes.internal\New-AzConnectedKubernetes @PSBoundParameters

        if ((-not $WhatIfPreference) -and (-not $CCResponse)) {
            Write-Error "Failed to create the 'Kubernetes - Azure Arc' resource."
            return
        }

        $arcAgentryConfigs = ConvertTo-ArcAgentryConfiguration `
            -ConfigurationSetting $ConfigurationSetting `
            -RedactedProtectedConfiguration $RedactedProtectedConfiguration `
            -CCRP $false `
            -Verbose:($PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent -eq $true) `
            -Debug:($PSCmdlet.MyInvocation.BoundParameters["Debug"].IsPresent -eq $true)

        # Convert the $Response object into a nested hashtable.
        Write-Debug "PUT response: $CCResponse"
        $Response = ConvertFrom-Json "$CCResponse"
        $Response = ConvertTo-Hashtable $Response

        # What-If processing does not create a full response so we might have
        # to create a minimal one.
        if (-not $Response) {
            $Response = @{}
        }
        if (-not $Response.ContainsKey('properties')) {
            $Response['properties'] = @{}
        }
        $Response['properties']['arcAgentryConfigurations'] = $arcAgentryConfigs

        # Retrieving Helm chart OCI (Open Container Initiative) Artifact location
        Write-Debug "Retrieving Helm chart OCI (Open Container Initiative) Artifact location."
        Write-Debug "PUT response: $Response"
        $ResponseStr = $Response | ConvertTo-Json -Depth 10
        Write-Debug "PUT response: $ResponseStr"

        if ($PSCmdlet.ShouldProcess("configDP", "request Helm values")) {
            $helmValuesDp = Get-HelmValuesFromConfigDP `
                -configDPEndpoint $configDPEndpoint `
                -releaseTrain $ReleaseTrain `
                -requestBody $ResponseStr `
                -Verbose:($PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent -eq $true) `
                -Debug:($PSCmdlet.MyInvocation.BoundParameters["Debug"].IsPresent -eq $true)

            Write-Debug "helmValuesDp: $helmValuesDp"
            Write-Debug "OCI Artifact location: ${helmValuesDp.repositoryPath}."

            $registryPath = if ($env:HELMREGISTRY) { $env:HELMREGISTRY } else { $helmValuesDp.repositoryPath }
            Write-Debug "RegistryPath: ${registryPath}"

            $helmValuesContent = $helmValuesDp.helmValuesContent
            Write-Debug "Helm values: ${helmValuesContent}."

            # We now need to process the helm values, add all the settings and
            # protected settings to the helm options and replace any placeholders
            # with the values that we have stored in the protected settings
            # hashtable.
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
        }

        # Get helm chart path (within the OCI registry).
        if ($PSCmdlet.ShouldProcess("configDP", "request Helm chart")) {
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

        $TenantId = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Tenant.Id
        Write-Debug $options -ErrorAction Continue
        if ($DebugPreference -eq "Continue") {
            $options += " --debug"
        }
        if ($PSCmdlet.ShouldProcess($ClusterName, "Update Kubernetes cluster with Azure Arc")) {
            Write-Verbose "Executing helm upgrade command, this can take a few minutes...."
            try {
                helm upgrade `
                    --install azure-arc `
                    $ChartPath `
                    --namespace $ReleaseInstallNamespace `
                    --create-namespace `
                    --set global.subscriptionId=$SubscriptionId `
                    --set global.resourceGroupName=$ResourceGroupName `
                    --set global.resourceName=$ClusterName `
                    --set global.tenantId=$TenantId `
                    --set global.location=$Location `
                    --set global.onboardingPrivateKey=$AgentPrivateKey `
                    --set systemDefaultValues.spnOnboarding=false `
                    --set global.azureEnvironment=AZUREPUBLICCLOUD `
                    --set systemDefaultValues.clusterconnect-agent.enabled=true `
                    --set global.kubernetesDistro=$Distribution `
                    --set global.kubernetesInfra=$Infrastructure (-split $options) | Out-Null
            }
            catch {
                throw "Unable to install helm chart at $ChartPath"
            }
        }

        if ($PSCmdlet.ShouldProcess($ClusterName, "Check agent state of the connected cluster")) {
            if ($PSBoundParameters.ContainsKey('OidcIssuerProfileEnabled') -or $PSBoundParameters.ContainsKey('WorkloadIdentityEnabled') ) {
                $ExistConnectedKubernetes = Get-AzConnectedKubernetes -ResourceGroupName $ResourceGroupName -ClusterName $ClusterName @CommonPSBoundParameters

                Write-Verbose "Cluster configuration is in progress..."
                $timeout = [datetime]::Now.AddMinutes(60)

                while (($ExistConnectedKubernetes.ArcAgentProfileAgentState -ne "Succeeded") -and ($ExistConnectedKubernetes.ArcAgentProfileAgentState -ne "Failed") -and ([datetime]::Now -lt $timeout)) {
                    Start-Sleep -Seconds 30
                    $ExistConnectedKubernetes = Get-AzConnectedKubernetes -ResourceGroupName $ResourceGroupName -ClusterName $ClusterName @CommonPSBoundParameters
                }

                if ($ExistConnectedKubernetes.ArcAgentProfileAgentState -eq "Succeeded") {
                    Write-Verbose "Cluster configuration succeeded."
                }
                elseif ($ExistConnectedKubernetes.ArcAgentProfileAgentState -eq "Failed") {
                    Write-Error "Cluster configuration failed."
                }
                else {
                    Write-Error "Cluster configuration timed out after 60 minutes."
                }
            }
        }
        Return $CCResponse
    }
}
