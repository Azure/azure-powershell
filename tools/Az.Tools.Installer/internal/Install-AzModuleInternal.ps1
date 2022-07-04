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

function Install-AzModuleInternal {
    [CmdletBinding(SupportsShouldProcess)]
    param(
        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [ModuleInfo[]]
        ${ModuleList},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${RepositoryUrl},

        [Parameter()]
        [Switch]
        ${AllowPrerelease},

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
        ${Invoker},

        [Parameter()]
        [Switch]
        ${DontClean}
    )

    process {

        try {
            Write-Progress -Id $script:FixProgressBarId "Download packages from $Repository."

            if ($Force -or !$WhatIfPreference) {
                [string]$tempRepo = Join-Path ([Path]::GetTempPath()) ((New-Guid).Guid)
                #$tempRepo = Join-Path 'D:/PSLocalRepo/' (Get-Date -Format "yyyyddMM-HHmm")
                if (Test-Path -Path $tempRepo) {
                    Microsoft.PowerShell.Management\Remove-Item -Path $tempRepo -Recurse -WhatIf:$false
                }
                $null = Microsoft.PowerShell.Management\New-Item -ItemType Directory -Path $tempRepo -WhatIf:$false
                Write-Debug "[$Invoker] The repository folder $tempRepo is created."

                PowerShellGet\Unregister-PSRepository -Name $script:AzTempRepoName -ErrorAction 'SilentlyContinue'
                PowerShellGet\Register-PSRepository -Name $script:AzTempRepoName -SourceLocation $tempRepo -ErrorAction 'Stop'
                PowerShellGet\Set-PSRepository -Name $script:AzTempRepoName -InstallationPolicy Trusted
                Write-Debug "[$Invoker] The temporary repository $script:AzTempRepoName is registered."

                $InstallStarted = Get-Date
                $downloader = [ParallelDownloader]::new($RepositoryUrl)

                try {
                    $module = $null
                    $fileList = @()
                    foreach ($module in $ModuleList) {
                        Write-Debug "[$Invoker] Downloading $($module.Name) version $($module.Version)."
                        $filePath = $downloader.Download($module.Name, [string] $module.Version, $tempRepo)
                        $fileList += @{
                            Name = $module.Name
                            Path = $filePath
                        }
                    }
                    $downloader.WaitForAllTasks()
                    $file = $null
                    foreach($file in $fileList) {
                        if (!(Test-Path -Path $file.Path)) {
                            Throw "[$Invoker] Fail to download $($file.Name) to $tempRepo. Please check your network connection and retry."
                        }
                    }
                    $durationInstallation = (Get-Date) - $InstallStarted
                    Write-Debug "[$Invoker] All download tasks are finished. Time Elapsed Total:$($durationInstallation.TotalSeconds)s."
                }
                finally {
                    $downloader.Dispose()
                }
            }

            Write-Progress -Id $script:FixProgressBarId  "Install packages from local."

            $moduleInstalled = @()

            $InstallStarted = Get-Date
            Write-Debug "[$Invoker] Will install modules $($ModuleList.Name)."
            $installModuleParams = @{
                Scope = $Scope
                Repository = $script:AzTempRepoName
                AllowClobber = $true
                Confirm = $false
                ErrorAction = 'Stop'
                SkipPublisherCheck = $true
                AllowPrerelease = if ($AllowPrerelease) {$AllowPrerelease} else {$false}
            }

            $modules = [Array] $moduleList
            if ($modules[0].Name -eq 'Az.Accounts') {
                $confirmInstallation = $Force -or $PSCmdlet.ShouldProcess("Install module Az.Accounts version $($modules[0].Version)", "Az.Accounts version $($modules[0].Version)", "Install")
                $confirmUninstallation = $false
                if ($RemovePrevious) {
                    $confirmUninstallation = $Force -or $PSCmdlet.ShouldProcess("Remove previously installed Az.Accounts", "Az.Accounts", 'Remove')
                }
                if ($confirmInstallation) {
                    if ($confirmUninstallation) {
                        PowerShellGet\Uninstall-Module -Name "Az.Accounts" -AllVersion -AllowPrerelease -ErrorAction 'SilentlyContinue'
                    }
                    PowerShellGet\Install-Module @installModuleParams -Name "Az.Accounts" -RequiredVersion "$($modules[0].Version)"
                }
                $moduleInstalled += [PSCustomObject]@{
                    Name = "Az.Accounts"
                    Version = ($modules[0].Version | Select-Object -First 1)
                }
                $modules = [Array] ($modules | Select-Object -Last ($modules.Length - 1))
            }

            try
            {
                $jobs = @()
                $module = $null
                $maxJobCount = 5
                $index = 0
                $functions = {
                    function Install-SingleModule {
                        param (
                            [Parameter(Mandatory)]
                            [ValidateNotNullOrEmpty()]
                            [string]
                            ${ModuleName},

                            [Parameter(Mandatory)]
                            [ValidateNotNullOrEmpty()]
                            [version[]]
                            ${ModuleVersion},

                            [Parameter()]
                            [Switch]
                            ${RemovePrevious},

                            [Parameter(Mandatory)]
                            [ValidateNotNullOrEmpty()]
                            [hashtable]
                            ${InstallModuleParam}
                        )

                        process {
                            $state = $null
                            $errorString = $null
                            try {
                                Import-Module PackageManagement
                                Import-Module PowerShellGet -MinimumVersion 2.1.3 -MaximumVersion 3.0.0.0 -Scope Global
                                if ($RemovePrevious) {
                                    PowerShellGet\Uninstall-Module -Name $moduleName -AllVersion -AllowPrerelease -ErrorAction 'SilentlyContinue'
                                }
                                PowerShellGet\Install-Module @installModuleParam -Name $moduleName -RequiredVersion "$moduleVersion"
                                $state = "succeeded"
                            }
                            catch {
                                $state = "failed"
                                $errorString = $_
                            }
                            finally {
                                Write-Output @{
                                    "ModuleName" = $moduleName
                                    "ModuleVersion" = $moduleVersion
                                    "Result" = $state
                                    "Error" = $errorString
                                }
                            }
                        }
                    }
                }
                $index = 1
                $module = $null
                foreach ($module in $modules) {
                    if ($PSVersionTable.PSEdition -eq "Core") {
                        $confirmInstallation = $Force -or $PSCmdlet.ShouldProcess("Install module $($module.Name) version $($module.Version)", "$($module.Name) version $($module.Version)", "Install")
                        $confirmUninstallation = $false
                        if ($RemovePrevious) {
                            $confirmUninstallation = $Force -or $PSCmdlet.ShouldProcess("Remove previously installed $($module.Name)", "$($module.Name)", 'Remove')
                        }
                        if ($confirmInstallation) {
                            $jobs  += Start-ThreadJob -Name "Az.Tools.Installer" -InitializationScript $functions -ScriptBlock {
                                $tmodule = $using:module
                                $tInstallModuleParam = $using:installModuleParams
                                $result = Install-SingleModule -ModuleName $tmodule.Name -ModuleVersion $tmodule.Version -InstallModuleParam $tInstallModuleParam -RemovePrevious:($using:confirmUninstallation)
                                Write-Output $result
                            } -ThrottleLimit $maxJobCount
                             #-StreamingHost $Host
                        }
                    }
                    else {
                        $runningJob = @()
                        $runningJob += Get-Job -State Running
                        if ($runningJob -and ($runningJob.Count -ge $maxJobCount)) {
                            Get-Job -State Running | Wait-Job -Any -Timeout 120 | Out-Null
                            $runningJob = @()
                            $runningJob += Get-Job -State Running
                            if ($runningJob -and ($runningJob.Count -ge $maxJobCount)) {
                                Throw "[$Invoker] You have enough background jobs currently. Please use 'Get-Job -State Running' to check them."
                            }
                        }
                        $confirmInstallation = $Force -or $PSCmdlet.ShouldProcess("Install module $($module.Name) version $($module.Version)", "$($module.Name) version $($module.Version)", "Install")
                        $confirmUninstallation = $false
                        if ($RemovePrevious) {
                            $confirmUninstallation = $Force -or $PSCmdlet.ShouldProcess("Remove previously installed $($module.Name)", "$($module.Name)", 'Remove')
                        }
                        if ($confirmInstallation) {
                            $jobs += Start-Job -Name "Az.Tools.Installer"  -InitializationScript $functions -ScriptBlock {
                                $tmodule = $using:module
                                $tInstallModuleParam = $using:installModuleParams
                                $result = Install-SingleModule -ModuleName $tmodule.Name -ModuleVersion $tmodule.Version -InstallModuleParam $tInstallModuleParam -RemovePrevious:($using:confirmUninstallation)
                                Write-Output $result
                            }
                            Write-Progress -ParentId $script:FixProgressBarId -Activity "Install Module" -Status "$($module.Name) version $($module.Version)" -PercentComplete ($index / $modules.Count * 100)
                            $index += 1
                        }
                    }
                }

                if ($Force -or !$WhatIfPreference) {
                    $result = $null
                    $job = $null
                    $index = 1
                    foreach ($job in $jobs) {
                        $job = Wait-Job $job
                        $result = $null
                        $result = Receive-Job $job
                        if ($job.State -eq 'Completed' -and $result.Result -eq "succeeded") {
                            Write-Debug  "[$Invoker] Installing $($result.ModuleName) of version $($result.ModuleVersion) is complete."
                            $moduleInstalled += [PSCustomObject]@{
                                Name = $result.ModuleName
                                Version = ($result.ModuleVersion | Select-Object -First 1)
                            }
                        }
                        else {
                            Write-Error "[$Invoker] Installing $($result.ModuleName) of version $($result.ModuleVersion) is failed. `n$($result.Error)"
                        }
                        Remove-Job $job -Confirm:$false
                        if ($PSVersionTable.PSEdition -eq "Core") {
                            Write-Progress -ParentId $script:FixProgressBarId -Activity "Install Module" -Status "$($result.ModuleName) of version $($result.ModuleVersion)" -PercentComplete ($index / $jobs.Count * 100)
                            $index += 1
                        }
                    }
                    Write-Output $moduleInstalled
                }
            }
            finally
            {
                $jobs = Get-Job -Name "Az.Tools.Installer" -ErrorAction 'SilentlyContinue'
                if ($jobs) {
                    Stop-Job $jobs
                    Remove-Job $jobs -Confirm:$false
                }
            }

            $durationInstallation = (Get-Date) - $InstallStarted
            Write-Debug "[$Invoker] All installing tasks are completed; Time Elapsed Total: $($durationInstallation.TotalSeconds)s."
        }
        finally {
            if ($Force -or !$WhatIfPreference) {
                if (!$DontClean) {
                    Write-Debug "[$Invoker] The temporary repository $script:AzTempRepoName is unregistered."
                    PowerShellGet\Unregister-PSRepository -Name $script:AzTempRepoName -ErrorAction 'Continue'

                    Write-Debug "[$Invoker] The Repository folder $tempRepo is removed."
                    if (Test-Path -Path $tempRepo) {
                        Microsoft.PowerShell.Management\Remove-Item -Path $tempRepo -Recurse -WhatIf:$false
                    }
                }
            }
        }
    }
}
