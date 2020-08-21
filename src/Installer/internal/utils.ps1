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

function Get-AzModuleMapping{
    [OutputType([Hashtable])]
    [CmdletBinding()]
    param(
        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [String]
        ${RequiredVersion},

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [String]
        ${MaximumVersion},

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [String]
        ${MinimumVersion},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [String]
        ${Repository}
    )
    
    process {

        $map = @{}

        $PSBoundParameters.Add('Name', 'Az')
        $cmd = Get-CommandAsString -Base 'Find-Module' -BoundParameter $PSBoundParameters

        (Invoke-Expression $cmd[0]).Dependencies | Foreach-Object {$map.Add($_.Name, $_)}
        return $map
    }
}

function Get-LatestVersion{
    [OutputType([String])]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [String]
        ${Repository},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [String]
        ${Name},

        [Parameter()]
        [Switch]
        ${AllowPrerelease}
    )

    $PSBoundParameters.Add('AllVersion', $true)
    $cmd = Get-CommandAsString -Base 'Find-Module' -BoundParameter $PSBoundParameters

    $version = @()
    Invoke-Expression $cmd[0] | ForEach-Object {
        $version += $_.Version
    }


    $latest = (($version -eq $null) -or ($version.Length -eq 0)) ? $null : $version[0]

    $version | Foreach-Object {
        if ((Compare-Version -Str1 $_ -Str2 $latest) -gt 0) {
            $latest = $_
        }
    }

    return $latest
}

function Compare-Version{
    [OutputType([Int])]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [String]
        ${Str1},

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [String]
        ${Str2}
    )
    #return 1 if Str1>Str2
    #return 0 if Str1==Str2
    #return -1 if Str1<Str2
}

function Get-AllModule{
    [OutputType([string[]])]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [String]
        ${Repository}
    )

    process {
        $prefix = 'Microsoft Azure PowerShell'
        $all = @()

        $PSBoundParameters.Add('Name', 'Az.*')
        $cmd = Get-CommandAsString -Base 'Find-Module' -BoundParameter $PSBoundParameters

        Invoke-Expression $cmd[0] | ForEach-Object {
            if ($_.Description.StartsWith($prefix)) {
                $all += $_.Name
            }
        }

        return $all
    }

}

function Get-DependencyMapping{
    [OutputType([Hashtable])]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${Repository}


    )



}

function Test-FullModuleName{
    [OutputType([bool])]
    [CmdletBinding(DefaultParameterSetName = 'Default', PositionalBinding = $false)]
    param(
        [Parameter(ParameterSetName = 'Default', Mandatory)]
        [ValidateNotNullOrEmpty()]
        [System.Array]
        ${Name}
    )

    process{
        return $Name.StartsWith('Az.')
    }
}

function Get-CommandAsString{
    [OutputType([String[]])]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [String]
        ${Base},

        [ValidateNotNullOrEmpty()]
        [System.Management.Automation.PSBoundParametersDictionary]
        ${BoundParameter},

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [HashTable]
        ${Index}
    )

    $cmdlist = @()
    $cmd = $Base
    
    if ($PSBoundParameters.ContainsKey($BoundParameter)) {
        $BoundParameter.Keys | Foreach-Object {
            $parameter = ''
    
            if ($BoundParameter[$_].GetType().Name -eq 'Boolean') {
                $parameter = Get-ParameterAsString -Key $_
            } else {
                $parameter = Get-ParameterAsString -Key $_ -Val $BoundParameter[$_]         
            }
            
            $cmd += $parameter
        }
    }

    if ($PSBoundParameters.ContainsKey($Index)) {
        $Index.Keys | Foreach-Object {
            $parameter = ''
            $parameter += Get-ParameterAsString -Key 'Name' -Val $_
            $parameter += Get-ParameterAsString -Key 'RequiredVersion' -Val $Index[$_]
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

    if ($PSBoundParameters.ContainsKey($Key)) {
        $param += ' -' + $Key
    }

    if ($PSBoundParameters.ContainsKey($Val)) {
        $param += ' ' + $Val
    }

    return $param
}