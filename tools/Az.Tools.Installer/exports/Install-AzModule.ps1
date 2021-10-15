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

function Install-AzModule {

<#
    .Synopsis
        Installs Azure PowerShell modules.

    .Description
        Installs Azure PowerShell modules.

    .Example
        C:\PS> Install-AzModuleV2 -Repository PSGallery -RemoveAzureRm -RequiredAzVersion 6.3 -UseExactAccountVersion -Confirm:$false -Debug

        C:\PS> Install-AzModuleV2 -Name Storage,Compute,Network,Blockchain -Repository PSGallery -AllowPrerelease -Confirm:$false -Debug

#>

    [OutputType([PSCustomObject[]])]
    [CmdletBinding(DefaultParameterSetName = 'Default', PositionalBinding = $false, SupportsShouldProcess)]
    param(
        [Parameter(HelpMessage = 'Az modules to install.', ValueFromPipelineByPropertyName = $true)]
        #[ValidateNotNullOrEmpty()]
        [string[]]
        ${Name},

        [Parameter(HelpMessage = 'Required Az Version.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${RequiredAzVersion},

        [Parameter(HelpMessage = 'The Registered Repostory.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Repository},

        [Parameter(HelpMessage = 'Allow preview modules to be installed.')]
        [Switch]
        ${AllowPrerelease},

        [Parameter(HelpMessage = 'Use exact account version.')]
        [Switch]
        ${UseExactAccountVersion},

        [Parameter(HelpMessage = 'Scope to install modules. Accepted values: CurrentUser, AllUser.')]
        [ValidateSet('CurrentUser', 'AllUsers')]
        [string]
        ${Scope},

        [Parameter(HelpMessage = 'Remove given module installed previously.')]
        [Switch]
        ${RemovePrevious},

        [Parameter(HelpMessage = 'Remove all AzureRm modules.')]
        [Switch]
        ${RemoveAzureRm},

        [Parameter(HelpMessage = 'Installs modules and overrides warning messages about module installation conflicts. If a module with the same name already exists on the computer, Force allows for multiple versions to be installed. If there is an existing module with the same name and version, Force overwrites that version.')]
        [Switch]
        ${Force}
    )

    process {
        $cmdStarted = Get-Date
        $Invoker = $MyInvocation.MyCommand
        $ppsedition = $PSVersionTable.PSEdition
        Write-Debug "Powershell $ppsedition Version $($PSVersionTable.PSVersion)"

        Write-Progress -Id $script:FixProgressBarId "Find modules on $Repository."

        $Name = Normalize-ModuleName $Name
        $findModuleParams = @{
            Repository = $Repository
            Name = $Name
            AllowPrerelease = $AllowPrerelease
            UseExactAccountVersion = $UseExactAccountVersion
            Invoker = $Invoker
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

            Write-Progress -Id 1 "Uninstall Azure and AzureRM."
            Uninstall-AzureRM
        }

        if ($Force -or $PSCmdlet.ShouldProcess('Remove Az if installed', 'Az', 'Remove')) {
            PowerShellGet\Uninstall-Module -Name 'Az' -AllVersion -AllowPrerelease -ErrorAction SilentlyContinue
        }

        if ($modules) {
            $installModuleParams = @{}
            foreach ($key in $PSBoundParameters.Keys) {
                if($key -ne 'Name') {
                    $installModuleParams.Add($key, $PSBoundParameters[$key])
                }
            }
            $installModuleParams.Add('Invoker', $Invoker)
            if (!$installModuleParams.Contains('Scope')) {
                $installModuleParams.Add('Scope', 'CurrentUser')
            }
            $moduleList = $modules | ForEach-Object {
                $m = New-Object ModuleInfo
                $m.Name = $_.Name
                $m.Version += [Version] $_.Version
                $m
            }
            $installModuleParams.Add('ModuleList', $moduleList)
            $output = Install-AzModuleInternal @installModuleParams

            if (!$WhatIfPreference -and $output) {
                Write-Output $output
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
