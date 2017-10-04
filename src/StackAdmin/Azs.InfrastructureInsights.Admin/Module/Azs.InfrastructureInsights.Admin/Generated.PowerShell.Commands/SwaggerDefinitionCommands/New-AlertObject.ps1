<#
The MIT License (MIT)

Copyright (c) 2017 Microsoft

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
#>

<#
.DESCRIPTION
    This class models an alert resource.

.PARAMETER FaultTypeId
    Gets or sets the fault type id of the alert.

.PARAMETER Tags
    List of key value pairs.

.PARAMETER ClosedTimestamp
    Gets or sets the closed timestamp of the alert.

.PARAMETER ClosedByUserAlias
    Gets or sets the user alias who closed the alert.

.PARAMETER Name
    Name of the resource.

.PARAMETER ResourceRegistrationId
    Gets or sets the registration id of the atomic component the alert belongs to.  This is null if not associated with a resource.

.PARAMETER Severity
    Gets or sets the severity of the alert.

.PARAMETER CreatedTimestamp
    Gets or sets the created timestamp of the alert.

.PARAMETER LastUpdatedTimestamp
    Gets or sets last updated timestamp of the alert.

.PARAMETER ResourceProviderRegistrationId
    Gets or sets the registration id of the service the alert belongs to.

.PARAMETER Type
    Type of resource.

.PARAMETER Remediation
    Gets or sets the admin friendly remediation instructions for the alert.

.PARAMETER ImpactedResourceId
    Gets or sets the ResourceId for the impacted item.

.PARAMETER Title
    Gets or sets the ResourceId for the impacted item.

.PARAMETER ImpactedResourceDisplayName
    Gets or sets the display name for the impacted item.

.PARAMETER AlertProperties
    Gets or sets properties of the alert.

.PARAMETER Description
    Gets or sets the description of the alert.

.PARAMETER Id
    URI of the resource.

.PARAMETER State
    Gets or sets the state of the alert.

.PARAMETER Location
    Location where resource is location.

.PARAMETER FaultId
    Gets or sets the fault id of the alert.

.PARAMETER AlertId
    Gets or sets the id of the alert.

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
