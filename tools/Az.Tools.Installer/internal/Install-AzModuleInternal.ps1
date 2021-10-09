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

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string]
        ${RequiredAzVersion},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Repository},

        [Parameter()]
        [Switch]
        ${AllowPrerelease},

        [Parameter()]
        [Switch]
        ${UseExactAccountVersion},

        [Parameter(Mandatory)]
        [ValidateSet('CurrentUser', 'AllUsers')]
        [string]
        ${Scope},

        [Parameter()]
        [Switch]
        ${RemovePrevious},

        [Parameter()]
        [Switch]
        ${RemoveAzureRm},

        [Parameter()]
        [Switch]
        ${Force},

        [Parameter()]
        [Switch]
        ${DontClean},

        [Parameter()]
        [string]
        ${Invoker}
    )

    process {

        Write-Progress "Uninstalling Az if installed" -PercentComplete (1 / 4 * 100)

        try {
            if ($RemovePrevious) {
                $pathTable = Get-ReferencePath
                $module = $null
                foreach ($module in $moduleList) {
                    if ($Force -or $PSCmdlet.ShouldProcess("Remove all previously installed $($module.Name)", "$($module.Name)", 'Remove')) {
                        Uninstall-Module -Name $module.Name -AllVersion -ErrorAction 'Continue'
                        #Uninstall-SingleModule -Name $moduleName -ReferencePath $referencePaths -Invoker $Invoker
                        Write-Debug "[$Invoker] Uninstalling $($module.Name) version $($module.Version) is completed."
<#
                        if ($pathTable.AdminPath) {
                            if ($pathTable.UserPath) {
                                Uninstall-SingleModule -Name $module.Name -UserPath $pathTable.userPath -AdminPath $pathTable.adminPath -Invoker $Invoker
                            }
                            else {
                                Uninstall-SingleModule -Name $module.Name -AdminPath $pathTable.adminPath -Invoker $Invoker
                            }
                        }
                        else {
                            if ($pathTable.UserPath) {
                                try
                                {
                                     Uninstall-SingleModule -Name $module.Name -UserPath $pathTable.userPath -Invoker $Invoker
                                }
                                catch
                                {
                                    Write-Warning $_
                                }
                    
                            }
                            else {
                                Write-Warning "[$Invoker] $($module.Name) is not installed."
                            }
                        }
                    }
                }
#>                
            }

            if ($Force -or !$WhatIfPreference) {
                [string]$tempRepo = Join-Path ([Path]::GetTempPath()) ([Path]::GetRandomFileName())
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
                $url = Get-RepositoryUrl $Repository
                $downloader = [ParallelDownloader]::new($url)

                Write-Progress "Downloading packagkes from $Repository" -PercentComplete (2 / 4 * 100)
                try {
                    $module = $null
                    foreach ($module in $moduleList) {
                        Write-Debug "[$Invoker] Downloading $($module.Name) version $($module.Version)."
                        $null = $downloader.Download($module.Name, [string] $module.Version, $tempRepo)
                    }
                    $downloader.WaitForAllTasks()
                    $durationInstallation = (Get-Date) - $InstallStarted
                    Write-Debug "[$Invoker] All download tasks are finished. Time Elapsed Total:$($durationInstallation.TotalSeconds)s."
                }
                finally {
                    $downloader.Dispose()
                }
            }

            Write-Progress "Installing packagkes from local" -PercentComplete (3 / 4 * 100) -Completed
            
            $InstallStarted = Get-Date
            Write-Debug "[$Invoker] Will install modules $($moduleList.Name)."
            $installModuleParams = @{
                Scope = $Scope
                Repository = $script:AzTempRepoName
                AllowClobber = $true
                Confirm = $false
                ErrorAction = 'Stop'
                SkipPublisherCheck = $true
                AllowPrerelease = if ($AllowPrerelease) {$AllowPrerelease} else {$false}
            }

            if ($moduleList[0].Name -eq 'Az.Accounts') {
                if ($Force -or $PSCmdlet.ShouldProcess("Install module Az.Accounts version $($moduleList[0].Version)", "Az.Accounts version $($moduleList[0].Version)", "Install")) {
                    PowerShellGet\Install-Module @installModuleParams -Name "Az.Accounts" -RequiredVersion "$($moduleList[0].Version)"
                }
                $moduleList = $moduleList | Select-Object -Last ($moduleList.Length - 1)
            }

            try
            {
                $jobs = @()
                $module = $null
                $maxJobCount = 5
                $index = 0
                foreach ($module in $moduleList) {
                    if ($PSVersionTable.PSEdition -eq "Core") {
                        if ($Force -or $PSCmdlet.ShouldProcess("Install module $($module.Name) version $($module.Version)", "$($module.Name) version $($module.Version)", "Install")) {
                            $jobs  += Start-ThreadJob -Name "Az.Tools.Installer" {
                                $tmodule = $using:module
                                Write-Output "$($tmodule.Name) version $($tmodule.Version)"
                                Import-Module PackageManagement
                                Import-Module PowerShellGet
                                PowerShellGet\Install-Module @using:installModuleParams -Name $tmodule.Name -RequiredVersion "$($tmodule.Version)"
                            } -ThrottleLimit $maxJobCount
                            #-StreamingHost $Host
                        }
                    }
                    else {
                        $runningJob = @()
                        $runningJob += Get-Job -State Running
                        if ($runningJob -and ($runningJob.Count -ge $maxJobCount)) {
                            Get-Job -State Running | Wait-Job -Any -Timeout 120
                            $runningJob = @()
                            $runningJob += Get-Job -State Running
                            if ($runningJob -and ($runningJob.Count -ge $maxJobCount)) {
                                Throw "[$Inovker] Some background jobs are blocked. Please use 'Get-Job -State Running' to check them."
                            }                          
                        }
                        if ($Force -or $PSCmdlet.ShouldProcess("Install module $($module.Name) version $($module.Version)", "$($module.Name) version $($module.Version)", "Install")) {
                            $jobs += Start-Job -Name "Az.Tools.Installer" {
                                $tmodule = $using:module
                                Write-Output "$($tmodule.Name) version $($tmodule.Version)"
                                Import-Module PackageManagement
                                Import-Module PowerShellGet
                                PowerShellGet\Install-Module @using:installModuleParams -Name $tmodule.Name -RequiredVersion "$($tmodule.Version)"
                            }
                            Write-Progress -Activity "Install Module" -CurrentOperation "$($module.Name) version $($module.Version)" -PercentComplete ($index / $moduleList.Count * 100)
                            $index += 1
                        }
                    }
                }
    
                if ($Force -or !$WhatIfPreference) {
                    $result = $null
                    $job = $null
                    $index = 0
                    foreach ($job in $jobs) {
                        $job = Wait-Job $job
                        try {
                            $result = $null
                            $result = Receive-Job $job
                            if ($job.State -eq 'Completed') {
                                Write-Debug  "[$Invoker] Installing $result is complete."
                            }
                            else {
                                Write-Warning  "[$Invoker] Installing $result is failed."
                            }
                        }
                        catch {
                            Write-Warning $_
                            Write-Warning  "[$Invoker] Installing $result is failed."
                        }
                        Remove-Job $job -Confirm:$false
                        if ($PSVersionTable.PSEdition -eq "Core") {
                            Write-Progress -Activity "Install Module" -CurrentOperation "$result" -PercentComplete ($index / $jobs.Count * 100)
                            $index += 1
                        }
                    }
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
