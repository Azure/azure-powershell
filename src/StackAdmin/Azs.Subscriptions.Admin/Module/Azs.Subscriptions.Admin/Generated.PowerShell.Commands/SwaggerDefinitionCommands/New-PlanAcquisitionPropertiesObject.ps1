<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Represents the acquisition of an add-on plan for a subscription.

.DESCRIPTION
    Represents the acquisition of an add-on plan for a subscription.

.PARAMETER ProvisioningState
    State of the provisioning.

.PARAMETER AcquisitionTime
    Acquisition time.

.PARAMETER Id
    Identifier in the tenant subscription context.

.PARAMETER PlanId
    Plan identifier in the tenant subscription context.

.PARAMETER AcquisitionId
    Acquisition identifier.

.PARAMETER ExternalReferenceId
    External reference identifier.

#>
function New-PlanAcquisitionPropertiesObject
{
    param(    
        [Parameter(Mandatory = $false)]
        [ValidateSet('NotSpecified', 'Accepted', 'Failed', 'Succeeded')]
        [string]
        $ProvisioningState,
    
        [Parameter(Mandatory = $false)]
        [string]
        $AcquisitionTime,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Id,
    
        [Parameter(Mandatory = $false)]
        [string]
        $PlanId,
    
        [Parameter(Mandatory = $false)]
        [string]
        $AcquisitionId,
    
        [Parameter(Mandatory = $false)]
        [string]
        $ExternalReferenceId
    )
    
    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Subscriptions.Admin.Models.PlanAcquisition -ArgumentList @()
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

