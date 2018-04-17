<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    This class models an alert resource.

.DESCRIPTION
    This class models an alert resource.

.PARAMETER FaultTypeId
    Fault type id of the alert.

.PARAMETER Tags
    List of key value pairs.

.PARAMETER ClosedTimestamp
    Timestamp when the alert was closed.

.PARAMETER ClosedByUserAlias
    User alias who closed the alert.

.PARAMETER Name
    Name of the resource.

.PARAMETER ResourceRegistrationId
    Registration id of the atomic component the alert belongs to.  This is null if not associated with a resource.

.PARAMETER Severity
    Severity of the alert.

.PARAMETER CreatedTimestamp
    Timestamp when the alert was created.

.PARAMETER LastUpdatedTimestamp
    Timestamp when the alert was last updated.

.PARAMETER ResourceProviderRegistrationId
    Registration id of the service the alert belongs to.

.PARAMETER Type
    Type of resource.

.PARAMETER Remediation
    Admin friendly remediation instructions for the alert.

.PARAMETER ImpactedResourceId
    ResourceId for the impacted item.

.PARAMETER Title
    Title of the alert.

.PARAMETER ImpactedResourceDisplayName
    Display name for the impacted item.

.PARAMETER AlertProperties
    Properties of the alert.

.PARAMETER Description
    Description of the alert.

.PARAMETER Id
    URI of the resource.

.PARAMETER State
    State of the alert.

.PARAMETER Location
    Location where resource is location.

.PARAMETER FaultId
    Fault id of the alert.

.PARAMETER AlertId
    Id of the alert.

#>
function New-AlertObject
{
    param(
        [Parameter(Mandatory = $false)]
        [string]
        $FaultTypeId,

        [Parameter(Mandatory = $false)]
        [System.Collections.Generic.Dictionary[[string],[string]]]
        $Tags,

        [Parameter(Mandatory = $false)]
        [string]
        $ClosedTimestamp,

        [Parameter(Mandatory = $false)]
        [string]
        $ClosedByUserAlias,

        [Parameter(Mandatory = $false)]
        [string]
        $Name,

        [Parameter(Mandatory = $false)]
        [string]
        $ResourceRegistrationId,

        [Parameter(Mandatory = $false)]
        [string]
        $Severity,

        [Parameter(Mandatory = $false)]
        [string]
        $CreatedTimestamp,

        [Parameter(Mandatory = $false)]
        [string]
        $LastUpdatedTimestamp,

        [Parameter(Mandatory = $false)]
        [string]
        $ResourceProviderRegistrationId,

        [Parameter(Mandatory = $false)]
        [string]
        $Type,

        [Parameter(Mandatory = $false)]
        [System.Collections.Generic.Dictionary[[string],[string]][]]
        $Remediation,

        [Parameter(Mandatory = $false)]
        [string]
        $ImpactedResourceId,

        [Parameter(Mandatory = $false)]
        [string]
        $Title,

        [Parameter(Mandatory = $false)]
        [string]
        $ImpactedResourceDisplayName,

        [Parameter(Mandatory = $false)]
        [System.Collections.Generic.Dictionary[[string],[string]]]
        $AlertProperties,

        [Parameter(Mandatory = $false)]
        [System.Collections.Generic.Dictionary[[string],[string]][]]
        $Description,

        [Parameter(Mandatory = $false)]
        [string]
        $Id,

        [Parameter(Mandatory = $false)]
        [string]
        $State,

        [Parameter(Mandatory = $false)]
        [string]
        $Location,

        [Parameter(Mandatory = $false)]
        [string]
        $FaultId,

        [Parameter(Mandatory = $false)]
        [string]
        $AlertId
    )

    $Object = New-Object -TypeName Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.Alert

    $PSBoundParameters.GetEnumerator() | ForEach-Object {
        if(Get-Member -InputObject $Object -Name $_.Key -MemberType Property)
        {
            $Object.$($_.Key) = $_.Value
        }
    }

    if(Get-Member -InputObject $Object -Name Validate -MemberType Method)
    {
        $Object.Validate()
    }

    return $Object
}

