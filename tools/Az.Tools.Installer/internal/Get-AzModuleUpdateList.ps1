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

function Get-AzModuleUpdateList {
    [OutputType([System.Collections.ArrayList])]
    [CmdletBinding(DefaultParameterSetName = 'Default', PositionalBinding = $false)]
    param(
        [Parameter(HelpMessage = 'The module name.')]
        [ValidateNotNullOrEmpty()]
        [string[]]
        ${Name},

        [Parameter(HelpMessage = 'The registered repostory.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Repository}
    )

    process {
        $modules = New-Object System.Collections.ArrayList

        Write-Debug "Retrieving installed Az modules"
        $installModules = @{}
        try {
            PowerShellGet\Get-InstalledModule -Name "Az*" -ErrorAction Stop | Where-Object {
                ($_.Author -eq 'Microsoft Corporation' -or $_.CompanyName -eq 'Microsoft Corporation') -and ($_.Name -match "Az(\.[a-zA-Z0-9]+)?$")
            } | ForEach-Object {
                $installModules[$_.Name] = @()
            }
        }
        catch {
            Write-Warning $_
        }

        Write-Debug "The Az modules currently installed: $($installModules.Keys)"

        if ($installModules.Keys -gt 0) {
            foreach ($key in $installModules.Keys.Clone()) {
                $installedModules = (PowerShellGet\Get-InstalledModule -Name $key -AllVersions) | Where-Object { -not $_.AdditionalMetadata.IsPrerelease }
                foreach ($installed in $installedModules) {
                    $installModules[$key] += [System.Tuple]::Create($installed.Version, $installed.Repository)
                }
                if($installModules[$key].Count -gt 1) {
                    $installModules[$key] = ($installModules[$key] | Sort-Object -Property @{Expression={[Version]$_.Item1}} -Descending)
                }
            }
        }

        $modulesToCheck = @()
        $modulesToCheck += if ($Name) {
            $Name.Foreach({
                if ($installModules.ContainsKey($_) -and $installModules[$_]) {
                    [System.Tuple]::Create($_, $installModules[$_][0].Item2)
                }
            })
        } else {
            $installModules.Keys.ForEach({[System.Tuple]::Create($_, $installModules[$_][0].Item2)})
        }

        $allModuleTable = @{}
        $moduleSet = [System.Collections.Generic.HashSet[string]]::new()
        $null = $modulesToCheck | ForEach-Object {$moduleSet.Add($_.Item1)}

        $index = 0
        while($index -lt $modulesToCheck.Count) {
            $moduleName = $modulesToCheck[$index].Item1
            $repo = if ($Repository) {$Repository} elseif ($installModules.ContainsKey($moduleName)) {$installModules[$moduleName][0].Item2} else {$modulesToCheck[$index].Item2}
            if($repo) {
                if($allModuleTable.ContainsKey($moduleName)) {
                    $module = $allModuleTable[$moduleName]
                }
                else {
                    $module = PowerShellGet\Find-Module -Name $moduleName -Repository $repo
                }
                if ($module) {
                    Write-Progress -Activity "Find Module" -CurrentOperation "$($module.Name) with the latest version $($module.Version)" -PercentComplete ($index / $modulesToCheck.Count * 100)
                    $null = $modules.Add($module)
                    $dep = $null
                    foreach ($dep in $module.Dependencies.Name) {
                        if (!$moduleSet.Contains($dep)) {
                            $modulesToCheck += [System.Tuple]::Create($dep, $repo)
                            $null = $moduleSet.Add($dep)
                        }
                    }
                }
            }
            else {
                Write-Warning "Failed to find Repository of $moduleName. The module cannot be updated."
            }
            $index += 1
        }
        Write-Progress -Activity "Find Module" -Completed
        $modules = ($modules | Sort-Object -Property Name -Unique)

        Write-Debug "The modules to check for update: $($modules.Name)"

        $modulesToUpdate = $modules | Where-Object { !$installModules.ContainsKey($_.Name) -or !$installModules[$_.Name] -or [Version]($_.Version) -gt [Version]$installModules[$_.Name][0].Item1 }
        if ("Az" -eq ($modulesToUpdate | Select-Object -First 1).Name) {
            $first, $rest = $modulesToUpdate
            $modulesToUpdate = (@() + $rest + $first) | Where-Object {$_ -ne $null}
        }

        If (-not $modulesToUpdate) {
            Write-Warning "None of your specified module needs upgrading."
        }
        else {
            Write-Debug "The modules contain update: $($modulesToUpdate.Name)"
        }
        Write-Output ($modulesToUpdate | ForEach-Object {
            New-Object -Type PSObject -Property @{
                'Name'             = $_.Name
                'VersionToUpgrade' = $_.Version
                'InstalledVersion' = if ($installModules.ContainsKey($_.Name)) {$installModules[$_.Name].Item1} else {@()}
                'Repository'       = $_.Repository
            }
        })
    }
}
