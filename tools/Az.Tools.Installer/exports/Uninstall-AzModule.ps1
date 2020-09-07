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
    [OutputType()]
    [CmdletBinding(DefaultParameterSetName = 'WithoutPreview', PositionalBinding = $false, SupportsShouldProcess = $true)]
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

        Import-Module "$PSScriptRoot\..\internal\utils.psm1"

        $author = 'Microsoft Corporation'
        $company_name = 'azure-sdk'

        [System.Collections.ArrayList]$module_name = @()
        $version = @{}
        $module = @{}
        $job = @()
        $result = @()
        $latest = ''
        $max_job_count = 15

        if ($PSBoundParameters.ContainsKey('Name')) {
            $Name = FullAzName -Name $Name
            $Name | Foreach-Object {
                $module_name += $_
            }
        }

        if ($PSBoundParameters.ContainsKey('MaximumVersion')) {
            $version.Add('MaximumVersion', $PSBoundParameters['MaximumVersion'])
        }

        if ($PSBoundParameters.ContainsKey('MinimumVersion')) {
            $version.Add('MinimumVersion', $PSBoundParameters['MinimumVersion'])
        }

        if ($PSBoundParameters.ContainsKey('RequiredVersion')) {
            $version.Add('RequiredVersion', $PSBoundParameters['RequiredVersion'])
        }

        if (!$PSBoundParameters.ContainsKey("AllowPrerelease")) {

            #Without preview
            $parameter = @{}
            $parameter.Add('Repository', $Repository)
            $parameter.Add('Name', 'Az')
            $parameter.Add('ErrorAction', 'Stop')
            $index = @{}         
            $version.Keys | Foreach-Object {$parameter.Add($_, $version[$_])}

            try {
                $az = Find-Module @parameter
            } catch {
                Write-Error "No related Az modules were found in $Repository, $_"
                break
            }

            $version = $az.Version
            $az.Dependencies | Foreach-Object {
                if ($_.Name -ne 'Az.Accounts') {
                    $index.Add($_.Name, $_.RequiredVersion)
                } else {
                    $index.Add($_.Name, $_.MinimumVersion)
                }
                if (!$PSBoundParameters.ContainsKey('Name')) {
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
                try {
                    Get-InstalledModule -Name 'Az.*' | ForEach-Object {
                        if (($_.Author -eq $author) -and ($_.CompanyName -eq $company_name)) {
                            $module_name += $_.Name
                        }
                    }
                } catch {
                    Write-Error "Nothing to delete, no Az modules found: $_"
                    break
                }
            }

            $remove = @()
            $module_name | Where-Object {$_.StartsWith('Az.Tools')} | Foreach-Object {$remove += $_}
            $remove | Foreach-Object {$module_name.Remove($_)}
            $module_name | Foreach-Object {$module.Add($_, '')}
        }

        if ($PSBoundParameters.ContainsKey('RemoveAzureRm') -and ($PSCmdlet.ShouldProcess('Remove AzureRm modules', 'AzureRm modules', 'Remove'))) {
            remove_installed_module -Name 'AzureRm*' -AllVersion
            remove_installed_module -Name 'Azure.*' -AllVersion
        }

        $module.Keys | Foreach-Object {
            $version = $module[$_]

            if ((Get-Job -State 'Running').Count -eq $max_job_count) {
                $null = ($job | Wait-Job -Any)
            }

            if ($PSCmdlet.ShouldProcess("Uninstall$latest $_ $version", "$latest $_ $version", "Uninstall")) {
                Write-Debug "Uninstall$latest $_ $version"
                $parameter = @{'Name' = $_}
                $parameter.Add('ErrorAction', 'SilentlyContinue')
                if ($PSBoundParameters.ContainsKey('AllVersion')) {
                    $parameter.Add('AllVersion', $AllVersion)
                    if ($PSCmdlet.ParameterSetName -eq 'WithPreviewAndAllVersion') {
                        $parameter.Add('AllowPrerelease', $AllowPrerelease)
                    }
                } elseif ($PSCmdlet.ParameterSetName -eq 'WithPreview') {
                    parameter.Add('AllowPrerelease', $AllowPrerelease)
                } elseif ($PSCmdlet.ParameterSetName -eq 'WithoutPreview') {
                    $parameter.Add('RequiredVersion', $version)
                }
                $job += Start-Job {
                    Uninstall-Module @using:parameter
                }
            }
        }

        while ($job.State -eq 'Running') {
            $null = $job | Wait-Job
        }

        $job | Foreach-Object {
            $result += Receive-Job $_
            Remove-Job $_
        }

        Send-PageViewTelemetry -SourcePSCmdlet $PSCmdlet `
            -IsSuccess $true `
            -StartDateTime $cmdStarted `
            -Duration ((Get-Date) - $cmdStarted)
    }
}