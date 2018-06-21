<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Holds properties related to activation.

.DESCRIPTION
    Holds properties related to activation.

.PARAMETER ProvisioningState
    Provisioning state of the resource.

.PARAMETER Expiration
    The activation expiration.

.PARAMETER AzureRegistrationResourceIdentifier
    Azure registration resource identifier.

.PARAMETER MarketplaceSyndicationEnabled
    Value indicating whether the marketplace syndication feature is enabled.

.PARAMETER UsageReportingEnabled
    Value indicating whether the usage reporting feature is enabled.

.PARAMETER DisplayName
    Name displayed for the product.

#>
function New-ActivationObject
{
    param(    
        [Parameter(Mandatory = $false)]
        [ValidateSet('Stopped', 'Starting', 'Running', 'Stopping')]
        [string]
        $ProvisioningState,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Expiration,
    
        [Parameter(Mandatory = $false)]
        [string]
        $AzureRegistrationResourceIdentifier,
    
        [Parameter(Mandatory = $false)]
        [switch]
        $MarketplaceSyndicationEnabled,
    
        [Parameter(Mandatory = $false)]
        [switch]
        $UsageReportingEnabled,
    
        [Parameter(Mandatory = $false)]
        [string]
        $DisplayName
    )
    
    $Object = New-Object -TypeName Microsoft.AzureStack.Management.AzureBridge.Admin.Models.Activation

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

