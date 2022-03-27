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

function Install-AzModule_Default {
    [OutputType([PSCustomObject[]])]
    [CmdletBinding(PositionalBinding = $false, SupportsShouldProcess)]
    param(
        [Parameter(ValueFromPipelineByPropertyName = $true, Position = 0)]
        #[ValidateNotNullOrEmpty()]
        [string[]]
        ${Name},

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string]
        ${RequiredAzVersion},

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Repository},

        [Parameter()]
        [Switch]
        ${AllowPrerelease},

        [Parameter()]
        [Switch]
        ${UseExactAccountVersion},

        [Parameter()]
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
        [ValidateNotNullOrEmpty()]
        [string]
        ${Invoker},

        [Parameter()]
        [Switch]
        ${Force}
    )

    process {
        Write-Progress -Id $script:FixProgressBarId "Find modules on $Repository."

        $Name = Normalize-ModuleName $Name
        $findModuleParams = @{
            Name = $Name
            AllowPrerelease = $AllowPrerelease
            UseExactAccountVersion = $UseExactAccountVersion
            Invoker = $Invoker
        }
        if ($Repository) {
            $findModuleParams.Add('Repository', $Repository)
        }
        if ($RequiredAzVersion) {
            $findModuleParams.Add('RequiredVersion', [Version]$RequiredAzVersion)
        }

        $modules = @()
        $modules += Get-AzModuleFromRemote @findModuleParams | Sort-Object -Property Name

        if($Name) {
            $moduleExcluded = $Name | Where-Object {!$modules -or $modules.Name -NotContains $_}
            if ($moduleExcluded) {
                $azVersion = if ($RequiredAzVersion) {$RequiredAzVersion} else {"Latest"}
                Write-Error "[$Invoker] The following specified modules:$moduleExcluded cannot be found in $Repository with the $azVersion version."
            }
        }

        if ($RemoveAzureRm -and ($Force -or $PSCmdlet.ShouldProcess('Remove AzureRm modules', 'AzureRm modules', 'Remove'))) {
            Write-Progress -Id $script:FixProgressBarId "Uninstall Azure and AzureRM."
            Remove-AzureRM
        }

        if ($Force -or $PSCmdlet.ShouldProcess('Remove Az if installed', 'Az', 'Remove')) {
            PowerShellGet\Uninstall-Module -Name 'Az' -AllVersion -AllowPrerelease -ErrorAction SilentlyContinue
        }

        if ($modules) {
            $moduleList = $modules | ForEach-Object {
                $m = New-Object ModuleInfo
                $m.Name = $_.Name
                $m.Version += [Version] $_.Version
                $m
            }
            $installModuleParams = @{
                ModuleList = $moduleList
                RepositoryUrl = (Get-RepositoryUrl $Repository)
                AllowPrerelease = $AllowPrerelease
                Scope = if ($Scope) {$Scope} else {'CurrentUser'}
                RemovePrevious = $RemovePrevious
                Force = $Force
                Invoker = $Invoker
            }
            $output = Install-AzModuleInternal @installModuleParams

            if (!$WhatIfPreference -and $output) {
                Write-Output $output
            }
        }
    }
}
