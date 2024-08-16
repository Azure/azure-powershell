[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute('PSUseSingularNouns', '',
    Justification='Helm values is a recognised term', Scope='Function', Target='Get-HelmValues')]
param()    

function Set-HelmClientLocation {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExportAttribute()]
    param(
    )
    process {
        $HelmLocation = Get-HelmClientLocation
        if ($null -eq $HelmLocation) {
            return
        }
        if (!($env:Path.contains($HelmLocation)) -and (Test-Path $HelmLocation)) {
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
        if (IsWindows -and IsAmd64) {
            if (Test-Path Env:HELM_CLIENT_PATH) {
                $CustomPath = (Get-Item Env:HELM_CLIENT_PATH).Value
                if ($CustomPath.EndsWith("helm.exe") -and (!((Get-Item $CustomPath) -is [System.IO.DirectoryInfo]))) {
                    $CustomPath = $CustomPath.Replace("helm.exe","")
                }
                return $CustomPath
            }
            if (Test-Path Env:Home) {
                $HomePath = (Get-Item Env:HOME).Value
            } else {
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
                    $null = New-Item $RootFolder -ItemType Directory
                }
                if ((!(Test-Path $HelmLocation))) {
                    Invoke-WebRequest -Uri "https://k8connecthelm.azureedge.net/helmsigned/$ZipName" -OutFile $ZipLocation -UseBasicParsing
                    Expand-Archive $ZipLocation $RootFolder
                    Write-Verbose "Downloaded helm: $HelmLocation"
                }
            } catch {
                throw "Failed to download helm ($_)"
            }
        } else {
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
        return "azure-arc-release"
    }
}

function IsWindows {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExportAttribute()]
    param(
    )
    process {
        return (Get-OSName).contains("Windows")
    }
}

function Get-OSName {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExportAttribute()]
    param(
    )
    process {
        if ($PSVersionTable.PSEdition.Contains("Core")) {
            $OSPlatform = $PSVersionTable.OS
        } else {
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
        $isSupport = [Environment]::Is64BitOperatingSystem -and ($env:PROCESSOR_ARCHITECTURE -eq "AMD64")
        return $isSupport
    }
}

function Get-HelmValues {
    param (
        [Parameter(Mandatory=$true)]
        $ConfigDpEndpoint,
        [string]$ReleaseTrainCustom,
        $RequestBody
    )

    # Setting uri
    $apiVersion = "2024-07-01-preview"
    $chartLocationUrlSegment = "azure-arc-k8sagents/GetHelmSettings?api-version=$apiVersion"
    $releaseTrain = if ($env:RELEASETRAIN) { $env:RELEASETRAIN } else { "stable" }
    $chartLocationUrl = "$ConfigDpEndpoint/$chartLocationUrlSegment"
    if ($ReleaseTrainCustom) {
        $releaseTrain = $ReleaseTrainCustom
    }
    $uriParameters = @{releaseTrain=$releaseTrain}
    $headers = @{
        "Content-Type" = "application/json"
    }
    if ($env:AZURE_ACCESS_TOKEN) {
        $headers["Authorization"] = "Bearer $($env:AZURE_ACCESS_TOKEN)"
    }

    $dpRequestIdentity = $RequestBody.identity
    $id = $RequestBody.id
    # $request_body = $request_body.serialize()
    $RequestBody = $RequestBody | ConvertTo-Json | ConvertFrom-Json -AsHashtable
    $RequestBody["Identity"] = @{
        tenantId = $dpRequestIdentity.tenantId
        principalId = $dpRequestIdentity.principalId
    }
    $RequestBody["Id"] = $id

    # Convert $request_body to JSON
    $jsonBody = $RequestBody | ConvertTo-Json
    Write-Error "Request body: $jsonBody"

    # Sending request with retries
    try {
        $r = Invoke-RestMethodWithUriParameters -Method 'post' -Uri $chartLocationUrl -Headers $headers -UriParameters $uriParameters -RequestBody $JsonBody -MaximumRetryCount 5 -RetryIntervalSec 3 -StatusCodeVariable statusCodeVariable

        # Response is a Hashtable of JSON values.
        if ($statusCode -eq 200 -and $r) {
            return $r
        }
        else {
            throw "No content was found in helm registry path response, StatusCode: ${statusCode}."
        }
    }
    catch {
        $errorMessage = "Error while fetching helm values from DP from JSON response: $_"
        Write-Error $errorMessage
        throw $errorMessage
    }
}

function Get-HelmChartPath {
    param (
        [string]$RegistryPath,
        [string]$KubeConfig,
        [string]$KubeContext,
        [string]$HelmClientLocation,
        [string]$ChartFolderName = 'AzureArcCharts',
        [string]$ChartName = 'azure-arc-k8sagents',
        [bool]$NewPath = $true
    )

    # Exporting Helm chart
    $ChartExportPath = Join-Path $env:USERPROFILE ('.azure', $ChartFolderName -join '\')
    try {
        if (Test-Path $ChartExportPath) {
            Remove-Item $ChartExportPath -Recurse -Force
        }
    }
    catch {
        Write-Warning "Unable to cleanup the $ChartFolderName already present on the machine. In case of failure, please cleanup the directory '$ChartExportPath' and try again."
    }

    Get-HelmChart -RegistryPath $RegistryPath -ChartExportPath $ChartExportPath -KubeConfig $KubeConfig -KubeContext $KubeContext -HelmClientLocation $HelmClientLocation -NewPath $NewPath -ChartName $ChartName

    # Returning helm chart path
    $HelmChartPath = Join-Path $ChartExportPath $ChartName
    if ($ChartFolderName -eq $consts.Pre_Onboarding_Helm_Charts_Folder_Name) {
        $ChartPath = $HelmChartPath
    }
    else {
        $ChartPath = if ($env:HELMCHART) { $env:HELMCHART } else { $HelmChartPath }
    }

    return $ChartPath
}

function Get-HelmChart {
    param (
        [string]$RegistryPath,
        [string]$ChartExportPath,
        [string]$KubeConfig,
        [string]$KubeContext,
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
        $basePath, $imageName = if ($chartUrl -match "(^.*?)/([^/]+$)") {$matches[1], $matches[2]}
        $chartUrl = "$basePath/v2/$imageName"
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
            & $cmdHelmChartPull[0] $cmdHelmChartPull[1..($cmdHelmChartPull.Count - 1)]
            break
        }
        catch {
            if ($i -eq $RetryCount - 1) {
                # Assuming telemetry.set_exception and consts.Pull_HelmChart_Fault_Type are handled elsewhere
                throw "Unable to pull $ChartName helm chart from the registry '$RegistryPath': $_"
            }
            Start-Sleep -Seconds $RetryDelay
        }
    }
}

# !!PDS: no dogfood so no need for this?
function Get-HelmValuesFile {
    $valuesFile = $env:HELMVALUESPATH
    if ($null -ne $valuesFile -and (Test-Path $valuesFile)) {
        Write-Warning "Values file detected. Reading additional helm parameters from same."
        # Trimming required for Windows OS
        if ($valuesFile.StartsWith("'") -or $valuesFile.StartsWith('"')) {
            $valuesFile = $valuesFile.Substring(1)
        }
        if ($valuesFile.EndsWith("'") -or $valuesFile.EndsWith('"')) {
            $valuesFile = $valuesFile.Substring(0, $valuesFile.Length - 1)
        }
        return $valuesFile
    }
    return $null
}
