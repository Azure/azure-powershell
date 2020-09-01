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

function Get-CommandAsString{
    [OutputType([String[]])]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [String]
        ${Base},

        [ValidateNotNullOrEmpty()]
        [HashTable]
        ${BoundParameter},

        [Parameter()]
        [HashTable]
        ${Index}
    )

    $cmdlist = @()
    $cmd = $Base
    
    if ($PSBoundParameters.ContainsKey('BoundParameter')) {
        $BoundParameter.Keys | Foreach-Object {
            $parameter = ''
            if (($BoundParameter[$_].GetType().Name -eq 'Boolean') -or ($BoundParameter[$_].GetType().Name -eq 'SwitchParameter')) {
                if ($BoundParameter[$_] -eq $true) {
                    $parameter = Get-ParameterAsString -Key $_
                }
            } else {
                $parameter = Get-ParameterAsString -Key $_ -Val $BoundParameter[$_]         
            }
            
            $cmd += $parameter
        }
    }

    if ($PSBoundParameters.ContainsKey('Index')) {
        $Index.Keys | Foreach-Object {
            $parameter = ''
            $parameter += Get-ParameterAsString -Key 'Name' -Val $_
            if ($Index[$_] -ne $null) {
                $parameter += Get-ParameterAsString -Key 'RequiredVersion' -Val $Index[$_]
            }
            $cmdlist += $cmd + $parameter
        }
    } else {
        $cmdlist += $cmd
    }

    return $cmdlist
}

function Get-ParameterAsString{
    [OutputType([String])]
    [CmdletBinding()]
    param(
        [String]
        ${Key},

        [String]
        ${Val}
    )

    $param = ''

    if (($PSBoundParameters.ContainsKey('Key')) -and ($Key.Length -gt 0)) {
        $param += ' -' + $Key
    }

    if (($PSBoundParameters.ContainsKey('Val')) -and ($Val.Length -gt 0)) {
        $param += ' ' + $Val
    }

    return $param
}

function remove_installed_module {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, 
        ValueFromPipelineByPropertyName = $true,
        ValueFromPipeline = $true)]
        [ValidateNotNullOrEmpty()]
        [String]
        ${Name}
    )

    process {
        Get-InstalledModule -Name $Name -ErrorAction SilentlyContinue | Foreach-Object {
            $name = $_.Name
            Write-Debug "Remove all previous versions of Module: $name"
            $_ | Uninstall-Module -AllVersions -AllowPrerelease
        } #| Uninstall-Module -AllVersions -AllowPrerelease
    }
}