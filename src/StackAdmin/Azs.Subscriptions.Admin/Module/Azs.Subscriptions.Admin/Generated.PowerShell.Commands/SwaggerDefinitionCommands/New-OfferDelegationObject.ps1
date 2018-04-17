<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Offer delegation.

.DESCRIPTION
    Offer delegation.

.PARAMETER Id
    URI of the resource.

.PARAMETER Type
    Type of resource.

.PARAMETER Tags
    List of key-value pairs.

.PARAMETER SubscriptionId
    Identifier of the subscription receiving the delegated offer.

.PARAMETER Name
    Name of the resource.

.PARAMETER Location
    Location of the resource.

#>
function New-OfferDelegationObject
{
    param(    
        [Parameter(Mandatory = $false)]
        [string]
        $Id,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Type,
    
        [Parameter(Mandatory = $false)]
        [System.Collections.Generic.Dictionary[[string],[string]]]
        $Tags,
    
        [Parameter(Mandatory = $false)]
        [string]
        $SubscriptionId,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Name,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Location
    )
    
    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Subscriptions.Admin.Models.OfferDelegation -ArgumentList @()
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

