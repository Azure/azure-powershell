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

function Get-AzModuleWithUpdate {
    [OutputType([System.Collections.ArrayList])]
    [CmdletBinding(DefaultParameterSetName = 'Default', PositionalBinding = $false)]
    param(
        [Parameter(HelpMessage = 'The module name.')]
        [ValidateNotNullOrEmpty()]
        [string[]]
        ${Name},

        [Parameter(Mandatory, HelpMessage = 'The Registered Repostory.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Repository}
    )

    process {

        $modules = New-Object System.Collections.ArrayList

        Write-Debug "Retrieving installed Az modules"
        $moduleNames =  @('Az', 'Az.*')
        $installModules = @{}
        try {
            $null = PowerShellGet\Get-InstalledModule -Name $moduleNames -ErrorAction Stop | ForEach-Object {
                $installModules[$_.Name] = @()
            }
        }
        catch {
            Write-Warning $_
        }

        if ($installModules.Keys.Count) {
            foreach ($key in $installModules.Keys.Clone()) {
                $modules = (PowerShellGet\Get-InstalledModule -Name $key -AllVersions).Where( { -not $_.AdditionalMetadata.IsPrerelease })
                if ($modules) {
                    $installModules[$key] += $modules.Version
                }
            }
        }

        Write-Debug "The modules currently installed: $($installModules.Keys)"

        $modulesToCheck = @("")
        $modulesToCheck += if ($Name) {$Name} else {@("Az")}
        Write-Debug "The modules to check for update at start: $modulesToCheck"
        $index = 1
        while($index -lt $modulesToCheck.Count) {
            $module = PowerShellGet\Find-Module -Name $modulesToCheck[$index] -Repository $Repository
            if ($module) {
                Write-Progress -Activity "Find Module" -CurrentOperation "$($module.Name) with the latest version $($module.Version)" -PercentComplete $index
                $null = $modules.Add($module)
                $module.Dependencies | ForEach-Object {
                    if (!$modulesToCheck.Contains($_['Name'])) {
                        $modulesToCheck += $_['Name']
                    }
                }
            }
            $index += 1
        }
        Write-Progress -Activity "Find Module" -Completed
        $modules = ($modules | Sort-Object -Property Name -Unique)

        Write-Debug "The modules to check for update: $($modules.Name)"

        $modulesToUpdate = $modules.Where({ !$installModules.ContainsKey($_.Name) -or !$installModules[$_.Name] -or [Version]($_.Version) -gt ($installModules[$_.Name].ForEach({[Version]$_}) | measure -Maximum).Maximum })
        if ("Az" -eq ($modulesToUpdate | Select-Object -First 1).Name) {
            $first, $rest = $modulesToUpdate
            $modulesToUpdate = (@() + $rest + $first)
        }

        If (0 -eq $modulesToUpdate.Count) {
            Write-Warning "None of your specifed module needs upgrading."
        }
        else {
            Write-Debug "The modules contain update: $($modulesToUpdate.Name)"
        }
        Write-Output ($modulesToUpdate | ForEach-Object {
            New-Object -Type PSObject -Property @{
                'Name'             = $_.Name
                'VersionToUpgrade' = $_.Version
                'InstalledVersion' = if ($installModules.ContainsKey($_.Name)) {$installModules[$_.Name]} else {@()}
                'Repository'       = $_.Repository
            }
        })
    }
}
