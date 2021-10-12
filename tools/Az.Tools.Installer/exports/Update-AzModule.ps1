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
        Updates Azure PowerShell modules.

    .Description
        Updates Azure PowerShell modules.

    .Example
        C:\PS> Update-AzModule

        Version              Name                                Repository           Description
        -------              ----                                ----------           -----------
        1.4.0                Az.Automation                       PSGallery            Microsoft Azure PowerShell - Automation service…
        4.3.1                Az.Compute                          PSGallery            Microsoft Azure PowerShell - Compute service…
        1.10.0               Az.DataFactory                      PSGallery            Microsoft Azure PowerShell - Data Factory service…
        2.0.0                Az.DesktopVirtualization            PSGallery            Microsoft Azure PowerShell: DesktopVirtualization cmdlets
        3.5.0                Az.HDInsight                        PSGallery            Microsoft Azure PowerShell - HDInsight service…
        2.1.0                Az.KeyVault                         PSGallery            Microsoft Azure PowerShell - Key Vault service…
        1.1.0                Az.Maintenance                      PSGallery            Microsoft Azure PowerShell - Maintenance…
        1.1.0                Az.ManagedServices                  PSGallery            Microsoft Azure PowerShell - ManagedServices cmdlets for Azure Resource Manager
        2.1.0                Az.Monitor                          PSGallery            Microsoft Azure PowerShell - Monitor service…
        2.12.0               Az.RecoveryServices                 PSGallery            Microsoft Azure PowerShell - Recovery Services…
        2.5.0                Az.Resources                        PSGallery            Microsoft Azure PowerShell - Azure Resource Manager and Active Directory…
        1.2.0                Az.SignalR                          PSGallery            Microsoft Azure PowerShell - Azure SignalR service…
        2.5.0                Az.Storage                          PSGallery            Microsoft Azure PowerShell - Storage service…
        4.6.1                Az                                  PSGallery            Microsoft Azure PowerShell - Cmdlets to manage resources in Azure…


        C:\PS> Update-AzModule -Name DesktopVirtualization,RecoveryServices

        Version              Name                                Repository           Description
        -------              ----                                ----------           -----------
        2.0.0                Az.DesktopVirtualization            PSGallery            Microsoft Azure PowerShell: DesktopVirtualization cmdlets
        2.12.0               Az.RecoveryServices                 PSGallery            Microsoft Azure PowerShell - Recovery Services…

#>
    [OutputType([PSCustomObject[]])]
    [CmdletBinding(DefaultParameterSetName = 'Default', PositionalBinding = $false, SupportsShouldProcess = $true)]
    param(
        [Parameter(HelpMessage = 'The Registered Repostory.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Repository},

        [Parameter(HelpMessage = 'The module names.')]
        [string[]]
        ${Name},

        [Parameter(HelpMessage = 'Scope to update modules. Accepted values: CurrentUser, AllUser.')]
        [ValidateSet('CurrentUser', 'AllUsers')]
        [string]
        ${Scope},

        [Parameter(HelpMessage = 'Present to keep the previous versions of the modules.')]
        [switch]
        ${KeepPrevious},

        [Parameter(HelpMessage = 'Installs modules and overrides warning messages about module installation conflicts. If a module with the same name already exists on the computer, Force allows for multiple versions to be installed. If there is an existing module with the same name and version, Force overwrites that version.')]
        [Switch]
        ${Force}
    )

    process {
        $cmdStarted = Get-Date
        $Invoker = $MyInvocation.MyCommand
        $ppsedition = $PSVersionTable.PSEdition
        Write-Debug "Powershell $ppsedition Version $($PSVersionTable.PSVersion)"

        Write-Progress -Id $script:FixProgressBarId "Check currently installed Az modules."

        $Name = Normalize-ModuleName $Name
        $allInstalled = Get-AllAzModule
        if (!$allInstalled) {
            Write-Warning "[$Invoker] No Az modules are installled."
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

        $modulesToUpdate = Get-AzModuleFromRemote -Name $intersection.Name -Repository $Repository -AllowPrerelease:$true -Invoker $Invoker
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
            Uninstall-Module -Name 'Az' -AllVersion -ErrorAction SilentlyContinue
        }

        if ($moduleUpdateTable) {
            Write-Debug "[$Invoker] Will update $($moduleUpdateTable.Name) to the latest version(s) on $Repository."

            if ($WhatIfPreference) {
                $module = $null
                foreach($module in $moduleUpdateTable) {
                    Write-Host "WhatIf: Wiil update $($module.Name) from $($module.VersionBeforeUpdate) to $($module.VersionUpdate)."
                }
            }
            else {
                $installModuleParams = @{}
                foreach ($key in $PSBoundParameters.Keys) {
                    if($key -ne 'Name'){
                        $installModuleParams.Add($key, $PSBoundParameters[$key])
                    }
                }
                $installModuleParams.Add('AllowPrerelease', $true)
                $installModuleParams.Add('Invoker', $Invoker)
                $installModuleParams.Add('RemovePrevious', !$KeepPrevious)
                if (!$installModuleParams.Contains('Scope')) {
                    $installModuleParams.Add('Scope', 'CurrentUser')
                }
                $modules = $moduleUpdateTable | Foreach-Object {
                    $m = New-Object ModuleInfo
                    $m.Name = $_.Name
                    $m.Version += [Version] $_.VersionUpdate
                    $m
                }
                $installModuleParams.Add('ModuleList', $modules)
                $output = Install-AzModuleInternal @installModuleParams

                if ($output) {
                    $moduleUpdated  = $moduleUpdateTable | Where-Object {$output.Name.Contains($_.Name)}
                    Write-Output $moduleUpdated
                }
            }
        }

        <#
        Send-PageViewTelemetry -SourcePSCmdlet $PSCmdlet `
        -IsSuccess $true `
        -StartDateTime $cmdStarted `
        -Duration $Duration
        #>
    }
}
