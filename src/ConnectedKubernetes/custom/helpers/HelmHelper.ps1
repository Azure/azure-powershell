
function Get-HelmClientLocation {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExportAttribute()]
    param(
    )
    process {
        if (Test-Path Env:HELM_CLIENT_PATH) {
            return (Get-Item Env:HELM_CLIENT_PATH).Value
        }

        if (IsWindows -and IsAmd64) {
            if (Test-Path Env:Home) {
                $HomePath = (Get-Item Env:HOME).Value
            } else {
                $HomePath = $Home
            }
            $Version = "v3.6.3"
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
                }
                if (Test-Path $HelmLocation) {
                    $PathStr = $InstallLocation + ";$env:Path"
                    Set-Item -Path Env:Path -Value $PathStr
                }
            } catch {
                throw "Failed to download helm"
            }
            Write-Verbose "Downloaded helm: $HelmLocation"
        } else {
            Write-Warning "Helm version 3.6.3 is required. Learn more at https://aka.ms/arc/k8s/onboarding-helm-install"
        }
        return $HelmLocation
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