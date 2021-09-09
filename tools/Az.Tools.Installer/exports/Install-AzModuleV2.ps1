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

function Install-AzModuleV2 {

<#
    .Synopsis
        Installs Azure PowerShell modules.
    
    .Description
        Installs Azure PowerShell modules.

    .Example
        C:\PS> Install-AzModule -Name Storage,Compute,Network -Repository PSGallery

#>

    [OutputType()]
    [CmdletBinding(DefaultParameterSetName = 'Default', 
    PositionalBinding = $false, 
    SupportsShouldProcess)]
    param(
        [Parameter(HelpMessage = 'Az modules to install.', ValueFromPipelineByPropertyName = $true)]
        #[ValidateNotNullOrEmpty()]
        [string[]]
        ${Name},

        [Parameter(HelpMessage = 'Required Az Version.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${RequiredAzVersion},

        [Parameter(Mandatory, HelpMessage = 'The Registered Repostory.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Repository},

        [Parameter(ParameterSetName = 'WithPreview', Mandatory, HelpMessage = 'Allow preview modules to be installed.')]
        [Switch]
        ${AllowPrerelease},

        [Parameter(HelpMessage = 'Use exact account version.')]
        [Switch]
        ${UseExactAccountVersion},

        [Parameter(HelpMessage = 'Remove given module installed previously.')]
        [Switch]
        ${RemovePrevious},

        [Parameter(HelpMessage = 'Remove all AzureRm modules.')]
        [Switch]
        ${RemoveAzureRm},

        [Parameter(HelpMessage = 'Installs modules and overrides warning messages about module installation conflicts. If a module with the same name already exists on the computer, Force allows for multiple versions to be installed. If there is an existing module with the same name and version, Force overwrites that version.')]
        [Switch]
        ${Force},

        [Parameter()]
        [Switch]
        ${DontClean}
    )

    process {
        $cmdStarted = Get-Date

        $ErrorActionPreference = 'Stop'

        $Name = Normalize-ModuleName $Name

        $findModuleParams = @{
            Repository = $Repository
            Name = $Name
            AllowPrerelease = $AllowPrerelease
            UseExactAccountVersion = $UseExactAccountVersion
        }

        if ($RequiredAzVersion) {
            $findModuleParams.Add('RequiredVersion', [Version]$RequiredAzVersion)
        }

        $modules = Get-AzModuleFromRemote @findModuleParams | Sort-Object -Property Name
        
        $modules

        if ($RemoveAzureRm -and ($Force -or $PSCmdlet.ShouldProcess('Remove AzureRm modules', 'AzureRm modules', 'Remove'))) {
            Uninstall-AzureRM
        }

        if ($RemovePrevious) {
            if ($Force -or $PSCmdlet.ShouldProcess('Remove all previously installed Az modules', 'Az modules', 'Remove')) {
                Uninstall-Az
            }
        }
        else {
            if ($Force -or $PSCmdlet.ShouldProcess('Remove Az if installed', 'Az', 'Remove')) {
                Uninstall-Az -AzOnly
            }
        }

        try {
            [string]$tempRepo = Join-Path ([Path]::GetTempPath()) (Get-Date -Format "yyyyddMM-HHmm")
            $tempRepo = Join-Path 'D:/PSLocalRepo/' (Get-Date -Format "yyyyddMM-HHmm")
            
            if ($Force -or !$WhatIfPreference) {
                if (Test-Path -Path $tempRepo) {
                    Microsoft.PowerShell.Management\Remove-Item -Path $tempRepo -Recurse -WhatIf:$false
                }
                Write-Debug "[$($MyInvocation.MyCommand)] Create repository folder $tempRepo"
                $null = Microsoft.PowerShell.Management\New-Item -ItemType Directory -Path $tempRepo -WhatIf:$false

                PowerShellGet\Unregister-PSRepository -Name $script:AzTempRepoName -ErrorAction 'SilentlyContinue'
                Write-Debug "[$($MyInvocation.MyCommand)] Registering temporary repository $script:AzTempRepoName"
                PowerShellGet\Register-PSRepository -Name $script:AzTempRepoName -SourceLocation $tempRepo -ErrorAction 'Stop'
                PowerShellGet\Set-PSRepository -Name $script:AzTempRepoName -InstallationPolicy Trusted

                $downloader = [PSParallelDownloader]::new($Repository)
                $module = $null
    
                try {
                    foreach ($module in $modules) {
                        $null = $downloader.Download($module.Name, $module.Version, $tempRepo)
                    }
                    $downloader.WaitForAllTasks()
                }
                finally {
                    $downloader.Dispose()
                }
            }
            
            Write-Debug "[$($MyInvocation.MyCommand)] Installing modules $($modules.Name)"
            $installModuleParams = @{
                Scope = 'CurrentUser'
                Repository = $script:AzTempRepoName
                AllowClobber = $true
                Confirm = $false
                ErrorAction = 'Stop'
                SkipPublisherCheck = $true
                AllowPrerelease = if ($AllowPrerelease) {$AllowPrerelease} else {$false}
            }
            
            if ($Force -or $PSCmdlet.ShouldProcess("Install module Az.Accounts version $($modules[0].Version)", "Az.Accounts version $($modules[0].Version)", "Install")) {
                PowerShellGet\Install-Module -Name 'Az.Accounts' -RequiredVersion $modules[0].Version @installModuleParams
                $modules = $modules[1..($modules.Length - 1)]
            }

            $module = $null
            $result = @()
            $find = @()
            $max_job_count = 5
            foreach ($module in $modules) {
                $running = @(Get-Job -State 'Running')
                if ($running -and $running.Count -eq $max_job_count) {
                    $null = ($running | Wait-Job -Any)
                }
                Get-Job | Where-Object {$_.State -eq 'Completed'} | Foreach-Object {
                    $find += Receive-Job $_
                    Remove-Job $_
                }

                if ($Force -or $PSCmdlet.ShouldProcess("Install module $($module.Name) version $($module.Version)", "$($module.Name) version $($module.Version)", "Install")) {
                    $null = Start-Job {
                        PowerShellGet\Install-Module -Name $($using:module.Name) -RequiredVersion $($using:module.Version) @using:installModuleParams
                    }
                }
            }

            $null = Get-Job | Wait-Job
            Get-Job | Foreach-Object {
                $result += Receive-Job $_
                Remove-Job $_ -Confirm:$false
            }
            Write-Debug "[$($MyInvocation.MyCommand)] Modules install complete"
        }
        finally {
            if ($Force -or !$WhatIfPreference) {
                if (!$DontClean) {
                    Write-Debug "[$($MyInvocation.MyCommand)] Unregistering temporary repository $script:AzTempRepoName"
                    PowerShellGet\Unregister-PSRepository -Name $script:AzTempRepoName -ErrorAction 'Continue'

                    Write-Debug "[$($MyInvocation.MyCommand)] Delete repository folder $tempRepo"
                    Microsoft.PowerShell.Management\Remove-Item -Path $tempRepo -Recurse -WhatIf:$false
                }
            }
        }
        <#
        Send-PageViewTelemetry -SourcePSCmdlet $PSCmdlet `
            -IsSuccess $true `
            -StartDateTime $cmdStarted `
            -Duration ((Get-Date) - $cmdStarted)
        #>
    }
}