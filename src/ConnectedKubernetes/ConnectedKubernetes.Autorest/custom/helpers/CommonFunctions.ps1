function Validate-HelmVersion {
    param (
        [string]$KubeConfig
    )
    Write-Debug "Setting up Helm client location and validating Helm version."
    try {
        Set-HelmClientLocation
        $HelmVersion = helm version --template='{{.Version}}' --kubeconfig $KubeConfig
        if ($HelmVersion.Contains("v2")) {
            Write-Error "Helm version 3+ is required (not ${HelmVersion}). Learn more at https://aka.ms/arc/k8s/onboarding-helm-install"
            return
        }
        $HelmVersion = helm version --short --kubeconfig $KubeConfig

        $HelmVersion = $HelmVersion.Substring(1)
        $HelmVersion = $HelmVersion.Split('+')[0]
        $helmV380 = [System.Version]::Parse("3.8.0")
        $helmThisVersion = [System.Version]::Parse($HelmVersion)
        if ($helmThisVersion -lt $helmV380) {
            Write-Error "Helm version of at least 3.8 is required for latest OCI handling."
            return
        }
    }
    catch {
        throw "Failed to install Helm version 3+ ($_). Learn more at https://aka.ms/arc/k8s/onboarding-helm-install"
    }
}

function Get-HelmReleaseNamespace {
    param (
        [string]$KubeConfig,
        [string]$KubeContext
    )
    Write-Debug "Getting release namespace."
    $ReleaseInstallNamespace = Get-ReleaseInstallNamespace
    $ReleaseNamespace = $null
    try {
        $ReleaseNamespace = (helm status azure-arc -o json --kubeconfig $KubeConfig --kube-context $KubeContext -n $ReleaseInstallNamespace 2> $null | ConvertFrom-Json).namespace
    }
    catch {
        Write-Error "Fail to find the namespace for azure-arc."
    }
    return $ReleaseNamespace
}

function Set-HelmRepositoryAndModules {
    param (
        [string]$KubeConfig,
        [string]$KubeContext,
        [string]$Location,
        [string]$ReleaseTrain,
        [object]$Account,
        [string]$TenantId,
        [string]$ProxyCert,
        [bool]$DisableAutoUpgrade,
        [string]$ContainerLogPath,
        [string]$CustomLocationsOid
    )
    Write-Debug "Setting Helm repository and checking for required modules."
    if ((Test-Path Env:HELMREPONAME) -and (Test-Path Env:HELMREPOURL)) {
        $HelmRepoName = Get-ChildItem -Path Env:HELMREPONAME
        $HelmRepoUrl = Get-ChildItem -Path Env:HELMREPOURL
        helm repo add $HelmRepoName $HelmRepoUrl --kubeconfig $KubeConfig --kube-context $KubeContext
    }

    $resources = Get-Module Az.Resources -ListAvailable
    if ($null -eq $resources) {
        Write-Error "Missing required module(s): Az.Resources. Please run 'Install-Module Az.Resources -Repository PSGallery' to install Az.Resources."
        return
    }

    if (Test-Path Env:HELMREGISTRY) {
        $RegistryPath = Get-ChildItem -Path Env:HELMREGISTRY
    }
    else {
        $ReleaseTrain = ''
        if ((Test-Path Env:RELEASETRAIN) -and (Test-Path Env:RELEASETRAIN)) {
            $ReleaseTrain = Get-ChildItem -Path Env:RELEASETRAIN
        }
        else {
            $ReleaseTrain = 'stable'
        }
        $AzLocation = Get-AzLocation | Where-Object { ($_.DisplayName -ieq $Location) -or ($_.Location -ieq $Location) }
        $Region = $AzLocation.Location
        if ($null -eq $Region) {
            Write-Error "Invalid location: $Location"
            return
        }
        else {
            $Location = $Region
        }
        $ChartLocationUrl = "https://${Location}.dp.kubernetesconfiguration.azure.com/azure-arc-k8sagents/GetLatestHelmPackagePath?api-version=2019-11-01-preview&releaseTrain=${ReleaseTrain}"

        $Uri = [System.Uri]::New($ChartLocationUrl)
        $Env = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment]::PublicEnvironments[[Microsoft.Azure.Commands.Common.Authentication.Abstractions.EnvironmentName]::AzureCloud]
        $PromptBehavior = [Microsoft.Azure.Commands.Common.Authentication.ShowDialog]::Never
        $Token = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.AuthenticationFactory.Authenticate($Account, $Env, $TenantId, $null, $PromptBehavior, $null)
        $AccessToken = $Token.AccessToken

        $HeaderParameter = @{
            "Authorization" = "Bearer $AccessToken"
        }

        $Response = Invoke-WebRequest -Uri $Uri -Headers $HeaderParameter -Method Post -UseBasicParsing
        if ($Response.StatusCode -eq 200) {
            $RegistryPath = ($Response.Content | ConvertFrom-Json).repositoryPath
        }
        else {
            Write-Error "Error while fetching helm chart registry path: ${$Response.RawContent}"
            return
        }
    }
    Set-Item -Path Env:HELM_EXPERIMENTAL_OCI -Value 1
}

