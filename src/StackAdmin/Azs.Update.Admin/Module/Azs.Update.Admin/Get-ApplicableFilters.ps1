<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

Microsoft.PowerShell.Core\Set-StrictMode -Version Latest

<#
.DESCRIPTION
   Get all filters that are applicable based on their Value.

.PARAMETER  Filters
    All filters to check for applicability. Required properties: 'Type', 'Value', 'Property'
    Supported types: 'wildcard', 'equalityOperator'
#>
function Get-ApplicableFilters {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [PSCustomObject[]]
        $Filters
    )


    foreach ($filter in $Filters) {
        $res = @{
            Filter = $filter
            Strict = $false
        }
        if ($filter.Type -eq 'wildcard') {
            if (Test-WildcardFilter -Filter $filter) {
                $res['Strict'] = $true
            }
        }
        elseif ($filter.Type -eq 'equalityOperator') {
            if (Test-EqualityFilter -Filter $filter) {
                $res['Strict'] = $true
            }
        } elseif ($filter.Type -eq 'powershellWildcard') {
            if (Test-PSWildcardFilter -Filter $filter) {
                $res['Strict'] = $true
            }
        }
        if ($res['Strict'] -or $filter.Value) {
            $res
        }
    }
}

function Test-WildcardFilter {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [PSCustomObject]
        $Filter
    )

    # Must contain wildcard character
    ($Filter) -and ($Filter.Value -is [System.String]) -and ($Filter.Value.Contains($Filter.Character))
}

function Test-EqualityFilter {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [PSCustomObject]
        $Filter
    )

    # Must be specified
    ($Filter -and $Filter.Value)
}

function Test-PSWildcardFilter {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [PSCustomObject]
        $Filter
    )

    ($Filter) -and ($Filter.Value -is [System.String]) -and [WildcardPattern]::ContainsWildcardCharacters($Filter.Value)
}
