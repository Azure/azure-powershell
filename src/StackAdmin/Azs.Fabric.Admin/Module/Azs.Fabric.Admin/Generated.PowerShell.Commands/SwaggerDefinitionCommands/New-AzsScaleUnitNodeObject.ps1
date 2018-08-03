<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Input data that allows for adding a scale unit node.

.DESCRIPTION
    Input data that allows for adding a scale unit node.

.PARAMETER BMCIPv4Address
    Bmc address of the physical machine.

.PARAMETER ComputerName
    Computer name of the physical machine.

#>
function New-AzsScaleUnitNodeObject
{
    param(
        [Parameter(Mandatory = $false)]
        [string]
        $BMCIPv4Address,

        [Parameter(Mandatory = $false)]
        [string]
        $ComputerName
    )

    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Fabric.Admin.Models.ScaleOutScaleUnitParameters

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

