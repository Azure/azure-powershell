<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    This resource defines the range of IP addresses from which addresses are  allocated for nodes within a subnet.

.DESCRIPTION
    This resource defines the range of IP addresses from which addresses are  allocated for nodes within a subnet.

.PARAMETER NumberOfIpAddressesInTransition
    The current number of IP addresses in transition.

.PARAMETER StartIpAddress
    The starting IP address.

.PARAMETER Id
    URI of the resource.

.PARAMETER Type
    Type of resource.

.PARAMETER Tags
    List of key-value pairs.

.PARAMETER AddressPrefix
    The address prefix.

.PARAMETER NumberOfIpAddresses
    The total number of IP addresses.

.PARAMETER Name
    Name of the resource.

.PARAMETER Location
    The region where the resource is located.

.PARAMETER EndIpAddress
    The ending IP address.

.PARAMETER NumberOfAllocatedIpAddresses
    The number of currently allocated IP addresses.

#>
function New-IpPoolObject {
    param(    
        [Parameter(Mandatory = $false)]
        [int64]
        $NumberOfIpAddressesInTransition,
    
        [Parameter(Mandatory = $false)]
        [string]
        $StartIpAddress,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Id,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Type,
    
        [Parameter(Mandatory = $false)]
        [System.Collections.Generic.Dictionary[[string], [string]]]
        $Tags,
    
        [Parameter(Mandatory = $false)]
        [string]
        $AddressPrefix,
    
        [Parameter(Mandatory = $false)]
        [int64]
        $NumberOfIpAddresses,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Name,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Location,
    
        [Parameter(Mandatory = $false)]
        [string]
        $EndIpAddress,
    
        [Parameter(Mandatory = $false)]
        [int64]
        $NumberOfAllocatedIpAddresses
    )
    
    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Fabric.Admin.Models.IpPool

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

