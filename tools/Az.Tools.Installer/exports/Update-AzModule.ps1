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

<#
    .Synopsis
        Update Azure PowerShell modules.

    .Description
        Update Azure PowerShell modules.
    .Example
        C:\PS> Update-AzModule -Repository PSGallery
    .Example
        C:\PS> Update-AzModule -Name desktopVirtualization,RecoveryServices -Repository PSGallery
#>
    [OutputType([PSCustomObject[]])]
    [CmdletBinding(DefaultParameterSetName = 'Default', PositionalBinding = $false, SupportsShouldProcess = $true)]
    param(
        [Parameter(HelpMessage = 'Az modules name to update. Can be the names without Az. prefix', Position = 0)]
        [string[]]
        ${Name},

        [Parameter(HelpMessage = 'The Registered Repository to install module from. If only one repository is registered in PowerShell, Update-AzModule will use it. If more than one, please specify the Repository.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Repository},

        [Parameter(HelpMessage = 'Scope to update modules. Default value is `CurrentUser` for all the Powershell platforms. Accepted values: CurrentUser, AllUser.')]
        [ValidateSet('CurrentUser', 'AllUsers')]
        [string]
        ${Scope},

        [Parameter(HelpMessage = 'Present to keep the previous versions of the modules.')]
        [switch]
        ${KeepPrevious},

        [Parameter(HelpMessage = 'Installs modules and overrides the confirmation messages of each step.')]
        [Switch]
        ${Force}
    )

    process {
        $cmdStarted = Get-Date
        $Invoker = $MyInvocation.MyCommand
        $ppsedition = $PSVersionTable.PSEdition
        Write-Debug "Powershell $ppsedition Version $($PSVersionTable.PSVersion)"
        $IsSuccess = $false
        $errorRecords = @()

        try {
            Write-Progress -Id $script:FixProgressBarId "Check currently installed Az modules."

            $Name = Normalize-ModuleName $Name
            $allInstalled = Get-AllAzModule
            if (!$allInstalled) {
                Write-Warning "[$Invoker] No Az modules are installled."
                $IsSuccess = $true
                return
            }

            $intersection = $allInstalled
            if ($Name) {
                $intersection = $intersection | Where-Object {$_.Name -eq "Az.Accounts" -or $Name -Contains $_.Name}
                $modulesNotInstalled = $Name | Where-Object {$allInstalled.Name -NotContains $_}
                if ($modulesNotInstalled) {
                    Write-Error "[$Invoker] $modulesNotInstalled are not installed. Please firstly install them before update."
                    #If Az.Accounts is in modulesNotInstalled，it will be warned but installed anyway.
                }
            }

            Write-Progress -Id $script:FixProgressBarId "Find modules on $Repository."

            $groupSet = @{}
            $group = $intersection | Group-Object -Property Name
            $group | Foreach-Object {$groupSet[$_.Name] = ($_.Group.Version | Sort-Object -Descending) }

            $findModuleParams = @{
                Name = $intersection.Name
                AllowPrerelease = $true
                Invoker = $Invoker
            }
            if ($Repository) {
                $findModuleParams.Add('Repository', $Repository)
            }
            $modulesToUpdate = Get-AzModuleFromRemote @findModuleParams
            if ($modulesToUpdate) {
                $Repository = $modulesToUpdate.Repository | Select-Object -First 1
            }

            $moduleUpdateTable = $modulesToUpdate | Foreach-Object { [PSCustomObject]@{
                Name = $_.Name
                VersionBeforeUpdate = [Version] ($groupSet[$_.Name] | Select-Object -First 1)
                VersionUpdate = [Version] $_.Version
            } }

            $modulesAlreadyLatest = @()
            $moduleUpdateTable = $moduleUpdateTable | Foreach-Object {
                if ($_.VersionUpdate -gt $_.VersionBeforeUpdate) {
                    $_
                }
                else {
                    $modulesAlreadyLatest += $_.Name
                }
            }
            if ($modulesAlreadyLatest) {
                Write-Debug "[$Invoker] $modulesAlreadyLatest are already in their latest version(s) with reference to $Repository.`n"
            }

            if ($Force -or $PSCmdlet.ShouldProcess('Remove Az if installed', 'Az', 'Remove')) {
                Uninstall-Module -Name 'Az' -AllVersion -ErrorAction 'SilentlyContinue'
            }

            if ($moduleUpdateTable) {
                Write-Debug "[$Invoker] Will update $($moduleUpdateTable.Name) to the latest version(s) on $Repository."

                if ($WhatIfPreference) {
                    $module = $null
                    foreach ($module in $moduleUpdateTable) {
                        Write-Host "WhatIf: Will update $($module.Name) from $($module.VersionBeforeUpdate) to $($module.VersionUpdate)."
                    }
                }
                else {
                    $moduleList = $moduleUpdateTable | ForEach-Object {
                        $m = New-Object ModuleInfo
                        $m.Name = $_.Name
                        $m.Version += [Version] $_.VersionUpdate
                        $m
                    }
                    $installModuleParams = @{
                        ModuleList = $moduleList
                        Repository = $Repository
                        AllowPrerelease = $true
                        Scope = if ($Scope) {$Scope} else {'CurrentUser'}
                        RemovePrevious = !$KeepPrevious
                        Force = $Force
                        Invoker = $Invoker
                    }
                    $output = Install-AzModuleInternal @installModuleParams

                    if ($output) {
                        $moduleUpdated  = $moduleUpdateTable | Where-Object {$output.Name.Contains($_.Name)}
                        Write-Output $moduleUpdated
                    }
                }
            }
            $IsSuccess = $true
        }
        catch
        {
            Write-Error $PSItem.ToString() -ErrorVariable +errorRecords
            throw $PSItem
        }
        finally {
            if ($errorRecords.Count -gt 0)
            {
                Send-PageViewTelemetry -SourcePSCmdlet $PSCmdlet `
                -IsSuccess $false `
                -StartDateTime $cmdStarted `
                -Duration ((Get-Date) - $cmdStarted)
            }
            else
            {
                Send-PageViewTelemetry -SourcePSCmdlet $PSCmdlet `
                -IsSuccess $IsSuccess `
                -StartDateTime $cmdStarted `
                -Duration ((Get-Date) - $cmdStarted)
            }
        }
    }
}
