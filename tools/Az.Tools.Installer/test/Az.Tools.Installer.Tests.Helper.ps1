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
function Get-AzSubModule {
    param (
    )

    process {
        Get-Module -ListAvailable -Name Az* | Where-Object {$_.Name -match "Az(\.[a-zA-Z0-9]+)?$"}
    }
}

function Get-AllAzModule {
    param (
        [Parameter()]
        [Switch]
        ${PrereleaseOnly}
    )

    process {
        $allmodules = Microsoft.PowerShell.Core\Get-Module -ListAvailable -Name Az*, Az `
         | Where-Object {$_.Name -match "Az(\.[a-zA-Z0-9]+)?$"} `
         | Where-Object {
            !$PrereleaseOnly -or ($_.PrivateData -and $_.PrivateData.ContainsKey('PSData') -and $_.PrivateData.PSData.ContainsKey('PreRelease') -and $_.PrivateData.PSData.Prerelease -eq 'preview') -or ($_.Version -lt [Version] "1.0")
        }
        $allmodules
    }
}

function Get-ReferencePath {
    param()
    process {
        $allAzModules = @()
        $allAzModules += Get-AzSubModule
        $pathList = @()
        $userPath = $null
        $adminPath = $null
        if ($allAzModules) {
            $pathList = $allAzModules.Path -split 'Az.' | Sort-Object -Property Length -Descending | Select-Object -First $allAzModules.Count | Select-Object -Unique
            $userPath = $pathList | Where-Object {$_.Contains($env:UserName)}
            $adminPath = $pathList | Where-Object {!$_.Contains($env:UserName)}
        }
        Write-Output @{UserPath = $userPath; AdminPath = $adminPath}
    }
}

function Uninstall-SingleModule {
    param (
        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Name},

        [Parameter()]
        [string[]]
        ${UserPath},

        [Parameter()]
        [string[]]
        ${AdminPath},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Invoker}
    )

    process {
        try {
            if ($UserPath) {
                $path = Join-Path $UserPath $Name
                if (Test-Path -Path $path) {
                    $subFolder = Get-ChildItem $path
                    $version = $null
                    if ($subFolder) {
                        $version = $subFolder.Name
                    }
                    Microsoft.PowerShell.Management\Remove-Item -Path $path -Recurse -Force -WhatIf:$false
                    Write-Debug "[$Invoker] Uninstalling $Name version $version is completed."
                }
            }
            if ($AdminPath) {
                $path = Join-Path $AdminPath $Name
                if (Test-Path -Path $path) {
                    $subFolder = Get-ChildItem $path
                    $version = $null
                    if ($subFolder) {
                        $version = $subFolder.Name
                    }
                    Microsoft.PowerShell.Management\Remove-Item -Path $path -Recurse -Force -WhatIf:$false
                    Write-Debug "[$Invoker] Uninstalling $Name version $version is completed."
                }
            }
        }
        catch {
            Write-Warning "[$Invoker] You don't have the enough permission to uninstall the module. Please run PowerShell as admin. $_"
        }
    }
}

function Remove-AllAzModule {
    param ()

    process {
        $prefix = 'Az.Tools.Installer.Tests'
        Write-Host "[$prefix] Remove all az modules"
        $referencePath = Get-ReferencePath
        if ($referencePath.AdminPath -or $referencePath.UserPath) {
            $allInstalled = @()
            $allInstalled += Get-AllAzModule
            $module = $null
            foreach ($module in $allInstalled) {
                Uninstall-SingleModule -Name $module.Name -UserPath $referencePath.UserPath -AdminPath $referencePath.AdminPath -Invoker $prefix
            }
        }
    }
}
