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
    [CmdletBinding(DefaultParameterSetName = 'RemoveAll', PositionalBinding = $false, SupportsShouldProcess = $true)]
    param(
        [Parameter(ParameterSetName = 'WithoutPreview',HelpMessage = 'Maximum Az Version.')]
        [ValidateNotNullOrEmpty()]
        [String]
        ${MaximumVersion},

        [Parameter(ParameterSetName = 'WithoutPreview',HelpMessage = 'Minimum Az Version.')]
        [ValidateNotNullOrEmpty()]
        [String]
        ${MinimumVersion},

        [Parameter(ParameterSetName = 'WithoutPreview',HelpMessage = 'Required Az Version.')]
        [ValidateNotNullOrEmpty()]
        [String]
        ${RequiredVersion},

        [Parameter(HelpMessage = 'Remove all AzureRm modules.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${RemoveAzureRm},

        [Parameter(HelpMessage = 'Installs modules and overrides warning messages about module installation conflicts. If a module with the same name already exists on the computer, Force allows for multiple versions to be installed. If there is an existing module with the same name and version, Force overwrites that version.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${Force},

        [Parameter(ParameterSetName = 'WithPreview', Mandatory, HelpMessage = 'Allow preview modules to be installed.')]
        [Parameter(ParameterSetName = 'WithPreviewAndAllVersion', Mandatory, HelpMessage = 'Allow preview modules to be installed.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${AllowPrerelease},

        [Parameter(HelpMessage = 'Az modules to install.', ValueFromPipelineByPropertyName = $true)]
        [ValidateNotNullOrEmpty()]
        [String[]]
        ${Name},

        [Parameter(ParameterSetName = 'WithPreviewAndAllVersion', Mandatory, HelpMessage = 'Remove all versions')]
        [Parameter(ParameterSetName = 'WithoutPreviewAndAllVersion', Mandatory, HelpMessage = 'Remove all versions')]
        [Switch]
        ${AllVersion},

        [Parameter(ParameterSetName = 'WithoutPreview', Mandatory, HelpMessage = 'The Registered Repostory.')]
        [Parameter(ParameterSetName = 'WithoutPreviewAndAllVersion', Mandatory, HelpMessage = 'The Registered Repostory.')]
        [ValidateNotNullOrEmpty()]
        [String]
        ${Repository}
    )

    process {

        $cmdStarted = Get-Date

        $author = 'Microsoft Corporation'
        $company_name = 'azure-sdk'

        [System.Collections.ArrayList]$module_name = @()
        $module = @{}
        $result = @()
        $installed = @()
        $latest = ''
        $max_job_count = 5

        if ($PSBoundParameters.ContainsKey('Name')) {
            $Name = $Name.Foreach({"Az." + $_})
            $Name | Foreach-Object {
                $module_name += $_
            }
        }

        
        try {
            $installed = Get-InstalledModule -Name 'Az.*','Az' -ErrorAction SilentlyContinue
        } catch {
            
        }

        if (!$PSBoundParameters.ContainsKey("AllowPrerelease") -and ($PSCmdlet.ParameterSetName -ne 'RemoveAll')) {

            #Without preview
            $parameter = @{}
            $parameter.Add('Repository', $Repository)
            $parameter.Add('Name', 'Az')
            $parameter.Add('ErrorAction', 'Stop')
            $index = @{}         
            if ($PSBoundParameters.ContainsKey('MaximumVersion')) {
                $parameter.Add('MaximumVersion', $MaximumVersion)
            }
    
            if ($PSBoundParameters.ContainsKey('MinimumVersion')) {
                $parameter.Add('MinimumVersion', $MinimumVersion)
            }
    
            if ($PSBoundParameters.ContainsKey('RequiredVersion')) {
                $parameter.Add('RequiredVersion', $RequiredVersion)
            }

            try {
                $az = Find-Module @parameter
            } catch {
                Write-Error "No related Az modules were found in $Repository, $_"
                break
            }

            $installed_name = ($installed | Foreach-Object{$_.Name})

            $version = $az.Version
            $az.Dependencies | Foreach-Object {
                if ($_.Name -ne 'Az.Accounts') {
                    $index.Add($_.Name, $_.RequiredVersion)
                } else {
                    $index.Add($_.Name, $_.MinimumVersion)
                }
                if (!$PSBoundParameters.ContainsKey('Name') -and ($installed_name -contains $_.Name)) {
                    $module_name += $_.Name
                }
            }

            #Uninstall Az modules by name
            $module_name | Foreach-Object {
                if (!$index.ContainsKey($_)) {
                    Write-Warning "module $_ will not be uninstalled since it is not a GAed Az module in Az $version, please try adding -AllowPrerelease option."
                } else {
                    $module.Add($_, $index[$_])
                }
            }

        } else {
            
            #With preview
            $latest = ' latest version of'

            if (!$PSBoundParameters.ContainsKey('Name')) {
                # all latest modules
                $installed | ForEach-Object {
                    if (($_.Author -eq $author) -and ($_.CompanyName -eq $company_name) -and (!$_.Name.StartsWith('Az.Tools'))) {
                        $module_name += $_.Name
                    }
                }
            }

            $module_name | Foreach-Object {$module.Add($_, '')}
        }

        if ($PSBoundParameters.ContainsKey('RemoveAzureRm') -and ($PSCmdlet.ShouldProcess('Remove AzureRm modules', 'AzureRm modules', 'Remove'))) {
            Uninstall-Module -Name 'AzureRm*' -AllVersion -ErrorAction SilentlyContinue
            Uninstall-Module -Name 'Azure.*' -AllVersion -ErrorAction SilentlyContinue
        }

        $module.Keys | Foreach-Object {
            $version = $module[$_]

            $running = Get-Job -State 'Running'
            if ($running.Count -eq $max_job_count) {
                $null = ($running | Wait-Job -Any)
            }

            Get-Job -State 'Completed' | Foreach-Object {
                $result += Receive-Job $_
                Remove-Job $_ -Confirm:$false
            }

            if ($PSCmdlet.ShouldProcess("Uninstall$latest $_ $version", "$latest $_ $version", "Uninstall")) {
                Write-Debug "Uninstall$latest $_ $version"
                $parameter = @{'Name' = $_}
                $parameter.Add('ErrorAction', 'SilentlyContinue')
                if ($PSBoundParameters.ContainsKey('AllVersion')) {
                    $parameter.Add('AllVersion', $AllVersion)
                } elseif ($PSCmdlet.ParameterSetName -eq 'WithPreview') {
                    $parameter.Add('AllowPrerelease', $AllowPrerelease)
                } elseif ($PSCmdlet.ParameterSetName -eq 'WithoutPreview') {
                    $parameter.Add('RequiredVersion', $version)
                } else {
                    $parameter.Add('AllVersion', $AllVersion)
                    $parameter.Add('AllowPrerelease', $AllowPrerelease)
                }
                $null = Start-Job {
                    Uninstall-Module @using:parameter
                }
            }
        }

        $null = Get-Job | Wait-Job
        Get-Job | Foreach-Object {
            $result += Receive-Job $_
            Remove-Job $_ -Confirm:$false
        }

        Send-PageViewTelemetry -SourcePSCmdlet $PSCmdlet `
            -IsSuccess $true `
            -StartDateTime $cmdStarted `
            -Duration ((Get-Date) - $cmdStarted)
    }
}