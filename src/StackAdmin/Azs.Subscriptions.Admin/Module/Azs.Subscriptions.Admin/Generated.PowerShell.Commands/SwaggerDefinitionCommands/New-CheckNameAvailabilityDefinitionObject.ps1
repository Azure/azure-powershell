<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    The check name availability action definition.

.DESCRIPTION
    The check name availability action definition.

.PARAMETER Name
    The resource name to verify.

.PARAMETER ResourceType
    The resource type to verify.

.EXAMPLE

    New-CheckNameAvailabilityDefinitionObject -Name 'MyPlan' -ResourceType 'Microsoft.Subscriptions.Admin/plans'

    Create an object to test if
#>
function New-CheckNameAvailabilityDefinitionObject
{
    param(
        [Parameter(Mandatory = $false)]
        [string]
        $Name,

        [Parameter(Mandatory = $false)]
        [string]
        $ResourceType
    )

    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Subscriptions.Admin.Models.CheckNameAvailabilityDefinition -ArgumentList @($name,$resourceType)

    if(Get-Member -InputObject $Object -Name Validate -MemberType Method)
    {
        $Object.Validate()
    }

    return $Object
}

