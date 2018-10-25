<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Definition for linking and unlinking plans to offers.

.DESCRIPTION
    Definition for linking and unlinking plans to offers.

.PARAMETER PlanName
    Name of the plan.

.PARAMETER PlanLinkType
    Type of the plan link.

.PARAMETER MaxAcquisitionCount
    The maximum acquisition count by subscribers

#>
function New-PlanLinkDefinitionObject
{
    param(    
        [Parameter(Mandatory = $false)]
        [string]
        $PlanName,
    
        [Parameter(Mandatory = $false)]
        [ValidateSet('None', 'Base', 'Addon')]
        [string]
        $PlanLinkType,
    
        [Parameter(Mandatory = $false)]
        [System.Nullable`1[long]]
        $MaxAcquisitionCount
    )
    
    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Subscriptions.Admin.Models.PlanLinkDefinition -ArgumentList @()
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

