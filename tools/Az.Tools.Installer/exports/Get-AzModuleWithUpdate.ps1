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
        [Parameter(ParameterSetName = 'Default', Mandatory, HelpMessage = 'The Registered Repostory.')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${Repository}
    )

    process {

        $modules = New-Object System.Collections.ArrayList

        if ($PSBoundParameters.ContainsKey('Repository')) {
            $installModules = @{}

            try {
                $null = Get-InstalledModule -Name @('Az', 'Az.*') -ErrorAction Stop | ForEach-Object { $installModules[$_.Name] = $_.Version }
            }
            catch {
                Write-Warning $_
            }

            $azModule = Find-Module -Name Az -Repository $Repository
            if ($azModule) {
                Write-Progress -Activity "Find Module" -CurrentOperation "Az with the latest version $($azModule.Version)"
                $null = $modules.Add($azModule)
                $null = $azModule.Dependencies | ForEach-Object { $_['Name'] } | ForEach-Object {
                    $m = Find-Module -Name $_ -Repository $Repository
                    $modules.Add($m)
                    Write-Progress -Activity "Find Module" -CurrentOperation "$_ with the latest version $($m.Version)"
                }
            }
            $modules = $modules.Where( { $installModules.ContainsKey($_.Name) -and [version]$_.Version -gt [version]$installModules[$_.Name] })
        }

        Write-Progress -Activity "Find Module" -Completed

        If (0 -eq $modules.Count) {
            Write-Warning "All of your installed Az modules are update to date."
        }
        else {
            Write-Host "The modules contains update:"
        }
        return $modules
    }
}

