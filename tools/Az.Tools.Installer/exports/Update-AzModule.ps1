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
        
        Write-Debug "Time Elapsed: $((Measure-Command { $allToUpdate = Get-AzModuleUpdateList @parameters }).TotalSeconds)s"

        Write-Host -ForegroundColor DarkGreen "The modules to Upddate:$($allToUpdate | Out-String)"

        if($allToUpdate.Count) {
            foreach ($module in $allToUpdate) {
                if ($Force -or $PSCmdlet.ShouldProcess($module.Name, "Upgrade to the latest version $($module.VersionToUpgrade) from $($module.Repository)")) {
                    if ($Force) {
                        Write-Debug "Upgrade $($module.Name) to the latest version $($module.VersionToUpgrade) from $($module.Repository)."
                    }
                    PowerShellGet\Update-Module -Name $module.Name -Force:$Force
                }
                if ($RemovePrevious) {
                    if ($module.InstalledVersion -and ($Force -or $PSCmdlet.ShouldProcess($module.Name, "Uninstall the versions: $($module.InstalledVersion)"))) {
                        if ($Force) {
                            Write-Debug "Uninstall $($module.Name) of versions $($module.InstalledVersion)."
                        }
                        foreach($version in $module.InstalledVersion) {
                            PowerShellGet\Uninstall-Module -Name $module.Name -RequiredVersion $version
                        }
                    }
                }
            }

            $output = @()
            foreach($name in $allToUpdate.Name) {
                try {
                    $output += (Get-InstalledModule -Name $name -ErrorAction Stop)
                }
                catch {
                    Write-Warning $_
                }
            }
            Write-Output $output
        }
    }
}

