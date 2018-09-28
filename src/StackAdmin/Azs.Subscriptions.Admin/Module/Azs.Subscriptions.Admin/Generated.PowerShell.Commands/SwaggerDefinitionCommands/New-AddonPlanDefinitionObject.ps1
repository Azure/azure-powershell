<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Contains the name of the desired plan to be linked or unlinked from an offer.

.DESCRIPTION
    Contains the name of the desired plan to be linked or unlinked from an offer.

.PARAMETER PlanId
    Plan identifier.

.PARAMETER MaxAcquisitionCount
    Maximum number of instances that can be acquired by a single subscription. If not specified, the assumed value is 1.

.EXAMPLE

    New-AddonPlanDefinitionObject -PlanId $planIdentifier -MaxAcquisitionCount 500

    Create a new plan definition object for the specified plan with the acquisition limit of 500.

#>
function New-AddonPlanDefinitionObject
{
    param(
        [Parameter(Mandatory = $false)]
        [string]
        $PlanId,

        [Parameter(Mandatory = $false)]
        [System.Nullable`1[long]]
        $MaxAcquisitionCount
    )

    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Subscriptions.Admin.Models.AddonPlanDefinition -ArgumentList @($planId,$maxAcquisitionCount)

    if(Get-Member -InputObject $Object -Name Validate -MemberType Method)
    {
        $Object.Validate()
    }

    return $Object
}

