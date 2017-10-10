<#
The MIT License (MIT)

Copyright (c) 2017 Microsoft

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
#>

<#
.DESCRIPTION
    This resource defines the range of IP addresses from which addresses are  allocated for nodes within a subnet.

.PARAMETER NumberOfIpAddressesInTransition
    The current number of ip addresses in transition.

.PARAMETER StartIpAddress
    The starting Ip address.

.PARAMETER Id
    URI of the resource.

.PARAMETER Type
    Type of resource.

.PARAMETER Tags
    List of key value pairs.

.PARAMETER AddressPrefix
    The address prefix.

.PARAMETER NumberOfIpAddresses
    The total number of ip addresses.

.PARAMETER Name
    Name of the resource.

.PARAMETER Location
    Region Location of resource.

.PARAMETER EndIpAddress
    The ending Ip address.

.PARAMETER NumberOfAllocatedIpAddresses
    The number of currently allocated ip addresses.

#>
function New-IpPoolObject
{
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
        [System.Collections.Generic.Dictionary[[string],[string]]]
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
