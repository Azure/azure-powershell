[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute('PSUseSingularNouns', '',
    Justification = 'Helm values is a recognised term', Scope = 'Function', Target = 'Get-HelmValues')]
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

function Get-HelmValues {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExport()]
    param (
        [Parameter(Mandatory = $true)]
        $ConfigDpEndpoint,
        [string]$ReleaseTrainCustom,
        [Parameter(Mandatory = $true)]
        [string]$RequestBody
    )

    # Setting uri
    Write-Debug "Preparing to retrieve Helm values from the API."
    $apiVersion = "2024-07-01-preview"
    $chartLocationUrlSegment = "azure-arc-k8sagents/GetHelmSettings"
    $releaseTrain = if ($env:RELEASETRAIN) { $env:RELEASETRAIN } else { "stable" }
    $chartLocationUrl = "$ConfigDpEndpoint/$chartLocationUrlSegment"
    if ($ReleaseTrainCustom) {
        $releaseTrain = $ReleaseTrainCustom
    }
    $uriParameters = [ordered]@{
        "api-version" = $apiVersion
        releaseTrain  = $releaseTrain
    }
    $headers = @{
        "Content-Type" = "application/json"
    }
    if ($env:AZURE_ACCESS_TOKEN) {
        $headers["Authorization"] = "Bearer $($env:AZURE_ACCESS_TOKEN)"
    }
    Write-Debug "Sending request to retrieve Helm values."

    # Sending request with retries
    try {
        Write-Verbose "Calculating Azure Arc resources required by Kubernetes cluster"
        $r = Invoke-RestMethodWithUriParameters `
            -Method 'post' `
            -Uri $chartLocationUrl `
            -Headers $headers `
            -UriParameters $uriParameters `
            -RequestBody $RequestBody `
            -MaximumRetryCount 5 `
            -RetryIntervalSec 3 `
            -StatusCodeVariable StatusCode `
            -Verbose:($PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent -eq $true) `
            -Debug:($PSCmdlet.MyInvocation.BoundParameters["Debug"].IsPresent -eq $true)

        # Response is a Hashtable of JSON values.
        if ($StatusCode -eq 200 -and $r) {
            Write-Debug "Successfully retrieved Helm values."
            return $r
        }
    }
    catch {
        $errorMessage = "Error while fetching helm values from DP from JSON response: $_"
        Write-Error $errorMessage
        throw $errorMessage
    }
    # Reach here and we received either a non-200 status code or no response.
    throw "No content was found in helm registry path response, StatusCode: ${StatusCode}."
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
