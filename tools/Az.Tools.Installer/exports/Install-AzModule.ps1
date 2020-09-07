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

function Install-AzModule{
    [OutputType()]
    [CmdletBinding(DefaultParameterSetName = 'WithoutPreview', 
    PositionalBinding = $false, 
    SupportsShouldProcess)]
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

        [Parameter(Mandatory, HelpMessage = 'The Registered Repostory.')]
        [ValidateNotNullOrEmpty()]
        [String]
        ${Repository},

        [Parameter(HelpMessage = 'Remove given module installed previously.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${RemovePrevious},

        [Parameter(HelpMessage = 'Remove all AzureRm modules.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${RemoveAzureRm},

        [Parameter(HelpMessage = 'Installs modules and overrides warning messages about module installation conflicts. If a module with the same name already exists on the computer, Force allows for multiple versions to be installed. If there is an existing module with the same name and version, Force overwrites that version.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${Force},

        [Parameter(ParameterSetName = 'WithPreview', Mandatory, HelpMessage = 'Allow preview modules to be installed.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${AllowPrerelease},

        [Parameter(HelpMessage = 'Az modules to install.', ValueFromPipelineByPropertyName = $true)]
        [ValidateNotNullOrEmpty()]
        [String[]]
        ${Name},

        [Parameter(HelpMessage = 'Skip publisher check.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${SkipPublisherCheck}
    )

    process {

        $cmdStarted = Get-Date

        Import-Module "$PSScriptRoot\..\internal\utils.psm1"

        $author = 'Microsoft Corporation'
        $company_name = 'azure-sdk'

        If ((Get-PSRepository -Name $Repository).InstallationPolicy -ne 'Trusted' -and !$PSBoundParameters.ContainsKey('Force')) {
            $confirmation = Read-Host "You are installing the modules from an untrusted repository. If you trust this repository, change its InstallationPolicy value by running the `nSet-PSRepository cmdlet. Are you sure you want to install the modules from"$Repository"?`n[Y] Yes  [N] No  (default is `"N`")"
            switch ($confirmation) {
                'Y' {
                    $PSBoundParameters.Add('Force', $true)
                }

                'N' {
                    Return
                }
            }
        }

        [System.Collections.ArrayList]$module_name = @()
        $version = @{}
        $module = @()
        $latest = ''
        $skip_publisher_check = $false
        $allow_prerelease = $false

        if ($PSBoundParameters.ContainsKey('Name')) {
            $Name = FullAzName -Name $Name
            $Name | Foreach-Object {
                if ($_ -ne 'Az.Accounts') {
                    $module_name += $_
                }
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

        if ($PSBoundParameters.ContainsKey('SkipPublisherCheck')) {
            $skip_publisher_check = $SkipPublisherCheck
        }

        if ($PSBoundParameters.ContainsKey('AllowPrerelease')) {
            $allow_prerelease = $AllowPrerelease
        }

        if ($PSCmdlet.ParameterSetName -eq 'WithoutPreview') {
         
            #Without preview
            $parameter = @{}
            $parameter.Add('Repository', $Repository)
            $parameter.Add('Name', 'Az')
            $parameter.Add('ErrorAction', 'Stop')
            $index = @{}         
            $version.Keys | Foreach-Object {$parameter.Add($_, $version[$_])}
            $cmd = Get-CommandAsString -Base 'Find-Module' -BoundParameter $parameter

            try {
                (Invoke-Expression -Command $cmd).Dependencies | Foreach-Object {
                    if ($_.Name -ne 'Az.Accounts') {
                        $index.Add($_.Name, $_.RequiredVersion)
                    }
                }
            } catch {
                Write-Error "No related Az modules were found in $Repository"
                break
            }
            
            if (!$PSBoundParameters.ContainsKey('Name')) {
                #Install Az package
                $index.Keys | Foreach-Object {$module += ([PSCustomObject] @{'Name'=$_; 'Version'=$index[$_]})}
            } else {
                #Install Az modules by name
                $module_name | Foreach-Object {
                    if (!$index.ContainsKey($_)) {
                        Write-Warning "module $_ will not be installed since it is not a GAed Az module, please try add -AllowPrerelease option."
                    } else {
                        $module += ([PSCustomObject] @{'Name'=$_; 'Version'=$index[$_]})
                    }
                }
            }

        } else {
            
            #With preview
            Write-Warning "this cmdlet will not install preview version for Az.Accounts."

            $latest = ' latest version of'

            if (!$PSBoundParameters.ContainsKey('Name')) {

                # all latest modules
                try {
                    Find-Module -Name 'Az.*' -Repository $Repository | ForEach-Object {
                        if (($_.Author -eq $author) -and ($_.CompanyName -eq $company_name) -and ($_.Name -ne 'Az.Accounts')) {
                            $module_name += $_.Name
                        }
                    }
                } catch {
                    Write-Error $_
                    break
                }
            }

            $remove = @()
            $module_name | Where-Object {$_.StartsWith('Az.Tools')} | Foreach-Object {$remove += $_}
            $remove | Foreach-Object {$module_name.Remove($_)}
            $module_name | Foreach-Object {$module += ([PSCustomObject] @{'Name'=$_})}
        }

        if ($PSBoundParameters.ContainsKey('RemoveAzureRm') -and ($PSCmdlet.ShouldProcess('Remove AzureRm modules', 'AzureRm modules', 'Remove'))) {
            remove_installed_module -Name 'AzureRm*' -AllVersion
            remove_installed_module -Name 'Azure.*' -AllVersion
        }

        if ($PSBoundParameters.ContainsKey('RemovePrevious')) {
            $module | Foreach-Object {
                $name = $_.Name
                if ($PSCmdlet.ShouldProcess("Remove all previous versions of $name", "All previous $name", "Remove")) {
                    $_ | remove_installed_module -AllVersion
                }
            }
        }

        $module | Foreach-Object {
            $name = $_.Name
            $version = $_.version
            if ($PSCmdlet.ShouldProcess("Install$latest $name $version", "$latest $name $version", "Install")) {
                Write-Debug "Install$latest $name $version"
                $_ | Install-Module -Repository $Repository -AllowClobber -Force -AllowPrerelease:$allow_prerelease -SkipPublisherCheck:$skip_publisher_check
            }
        }

        Send-PageViewTelemetry -SourcePSCmdlet $PSCmdlet `
            -IsSuccess $true `
            -StartDateTime $cmdStarted `
            -Duration ((Get-Date) - $cmdStarted)
    }
}