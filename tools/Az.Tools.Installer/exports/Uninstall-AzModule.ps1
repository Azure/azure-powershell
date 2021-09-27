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

function Uninstall-AzModule {

<#
    .Synopsis
        Uninstalls Azure PowerShell modules.
    
    .Description
        Uninstalls Azure PowerShell modules.

    .Example
        C:\PS> Uninstall-AzModule -AllowPrerelease -AllVersion

#>

    [OutputType()]
    [CmdletBinding(DefaultParameterSetName = 'Default', PositionalBinding = $false, SupportsShouldProcess = $true)]
    param(
        [Parameter(ParameterSetName = 'ByName', Mandatory, HelpMessage = 'Az modules to uninstall.', ValueFromPipelineByPropertyName = $true)]
        [ValidateNotNullOrEmpty()]
        [string[]]
        ${Name},

        [Parameter(ParameterSetName = 'Default',HelpMessage = 'Az modules to exclude from uninstall.', ValueFromPipelineByPropertyName = $true)]
        [ValidateNotNullOrEmpty()]
        [string[]]
        ${ExcludeModule},

        [Parameter(ParameterSetName = 'Default', HelpMessage = 'Specify to uninstall prerelease modules only.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${PrereleaseOnly},
        
        [Parameter(HelpMessage = 'Remove all AzureRm modules.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${RemoveAzureRm},

        [Parameter(HelpMessage = 'Installs modules and overrides warning messages about module installation conflicts. If a module with the same name already exists on the computer, Force allows for multiple versions to be installed. If there is an existing module with the same name and version, Force overwrites that version.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${Force}
    )

    process
    {
        $cmdStarted = Get-Date

        $Invoker = $MyInvocation.MyCommand
        $preErrorActionPreference =  $ErrorActionPreference
        $ErrorActionPreference = 'Stop'
        $ppsedition = $PSVersionTable.PSEdition
        Write-Debug "Powershell $ppsedition Version $($PSVersionTable.PSVersion)"

        if ($RemoveAzureRm -and ($Force -or $PSCmdlet.ShouldProcess('Remove AzureRm modules', 'AzureRm modules', 'Remove'))) {
            Uninstall-AzureRM
        }

        if ($Force -or $PSCmdlet.ShouldProcess('Remove Az if installed', 'Az', 'Remove')) {
            Uninstall-Az -AzOnly -Invoker $Invoker
        }

        $allInstalled = Get-AllAzModule -PrereleaseOnly:$PrereleaseOnly

        $moduleToUninstall = $allInstalled | Foreach-Object {[PSCustomObject]@{Name = $_.Name; Version = $_.Version}}
        if ($Name) {
            $Name = Normalize-ModuleName $Name
            $moduleToUninstall = $moduleToUninstall | Where-Object {!$Name -or $Name.Contains($_.Name)}
            $modulesNotInstalled = $Name | Where-Object {!$allInstalled.Name.Contains($_)}
            if ($modulesNotInstalled) {
                Write-Warning "[$Invoker] $modulesNotInstalled are not installed."
            }         
        }
        else {
            if ($ExcludeModule) {
                $ExcludeModule = Normalize-ModuleName $ExcludeModule
                $moduleToUninstall = $moduleToUninstall | Where-Object {!$ExcludeModule.Contains($_.Name)}
            }      
        }

        $groupSet = @{}
        $moduleToUninstall | Group-Object -Property Name | Foreach-Object {$groupSet[$_.Name] = ($_.Group.Version | Sort-Object -Descending) }

        $modules = $groupSet.Keys | ForEach-Object {
            $m = New-Object ModuleInfo
            $m.Name = $_
            $m.Version = $groupSet[$_]
            $m
        }
        $s = {
            param($module)
            Write-Output "$($module.Name) ver $($module.Version)"
            PowerShellGet\Uninstall-Module -Name $module.Name -AllVersions -ErrorAction SilentlyContinue
        }

        if ($modules) {
            $JobParams = @{
                ModuleList = $modules
                Snippet = $s
                Operation = 'Uninstalling'
                JobName = 'Az.Tools.Installer'
                Invoker = $Invoker
            }
    
            if ($PSBoundParameters.ContainsKey('Force'))
            {
                $JobParams.Add('Confirm', $false)
            }
    
            if ($PSBoundParameters.ContainsKey('Confirm'))
            {
                $JobParams.Add('Confirm', $PSBoundParameters['Confirm'])
            }
    
            if ($PSBoundParameters.ContainsKey('WhatIf'))
            {
                $JobParams.Add('WhatIf', $PSBoundParameters['WhatIf'])
            }

            Write-Host "[$Invoker] Uninstalling $($modules.Name)"
            $InstallStarted = Get-Date

            #Invoke-ThreadJob @JobParams

            $module = $null
            foreach ($module in $modules) {
                if ($PSCmdlet.ShouldProcess("Uninstall module $($module.Name) version $($module.Version)", "$($module.Name) version $($module.Version)", "Uninstall")) {
                    PowerShellGet\Uninstall-Module -Name $module.Name -AllVersions -ErrorAction SilentlyContinue
                    Write-Host  "[$Invoker] Uninstalling $($module.Name) ver $($module.Version) is completed"
                }
            }

            $durationInstallation = (Get-Date) - $InstallStarted
            Write-Host "[$Invoker] All uninstallation tasks are finished; Time Elapsed Total: $($durationInstallation.TotalSeconds)s"
        }
        
        <#
        Send-PageViewTelemetry -SourcePSCmdlet $PSCmdlet `
            -IsSuccess $true `
            -StartDateTime $cmdStarted `
            -Duration ((Get-Date) - $cmdStarted)

        #>

        $ErrorActionPreference = $preErrorActionPreference 
    }
}