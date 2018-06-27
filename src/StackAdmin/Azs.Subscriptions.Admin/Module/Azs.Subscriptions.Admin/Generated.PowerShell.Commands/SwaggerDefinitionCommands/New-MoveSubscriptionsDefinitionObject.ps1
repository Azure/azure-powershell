<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    The move subscriptions action definition

.DESCRIPTION
    The move subscriptions action definition

.PARAMETER Resources
    A collection of subscriptions to move to the target delegated provider offer.

.PARAMETER TargetDelegatedProviderOffer
    The delegated provider offer identifier (from the Admin context) that the subscriptions to be moved to.

#>
function New-MoveSubscriptionsDefinitionObject
{
    param(    
        [Parameter(Mandatory = $true)]
        [string[]]
        $Resources,
    
        [Parameter(Mandatory = $false)]
        [string]
        $TargetDelegatedProviderOffer
    )
    
    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Subscriptions.Admin.Models.MoveSubscriptionsDefinition
    $Object.Resources = $Resources
    if(-not [string]::IsNullOrEmpty($DestinationDelegatedProviderOffer))
    {
        $Object.TargetDelegatedProviderOffer = $targetDelegatedProviderOffer
    }  
    
    if(Get-Member -InputObject $Object -Name Validate -MemberType Method)
    {
        $Object.Validate()
    }

    return $Object
}

