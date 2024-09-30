[CmdletBinding()]
param()

function Set-HelmClientLocation {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExportAttribute()]
    param(
    )
    process {
        Write-Debug "Setting Helm client location."
        $HelmLocation = Get-HelmClientLocation
        if ($null -eq $HelmLocation) {
            Write-Debug "Helm location not found."
            return
        }
        if (!($env:Path.contains($HelmLocation)) -and (Test-Path $HelmLocation)) {
            Write-Debug "Updating PATH environment variable with Helm location."
            $PathStr = $HelmLocation + ";$env:Path"
            Set-Item -Path Env:Path -Value $PathStr
        }
    }
}

function Get-HelmClientLocation {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExportAttribute()]
    param(
    )
    process {
        Write-Debug "Getting Helm client location."
        if (IsWindows -and IsAmd64) {
            Write-Debug "Detected Windows AMD64 architecture."
            if (Test-Path Env:HELM_CLIENT_PATH) {
                $CustomPath = (Get-Item Env:HELM_CLIENT_PATH).Value
                Write-Debug "Custom Helm path detected: $CustomPath"
                if ($CustomPath.EndsWith("helm.exe") -and (!((Get-Item $CustomPath) -is [System.IO.DirectoryInfo]))) {
                    $CustomPath = $CustomPath.Replace("helm.exe", "")
                }
                return $CustomPath
            }
            if (Test-Path Env:Home) {
                $HomePath = (Get-Item Env:HOME).Value
            }
            else {
                $HomePath = $Home
            }
            # $Version = "v3.6.3"
            $Version = "v3.12.2"
            $ZipName = "helm-$Version-windows-amd64.zip"
            $RootFolder = Join-Path -Path $HomePath -ChildPath ".azure" | Join-Path -ChildPath "helm" | Join-Path -ChildPath "$Version"
            $ZipLocation = Join-Path -Path $RootFolder -ChildPath $ZipName
            $InstallLocation = Join-Path -Path $RootFolder -ChildPath "windows-amd64"
            $HelmLocation = Join-Path -Path $InstallLocation -ChildPath "helm.exe"
            try {
                if (!(Test-Path $RootFolder)) {
                    Write-Debug "Creating Helm root folder: $RootFolder"
                    $null = New-Item $RootFolder -ItemType Directory
                }
                if ((!(Test-Path $HelmLocation))) {
                    Write-Debug "Downloading Helm zip to: $ZipLocation"
                    Invoke-WebRequest -Uri "https://k8connecthelm.azureedge.net/helmsigned/$ZipName" -OutFile $ZipLocation -UseBasicParsing
                    Write-Debug "Extracting Helm zip to: $RootFolder"
                    Expand-Archive $ZipLocation $RootFolder
                    Write-Verbose "Downloaded helm: $HelmLocation"
                }
            }
            catch {
                throw "Failed to download helm ($_)"
            }
        }
        else {
            Write-Warning "Helm version 3.6.3 is required. Learn more at https://aka.ms/arc/k8s/onboarding-helm-install"
        }
        return $InstallLocation
    }
}

function Get-ReleaseInstallNamespace {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExportAttribute()]
    param(
    )
    process {
        Write-Debug "Getting Helm release install namespace."
        return "azure-arc-release"
    }
}

function IsWindows {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExportAttribute()]
    param(
    )
    process {
        Write-Debug "Determining if the system is Windows."
        return (Get-OSName).contains("Windows")
    }
}

function Get-OSName {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExportAttribute()]
    param(
    )
    process {
        Write-Debug "Getting the operating system name."
        if ($PSVersionTable.PSEdition.Contains("Core")) {
            $OSPlatform = $PSVersionTable.OS
        }
        else {
            $OSPlatform = $env:OS
        }
        return $OSPlatform
    }
}

function IsAmd64 {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExportAttribute()]
    param(
    )
    process {
        Write-Debug "Checking if the architecture is AMD64."
        $isSupport = [Environment]::Is64BitOperatingSystem -and ($env:PROCESSOR_ARCHITECTURE -eq "AMD64")
        return $isSupport
    }
}