function Configure-ProxySettings {
    param (
        [string]$HttpProxy,
        [string]$HttpsProxy,
        [string]$NoProxy,
        [string]$ProxyCert,
        [bool]$DisableAutoUpgrade,
        [bool]$ProxyEnableState,
        [string]$ContainerLogPath,
        [string]$KubeConfig,
        [string]$KubeContext,
        [string]$CustomLocationsOid,
        [hashtable]$ConfigurationSetting,
        [hashtable]$ConfigurationProtectedSetting,
        [hashtable]$PSBoundParameters
    )
    if (![string]::IsNullOrEmpty($HttpProxy) -or ![string]::IsNullOrEmpty($HttpsProxy) -or ![string]::IsNullOrEmpty($NoProxy)) {
        if (-not $ConfigurationSetting.ContainsKey("proxy")) {
            $ConfigurationSetting["proxy"] = @{}
        }
        if (-not $ConfigurationProtectedSetting.ContainsKey("proxy")) {
            $ConfigurationProtectedSetting["proxy"] = @{}
        }
    }

    if (-not ([string]::IsNullOrEmpty($HttpProxy))) {
        $HttpProxyStr = $HttpProxy.ToString()
        $HttpProxyStr = $HttpProxyStr -replace ',', '\,'
        $HttpProxyStr = $HttpProxyStr -replace '/', '\/'
        $options += " --set global.httpProxy=$HttpProxyStr"
        $proxyEnableState = $true
        $ConfigurationSetting["proxy"]["http_proxy"] = $HttpProxyStr
        $ConfigurationProtectedSetting["proxy"]["http_proxy"] = $HttpProxyStr
        $Null = $PSBoundParameters.Remove('HttpProxy')
    }
    if (-not ([string]::IsNullOrEmpty($HttpsProxy))) {
        $HttpsProxyStr = $HttpsProxy.ToString()
        $HttpsProxyStr = $HttpsProxyStr -replace ',', '\,'
        $HttpsProxyStr = $HttpsProxyStr -replace '/', '\/'
        $options += " --set global.httpsProxy=$HttpsProxyStr"
        $proxyEnableState = $true
        $ConfigurationSetting["proxy"]["https_proxy"] = $HttpsProxyStr
        $ConfigurationProtectedSetting["proxy"]["https_proxy"] = $HttpsProxyStr
        $Null = $PSBoundParameters.Remove('HttpsProxy')
    }
    if (-not ([string]::IsNullOrEmpty($NoProxy))) {
        $NoProxy = $NoProxy -replace ',', '\,'
        $NoProxy = $NoProxy -replace '/', '\/'
        $options += " --set global.noProxy=$NoProxy"
        $proxyEnableState = $true
        $ConfigurationSetting["proxy"]["no_proxy"] = $NoProxy
        $ConfigurationProtectedSetting["proxy"]["no_proxy"] = $NoProxy
        $Null = $PSBoundParameters.Remove('NoProxy')
    }
    if ($proxyEnableState) {
        $options += " --set global.isProxyEnabled=true"
    }
    try {
        if ((-not ([string]::IsNullOrEmpty($ProxyCert))) -and (Test-Path $ProxyCert)) {
            $options += " --set-file global.proxyCert=$ProxyCert"
            $options += " --set global.isCustomCert=true"
            $ConfigurationSetting["proxy"]["proxy_cert"] = $ProxyCert
            $ConfigurationProtectedSetting["proxy"]["proxy_cert"] = $ProxyCert
        }
    }
    catch {
        throw "Unable to find ProxyCert from file path"
    }
    if ($DisableAutoUpgrade) {
        $options += " --set systemDefaultValues.azureArcAgents.autoUpdate=false"
        $Null = $PSBoundParameters.Remove('DisableAutoUpgrade')
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
}

function Configure-ProxyCredential {
    param (
        [Uri]$Proxy,
        [PSCredential]$ProxyCredential,
        [hashtable]$PSBoundParameters
    )
    if ((-not ([string]::IsNullOrEmpty($Proxy))) -and (-not $PSBoundParameters.ContainsKey('ProxyCredential'))) {
        if (-not ([string]::IsNullOrEmpty($Proxy.UserInfo))) {
            try {
                $userInfo = $Proxy.UserInfo -Split ':'
                $pass = ConvertTo-SecureString $userInfo[1] -AsPlainText -Force
                $ProxyCredential = New-Object System.Management.Automation.PSCredential ($userInfo[0], $pass)
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
}

function Configure-ArcAgentry {
    param (
        [hashtable]$ConfigurationSetting,
        [hashtable]$ConfigurationProtectedSetting,
        [hashtable]$PSBoundParameters,
        [string]$Location
    )
    $arcAgentryConfigs = @(
        )

        if ($ConfigurationSetting) {
            foreach ($key in $ConfigurationSetting.Keys) {
                $ArcAgentryConfiguration = [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.ArcAgentryConfigurations]@{
                    Feature = $key
                    Setting = $ConfigurationSetting[$key]
                }
                if ($ConfigurationProtectedSetting -and $ConfigurationProtectedSetting[$key]) {
                    $ArcAgentryConfiguration.ProtectedSetting = $ConfigurationProtectedSetting[$key]

                    # Remove this key from ConfigurationProtectedSetting.
                    $Null = $ConfigurationProtectedSetting.Remove($key)
                }
                $arcAgentryConfigs += $ArcAgentryConfiguration
            }
            $PSBoundParameters.Remove('ConfigurationSetting')
        }

        # Add the remaining (protected only) settings.
        if ($ConfigurationProtectedSetting) {
            foreach ($key in $ConfigurationProtectedSetting.Keys) {
                $ArcAgentryConfiguration = [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.ArcAgentryConfigurations]@{
                    Feature          = $key
                    ProtectedSetting = $ConfigurationProtectedSetting[$key]
                }
                $argAgentryConfigs += $ArcAgentryConfiguration
            }
            $PSBoundParameters.Remove('ConfigurationProtectedSetting')
        }

        $PSBoundParameters.Add('ArcAgentryConfiguration', $arcAgentryConfigs)

        # A lot of what follows relies on knowing the cloud we are using and the
        # various endpoints so get that information now.
        $cloudMetadata = Get-AzCloudMetadata

        # Perform DP health check
        $configDpinfo = Get-ConfigDPEndpoint -location $Location -Cloud $cloudMetadata
        $configDPEndpoint = $configDpInfo.configDPEndpoint

        # If the health check fails (not 200 response), an exception is thrown
        # so we can ignore the output.
        $null = Invoke-ConfigDPHealthCheck -configDPEndpoint $configDPEndpoint
}
