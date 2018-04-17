<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    List of supported operations.

.DESCRIPTION
    List of supported operations.

.PARAMETER TenantId
    Directory tenant identifier.

.PARAMETER Type
    Type of resource.

.PARAMETER SubscriptionId
    Subscription identifier.

.PARAMETER DisplayName
    Subscription name.

.PARAMETER DelegatedProviderSubscriptionId
    Parent DelegatedProvider subscription identifier.

.PARAMETER Name
    Name of the resource.

.PARAMETER Owner
    Subscription owner.

.PARAMETER RoutingResourceManagerType
    Routing resource manager type.

.PARAMETER Tags
    List of key-value pairs.

.PARAMETER ExternalReferenceId
    External reference identifier.

.PARAMETER State
    Subscription state.

.PARAMETER Id
    Fully qualified identifier.

.PARAMETER Location
    Location where resource is location.

.PARAMETER OfferId
    Identifier of the offer under the scope of a delegated provider.

#>
function New-SubscriptionObject
{
    param(    
        [Parameter(Mandatory = $false)]
        [string]
        $TenantId,
    
        [Parameter(Mandatory = $false)]
        [string]
        $SubscriptionId,
    
        [Parameter(Mandatory = $false)]
        [string]
        $DisplayName,
    
        [Parameter(Mandatory = $false)]
        [string]
        $DelegatedProviderSubscriptionId,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Name,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Owner,
    
        [Parameter(Mandatory = $false)]
        [ValidateSet('Default', 'Admin')]
        [string]
        $RoutingResourceManagerType,
    
        [Parameter(Mandatory = $false)]
        [string]
        $ExternalReferenceId,
    
        [Parameter(Mandatory = $false)]
        [ValidateSet('NotDefined', 'Enabled', 'Warned', 'PastDue', 'Disabled', 'Deleted')]
        [string]
        $State,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Id,
    
        [Parameter(Mandatory = $false)]
        [string]
        $OfferId
    )
    
    if($TenantId)
    {
        $Object = New-Object -TypeName Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Subscription -ArgumentList @($delegatedProviderSubscriptionId,$displayName,$id,$externalReferenceId,$offerId,$owner,$routingResourceManagerType,$state,$subscriptionId,$TenantId)
    }
    else
    {
        $Object = New-Object -TypeName Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Subscription -ArgumentList @($delegatedProviderSubscriptionId,$displayName,$id,$externalReferenceId,$offerId,$owner,$routingResourceManagerType,$state,$subscriptionId)
    }


    if(Get-Member -InputObject $Object -Name Validate -MemberType Method)
    {
        $Object.Validate()
    }

    return $Object
}
