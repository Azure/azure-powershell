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
    [OutputType([System.Collections.Hashtable])]
    [CmdletBinding(DefaultParameterSetName = 'All', PositionalBinding = $false, SupportsShouldProcess)]
    param(
        [Parameter(ParameterSetName = 'All',HelpMessage = 'Maximum Az Version.')]
        [Parameter(ParameterSetName = 'ByName',HelpMessage = 'Maximum Az Version.')]
        [ValidateNotNullOrEmpty()]
        [String]
        ${MaximumVersion},

        [Parameter(ParameterSetName = 'All',HelpMessage = 'Minimum Az Version.')]
        [Parameter(ParameterSetName = 'ByName',HelpMessage = 'Minimum Az Version.')]
        [ValidateNotNullOrEmpty()]
        [String]
        ${MinimumVersion},

        [Parameter(ParameterSetName = 'All',HelpMessage = 'Required Az Version.')]
        [Parameter(ParameterSetName = 'ByName',HelpMessage = 'Required Az Version.')]
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

        [Parameter(HelpMessage = 'Remove corresponding AzureRm modules.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${RemoveAzureRm},

        [Parameter(HelpMessage = 'Installs modules and overrides warning messages about module installation conflicts. If a module with the same name already exists on the computer, Force allows for multiple versions to be installed. If there is an existing module with the same name and version, Force overwrites that version.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${Force},

        [Parameter(ParameterSetName = 'AllAndPreview', Mandatory, HelpMessage = 'Allow preview modules to be installed.')]
        [Parameter(ParameterSetName = 'ByNameAndPreview', Mandatory, HelpMessage = 'Allow preview modules to be installed.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${AllowPrerelease},

        [Parameter(ParameterSetName = 'ByName', Mandatory, HelpMessage = 'Az modules to install.')]
        [Parameter(ParameterSetName = 'ByNameAndPreview', Mandatory, HelpMessage = 'Az modules to install.')]
        [ValidateNotNullOrEmpty()]
        [String[]]
        ${Name}
    )

    process {

        $author = 'Microsoft Corporation'
        $company_name = 'azure-sdk'

        if (!$PSBoundParameters.ContainsKey('Force')) {
            $confirmation = Read-Host "You are installing the modules from an untrusted repository. If you trust this repository, change its InstallationPolicy value by running the `nSet-PSRepository cmdlet. Are you sure you want to install the modules from 'PSGallery'?`n[Y] Yes  [N] No  (default is `"N`")"

            switch ($confirmation) {
                'Y' {
                    $PSBoundParameters.Add('Force', $true)
                }

                'N' {
                    Return
                }
            }
        }

        $module_name = @()
        $version = @{}
        $module = @()
        $latest = ''

        if ($PSBoundParameters.ContainsKey('Name')) {
            $PSBoundParameters['Name'] | Foreach-Object {
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

        if (($PSCmdlet.ParameterSetName -eq 'ByName') -or ($PSCmdlet.ParameterSetName -eq 'All')) {
         
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
                Write-Error $_
                break
            }
            

            if ($PSCmdlet.ParameterSetName -eq 'All') {
                #Install Az package
                $index.Keys | Foreach-Object {$module += ([PSCustomObject] @{'Name'=$_; 'Version'=$index[$_]})}
            } elseif ($PSCmdlet.ParameterSetName -eq 'ByName') {
                #Install Az modules by name
                $module_name | Foreach-Object {$module += ([PSCustomObject] @{'Name'=$_; 'Version'=$index[$_]})}
            }

        } else {
            
            #With preview
            Write-Warning 'Please use `Install-Module -Name Az.Accounts -AllowPrerelease` to install preview version for Az.Accounts'

            $latest = ' latest'

            if ($PSCmdlet.ParameterSetName -eq 'AllAndPreview') {

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
            
            $module_name | Foreach-Object {$module += ([PSCustomObject] @{'Name'=$_})}
        }
        
        if ($PSBoundParameters.ContainsKey('RemoveAzureRm') -and $PSCmdlet.ShouldProcess('Remove AzureRm modules', 'AzureRm modules', 'Remove')) {
            remove_installed_module -Name 'AzureRm*'
            remove_installed_module -Name 'Azure.*'
        }

        if ($PSBoundParameters.ContainsKey('RemovePrevious')) {
            $module | Foreach-Object {
                $name = $_.Name
                if ($PSCmdlet.ShouldProcess("Remove all previous versions of $name", "$name", "Remove")) {
                    Write-Output $_
                }
            } | remove_installed_module
        }

        $module | Foreach-Object {
            $name = $_.Name
            $version = $_.version
            if ($PSCmdlet.ShouldProcess("Install$latest $name $version", "$latest $name $version", "Install")) {
                Write-Debug "Install$latest $name $version"
                Write-Output $_
            }
        } | Install-Module -Repository $Repository -AllowClobber -Force -AllowPrerelease
    }
}