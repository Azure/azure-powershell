<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    List of supported operations.

.DESCRIPTION
    List of supported operations.

.PARAMETER OfferId
    Identifier of the offer under the scope of a delegated provider.

.PARAMETER Name
    Name of the resource.

.PARAMETER Id
    Fully qualified identifier.

.PARAMETER Type
    Type of resource.

.PARAMETER Tags
    List of key-value pairs.

.PARAMETER SubscriptionId
    Subscription identifier.

.PARAMETER State
    Subscription state.

.PARAMETER TenantId
    Directory tenant identifier.

.PARAMETER Location
    Location where resource is location.

.PARAMETER DisplayName
    Subscription name.

#>
function New-SubscriptionObject
{
    param(    
        [Parameter(Mandatory = $false)]
        [string]
        $OfferId,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Id,
    
        [Parameter(Mandatory = $false)]
        [string]
        $SubscriptionId,
    
        [Parameter(Mandatory = $false)]
        [ValidateSet('NotDefined', 'Enabled', 'Warned', 'PastDue', 'Disabled', 'Deleted')]
        [string]
        $State,
    
        [Parameter(Mandatory = $false)]
        [string]
        $TenantId,
    
        [Parameter(Mandatory = $false)]
        [string]
        $DisplayName
    )
    
    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Subscription.Models.SubscriptionModel -ArgumentList @($displayName,$id,$offerId,$state,$subscriptionId,$tenantId)

    if(Get-Member -InputObject $Object -Name Validate -MemberType Method)
    {
        $Object.Validate()
    }

    return $Object
}

