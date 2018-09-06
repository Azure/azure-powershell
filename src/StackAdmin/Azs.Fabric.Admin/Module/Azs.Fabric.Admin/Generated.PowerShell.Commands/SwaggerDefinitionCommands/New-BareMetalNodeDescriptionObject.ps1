<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Description of a bare metal node used for ScaleOut operation on a cluster.

.DESCRIPTION
    Description of a bare metal node used for ScaleOut operation on a cluster.

.PARAMETER SerialNumber
    Serial number of the physical machine.

.PARAMETER BiosVersion
    Bios version of the physical machine.

.PARAMETER ClusterName
    Name of the cluster.

.PARAMETER ComputerName
    Name of the computer.

.PARAMETER MacAddress
    Name of the MAC address of the bare metal node.

.PARAMETER Model
    Model of the physical machine.

.PARAMETER BMCIPv4Address
    BMC address of the physical machine.

.PARAMETER Vendor
    Vendor of the physical machine.

#>
function New-BareMetalNodeDescriptionObject {
    param(    
        [Parameter(Mandatory = $false)]
        [string]
        $SerialNumber,
    
        [Parameter(Mandatory = $false)]
        [string]
        $BiosVersion,
    
        [Parameter(Mandatory = $false)]
        [string]
        $ClusterName,
    
        [Parameter(Mandatory = $false)]
        [string]
        $ComputerName,
    
        [Parameter(Mandatory = $false)]
        [string]
        $MacAddress,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Model,
    
        [Parameter(Mandatory = $false)]
        [string]
        $BMCIPv4Address,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Vendor
    )
    
    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Fabric.Admin.Models.BareMetalNodeDescription

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

