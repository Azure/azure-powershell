function Assert-AzChangeSafetyChangeRecordName {
    param(
        [Parameter(Mandatory)]
        [string] $Name
    )

    if ([string]::IsNullOrWhiteSpace($Name)) {
        throw "Parameter 'Name' is required for ChangeRecord operations."
    }

    if ($Name.Length -lt 3) {
        throw "Parameter 'Name' is invalid: ChangeRecord name must be at least 3 characters."
    }
}

function Assert-AzChangeSafetyChangeRecordWindow {
    param(
        [Parameter(Mandatory)]
        [System.Collections.IDictionary] $BoundParameters,

        [datetime] $AnticipatedStartTime,

        [datetime] $AnticipatedEndTime
    )

    $now = (Get-Date).ToUniversalTime().AddSeconds(-30)
    $hasStart = $BoundParameters.ContainsKey('AnticipatedStartTime')
    $hasEnd = $BoundParameters.ContainsKey('AnticipatedEndTime')

    if ($hasStart -and $AnticipatedStartTime.ToUniversalTime() -lt $now) {
        throw "Parameter 'AnticipatedStartTime' is invalid: value must not be in the past."
    }

    if ($hasEnd -and $AnticipatedEndTime.ToUniversalTime() -lt $now) {
        throw "Parameter 'AnticipatedEndTime' is invalid: value must not be in the past."
    }

    if (($hasStart -or $hasEnd) -and $AnticipatedEndTime -ne [datetime]::MinValue -and $AnticipatedStartTime -ne [datetime]::MinValue -and $AnticipatedEndTime -le $AnticipatedStartTime) {
        throw "Parameter 'AnticipatedEndTime' is invalid: value must be later than AnticipatedStartTime."
    }
}

function Assert-AzChangeSafetyChangeRecordEnumValue {
    param(
        [Parameter(Mandatory)]
        [string] $ParameterName,

        [Parameter(Mandatory)]
        [string] $Value,

        [Parameter(Mandatory)]
        [string[]] $AllowedValues
    )

    if ([string]::IsNullOrWhiteSpace($Value)) {
        throw "Parameter '$ParameterName' is required and cannot be empty."
    }

    if ($AllowedValues -notcontains $Value) {
        throw "Parameter '$ParameterName' is invalid: '$Value'. Allowed values are: $($AllowedValues -join ', ')."
    }
}

function ConvertTo-AzChangeSafetyTargetList {
    param(
        [Parameter(Mandatory)]
        [object[]] $Targets
    )

    if ($null -eq $Targets -or $Targets.Count -eq 0) {
        throw "Parameter 'Targets' is required and must contain at least one target."
    }

    $allowedHttpMethods = @('DELETE', 'GET', 'HEAD', 'PATCH', 'POST', 'PUT')
    $targetList = [System.Collections.Generic.List[object]]::new()

    foreach ($target in $Targets) {
        if ($target -isnot [System.Collections.IDictionary]) {
            throw "Parameter 'Targets' is invalid: each target must be a hashtable with keys such as resourceId, subscriptionId, and httpMethod."
        }

        if (-not $target.Contains('resourceId') -and -not $target.Contains('subscriptionId')) {
            throw "Parameter 'Targets' is invalid: each target must include either 'resourceId' or 'subscriptionId'."
        }

        if ($target.Contains('httpMethod')) {
            $method = [string]$target['httpMethod']
            if ([string]::IsNullOrWhiteSpace($method) -or $allowedHttpMethods -notcontains $method.ToUpperInvariant()) {
                throw "Parameter 'Targets.httpMethod' is invalid: '$method'. Allowed values are: $($allowedHttpMethods -join ', ')."
            }

            $target['httpMethod'] = $method.ToUpperInvariant()
        }

        $targetList.Add($target)
    }

    Write-Output -NoEnumerate $targetList
}
