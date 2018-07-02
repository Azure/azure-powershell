<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

Microsoft.PowerShell.Core\Set-StrictMode -Version Latest

<#
.DESCRIPTION
   Determines if a result matches the given filter.

.PARAMETER  Result
    Result to filter

.PARAMETER  Filter
    Filter to apply
#>
function Test-FilteredResult {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [object]
        $Result,

        [Parameter(Mandatory=$true)]
        [PSCustomObject]
        $Filter
    )

    $ErrorActionPreference = 'Stop'
    if ($Filter.Type -eq 'wildcard') {
        Test-WildcardFilterOnResult -Filter $Filter -Result $Result
    } elseif ($Filter.Type -eq 'equalityOperator') {
        Test-EqualityFilterOnResult -Filter $Filter -Result $Result
    } elseif ($Filter.Type -eq 'powershellWildcard') {
        Test-PSWildcardFilterOnResult -Filter $Filter -Result $Result
    }
}

function Test-WildcardFilterOnResult {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [object]
        $Result,

        [Parameter(Mandatory=$true)]
        [PSCustomObject]
        $Filter
    )

    foreach ($char in $Filter.Value.ToCharArray()) {
        if ($char -ne $Filter.Character) {
            $regex += "[$char]"
        } else {
            $regex += ".*"
        }
    }

    ($Result.($Filter.Property)) -match $regex
}

function Test-EqualityFilterOnResult {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [object]
        $Result,

        [Parameter(Mandatory=$true)]
        [PSCustomObject]
        $Filter
    )

    if ($Filter.Operation -eq '<') {
        ($Result.($Filter.Property) -lt $Filter.Value)
    } elseif ($Filter.Operation -eq '<=') {
        ($Result.($Filter.Property) -le $Filter.Value)
    } elseif ($Filter.Operation -eq '=') {
        ($Result.($Filter.Property) -eq $Filter.Value)
    } elseif ($Filter.Operation -eq '>=') {
        ($Result.($Filter.Property) -ge $Filter.Value)
    } elseif ($Filter.Operation -eq '>') {
        ($Result.($Filter.Property) -gt $Filter.Value)
    }
}

function Test-PSWildcardFilterOnResult {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [object]
        $Result,

        [Parameter(Mandatory=$true)]
        [PSCustomObject]
        $Filter
    )

    $pattern = [WildcardPattern]::Get($Filter.Value, [System.Management.Automation.WildcardOptions]::IgnoreCase)
    $pattern.IsMatch(($Result.($Filter.Property)))
}