function Get-HelmChartPath {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExport()]
    param (
        [Parameter(Mandatory)]
        [string]$RegistryPath,
        [Parameter(Mandatory)]
        [string]$HelmClientLocation,
        [string]$KubeConfig,
        [string]$KubeContext,
        [string]$ChartFolderName = 'AzureArcCharts',
        [string]$ChartName = 'azure-arc-k8sagents',
        [bool]$NewPath = $true
    )
    Write-Debug "Preparing to export Helm chart to a specific path."

    # Special path!
    $PreOnboardingHelmChartsFolderName = 'PreOnboardingChecksCharts'

    # Exporting Helm chart
    Write-Verbose "Using 'helm' to add Azure Arc resources to Kubernetes cluster"
    $ChartExportPath = Join-Path $env:USERPROFILE ('.azure', $ChartFolderName -join '\')
    try {
        if (Test-Path $ChartExportPath) {
            Write-Debug "Cleaning up existing Helm chart folder at: $ChartExportPath"
            Remove-Item $ChartExportPath -Recurse -Force
        }
    }
    catch {
        Write-Warning -Message "Unable to cleanup the $ChartFolderName already present on the machine. In case of failure, please cleanup the directory '$ChartExportPath' and try again."
    }
    Write-Debug "Starting Helm chart export to path: $ChartExportPath"
    Get-HelmChart -RegistryPath $RegistryPath -ChartExportPath $ChartExportPath -KubeConfig $KubeConfig -KubeContext $KubeContext -HelmClientLocation $HelmClientLocation -NewPath $NewPath -ChartName $ChartName

    # Returning helm chart path
    $HelmChartPath = Join-Path $ChartExportPath $ChartName
    if ($ChartFolderName -eq $PreOnboardingHelmChartsFolderName) {
        $ChartPath = $HelmChartPath
    }
    else {
        $ChartPath = if ($env:HELMCHART) { $env:HELMCHART } else { $HelmChartPath }
    }
    Write-Debug "Helm chart path is: $ChartPath"
    return $ChartPath
}

function Get-HelmChart {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExport()]
    param (
        [Parameter(Mandatory)]
        [string]$RegistryPath,
        [Parameter(Mandatory)]
        [string]$ChartExportPath,
        [string]$KubeConfig,
        [string]$KubeContext,
        [Parameter(Mandatory)]
        [string]$HelmClientLocation,
        [bool]$NewPath,
        [string]$ChartName = 'azure-arc-k8sagents',
        [int]$RetryCount = 5,
        [int]$RetryDelay = 3
    )

    $chartUrl = $RegistryPath.Split(':')[0]
    $chartVersion = $RegistryPath.Split(':')[1]

    if ($NewPath) {
        # Version check for stable release train (chart_version will be in X.Y.Z format as opposed to X.Y.Z-NONSTABLE)
        if (-not $chartVersion.Contains('-') -and ([version]$chartVersion -lt [version]"1.14.0")) {
            $errorSummary = "This CLI version does not support upgrading to Agents versions older than v1.14"
            # Assuming telemetry.set_exception and consts.Operation_Not_Supported_Fault_Type are handled elsewhere
            throw "Operation not supported on older Agents: $errorSummary"
        }

        # We do not use Split-Path here because it results in "\" characters in
        # the results.
        $basePath, $imageName = if ($chartUrl -match "(^.*?)/([^/]+$)") { $matches[1], $matches[2] }
        $chartUrl = "$basePath/v2/$imageName"
        # Write-Error "Chart URL: $chartUrl"
    }

    $cmdHelmChartPull = @($HelmClientLocation, "pull", "oci://$chartUrl", "--untar", "--untardir", $ChartExportPath, "--version", $chartVersion)
    if ($KubeConfig) {
        $cmdHelmChartPull += "--kubeconfig", $KubeConfig
    }
    if ($KubeContext) {
        $cmdHelmChartPull += "--kube-context", $KubeContext
    }

    Write-Debug "Pull helm chart: $cmdHelmChartPull[0] $cmdHelmChartPull[1..($cmdHelmChartPull.Count - 1)]"
    for ($i = 0; $i -lt $RetryCount; $i++) {
        try {
            Invoke-ExternalCommand $cmdHelmChartPull[0] $cmdHelmChartPull[1..($cmdHelmChartPull.Count - 1)]
            break
        }
        catch {
            Start-Sleep -Seconds $RetryDelay
        }
    }

    if ($i -eq $RetryCount) {
        # Assuming telemetry.set_exception and consts.Pull_HelmChart_Fault_Type are handled elsewhere
        throw "Unable to pull '$ChartName' helm chart from the registry '$RegistryPath'."
    }
}

# This method exists to allow us to effectively Mock the call operator (&).
# We cannnot do that directly so instead we have this wrapper, which we can mock!
function Invoke-ExternalCommand {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExport()]
    param (
        [Parameter(Mandatory = $true)]
        [string]$Command,
        [array]$Arguments
    )
    & $Command $Arguments
}


function Set-HelmRepositoryAndModules {
    param (
        [string]$KubeConfig,
        [string]$KubeContext,
        [string]$Location,
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
        $Account = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Account
        $Env = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment]::PublicEnvironments[[Microsoft.Azure.Commands.Common.Authentication.Abstractions.EnvironmentName]::AzureCloud]
        $TenantId = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Tenant.Id
        $PromptBehavior = [Microsoft.Azure.Commands.Common.Authentication.ShowDialog]::Never
        $Token = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.AuthenticationFactory.Authenticate($account, $env, $tenantId, $null, $promptBehavior, $null)
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
    return $RegistryPath
}

function Get-HelmReleaseNamespaces {
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
    #  return @{"site" = $($site); "app" = $($app)}
    return , @{"ReleaseNamespace" = $($ReleaseNamespace); "ReleaseInstallNamespace" = $($ReleaseInstallNamespace) }
}

function Confirm-HelmVersion {
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

        # Compare the helm version to 3.8 in a symantic versioning valid way
        # Strip the leading "v" from the helm version and discard any metadata
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