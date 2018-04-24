<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    A list of input data that allows for adding a set of scale unit nodes.

.DESCRIPTION
    A list of input data that allows for adding a set of scale unit nodes.

.PARAMETER NodeList
    List of nodes in the scale unit.

.PARAMETER AwaitStorageConvergence
    Flag indicates if the operation should wait for storage to converge before returning.

.EXAMPLE

    PS C:\> New-ScaleOutScaleUnitParametersObject -BMCIPv4Address 192.168.1.1 -ComputerName "BMCNode"

    Creates an object used to add a new scale unit node.

#>
function New-ScaleOutScaleUnitParametersListObject {
    param(
        [Parameter(Mandatory = $false)]
        [Microsoft.AzureStack.Management.Fabric.Admin.Models.ScaleOutScaleUnitParameters[]]
        $NodeList,

        [Parameter(Mandatory = $false)]
        [switch]
        $AwaitStorageConvergence
    )

    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Fabric.Admin.Models.ScaleOutScaleUnitParametersList

    $PSBoundParameters.GetEnumerator() | ForEach-Object {
        if (Get-Member -InputObject $Object -Name $_.Key -MemberType Property) {
            $Object.$($_.Key) = $_.Value
        }
    }

    if (Get-Member -InputObject $Object -Name Validate -MemberType Method) {
        $Object.Validate()
    }

    return $Object
}

