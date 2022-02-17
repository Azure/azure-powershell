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

function Install-SingleModuleFromPackage{
    [CmdletBinding(SupportsShouldProcess)]
    param(
        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Path},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${DestinationPath},

        [Parameter(Mandatory)]
        [ValidateSet('CurrentUser', 'AllUsers')]
        [string]
        ${Scope},

        [Parameter()]
        [Switch]
        ${RemovePrevious},

        [Parameter()]
        [Switch]
        ${Force},

        [Parameter()]
        [string]
        ${Invoker}
    )

    process {
        $InstallStarted = Get-Date
        $downloader = [ParallelDownloader]::new()                
        try {
            $filePath = $downloader.Download($Path, $DestinationPath)
            $moduleName = $downloader.LastModuleName
            $moduleVersion = $downloader.LastModuleVersion
            Write-Debug "[$Invoker] Downloading $moduleName version $moduleVersion."
            $downloader.WaitForAllTasks()
            if (!(Test-Path -Path $filePath)) {
                Throw "[$Invoker] Fail to download $moduleName to $DestinationPath. Please check your network connection and retry."
            }
            $durationInstallation = (Get-Date) - $InstallStarted
            Write-Debug "[$Invoker] The download task is finished. Time Elapsed Total:$($durationInstallation.TotalSeconds)s."
        }
        finally {
            $downloader.Dispose()
        }

        Write-Progress -Id $script:FixProgressBarId  "Install packages from local."

        $InstallStarted = Get-Date
        Write-Debug "[$Invoker] Will install $moduleName"
        $installModuleParams = @{
            Scope = $Scope
            Repository = $script:AzTempRepoName
            AllowClobber = $true
            Confirm = $false
            ErrorAction = 'Stop'
            SkipPublisherCheck = $true
            AllowPrerelease = $true
        }
        $confirmInstallation = $Force -or $PSCmdlet.ShouldProcess("Install module $moduleName version $moduleVersion", "$moduleName version $moduleVersion", "Install")
        $confirmUninstallation = $false
        if ($RemovePrevious) {
            $confirmUninstallation = $Force -or $PSCmdlet.ShouldProcess("Remove previously installed $moduleName", "$moduleName", 'Remove')
        }
        if ($confirmInstallation) {
            if ($confirmUninstallation) {
                PowerShellGet\Uninstall-Module -Name $moduleName -AllVersion -AllowPrerelease -ErrorAction 'SilentlyContinue'
            }
            PowerShellGet\Install-Module @installModuleParams -Name $moduleName -RequiredVersion "$moduleVersion"
        }
        
        if (!$WhatIfPreference) {
            $moduleInstalled = @()
            $moduleInstalled += [PSCustomObject]@{
                Name = $moduleName
                Version = $moduleVersion
            }
            Write-Output $moduleInstalled 
        }
    }
}
