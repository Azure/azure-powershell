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

function Update-AzModule {
    [OutputType([PSCustomObject[]])]
    [CmdletBinding(DefaultParameterSetName = 'Default', PositionalBinding = $false, SupportsShouldProcess = $true)]
    param(
        [Parameter(HelpMessage = 'The module names.')]
        [ValidateNotNullOrEmpty()]
        [string[]]
        ${Name},

        [Parameter(HelpMessage = 'Present to decide whether to remove the previous versions of the modules.')]
        [switch]
        ${RemovePrevious},

        [Parameter(HelpMessage = 'Update modules and override warning messages about module installation conflicts. If a module with the same name already exists on the computer, Force allows for multiple versions to be installed. If there is an existing module with the same name and version, Force overwrites that version.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${Force}
    )

    process {
        $cmdStarted = Get-Date

        $WhatIf = $PSBoundParameters.ContainsKey('WhatIf')

        $ppsedition = $PSVersionTable.PSEdition
        Write-Host "Powershell $ppsedition Version $($PSVersionTable.PSVersion)"

        if ($ppsedition -eq "Core") {
            $allPahts = (Microsoft.PowerShell.Core\Get-Module -Name "Az*" -ListAvailable -ErrorAction Stop).Where({$_.Author -eq "Microsoft Corporation" -and $_.Name -match "Az(\.[a-zA-Z0-9]+)?$"}).Path
            $allPahts = ($allPahts | Select-String -Pattern "WindowsPowerShell")
            if ($allPahts) {
                Write-Warning "Az modules are also installed in WindowsPowerShell. Please update them using WindowsPowerShell."
            }
        }

        $parameters = @{}
        if ($Name) {
            $Name = $Name.Foreach({"Az." + $_}) | Sort-Object -Unique
            $parameters['Name'] = $Name
        }
        
        $totalSeconds = (Measure-Command { $allToUpdate = Get-AzModuleUpdateList @parameters }).TotalSeconds
        Write-Debug "Time Elapsed: ${totalSeconds}s"

        if($allToUpdate) {
            Write-Host -ForegroundColor DarkGreen "The modules to Upddate:$($allToUpdate | Out-String)"

            $allToUpdateReordered = @() + $allToUpdate.Where({$_.Name -eq "Az"})
            $allToUpdateReordered += $allToUpdate.Where({$_.Name -ne "Az" -and $_.Name -ne "Az.Accounts"})
            $allToUpdateReordered += $allToUpdate.Where({$_.Name -eq "Az.Accounts"})

            foreach ($module in $allToUpdateReordered) {
                if (-not $module) {
                    continue
                }
                if ($RemovePrevious) {
                    if ($module.InstalledVersion -and ($Force -or $PSCmdlet.ShouldProcess("Remove $($module.Name) of the versions: $($module.InstalledVersion)", $module.Name, "Remove"))) {
                        if ($Force) {
                            Write-Debug "Remove $($module.Name) of versions $($module.InstalledVersion)."
                        }
                        foreach ($version in $module.InstalledVersion) {
                            PowerShellGet\Uninstall-Module -Name $module.Name -RequiredVersion $version
                        }
                    }
                }
                
                if ($Force -or $PSCmdlet.ShouldProcess("Update $($module.Name) to the latest version $($module.VersionToUpgrade) from $($module.Repository)", $module.Name, "Update")) {
                    if ($Force) {
                        Write-Debug "Update $($module.Name) to the latest version $($module.VersionToUpgrade) from $($module.Repository)."
                    }

                    try {
                        $installModule = Get-InstalledModule -Name $module.Name -RequiredVersion $module.VersionToUpgrade -ErrorAction Stop
                    }
                    catch {
                        Write-Debug $_
                    }
                    if (-not $installModule -or $installModule.Repository -ne $module.Repository) {
                        $parameters = @{}
                        $parameters['Name'] = $module.Name
                        $parameters['Repository'] = $module.Repository
                        $parameters['RequiredVersion'] = $module.VersionToUpgrade
                        $parameters['Force'] = $installModule.Repository -ne $module.Repository -or $Force
                        PowerShellGet\Install-Module @parameters
                    }
                }
            } 

            $output = @()
            if (-not $WhatIf) {
                foreach($name in $allToUpdate.Name) {
                    try {
                        $output += (Get-InstalledModule -Name $name -ErrorAction Stop)
                    }
                    catch {
                        Write-Warning $_
                    }
                }
            }
            Write-Output $output
        }

        $Duration = (Get-Date) - $cmdStarted
        Write-Debug "Time Elapsed Total: $($Duration.TotalSeconds)s"

        Send-PageViewTelemetry -SourcePSCmdlet $PSCmdlet `
        -IsSuccess $true `
        -StartDateTime $cmdStarted `
        -Duration $Duration
    }
}