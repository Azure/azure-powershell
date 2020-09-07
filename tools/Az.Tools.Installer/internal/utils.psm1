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

function remove_installed_module {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, 
        ValueFromPipelineByPropertyName = $true,
        ValueFromPipeline = $true)]
        [ValidateNotNullOrEmpty()]
        [String]
        ${Name},

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${AllVersion},

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [String]
        ${RequiredVersion}
    )

    process {
        Get-InstalledModule -Name $Name -ErrorAction SilentlyContinue | Foreach-Object {
            $name = $_.Name
            $version = $_.Version
            $parameter = @{'AllowPrerelease' = $true}
            if ($PSBoundParameters.ContainsKey('AllVersion')) {
                Write-Debug "Remove all versions of Module: $name"
                $parameter.Add('AllVersion', $AllVersion)
            } elseif ($PSBoundParameters.ContainsKey('RequiredVersion')) {
                Write-Debug "Remove Module: $name $version"
                $parameter.Add('RequiredVersion', $version)
            } else {
                Write-Debug "Remove Module: $name $version"
            }
            $_ | Uninstall-Module @parameter
        }
    }
}

function Get-FullAzName {
    [OutputType([String[]])]
    [CmdletBinding()]
    param(
        [String[]]
        ${Name}
    )

    $output = @()
    $Name | Foreach-Object {$output += "Az.$_"}
    
    Write-Output $output
}