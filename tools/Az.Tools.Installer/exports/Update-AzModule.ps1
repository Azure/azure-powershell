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

        [Parameter(HelpMessage = 'The Registered Repostory.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Repository},

        [Parameter(HelpMessage = 'Present to decide whether to remove the previous versions of the modules.')]
        [switch]
        ${RemovePrevious},

        [Parameter(HelpMessage = 'Update modules and override warning messages about module installation conflicts. If a module with the same name already exists on the computer, Force allows for multiple versions to be installed. If there is an existing module with the same name and version, Force overwrites that version.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${Force}
    )

    process {
        Write-Host "Powershell $($PSVersionTable.PSEdition) Version $($PSVersionTable.PSVersion)"
        $parameters = @{}
        if ($Name) {
            $parameters['Name'] = ($Name | Sort-Object -Unique)
        }

        if ($Repository) {
            $parameters['Repository'] = $Repository
        }
        
        Write-Debug "Time Elapsed: $((Measure-Command { $allToUpdate = Get-AzModuleWithUpdate @parameters }).TotalSeconds) s"

        Write-Host -ForegroundColor DarkGreen "The modules to Upddate:$($allToUpdate | Out-String)"

        if($allToUpdate) {
            $azModule = $allToUpdate.Where({$_.Name -eq "Az"})
            $allToUpdate | Foreach-Object {
                if ($RemovePrevious) {
                    if ($_.InstalledVersion -and ($Force -or $PSCmdlet.ShouldProcess($_.Name, "Uninstall the versions: $($_.InstalledVersion)"))) {
                        if ($Force) {
                            Write-Debug "Uninstall $($_.Name) of versions $($_.InstalledVersion)."
                        }
                        PowerShellGet\Uninstall-Module -Name $_.Name -AllVersions
                    }
                }
                if (-not $azModule -and ($Force -or $PSCmdlet.ShouldProcess($_.Name, "Upgrade to the latest version $($_.VersionToUpgrade) from $($_.Repository)"))) {
                    if ($Force) {
                        Write-Debug "Upgrade $($_.Name) to the latest version $($_.VersionToUpgrade) from $($_.Repository)."
                    }
                    PowerShellGet\Install-Module -Name $_.Name -Repository $_.Repository -Force
                }
            }
            if($azModule -and ($Force -or $PSCmdlet.ShouldProcess($azModule.Name, "Upgrade to the latest version $($azModule.VersionToUpgrade) from $($azModule.Repository)"))) {
                if ($Force) {
                    Write-Debug "Upgrade $($azModule.Name) to the latest version $($azModule.VersionToUpgrade) from $($azModule.Repository)."
                }
                PowerShellGet\Install-Module -Name $azModule.Name -Repository $azModule.Repository -Force
            }

            $output = @()
            $allToUpdate.Name | Foreach-Object {
                try {
                    $output += (Get-InstalledModule -Name $_ -ErrorAction Stop)
                }
                catch {
                    Write-Warning $_
                }
            }
            Write-Output $output
        }
    }
}

