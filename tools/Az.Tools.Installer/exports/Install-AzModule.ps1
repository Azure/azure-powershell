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
        C:\PS> Install-AzModule -Name Storage,Compute,Network -Repository PSGallery

#>

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
        $module = @{}
        $result = @()
        $find = @()
        $max_job_count = 5

        if ($PSBoundParameters.ContainsKey('Name')) {
            $Name = $Name.Foreach({"Az." + $_})
            $Name | Foreach-Object {
                if ($_ -ne 'Az.Accounts') {
                    $module_name += $_
                }
            }
        }

        if ($PSCmdlet.ParameterSetName -eq 'WithoutPreview') {
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
            
            $count = 0
            $module_name | Foreach-Object {
                if (!$index.ContainsKey($_)) {
                    Write-Warning "module $_ will not be installed because it is not a GAed Az module in Az $version, please try add -AllowPrerelease option."
                    $count += 1
                } else {
                    $module.Add($_, $index[$_])
                }
            }
            
            #validate input module names
            if ($count -eq $module_name.Count) {
                return
            }

        } else {
            #With preview
            Write-Warning "This cmdlet will not install preview version for Az.Accounts."

            # all latest modules
            $all = @()
            try {
                Find-Module -Name 'Az.*' -Repository $Repository | ForEach-Object {
                    if (($_.Author -eq $author) -and ($_.CompanyName -eq $company_name) -and ($_.Name -ne 'Az.Accounts') -and (!$_.Name.StartsWith('Az.Tools'))) {
                        $all += $_.Name
                    }
                }
            } catch {
                Write-Error $_
                break
            }
            
            #validate input module names
            if ($PSBoundParameters.ContainsKey('Name')) {
                $count = 0
                $module_name | Foreach-Object {
                    if (!$all.Contains($_)) {
                        Write-Warning "module $_ will not be installed because it is not a valid Az module."
                        $count += 1
                    }
                }
                if ($count -eq $module_name.Count) {
                    return
                }
            } else {
                $all | Foreach-Object {
                    $module_name += $_
                }
            }

            $module_name | Foreach-Object {
                $running = Get-Job -State 'Running'
                if ($running.Count -eq $max_job_count) {
                    $null = ($running | Wait-Job -Any)
                }

                Get-Job | Where-Object {$_.State -eq 'Completed'} | Foreach-Object {
                    $find += Receive-Job $_
                    Remove-Job $_
                }

                $null = Start-Job {
                    Find-Module -Name $using:_ -Repository $using:Repository -AllowPrerelease
                }
            }

            while (Get-Job -State 'Running') {
                $null = Get-Job | Wait-Job
            }
    
            Get-Job | Foreach-Object {
                $find += Receive-Job $_
                Remove-Job $_
            }

            $find | Foreach-Object {
                $module.Add($_.Name, $_.Version)
            }
        }

        if ($RemoveAzureRm -and ($PSCmdlet.ShouldProcess('Remove AzureRm modules', 'AzureRm modules', 'Remove'))) {
            try {
                $azureModuleNames = (Get-InstalledModule -Name Azure* -ErrorAction Stop).Name | Where-Object {$_ -match "Azure(\.[a-zA-Z0-9]+)?$" -or $_ -match "AzureRM(\.[a-zA-Z0-9]+)?$"}
                foreach($azureModuleName in $azureModuleNames) {
                    Uninstall-Module -Name $azureModuleName -AllVersion -ErrorAction SilentlyContinue
                }
            }
            catch {
                Write-Warning $_
            }
        }

        #install Az.Accounts first
        $parameter = @{}
        $parameter.Add('Repository', $Repository)
        $parameter.Add('AllowClobber', $true)
        $parameter.Add('SkipPublisherCheck', $SkipPublisherCheck)
        $parameter.Add('Name', 'Az.Accounts')
        if ($module.ContainsKey('Az.Accounts')) {
            $parameter.Add('RequiredVersion', $module['Az.Accounts'])
            $module.Remove('Az.Accounts')
        }
        if ($RemovePrevious) {
            Uninstall-Module -Name Az.Accounts -AllVersion -ErrorAction SilentlyContinue
        }
        Install-Module @parameter

        $module.Keys | Foreach-Object {
            $name = $_
            $version = $module[$_]
            $parameter = @{'Name' = $name}
            if ($version -ne $null) {
                $parameter.Add('RequiredVersion', $version)
            }
            $parameter.Add('Repository', $Repository)
            $parameter.Add('AllowClobber', $true)
            $parameter.Add('SkipPublisherCheck', $SkipPublisherCheck)
            $parameter.Add('AllowPrerelease', $AllowPrerelease)

            $running = Get-Job -State 'Running'
            if ($running.Count -eq $max_job_count) {
                $null = ($running | Wait-Job -Any)
            }

            Get-Job -State 'Completed' | Foreach-Object {
                $result += Receive-Job $_
                Remove-Job $_ -Confirm:$false
            }

            if ($PSCmdlet.ShouldProcess("Install $name $version", "$name $version", "Install")) {
                Write-Debug "Install $name $version"
                $null = Start-Job {
                    if ($using:RemovePrevious) {
                        Uninstall-Module -Name $using:name -AllVersion -ErrorAction SilentlyContinue
                    }
                    Install-Module @using:parameter
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