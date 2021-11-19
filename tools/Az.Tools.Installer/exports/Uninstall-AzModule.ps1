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
        Uninstall Azure PowerShell modules.

    .Description
        Uninstall Azure PowerShell modules.

    .Example
        C:\PS> Uninstall-AzModule storage, network
    .Example
        C:\PS> Uninstall-AzModule -ExcludeModule storage, network
    .Example
        C:\PS> Uninstall-AzModule -PrereleaseOnly
#>

    [CmdletBinding(DefaultParameterSetName = 'Default', PositionalBinding = $false, SupportsShouldProcess = $true)]
    param(
        [Parameter(ParameterSetName = 'ByName', Mandatory, HelpMessage = 'Az modules to uninstall. Can be the names without Az. prefix', ValueFromPipelineByPropertyName = $true, Position = 0)]
        [ValidateNotNullOrEmpty()]
        [string[]]
        ${Name},

        [Parameter(ParameterSetName = 'Default',HelpMessage = 'Az modules to exclude from uninstallation.', ValueFromPipelineByPropertyName = $true)]
        [ValidateNotNullOrEmpty()]
        [string[]]
        ${ExcludeModule},

        [Parameter(ParameterSetName = 'Default', HelpMessage = 'Specify to uninstall prerelease modules only.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${PrereleaseOnly},

        [Parameter(HelpMessage = 'Remove all Azure and AzureRm modules.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${RemoveAzureRm},

        [Parameter(HelpMessage = 'Installs modules and overrides the confirmation messages of each step.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${Force}
    )

    process {
        $cmdStarted = Get-Date
        $Invoker = $MyInvocation.MyCommand
        $ppsedition = $PSVersionTable.PSEdition
        Write-Debug "Powershell $ppsedition Version $($PSVersionTable.PSVersion)"

        if ($RemoveAzureRm -and ($Force -or $PSCmdlet.ShouldProcess('Remove AzureRm modules', 'AzureRm modules', 'Remove'))) {
            Write-Progress -Id $script:FixProgressBarId "Uninstall Azure and AzureRM."
            Remove-AzureRM
        }

        if ($Force -or $PSCmdlet.ShouldProcess('Remove Az if installed', 'Az', 'Remove')) {
            Uninstall-Module -Name 'Az' -AllVersion -ErrorAction SilentlyContinue
        }

        Write-Progress -Id $script:FixProgressBarId "Check currently installed Az modules."

        $allInstalled = @()
        $allInstalled += Get-AllAzModule -PrereleaseOnly:$PrereleaseOnly

        $moduleToUninstall = $allInstalled | Foreach-Object {[PSCustomObject]@{Name = $_.Name; Version = $_.Version}}
        if ($Name) {
            $Name = Normalize-ModuleName $Name
            $moduleToUninstall = $moduleToUninstall | Where-Object {$Name -Contains $_.Name}
            $modulesNotInstalled = $Name | Where-Object {!$allInstalled -or $allInstalled.Name -NotContains $_}
            if ($modulesNotInstalled) {
                Write-Warning "[$Invoker] $modulesNotInstalled are not installed."
            }
        }
        else {
            if ($ExcludeModule) {
                $ExcludeModule = Normalize-ModuleName $ExcludeModule
                $moduleToUninstall = $moduleToUninstall | Where-Object {$ExcludeModule -NotContains $_.Name}
                $modulesNotInstalled = $ExcludeModule | Where-Object {!$allInstalled -or $allInstalled.Name -NotContains $_}
                if ($modulesNotInstalled) {
                    Throw "[$Invoker] $modulesNotInstalled are not installed."
                }
            }
        }

        Write-Progress -Id $script:FixProgressBarId "Uninstall specified Az modules."

        if ($moduleToUninstall) {
            $moduleNotToUninstall = $allInstalled.Name | Where-Object{$moduleToUninstall.Name -NotContains $_ }
            if ($null -ne $moduleNotToUninstall -and $null -ne $Name -and $Name -Contains 'Az.Accounts') {
                $moduleToUninstall = $moduleToUninstall | Where-Object{ $_.Name -ne 'Az.Accounts'}
                Write-Warning "[$Invoker] 'Az.Accounts cannot be uninstalled now for other modules are still dependent of it."
            }

            $groupSet = @{}
            $moduleToUninstall | Group-Object -Property Name | Foreach-Object {$groupSet[$_.Name] = ($_.Group.Version | Sort-Object -Descending) }

            $started = Get-Date
            $moduleName  = $null
            $index = 1
            foreach ($moduleName in $groupSet.Keys) {
                $versions = $groupSet[$moduleName]
                if ($Force -or $PSCmdlet.ShouldProcess("Uninstalling module $moduleName version $versions", "$moduleName version $versions", "Uninstall")) {
                    Write-Progress -ParentId $script:FixProgressBarId -Activity "Uninstall Module" -Status "$moduleName version $versions" -PercentComplete ($index / $groupSet.Count * 100)
                    if ($PrereleaseOnly) {
                        $versionStrings = $versions | ForEach-Object {
                            if ($_ -ge [Version] "1.0") {
                                "$($_)-preview"
                            }
                            else {
                                "$_"
                            }
                        }
                        foreach($versionString in $versionStrings) {
                            PowerShellGet\Uninstall-Module -Name $moduleName -RequiredVersion $versionString -AllowPrerelease -ErrorAction 'Continue'
                        }
                    }
                    else {
                        PowerShellGet\Uninstall-Module -Name $moduleName -AllVersion -AllowPrerelease -ErrorAction 'Continue'
                    }
                    Write-Debug "[$Invoker] Uninstalling $moduleName version $versions is completed."
                    $index += 1
                }
            }
            $duration = (Get-Date) - $started
            Write-Debug "[$Invoker] All uninstallation tasks are finished; Time Elapsed Total: $($duration.TotalSeconds)s."
        }

        Send-PageViewTelemetry -SourcePSCmdlet $PSCmdlet `
            -IsSuccess $true `
            -StartDateTime $cmdStarted `
            -Duration ((Get-Date) - $cmdStarted)
    }
}
