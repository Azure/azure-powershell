<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    A plan represents a package of quotas and capabilities that are offered tenants. A tenant can acquire this plan through an offer to upgrade his access to underlying cloud services.

.DESCRIPTION
    A plan represents a package of quotas and capabilities that are offered tenants. A tenant can acquire this plan through an offer to upgrade his access to underlying cloud services.

.PARAMETER Description
    Description of the plan.

.PARAMETER Id
    URI of the resource.

.PARAMETER Type
    Type of resource.

.PARAMETER SkuIds
    SKU identifiers.

.PARAMETER Tags
    List of key-value pairs.

.PARAMETER ExternalReferenceId
    External reference identifier.

.PARAMETER Name
    Name of the resource.

.PARAMETER DisplayName
    Display name.

.PARAMETER Location
    Location where resource is location.

.PARAMETER QuotaIds
    Quota identifiers under the plan.

.PARAMETER SubscriptionCount
    Subscription count.

#>
function New-PlanObject
{
    param(    
        [Parameter(Mandatory = $false)]
        [string]
        $Description,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Id,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Type,
    
        [Parameter(Mandatory = $false)]
        [string[]]
        $SkuIds,
    
        [Parameter(Mandatory = $false)]
        [System.Collections.Generic.Dictionary[[string],[string]]]
        $Tags,
    
        [Parameter(Mandatory = $false)]
        [string]
        $ExternalReferenceId,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Name,
    
        [Parameter(Mandatory = $false)]
        [string]
        $DisplayName,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Location,
    
        [Parameter(Mandatory = $false)]
        [string[]]
        $QuotaIds,
    
        [Parameter(Mandatory = $false)]
        [System.Nullable`1[long]]
        $SubscriptionCount
    )
    
    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Plan -ArgumentList @($id,$name,$type,$location,$tags,$description,$displayName,$externalReferenceId,$quotaIds,$name,$subscriptionCount,$skuIds)

    if(Get-Member -InputObject $Object -Name Validate -MemberType Method)
    {
        $Object.Validate()
    }

    return $Object
}
